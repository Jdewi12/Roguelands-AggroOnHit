using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(ScarabScript))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_ScarabScript_TD
    {
        [HarmonyPostfix]
        public static void Postfix(ScarabScript __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}