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
    class Character
    {
        public int col=0;
        public int row=0;
        PictureBox[,] pictureBoxes;
        public string PathTexture { get; set; }

        public Character(PictureBox[,] pictureBoxes)
        {
            this.pictureBoxes = pictureBoxes;
            pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
        }

        public void Right()
        {

            if (row != pictureBoxes.GetLength(1)-1)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                row++;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Down()
        {
            if (col != pictureBoxes.GetLength(0) - 1)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                col++;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Left()
        {
            if (row!=0)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                row--;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }

        public void Up()
        {
            if (col!=0)
            {
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                col--;
                pictureBoxes[row, col].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\1.jpg");
            }
        }
    }
}
