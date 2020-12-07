using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameProgramm_v_1._0
{
    public static class FileClass
    {
        public static string path_for_Level_1 = Directory.GetCurrentDirectory() + @"\Prepatstvia_1_Level.txt";
        public static string path_for_Level_2 = Directory.GetCurrentDirectory() + @"\Prepatstvia_2_Level.txt";
        public static string path_for_Level_3 = Directory.GetCurrentDirectory() + @"\Prepatstvia_3_Level.txt";
        public static string GetTextFromFile(string path)
        {
            string text = "";
            text = File.ReadAllText(path);
            return text;
        }
    }
}
