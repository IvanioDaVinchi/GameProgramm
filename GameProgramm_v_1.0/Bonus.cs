using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramm_v_1._0
{
    public class Bonus
    {
            public int x;
            public int y;
            public bool exist = false;

            public bool Exist()
            {
                return exist ? true : false;
            }
    }
}
