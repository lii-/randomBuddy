
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Text;

namespace randomBuddy
{
	public partial class randomBuddyGUI : Form
	{
		BindingList<KeyValuePair<string, string>> zones = new BindingList<KeyValuePair<string, string>>();
		string version_id;

		public randomBuddyGUI()
		{
			InitializeComponent();
			
			zones.Add(new KeyValuePair<string, string>("9999", "------------------------ Eastern Kingdoms ----------------------------"));
			zones.Add(new KeyValuePair<string, string>("145", "                     Arathi Highlands [145]"));
			zones.Add(new KeyValuePair<string, string>("103", "                           Badlands [103]"));
			zones.Add(new KeyValuePair<string, string>("104", "                       Blasted Lands [104]"));
			zones.Add(new KeyValuePair<string, string>("146", "                     Burning Steppes [146]"));
			zones.Add(new KeyValuePair<string, string>("6276", "                     Coldridge Valley [6276]"));
			zones.Add(new KeyValuePair<string, string>("141", "                       Deadwind Pass [141]"));
			zones.Add(new KeyValuePair<string, string>("101", "                         Dun Morogh [101]"));
			zones.Add(new KeyValuePair<string, string>("110", "                          Duskwood [110]"));
			zones.Add(new KeyValuePair<string, string>("239", "                   Eastern Plaguelands [239]"));
			zones.Add(new KeyValuePair<string, string>("112", "                         Elwynn Forest [112]"));
			zones.Add(new KeyValuePair<string, string>("3530", "                     Eversong Woods [3530]"));
			zones.Add(new KeyValuePair<string, string>("3533", "                          Ghostlands [3533]"));
			zones.Add(new KeyValuePair<string, string>("367", "                      Hillsbrad Foothills [367]"));
			zones.Add(new KeyValuePair<string, string>("138", "                          Loch Modan [138]"));
			zones.Add(new KeyValuePair<string, string>("144", "                   Redridge Mountains [144]"));
			zones.Add(new KeyValuePair<string, string>("5451", "                      Ruins of Gilneas [5451]"));
			zones.Add(new KeyValuePair<string, string>("151", "                         Searing Gorge [151]"));
			zones.Add(new KeyValuePair<string, string>("230", "                        Silverpine Forest [230]"));
			zones.Add(new KeyValuePair<string, string>("133", "                     Stranglethorn Jungle [133]"));
			zones.Add(new KeyValuePair<string, string>("5439", "                      Stranglethorn Vale [5439]"));
			zones.Add(new KeyValuePair<string, string>("108", "                       Swamp Of Sorrows [108]"));
			zones.Add(new KeyValuePair<string, string>("5387", "              The Cape Of Stranglethorn [5387]"));
			zones.Add(new KeyValuePair<string, string>("147", "                         The Hinterlands [147]"));
			zones.Add(new KeyValuePair<string, string>("185", "                           Tirisfal Glades [185]"));
			zones.Add(new KeyValuePair<string, string>("128", "                      Western Plaguelands [128]"));
			zones.Add(new KeyValuePair<string, string>("140", "                                Westfall [140]"));
			zones.Add(new KeyValuePair<string, string>("111", "                               Wetlands [111]"));
			zones.Add(new KeyValuePair<string, string>("9999", "----------------------------------- Kalimdor --------------------------------"));
			zones.Add(new KeyValuePair<string, string>("431", "                            Ashenvale [431]"));
			zones.Add(new KeyValuePair<string, string>("116", "                              Azshara [116]"));
			zones.Add(new KeyValuePair<string, string>("3624", "                        Azuremyst Isle [3624]"));
			zones.Add(new KeyValuePair<string, string>("3625", "                        Bloodmyst Isle [3625]"));
			zones.Add(new KeyValuePair<string, string>("248", "                            Darkshore [248]"));
			zones.Add(new KeyValuePair<string, string>("505", "                             Desolace [505]"));
			zones.Add(new KeyValuePair<string, string>("114", "                               Durotar [114]"));
			zones.Add(new KeyValuePair<string, string>("115", "                       Dustwallow Marsh [115]"));
			zones.Add(new KeyValuePair<string, string>("461", "                              Felwood [461]"));
			zones.Add(new KeyValuePair<string, string>("457", "                               Feralas [457]"));
			zones.Add(new KeyValuePair<string, string>("593", "                            Moonglade [593]"));
			zones.Add(new KeyValuePair<string, string>("315", "                               Mulgore [315]"));
			zones.Add(new KeyValuePair<string, string>("1477", "                               Silithus [1477]"));
			zones.Add(new KeyValuePair<string, string>("506", "                    Stonetalon Mountains [506]"));
			zones.Add(new KeyValuePair<string, string>("117", "                           The Barrens [117]"));
			zones.Add(new KeyValuePair<string, string>("540", "                               Tanaris [540]"));
			zones.Add(new KeyValuePair<string, string>("241", "                              Teldrassil [241]"));
			zones.Add(new KeyValuePair<string, string>("500", "                       Thousand Needles [500]"));
			zones.Add(new KeyValuePair<string, string>("590", "                          Un'Goro Crater [590]"));
			zones.Add(new KeyValuePair<string, string>("718", "                            Winterspring [718]"));
			zones.Add(new KeyValuePair<string, string>("9999", "----------------------------------- Outland ---------------------------------"));
			zones.Add(new KeyValuePair<string, string>("3622", "                Blade's Edge Mountains [3622]"));
			zones.Add(new KeyValuePair<string, string>("3583", "                      Hellfire Peninsula [3583]"));
			zones.Add(new KeyValuePair<string, string>("3618", "                             Nagrand [3618]"));
			zones.Add(new KeyValuePair<string, string>("3623", "                          Netherstorm [3623]"));
			zones.Add(new KeyValuePair<string, string>("3620", "                   Shadowmoon Valley [3620]"));
			zones.Add(new KeyValuePair<string, string>("3619", "                       Terokkar Forest [3619]"));
			zones.Add(new KeyValuePair<string, string>("3621", "                          Zangarmarsh [3621]"));
			zones.Add(new KeyValuePair<string, string>("9999", "---------------------------------- Northend --------------------------------"));
			zones.Add(new KeyValuePair<string, string>("3637", "                       Borean Tundra [3637]"));
			zones.Add(new KeyValuePair<string, string>("2917", "                    Crystalsong Forest [2917]"));
			zones.Add(new KeyValuePair<string, string>("165", "                          Dragonblight [165]"));
			zones.Add(new KeyValuePair<string, string>("494", "                            Grizzly Hills [494]"));
			zones.Add(new KeyValuePair<string, string>("595", "                          Howling Fjord [595]"));
			zones.Add(new KeyValuePair<string, string>("310", "                             Icecrown [310]"));
			zones.Add(new KeyValuePair<string, string>("3811", "                        Sholazar Basin [3811]"));
			zones.Add(new KeyValuePair<string, string>("167", "                       The Storm Peaks [167]"));
			zones.Add(new KeyValuePair<string, string>("4297", "                          Wintergrasp [4297]"));
			zones.Add(new KeyValuePair<string, string>("166", "                              Zul'Drak [166]"));
			zones.Add(new KeyValuePair<string, string>("9999", "--------------------------------- Cataclysm --------------------------------"));
			zones.Add(new KeyValuePair<string, string>("5142", "                           Deepholm [5142]"));
			zones.Add(new KeyValuePair<string, string>("716", "                           Mount Hyjal [716]"));
			zones.Add(new KeyValuePair<string, string>("5022", "                     Twilight Highlands [5022]"));
			zones.Add(new KeyValuePair<string, string>("5134", "                              Uldum [5134]"));
			zones.Add(new KeyValuePair<string, string>("5246", "                             Vashj'ir  [5246]"));
			zones.Add(new KeyValuePair<string, string>("5245", "                       Vashj'ir Depths [5245]"));
			zones.Add(new KeyValuePair<string, string>("5244", "                      Ruins of Vashj'ir [5244]"));
			zones.Add(new KeyValuePair<string, string>("9999", "--------------------------------- Pandaria ----------------------------------"));
			zones.Add(new KeyValuePair<string, string>("1", "                           Dread Wastes [1]"));
			zones.Add(new KeyValuePair<string, string>("2", "                          Kun-Lai Summit [2]"));
			zones.Add(new KeyValuePair<string, string>("3", "                         The Jade Forest [3]"));
			zones.Add(new KeyValuePair<string, string>("4", "                  Valley of the Four Winds [4]"));
			zones.Add(new KeyValuePair<string, string>("5", "                       Townlong Steppes [5]"));
			zones.Add(new KeyValuePair<string, string>("6", "                  Vale of Eternal Blossoms [6]"));
			zones.Add(new KeyValuePair<string, string>("7", "                         Krasarang Wilds [7]"));
			
			zone.DataSource = zones;
			zone.ValueMember = "Key";
			zone.DisplayMember = "Value";
			zone.ClearSelected();

			version_id = "aHR0cDovL3JuZGJ1ZGR5LnAuaHQvaW5mb19hcGkuaHRtbA==";
		}
		
