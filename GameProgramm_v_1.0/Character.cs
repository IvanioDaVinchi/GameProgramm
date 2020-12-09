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
        public int col=0;
        public int row=0;
        public int life=1;
        PictureBox[,] pictureBoxes;
        public string PathTexture { get; set; }

        public Character(PictureBox[,] pictureBoxes)
        {
            this.pictureBoxes = pictureBoxes;
            pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
        }

        public void picupBonus()
        {

        }

        public void Right()
        {

            if (col != pictureBoxes.GetLength(1)-1)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                col++;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Down()
        {
            if (row != pictureBoxes.GetLength(0) - 1)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                row++;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Left()
        {
            if (col!=0)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                col--;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Up()
        {
            if (row!=0)
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
    }
}
