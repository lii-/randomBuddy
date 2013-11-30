/* 
 * randomBuddy by piotr55 & roboto
 * 
 * Plugin for randomBuddy (http://rndbuddy.zz.mu/index.html) to auto-refresh and load random gather profiles
 * 
 * Special thanks roboto for randomBuddy and its API
 *
 * v0.9
 * reworked fallback to use third server as well...
 *
 * v0.8
 * added server fallback
 * added additional Error Codes
 *
 * v0.7
 * added checkbox to activate/deactivate method to optimize the hotspots order based on the current player position
 *
 * v0.6
 * added "factions" detection (needed to choose correct mailboxes in pre-mop zones)
 * added "MinFreeBagSlots" and "MinDurability" option
 * Zones can now selected in a Checkboxlist (if checked multiple Zones randomBuddy API will randomly choose one of them)
 *
 * v0.5
 * added method to check validation of your API key
 * removed all URLs to robotos randomBuddy API according to the rules of Honorbuddy (http://www.thebuddyforum.com/honorbuddy-forum/plugins/123619-rules-update-everyone-must-read.html)
 *
 * v0.4
 * added method to optimize the hotspots order based on the current player position 
 * added API error handling to give more information about wrong settings
 * cleaned up coding mess :)
 * 
 * v0.3
 * "Profile Name:" now needs to be the FULL path to the desired Profile XML
 * other BotBases are now allowed to use the Plugin
 * 
 * v0.2
 * added creating "profiles" directory if not exist
 * 
 * v0.1
 * first release!
 */

using System;
using System.IO;
using System.Text;
using System.Threading;					// Thread
using System.Diagnostics; 				// Stopwatch
using System.Net; 						// WebClient
using System.Collections.Specialized; 	// NameValueCollection
using System.Windows.Media; 			// Colors

using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Profiles;
using Styx.Pathing;						// Navigator
using Styx.WoWInternals;				// Battlegrounds
using Styx.WoWInternals.WoWObjects;		// LocalPlayer
using Styx.Plugins;						// HBPlugin



namespace randomBuddy
{
	
    class randomBuddy : HBPlugin
    {
        public override string Name { get { return "randomBuddy"; } }
        public override string Author { get { return "piotr55"; } }
        public override Version Version { get { return new Version(0, 9); } }
        public override bool WantButton { get { return true; } }
        public override void OnButtonPress() { var GUI = new randomBuddyGUI(); GUI.ShowDialog(); }
        public override string ButtonText { get { return "Settings"; } }

        private static readonly LocalPlayer Me = StyxWoW.Me;
		
		static Stopwatch SWProfile = new Stopwatch();
		bool hasItBeenInitialized = false;
		private bool _init;

		public static void Log(string format, params object[] args)
        {
			Logging.Write(Colors.BlueViolet, "[randomBuddy] " + format, args);
		}		
		
		public override void Initialize()
        {
			if (_init) return;
			Log("Version: {0}.{1}", Version.Major, Version.Minor);
			hasItBeenInitialized = false;
			randomBuddySettings.Instance.Load();
			BotEvents.OnBotStarted += BotEvents_OnBotStarted;
			var XMLFilepath = Path.Combine(Utilities.AssemblyDirectory, "Plugins/randomBuddy/emptyprofile.xml");
			if (!File.Exists(XMLFilepath))
			{
				TextWriter tw = new StreamWriter(XMLFilepath, true);
				tw.WriteLine("<HBProfile>");
				tw.WriteLine("  <Name>empty profile to initialize randomBuddy</Name>");
				tw.WriteLine("  <MinLevel>0</MinLevel>");
				tw.WriteLine("  <MaxLevel>91</MaxLevel>");
				tw.WriteLine("  	<Hotspots>");
				tw.WriteLine("		<Hotspot X=\"0\" Y=\"0\" Z=\"0\" />");
				tw.WriteLine("	</Hotspots>");
				tw.WriteLine("</HBProfile>");
				tw.Close(); 
			}
			ProfileManager.LoadNew(XMLFilepath);
			_init = true;
        }

		public override void Dispose()
        {
            BotEvents.OnBotStarted -= BotEvents_OnBotStarted;
        }
		
		private void BotEvents_OnBotStarted(object _object)
        {
			hasItBeenInitialized = false;
		}
		
        #region Changer Thread
        private static Thread _ChangerThread;
        private static void ChangerThread(string XMLFilepath)
        {
			if (File.Exists(@XMLFilepath))
			{
				Log("Loading Profile...");
				ProfileManager.LoadNew(XMLFilepath);
				while (ProfileManager.CurrentOuterProfile.Equals(null) || ProfileManager.CurrentProfile.Equals(null)) { Thread.Sleep(500); }
			}else{
				Log("Profile does not exist!");
				Log("Please check randomBuddy Settings!");
			}
            _ChangerThread.Abort();
        }
        #endregion

