using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public class Bot
    {
        public int col;
        public int row;
        PictureBox[,] pictureBoxes;

        public void Restart()
        {
            pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
            col = 0;
            row = pictureBoxes.GetLength(0) - 2;
            pictureBoxes[pictureBoxes.GetLength(0) - 2, 0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
        }

        public void SetValues(PictureBox[,] pictureBoxes1)
        {
            pictureBoxes = pictureBoxes1;
            row = pictureBoxes.GetLength(0) - 2;
            pictureBoxes[pictureBoxes.GetLength(0) - 2, 0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bot.jpg");
        }

        public void Move(int playerX, Barrier[] barriers)
        {
            bool hodit = true;

            if (col != playerX)
            {
                if (col < playerX)
                {
                    pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                    col++;
                    foreach (var item in barriers)
                    {
                        if (row == item.X && col == item.Y)
                        {
                            hodit = false;
                            break;
                        }
                    }
                    if (hodit == true)
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
                    col--;
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






