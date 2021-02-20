using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(DestroyerTrue))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_DestroyerTrue_TD
    {
        [HarmonyPostfix]
        public static void Postfix(DestroyerTrue __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}