        public override void Pulse()
        {
			// ------------ Deactivate if not in Game etc
			if (!StyxWoW.IsInGame || !StyxWoW.IsInWorld)
				return;
			// ------------ Deactivate Plugin in BGs, Inis, while Casting and on Transport
			if (Battlegrounds.IsInsideBattleground || Me.IsInInstance || Me.IsOnTransport)
				return;
			// ------------ Deactivate Plugin if in Combat, Dead or Ghost			
			if (Me.Combat)
				return;
			if (!hasItBeenInitialized || SWProfile.Elapsed.TotalMinutes > Convert.ToInt32(randomBuddySettings.Instance.refreshmins))
			{
				hasItBeenInitialized = true;
				Navigator.PlayerMover.MoveStop();
				StyxWoW.SleepForLagDuration();
				LoadChanger();
				SWProfile.Restart();
			}
        }
		
        private void LoadChanger()
        {
            Thread.Sleep(500);
            Navigator.PlayerMover.MoveStop();
            StyxWoW.SleepForLagDuration();
			RefreshXML();
			_ChangerThread = new Thread(() => ChangerThread(randomBuddySettings.Instance.xmlFile));
            _ChangerThread.Start();
        }
		
		double GetDistance(string x1, string x2, string y1, string y2)
		{
  			float x1f = float.Parse(x1, System.Globalization.CultureInfo.InvariantCulture);
  			float x2f = float.Parse(x2, System.Globalization.CultureInfo.InvariantCulture);
 			float y1f = float.Parse(y1, System.Globalization.CultureInfo.InvariantCulture);
  			float y2f = float.Parse(y2, System.Globalization.CultureInfo.InvariantCulture);

  			return Math.Sqrt(((x1f-x2f)*(x1f-x2f))+((y1f-y2f)*(y1f-y2f)));
		}
		
		string OptimizeRoute(string xmldata)
		{
    		var pos_start = xmldata.IndexOf("<Hotspots>");
    		var pos_end = xmldata.IndexOf("</Hotspots>")-pos_start+11;
   			string _xmldata = xmldata.Substring(pos_start, pos_end).Replace("\t", "");
   				
   			StringCollection coords = new StringCollection();
   				
   			string[] hotspots = _xmldata.Split('\n');
   			foreach (string hotspot in hotspots)
   			{
   				if (hotspot.IndexOf("<Hotspot ") == -1) continue;
      			string[] temp = hotspot.Split('"');
				coords.Add(temp[1]+";"+temp[3]+";"+temp[5]);
      		}
   				
   			if (coords.Count <= 0) return "";
   				
  			double dist_old = 9999999.9;
  			double dist_new = 0.0;
  			int nearest_pos = -1;
  				
   			string[] start_pos = { Me.X.ToString(), Me.Y.ToString(), Me.Z.ToString() };
   			string[] curr_pos = { "0.0", "0.0", "0.0" };
	
  			StringCollection optimized = new StringCollection();
  				
  			int index = 0;  				
  			do
  			{
  				index = 0;
    			foreach (string coord in coords)
  				{
    				string[] temp_pos = coord.Split(';');
				   	dist_new = GetDistance(start_pos[0], temp_pos[0], start_pos[1], temp_pos[1]);
      				if (dist_new < dist_old)
      				{
      					curr_pos[0] = temp_pos[0];
        				curr_pos[1] = temp_pos[1];
        				curr_pos[2] = temp_pos[2];
        				nearest_pos = index;
        				dist_old = dist_new;
      				}
      				index++;
  				}

    			dist_old = 9999999.9;
    			start_pos[0] = curr_pos[0];
    			start_pos[1] = curr_pos[1];
    			start_pos[2] = curr_pos[2];
    			optimized.Add("		<Hotspot X=\""+start_pos[0]+"\" Y=\""+start_pos[1]+"\" Z=\""+start_pos[2]+"\" />");
    			coords.RemoveAt(nearest_pos);
  			}
  			while (coords.Count != 0);

  			
  			pos_start = xmldata.IndexOf("<Hotspots>")+10;
  			pos_end = xmldata.IndexOf("</Hotspots>")-pos_start-3;
  			xmldata = xmldata.Remove(pos_start, pos_end);
  			
  			string optimized_all = "";
  			foreach (string optimize in optimized)
  			{
  				optimized_all = optimized_all + optimize + Environment.NewLine;
  			}

  			xmldata = xmldata.Replace("<Hotspots>", "<Hotspots>"+Environment.NewLine+optimized_all);
 			xmldata = xmldata.Replace(Environment.NewLine+Environment.NewLine, Environment.NewLine);

  			return xmldata;
		}		
		
