using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace NS2AdminLib.JSONClasses
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class NS2ServerInfo
    {
        // JSON elements.
        public int alien_res { get; set; }
        public int aliens { get; set; }
        public bool cheats { get; set; }
        public bool devmode { get; set; }
        public decimal frame_rate { get; set; }
        public bool game_started { get; set; }
        public int game_time { get; set; }
        public string map { get; set; }
        public int marine_res { get; set; }
        public int marines { get; set; }
        public List<NS2Player> player_list { get; set; }
        public int players_online { get; set; }
        public string server_name { get; set; }
        public int uptime { get; set; }
        public string webdomain { get; set; }
        public string webport { get; set; }

        public int RealPlayers { get { return player_list.Count(a => !a.isbot); } }
        public int Bots { get { return player_list.Count(a => a.isbot); } }

        private string DebuggerDisplay { get { return string.Format("{0} [Players: {1} / Tick Rate: {2}]", server_name, RealPlayers, Math.Round(frame_rate, 0, MidpointRounding.AwayFromZero)); } }
    }
}