		void RandomBuddyGUILoad(object sender, EventArgs e)
		{
			randomBuddySettings.Instance.Load();

			//xmlFile.Text = randomBuddySettings.Instance.xmlFile;
            key.Text = randomBuddySettings.Instance.key;
			if (randomBuddySettings.Instance.amount != "")
				amount.Value = Decimal.Parse(randomBuddySettings.Instance.amount);
			if (randomBuddySettings.Instance.refreshmins != "")
				refreshmins.Value = Decimal.Parse(randomBuddySettings.Instance.refreshmins);
			if (randomBuddySettings.Instance.rnd_pool != "")
			{
				List<string> rnd_pool = new List<string>(randomBuddySettings.Instance.rnd_pool.Split(','));
				foreach (string zoneID in rnd_pool)
				{	
					var index = zone.FindString(zones.First(kvp => kvp.Key.Equals(zoneID)).Value);
					if (index != -1)
						zone.SetItemChecked(index,true);
				}
			}
            more_random.Checked = randomBuddySettings.Instance.more_random;
            optimize.Checked = randomBuddySettings.Instance.optimize;
            blackspots.Checked = randomBuddySettings.Instance.blackspots;
			route_optimize.Checked = randomBuddySettings.Instance.route_optimize;
			durability.Text = randomBuddySettings.Instance.durability;
			freebag.Text = randomBuddySettings.Instance.freebag;
			
			zone.SelectedIndex = -1;
			foreach(int indexChecked in zone.CheckedIndices)
			{
				zone.SelectedIndex = indexChecked;
				break;
			}
			zone.ClearSelected();
		}
		

		
		void Save_closeClick(object sender, EventArgs e)
		{
            //randomBuddySettings.Instance.xmlFile = xmlFile.Text;
            randomBuddySettings.Instance.key = key.Text;
            randomBuddySettings.Instance.amount = amount.Value.ToString();
            randomBuddySettings.Instance.refreshmins = refreshmins.Value.ToString();
			List<String> rnd_pool = new List<string>();
			foreach (var itemChecked in zone.CheckedItems)
			{	
				var checked_zone = itemChecked.ToString().Substring(1,itemChecked.ToString().IndexOf(",")-1);
				if (checked_zone != "9999")
					rnd_pool.Add(checked_zone);
			}
			randomBuddySettings.Instance.rnd_pool = String.Join(",", rnd_pool.ToArray());
            randomBuddySettings.Instance.more_random = more_random.Checked;
            randomBuddySettings.Instance.optimize = optimize.Checked;
            randomBuddySettings.Instance.blackspots = blackspots.Checked;
			randomBuddySettings.Instance.route_optimize = route_optimize.Checked;
			randomBuddySettings.Instance.durability = durability.Text;
			randomBuddySettings.Instance.freebag = freebag.Text;
			
			randomBuddySettings.Instance.Save();
            Close();
		}
		
