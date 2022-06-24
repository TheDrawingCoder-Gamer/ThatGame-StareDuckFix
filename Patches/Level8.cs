using HarmonyLib;

namespace StareDuckFix.Patches {
    [HarmonyPatch(typeof(Level08))]
    [HarmonyPatch("Update", MethodType.Normal)]
    internal class PatchLevel08 {
        private static void Postfix(ref float ___interval) {
            // LOL
            ___interval = 3f;
        }
    }
}
