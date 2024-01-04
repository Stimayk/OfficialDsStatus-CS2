using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace OfficialDSStatus
{
    public class OfficialDSStatus : BasePlugin
    {
        public override string ModuleName => "OfficialDSStatus";
        public override string ModuleVersion => "v1.0";

        public override void Load(bool hotReload)
        {
            AddTimer(0.1f, () => SetIsValveDS());
        }

        public void SetIsValveDS()
        {
            CCSGameRules gamerules = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").First().GameRules!;
            gamerules.IsValveDS = true;
            Server.PrintToConsole($"IsValveDS - {gamerules.IsValveDS}");
        }
    }
}