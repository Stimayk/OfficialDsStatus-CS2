using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Timers;

namespace FgOfficialDS;

// Oznacza serwer jako "Official DS" (gamerules.IsValveDS = true), dzieki czemu da sie dolaczyc przez liste znajomych / lobby.
// Na podstawie github.com/Stimayk/OfficialDsStatus-CS2 (E!N), przeniesione na .NET 10 / CounterStrikeSharp 1.0.37x.
// Wymaga: GSLT (sv_setsteamaccount) oraz "FollowCS2ServerGuidelines": false w configs/core.json.
public class OfficialDSStatus : BasePlugin
{
    public override string ModuleName => "OfficialDSStatus";
    public override string ModuleVersion => "1.2.0";
    public override string ModuleAuthor => "E!N // edited by Ziuber";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventRoundStart>((_, _) => { Apply(); return HookResult.Continue; });
        RegisterListener<Listeners.OnMapStart>(_ => AddTimer(1.0f, Apply, TimerFlags.STOP_ON_MAPCHANGE));
        if (hotReload) Apply();
    }

    private static void Apply()
    {
        var proxy = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").FirstOrDefault();
        var rules = proxy?.GameRules;
        if (proxy == null || rules == null || rules.IsValveDS) return;

        rules.IsValveDS = true;
        Utilities.SetStateChanged(proxy, "CCSGameRulesProxy", "m_pGameRules");
    }
}
