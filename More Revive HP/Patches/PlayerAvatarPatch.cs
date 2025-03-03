using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using More_Revive_HP;

namespace More_Revive_HP.Patches
{
    [HarmonyPatch(typeof(PlayerAvatar), "ReviveRPC")]
    class PlayerAvatarPatch
    {
        static void Postfix(PlayerAvatar __instance, bool _revivedByTruck)
        {

            int ExtraHealth = Plugin.GetExtraHealth();

            if (__instance.photonView.IsMine)
            {
                __instance.playerHealth.HealOther(ExtraHealth, true); 
            }
        }
    }
}
