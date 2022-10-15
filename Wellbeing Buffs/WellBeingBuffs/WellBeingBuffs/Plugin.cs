using HarmonyLib;
using TimberApi.ModSystem;
using TimberApi.ConsoleSystem;
using TimberApi.ConfigSystem;

namespace WellBeingBuffs
{
    [HarmonyPatch]
    public class WellBeingBuffs : IModEntrypoint
    {
        public static WellBeingBuffConfig Config;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            Config = mod.Configs.Get<WellBeingBuffConfig>();
            var harmony = new Harmony("Valoneu.plugins.WellBeingBuff");
            harmony.PatchAll();
        }
    }
    public class WellBeingBuffConfig : IConfig
    {
        public string ConfigFileName => "WellBeingBuffs";

        public int WellBeingMultipler = 2;
    }
}
