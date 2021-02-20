using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(WormScript))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_WormScript_TD
    {
        [HarmonyPostfix]
        public static void Postfix(WormScript __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}