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
    public class Character
    {
        private int counter = 0;
        public int col = 0;
        public int row = 0;
        public int life = 1;
        PictureBox[,] pictureBoxes;
        public string PathTexture { get; set; }

        public Character(PictureBox[,] pictureBoxes)
        {
            this.pictureBoxes = pictureBoxes;
            pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
        }

        private void Right()
        {
            if (col != pictureBoxes.GetLength(1) - 1)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                col++;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        private void Down()
        {
            if (row != pictureBoxes.GetLength(0) - 1)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                row++;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        private void Left()
        {
            if (col != 0)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                col--;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        private void Up()
        {
            if (row != 0)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                row--;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Dead()
        {
            life--;
            pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
            row = 0;
            col = 0;
            pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            Bot.Restart();
            MessageBox.Show("Вы умерли.");
        }

        public void HoditRight(Barrier[] barriersArray, Bonus bonus, Timer timer1, Timer timer2, Action<PictureBox[,]> RandBonus)
        {
            bool hodit = true;
            foreach (var item in barriersArray)
            {
                if (col - 1 == item.Y && row == item.X)
                {
                    hodit = false;
                }
            }
            if (hodit == true)
            {
                if (bonus.exist == false)
                {
                    counter++;
                }
                Right();
                if (row == bonus.x && col == bonus.y)
                {
                    bonus.exist = false;
                    timer1.Stop();
                    timer2.Start();
                }
                if (counter == 6)
                {
                    RandBonus(pictureBoxes);
                    counter = 0;
                }
            }
        }

        public void HoditLeft(Barrier[] barriersArray, Bonus bonus, Timer timer1, Timer timer2, Action<PictureBox[,]> RandBonus)
        {
            bool hodit = true;
            foreach (var item in barriersArray)
            {
                if (col - 1 == item.Y && row == item.X)
                {
                    hodit = false;
                }
            }
            if (hodit == true)
            {
                if (bonus.exist == false)
                {
                    counter++;
                }
                Left();
                if (row == bonus.x && col == bonus.y)
                {
                    bonus.exist = false;
                    timer1.Stop();
                    timer2.Start();
                }
                if (counter == 6)
                {
                    RandBonus(pictureBoxes);
                    counter = 0;
                }
            }
        }

        public void HoditDown(Barrier[] barriersArray, Bonus bonus, Timer timer1, Timer timer2, Action<PictureBox[,]> RandBonus)
        {
            bool hodit = true;
            foreach (var item in barriersArray)
            {
                if (col - 1 == item.Y && row == item.X)
                {
                    hodit = false;
                }
            }
            if (hodit == true)
            {
                if (bonus.exist == false)
                {
                    counter++;
                }
                Down();
                if (row == bonus.x && col == bonus.y)
                {
                    bonus.exist = false;
                    timer1.Stop();
                    timer2.Start();
                }
                if (counter == 6)
                {
                    RandBonus(pictureBoxes);
                    counter = 0;
                }
            }
        }

        public void HoditUp(Barrier[] barriersArray, Bonus bonus, Timer timer1, Timer timer2, Action<PictureBox[,]> RandBonus)
        {
            bool hodit = true;
            foreach (var item in barriersArray)
            {
                if (col - 1 == item.Y && row == item.X)
                {
                    hodit = false;
                }
            }
            if (hodit == true)
            {
                if (bonus.exist == false)
                {
                    counter++;
                }
                Up();
                if (row == bonus.x && col == bonus.y)
                {
                    bonus.exist = false;
                    timer1.Stop();
                    timer2.Start();
                }
                if (counter == 6)
                {
                    RandBonus(pictureBoxes);
                    counter = 0;
                }
            }
        }
    }
}
