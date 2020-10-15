using BeatSaberMarkupLanguage.Attributes;

namespace PlaneVisualizer.UI
{
    class Settings : PersistentSingleton<Settings>
    {
        [UIValue("enabled")]
        public bool enabled
        {
            get => Config.enabled;
            set
            {
                Logger.log.Debug("enable change");
                Config.enabled = value;
                if (value)
                {
                    Plugin.instance.ApplyHarmonyPatches();
                }
                else
                {
                    Plugin.instance.RemoveHarmonyPatches();
                }
                Config.Write();
            }
        }

        [UIValue("practiceEnable")]
        public bool practiceEnable
        {
            get => Config.practiceEnable;
            set
            {
                Logger.log.Debug("practice change");
                Config.practiceEnable = value;
                Config.Write();
            }
        }
    }
}
