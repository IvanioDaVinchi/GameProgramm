using System.IO;

namespace GameProgramm_v_1._0
{
    public static class Settings
    {
        public static string PathCharacterTexture { get; set; } = Directory.GetCurrentDirectory() + "\\Kartinki\\1.jpg";
        public static string PathBotTexture { get; set; } = Directory.GetCurrentDirectory() + "\\Kartinki\\bot.jpg";
        public static bool ChoiceLevels { get; set; } = false;
        public static int CountLife { get; set; } = 1;
    }
}
