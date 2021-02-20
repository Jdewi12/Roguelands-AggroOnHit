using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(Destroyer))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_Destroyer_TD
    {
        [HarmonyPostfix]
        public static void Postfix(Destroyer __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}