using NS2AdminLib.Enumerations;
using System.Diagnostics;

namespace NS2AdminLib.JSONClasses
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class NS2Player
    {
        // JSON elements.
        public int assists { get; set; }
        public int deaths { get; set; }
        public string ipaddress { get; set; }
        public bool isbot { get; set; }
        public bool iscomm { get; set; }
        public int kills { get; set; }
        public string name { get; set; }
        public int ping { get; set; }
        public decimal resources { get; set; }
        public int score { get; set; }
        public int steamid { get; set; }
        public NS2PlayerTeam team { get; set; }

        private string DebuggerDisplay { get { return string.Format("{0} [SteamID: {1} / IP: {2}]", name, steamid, ipaddress); } }
    }
}