		private void RefreshXML()
		{
			Log("Refreshing Profile...");
			using (var wb = new WebClient())
			{
				randomBuddySettings.Instance.Load();
				randomBuddySettings.Instance.xmlFile = Path.Combine(Path.Combine(Utilities.AssemblyDirectory, "Profiles"), string.Format("randomBuddy {0}.xml", Me.Name+"-"+Me.RealmName));
				
				//choose one host
				int randomNumber;
				Random RNG = new Random();
				randomNumber = RNG.Next(0,2);
				var rb_hosts = new [] { "rndbuddy.pusku.com", "rndbuddy.zz.mu", "rndbuddy.hol.es" };
				string host = rb_hosts[randomNumber];
				Log("Using host {0}",host);
				
				//check the host
				string check = wb.DownloadString("http://"+host+"/api/hello");
				if (check != "hello")
				{
					Log("Server did not say 'hello', there might be some issues");
					
					//we like to keep it simple, might do a while instead
					if(randomNumber == 2)
					{
						randomNumber = 0;
					}
					else
					{
						randomNumber++;
					}
					host = rb_hosts[randomNumber];
					Log("Falling back to Server {0}",host);
					
					//check again
					check = wb.DownloadString("http://"+host+"/api/hello");
					if (check != "hello")
					{
						Log("I was unable to find a working Server, lst try");
						if(randomNumber == 2)
						{
							randomNumber = 0;
						}
						else
						{
							randomNumber++;
						}
						host = rb_hosts[randomNumber];
						Log("Falling back to Server {0}",host);
						
						//check again
						check = wb.DownloadString("http://"+host+"/api/hello");
						if (check != "hello")
						{
							Log("Looks like it got busted, please stand by, I'll try to fix this asap");
							if (TreeRoot.IsRunning)
							{
								TreeRoot.Stop();
								Thread.Sleep(1000);
							}
						}						
					}
				}
				
				
				var data = new NameValueCollection();
				data["key"] = randomBuddySettings.Instance.key;
				data["zone"] = "RND";
				data["amount"] = randomBuddySettings.Instance.amount;
				if (randomBuddySettings.Instance.blackspots)
					data["blackspots"] = "on";
				if (randomBuddySettings.Instance.optimize)	
					data["optimize"] = "on";
				if (randomBuddySettings.Instance.more_random)
					data["more_random"] = "on";
				if (randomBuddySettings.Instance.rnd_pool != "")	
					data["rnd_pool"] = randomBuddySettings.Instance.rnd_pool;
				data["faction"] = "0";
 				if (Me.IsAlliance)
					data["faction"] = "1"; 
				if (Me.IsHorde)
					data["faction"] = "2"; 
				if (randomBuddySettings.Instance.freebag != "")	
					data["min_fbs"] = randomBuddySettings.Instance.freebag;
				if (randomBuddySettings.Instance.durability != "")	
					data["min_dur"] = randomBuddySettings.Instance.durability;					
				
				var response = wb.UploadValues("http://"+host+"/api/", "POST", data);
				string str = Encoding.UTF8.GetString(response);
				
				if (str.Contains("<?xml version="))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(randomBuddySettings.Instance.xmlFile));
					if (randomBuddySettings.Instance.route_optimize)
						str = OptimizeRoute(str);
					File.WriteAllText(@randomBuddySettings.Instance.xmlFile, str);
					Log("New Profile received.");
				}else{
					if (str.IndexOf(" ") != -1)
					{
						var _errorcode = str.Substring(str.LastIndexOf(" ")+1);
						switch (_errorcode)
						{
							case "E001":
								Log("Error: Unknown API Key!");
								break;
							case "E002":
								Log("Error: Flood Protection - Refreshing profile is allowed every 5 mins!");
								break;
							case "E003":
								Log("Error: Wrong amount of Hotspots - allowed: 5-85!");
								break;
							case "E004":
								Log("Error: Unknown API Key and ZoneID!");
								break;
							case "E006":
								Log("Error: Unknown random ZoneID!");
								break;
							case "E008":
								Log("Error: Unknown ZoneID!");								
								break;
							case "E011":
								Log("Error: No API Key received");								
								break;
							
							//admin errors
							case "EF00":
								Log("Error: Server is in Maintenance Mode! Nothing you can fix...");								
								break;
								
								
							default:
								Log("Error receiving new Profile! (Code {0})!", _errorcode);
								break;
						}
					} else Log("Error receiving new Profile!");
					Log("Please check randomBuddy Settings!");
					File.Delete(randomBuddySettings.Instance.xmlFile);
					if (TreeRoot.IsRunning)
					{
						TreeRoot.Stop();
						Thread.Sleep(1000);
					}
				}

			}
		}
    }
}


