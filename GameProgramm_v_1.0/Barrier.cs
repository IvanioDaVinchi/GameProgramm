using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramm_v_1._0
{
    public class Barrier
    {
        int X;
        int Y;
        public Barrier[] GetBarrier_Level1()
        {
            Barrier[] barriersArray;
            string barriers = FileClass.GetTextFromFile(FileClass.path_for_Level_1);
            return barriersArray;
        }
    }
}
