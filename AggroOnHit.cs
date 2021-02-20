using GadgetCore.API;
using UnityEngine;

namespace AggroOnHit
{
    [Gadget("AggroOnHit", RequiredOnClients: false)]
    public class AggroOnHit : Gadget
    {
        public const string MOD_VERSION = "1.2"; // Set this to the version of your mod.
        public const string CONFIG_VERSION = "1.0"; // Increment this whenever you change your mod's config file.

        public static GadgetCore.GadgetLogger logger;

        internal static void Log(string text)
        {
            logger.Log(text);
        }

        protected override void PrePatch()
        {
            logger = base.Logger;
        }

        protected override void Initialize()
        {
            Log("Gadget Initialised");
        }

        public static void SetPlayerTarget(MonoBehaviour enemy)
        {
            GameObject target = null;
            if (Network.isServer)
            {
                var scripts = GameObject.FindObjectsOfType<PlayerScript>();
                float closestSqr = Mathf.Infinity;
                foreach (PlayerScript script in scripts)
                {
                    GameObject player = script.gameObject;
                    PlayerAppearance playerAppearance = player.GetComponentInChildren<PlayerAppearance>();
                    // if player is not dead
                    if ((playerAppearance == null  /*playerAppearance shouldn't be null, but just in case*/ && !GameScript.dead) || (playerAppearance != null && !playerAppearance.reviveObj.activeSelf))
                    {
                        float sqrDist = Mathf.Pow(player.transform.position.x - enemy.transform.position.x, 2) + Mathf.Pow(player.transform.position.y - enemy.transform.position.y, 2);
                        if (sqrDist < closestSqr)
                        {
                            closestSqr = sqrDist;
                            target = player;
                        }
                    }
                }
            }
            if(target != null) // target might be null if all players are dead or something is seriously wrong.
                enemy.SendMessage("SetTarget", target);
        }
    }
}