using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace BoomboxTutorial
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    internal class Plugin : BaseUnityPlugin
    {
        private static ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(PluginInfo.PLUGIN_GUID);
        public static Plugin Instance;

        private static AssetBundle Bundle;
        public static AudioClip[] BoomboxSongs;

        void Awake()
        {
            Instance = this;
            mls.LogInfo("Plugin is awake!");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginInfo.PLUGIN_GUID);

            var BundleDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "boomboxtutorial");
            Bundle = AssetBundle.LoadFromFile(BundleDir);

            if (Bundle == null)
            {
                mls.LogError("Failed to load asset bundle.");
                return;
            }

            mls.LogInfo("Successfully loaded asset bundle.");
            BoomboxSongs = Bundle.LoadAllAssets<AudioClip>();
        }
    }
}