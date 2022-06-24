using UnityEngine;
using HarmonyLib;

namespace StareDuckFix.Patches {
    [HarmonyPatch(typeof(Level02))]
    [HarmonyPatch("Update", MethodType.Normal)]
    internal class PatchLevel02 {
        private static void Postfix(Level02 __instance) {
            float distance = Vector3.Distance(__instance.player.position, __instance.duck.position);
            float alignedby = Vector3.Dot(__instance.playerTransform.forward, (__instance.duckTransform.position - __instance.player.position).normalized);
            // map 1.3 to 10 to -0.5 to 0.95
            // 0.5 is ~120 deg, 0.95 is ~15 deg
            // 1.3 is the distance when collison with the duck is activated
            // 10 is just arbitrary LOL
            float threshold = Mathf.Lerp(-0.5f, 0.95f, Mathf.Clamp(1.3f, 10f, distance) / 10f);
            if (alignedby > threshold) {
                __instance.player.useGravity = false;
                __instance.player.velocity = new Vector3(__instance.player.velocity.x, 0, __instance.player.velocity.z);
            } 
        }
    }
}
