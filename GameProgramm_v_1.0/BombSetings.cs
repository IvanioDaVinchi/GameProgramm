using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramm_v_1._0
{
    static public class BombSetings
    {
        static public int timeExplode = 3;

        static public int TimeExplode
        {
            get
            {
                return timeExplode;
            }
            set
            {
                timeExplode = value;
            }
        }
    }
}
