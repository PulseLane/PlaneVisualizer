using System;
using System.Reflection;
using HarmonyLib;
using IPA;
using IPALogger = IPA.Logging.Logger;
using BeatSaberMarkupLanguage.Settings;
using PlaneVisualizer.UI;
using UnityEngine;
using BS_Utils.Gameplay;

namespace PlaneVisualizer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public const string HarmonyId = "com.PulseLane.BeatSaber.PlaneVisualizer";
        internal static Plugin instance { get; private set; }
        internal static string Name => "PlaneVisualizer";
        internal static Harmony harmony => new Harmony(HarmonyId);
        internal static PlaneVisualizerController PluginController { get { return PlaneVisualizerController.instance; } }

        [Init]
        public Plugin(IPALogger logger)
        {
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
        }

        [OnEnable]
        public void OnEnable()
        {
            Config.Read();
            if (Config.enabled)
            {
                ApplyHarmonyPatches();
            }
            BSMLSettings.instance.AddSettingsMenu("PlaneVisualizer", "PlaneVisualizer.UI.settings.bsml", Settings.instance);
            BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneLoaded;
            BS_Utils.Utilities.BSEvents.lateMenuSceneLoadedFresh += OnMenuSceneLoadedFresh;
        }
        
        [OnDisable]
        public void OnDisable()
        {
            RemoveHarmonyPatches();
            BSMLSettings.instance.RemoveSettingsMenu(Settings.instance);
            BS_Utils.Utilities.BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
            BS_Utils.Utilities.BSEvents.lateMenuSceneLoadedFresh -= OnMenuSceneLoadedFresh;
            if (PluginController != null)
                GameObject.Destroy(PluginController);
        }

        private void OnGameSceneLoaded()
        {
            if (Config.enabled)
                PluginController.OnGameSceneLoad();
        }
        private void OnMenuSceneLoadedFresh(ScenesTransitionSetupDataSO obj)
        {
            if (PluginController == null)
                new GameObject("Plane Visualizer Controller").AddComponent<PlaneVisualizerController>();
        }

        public void ApplyHarmonyPatches()
        {
            try
            {
                Logger.log.Debug("Applying Harmony patches.");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                ScoreSubmission.ProlongedDisableSubmission("PlaneVisualizer");
            }
            catch (Exception ex)
            {
                Logger.log.Critical("Error applying Harmony patches: " + ex.Message);
                Logger.log.Debug(ex);
            }
        }

        public void RemoveHarmonyPatches()
        {
            try
            {
                // Removes all patches with this HarmonyId
                Logger.log.Debug("Removing harmony patches");
                harmony.UnpatchAll(HarmonyId);
                ScoreSubmission.RemoveProlongedDisable("PlaneVisualizer");
            }
            catch (Exception ex)
            {
                Logger.log.Critical("Error removing Harmony patches: " + ex.Message);
                Logger.log.Debug(ex);
            }
        }
    }
}
