#region System Namespace
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
#endregion

#region Styx Namespace
using Styx;
using Styx.Common;
using Styx.Helpers;
#endregion

namespace randomBuddy
{
    public class randomBuddySettings : Settings
    {
        public static readonly randomBuddySettings Instance = new randomBuddySettings();
        public randomBuddySettings()
            : base(Path.Combine(Path.Combine(Utilities.AssemblyDirectory, "Settings"), string.Format("randomBuddySettings_{0}.xml", StyxWoW.Me.Name)))
        {
        }

        #region Profile
        [Setting, DefaultValue("C:/")]
        public string xmlFile { get; set; }
        #endregion
		
		#region swaptime
        [Setting, DefaultValue("20")]
        public string refreshmins { get; set; }
        #endregion
        
        #region API Key
        [Setting, DefaultValue("Enter your API Key here")]
        public string key { get; set; }
        #endregion
		
        #region Amount
        [Setting, DefaultValue("45")]
        public string amount { get; set; }
        #endregion

        #region rnd_pool
        [Setting, DefaultValue("")]
        public string rnd_pool { get; set; }
        #endregion

        #region blackspots
        [Setting, DefaultValue(false)]
        public bool blackspots { get; set; }
        #endregion

        #region optimize
        [Setting, DefaultValue(false)]
        public bool optimize { get; set; }
        #endregion

        #region more_random
        [Setting, DefaultValue(false)]
        public bool more_random { get; set; }
        #endregion
		
		#region freebag
        [Setting, DefaultValue("1")]
        public string freebag { get; set; }
        #endregion
		
		#region durability
        [Setting, DefaultValue("0.4")]
        public string durability { get; set; }
        #endregion
		
        #region route_optimize
        [Setting, DefaultValue(false)]
        public bool route_optimize { get; set; }
        #endregion		
    }
}