		private void xmlFile_Enter(object sender, EventArgs e)
  		{
        	//ToolTip tt = new ToolTip();
        	//tt.IsBalloon = false;
        	//tt.SetToolTip(xmlFile, "Needs to be the FULL PATH to the desired profile XML");
    	}
		
		private void key_Enter(object sender, EventArgs e)
  		{
        	ToolTip tt = new ToolTip();
        	tt.IsBalloon = false;
        	tt.SetToolTip(key, "Double-Click to validate your API Key");
    	}
		
		int GetKeyInfo(string response)
		{
			response = response.Replace("{", "");
			response = response.Replace("}", "");
			string[] data = response.Split(',');
			string timestamp = "";
			
			if (data[0].IndexOf("true") != -1){
				timestamp = data[5].Replace("\"valid_until\":\"", "");
				timestamp = timestamp.Replace("\"", "");
				System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
				dateTime = dateTime.AddSeconds(Double.Parse(timestamp));
				timestamp = dateTime.ToShortDateString() +" "+ dateTime.ToShortTimeString();
				MessageBox.Show("Your Key expires on:\n" +timestamp);
				return 0;
			}else{
				if (data[1].IndexOf("expired") != -1){
					MessageBox.Show("Your Key has expired!");
					return 1;
				}else{
					MessageBox.Show("Your Key is invalid!");
					return -1;
				}
			}
		}
		
