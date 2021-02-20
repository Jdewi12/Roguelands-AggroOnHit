using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(SliverScript))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_SliverScript_TD
    {
        [HarmonyPostfix]
        public static void Postfix(SliverScript __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}