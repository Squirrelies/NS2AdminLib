# NS2AdminLib
A .NET Standard C# library for administering a Natural Selection 2 server.

Example usage:

using (NS2Admin admin = new NS2Admin(@"MyUser", @"MyPass", "www.mydomain.com", 80))
{
    // Illustrates how to get server information including current tick rate, players connected, player list, etc.
    NS2ServerInfo info = admin.GetServerInfo();

    // Sends an RCON command to the server. In this example, we send the sv_say command with some parameters we retrieved from the info call previously.
    admin.Rcon(string.Format("sv_say Server Perf. [Tick Rate: {0}] [Uptime: {1}] [Players: {2}] [Bots: {3}]", Math.Round(info.frame_rate, 2, MidpointRounding.AwayFromZero), TimeSpan.FromSeconds(info.uptime), info.RealPlayers, info.Bots));
}
