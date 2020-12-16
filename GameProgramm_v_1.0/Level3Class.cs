using System.IO;

namespace GameProgramm_v_1._0
{
    public static class Level3Class
    {
        public static int Time { get; set; } = 999;
        public static string Map { get; set; } = Directory.GetCurrentDirectory() + "Prepatstvia_3_Level.txt";
        public static int TimeBotMove { get; set; } = 1;
    }
}
