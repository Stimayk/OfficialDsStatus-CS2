using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace OfficialDSStatus
{
    public class OfficialDSStatus : BasePlugin
    {
        public override string ModuleName => "OfficialDSStatus";
        public override string ModuleAuthor => "E!N";
        public override string ModuleVersion => "v1.1";

        [GameEventHandler]
        public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
        {
            CCSGameRules gamerules = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").First().GameRules!;
            gamerules.IsValveDS = true;
            return HookResult.Continue;
        }
    }
}