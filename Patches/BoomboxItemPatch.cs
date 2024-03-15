using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace BoomboxTutorial.Patches
{
    [HarmonyPatch(typeof(BoomboxItem), "Start")]
    internal class BoomboxItemPatch
    {
        private static void Postfix(ref BoomboxItem __instance)
        {
            if (__instance == null) return;

            List<AudioClip> AllMusicAudios = new List<AudioClip>(__instance.musicAudios);
            AllMusicAudios.AddRange(Plugin.BoomboxSongs);

            __instance.musicAudios = AllMusicAudios.ToArray();
        }
    }
}