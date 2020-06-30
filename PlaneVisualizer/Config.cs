namespace PlaneVisualizer
{
    class Config
    {
        public static BS_Utils.Utilities.Config config = new BS_Utils.Utilities.Config("PlaneVisualizer");
        public static bool enabled = false;
        public static bool practiceEnable = false;

        public static void Read()
        {
            enabled = config.GetBool("PlaneVisualizer", "enabled", false, true);
            practiceEnable = config.GetBool("PlaneVisualizer", "practiceEnable", false, true);
        }

        public static void Write()
        {
            config.SetBool("PlaneVisualizer", "enabled", enabled);
            config.SetBool("PlaneVisualizer", "practiceEnable", practiceEnable);
        }
    }
}
