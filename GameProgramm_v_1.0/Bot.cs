using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    static public class Bot
    {
        static public int col;
        static public int row;
        static PictureBox[,] pictureBoxes;

        static public void Restart()
        {
            col = 0;
            row = pictureBoxes.GetLength(0) - 2;
            pictureBoxes[pictureBoxes.GetLength(0) - 2, 0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
        }

        static public void SetValues(PictureBox[,] pictureBoxes1)
        {
            pictureBoxes = pictureBoxes1;
            row = pictureBoxes.GetLength(0) - 2;
            pictureBoxes[pictureBoxes.GetLength(0)- 2, 0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
        }

        static public void Move(int col1,Barrier[] barriers)
        {
            bool hodit=true;

            if (col != pictureBoxes.GetLength(1) - 1)
            {
                if (col < col1)
                {
                    pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                    col++;
                    foreach (var item in barriers)
                    {
                        if (row == item.X && col == item.Y)
                        {
                            hodit = false;
                        }
                    }
                    if (hodit==true)
                    {
                        pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
                    }
                    else
                    {
                            col--;
                        pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
                    }
                }
                else
                {
                    pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                    if (col!=col1)
                    {
                        col--;
                    }
                    foreach (var item in barriers)
                    {
                        if (row == item.X && col == item.Y)
                        {
                            hodit = false;
                        }
                    }
                    if (hodit == true)
                    {
                        pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
                    }
                    else
                    {
                        col++;
                        pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
                    }
                }
            }
        }
    }
}
