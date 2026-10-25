The plugin changes the status of your community server to "Official DS".

Adds the ability to connect to your server via friends list in the game lobby, and POSSIBLY via Steam (not tested).

IMPORTANT:
GSLT token (sv_setsteamaccount) must be specified for the plugin to work correctly, otherwise there will be an error when connecting through the lobby.

In addons/counterstrikesharp/configs/core.json set FollowCS2ServerGuidelines to false

## Fixed build (1.2.0)

- Targets .NET 10 and CounterStrikeSharp 1.0.37x (NuGet package `CounterStrikeSharp.API`), so it loads on current servers.
- Sets the flag on map start and on every round start, and marks the game rules as changed so clients receive it.

Build: `dotnet build -c Release`, then copy `bin/Release/net10.0/OfficialDSStatus.dll` to
`game/csgo/addons/counterstrikesharp/plugins/OfficialDSStatus/` and restart the server.
If an old Metamod version of OfficialDSStatus is installed, remove it first (it shows `<ERROR>` in `meta list`).
