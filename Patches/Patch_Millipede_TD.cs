using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(Millipede))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_Millipede_TD
    {
        [HarmonyPostfix]
        public static void Postfix(Millipede __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}