using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(Hivemind))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_Hivemind_TD
    {
        [HarmonyPostfix]
        public static void Postfix(Hivemind __instance)
        {
            AggroOnHit.SetPlayerTarget(__instance);
        }
    }
}