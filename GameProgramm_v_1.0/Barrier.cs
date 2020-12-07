using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramm_v_1._0
{
    public class Barrier
    {
        public int X;
        public int Y;
        public Barrier[] GetBarrier_Level1()
        {
            string barrier = FileClass.GetTextFromFile(FileClass.path_for_Level_1);
            string[] barriers = barrier.Split('\n');
            Barrier[] barriersArray = new Barrier[barriers.Length];
            for(int i = 0; i < barriersArray.Length; i++)
            {
                string str = barriers[i];
                barriersArray[i].X = Convert.ToInt32(Convert.ToString(str[0]));
                barriersArray[i].Y = Convert.ToInt32(Convert.ToString(str[3]));
            }
            return barriersArray;
        }
        public Barrier[] GetBarrier_Level2()
        {
            string barrier = FileClass.GetTextFromFile(FileClass.path_for_Level_2);
            string[] barriers = barrier.Split('\n');
            Barrier[] barriersArray = new Barrier[barriers.Length];
            for (int i = 0; i < barriersArray.Length; i++)
            {
                string str = barriers[i];
                barriersArray[i].X = Convert.ToInt32(Convert.ToString(str[0]));
                barriersArray[i].Y = Convert.ToInt32(Convert.ToString(str[3]));
            }
            return barriersArray;
        }
        public Barrier[] GetBarrier_Level3()
        {
            string barrier = FileClass.GetTextFromFile(FileClass.path_for_Level_3);
            string[] barriers = barrier.Split('\n');
            Barrier[] barriersArray = new Barrier[barriers.Length];
            for (int i = 0; i < barriersArray.Length; i++)
            {
                string str = barriers[i];
                barriersArray[i].X = Convert.ToInt32(Convert.ToString(str[0]));
                barriersArray[i].Y = Convert.ToInt32(Convert.ToString(str[3]));
            }
            return barriersArray;
        }
    }
}