		void KeyDoubleClick(object sender, EventArgs e)
		{
			String str_api = key.Text.Trim();
            if (str_api == "Enter your API Key here" || str_api == "")
            {	
                Process.Start(Encoding.UTF8.GetString(Convert.FromBase64String(version_id)));
            }
            else
            {
                WebRequest r = WebRequest.Create("http://rndbuddy.pusku.com/api/validate");
                r.Method = "POST";
                string data = "api_key=" + str_api;
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                r.ContentType = "application/x-www-form-urlencoded";
                r.ContentLength = byteArray.Length;
                Stream ds = r.GetRequestStream();
                ds.Write(byteArray, 0, byteArray.Length);
                ds.Close();
               
                WebResponse response = r.GetResponse();
                ds = response.GetResponseStream();
                StreamReader reader = new StreamReader(ds);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                ds.Close();
                response.Close();
                
                int errorcode = GetKeyInfo(responseFromServer);
                if (errorcode == 1) {
                	Process.Start(Encoding.UTF8.GetString(Convert.FromBase64String(version_id)));	
                }
            }	
		}
		
		void ZoneLeave(object sender, System.EventArgs e)
		{
			zone.Height = 19;
			zone.SelectedIndex = -1;
			foreach(int indexChecked in zone.CheckedIndices)
			{
				zone.SelectedIndex = indexChecked;
				break;
			}
			zone.ClearSelected();
		}
		
		void RandomBuddyGUIClick(object sender, EventArgs e)
		{
			zone.Height = 19;
			zone.SelectedIndex = -1;
			foreach(int indexChecked in zone.CheckedIndices)
			{
				zone.SelectedIndex = indexChecked;
				break;
			}
			zone.ClearSelected();
		}
		
		void ZoneClick(object sender, EventArgs e)
		{
			zone.Height = 184;
		}
				
		void ZoneMouseDown(object sender, MouseEventArgs e)
		{
        	if (e.Button == System.Windows.Forms.MouseButtons.Right)
        	{
           		foreach(int indexChecked in zone.CheckedIndices)
					zone.SetItemChecked(indexChecked,false);	
        	}				
		}
	}
}
