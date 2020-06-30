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
                Config.practiceEnable = value;
                Config.Write();
            }
        }
    }
}
