using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public class Bomb
    {
        int x;
        int y;
        int timer=3;
        string path;
        bool exist;
        PictureBox[,] pictureBoxes;
        Random random = new Random();

        public Bomb(PictureBox[,] pictureBoxes)
        {
            this.pictureBoxes = pictureBoxes;
        }

        public Bomb()
        {
        }


        public void RandomPlace(Barrier[] barriersArray, Bot bot)
        {
            bool proxod = false;
            int counter = 0;

            while (proxod == false)
            {
                x = random.Next(0, pictureBoxes.GetLength(0) - 1);
                y = random.Next(0, pictureBoxes.GetLength(1) - 1);

                foreach (var item in barriersArray)
                {
                    if (x == item.X && y == item.Y)
                    {
                        counter++;
                    }
                }

                if (x == bot.row && y == bot.col)
                {
                    counter++;
                }

                if (counter == 0)
                {
                    proxod = true;
                }
                else
                {
                    counter = 0;
                }
            }

            pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bomb.jpg");
            exist = true;
        }

        public bool Exist()
        {
            return exist ? true : false;
        }
    }
}
