using BepInEx;
namespace StareDuckFix
{
    [BepInPlugin("StareDuckFix", "StareDuckFix", "0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo("Plugin StareDuckFix is loaded!");
            HarmonyPatches.ApplyHarmonyPatches();
        }
    }
}
