using UnityEngine;
using HarmonyLib;
using GadgetCore.API;

namespace AggroOnHit.Patches
{
    [HarmonyPatch(typeof(EnemyScript))]
    [HarmonyPatch("TD")]
    [HarmonyGadget("AggroOnHit")]
    public static class Patch_EnemyScript_TD
    {
        [HarmonyPostfix]
        public static void Postfix(EnemyScript __instance, ref bool ___initialized)
        {
            AggroOnHit.SetPlayerTarget(__instance);
            if (Network.isServer)
            {
                if (!___initialized)
                {
                    ___initialized = true;
                }
            }
        }
    }
}