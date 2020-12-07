using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public partial class Level2 : Form
    {
        PictureBox[,] pictureBoxes = new PictureBox[8, 8];
        public Level2()
        {
            InitializeComponent();
            SetMasImage(pictureBoxes);
        }
        private void SetMasImage(PictureBox[,] pictureBoxes)
        {
            int i = pictureBoxes.GetLength(0)-1, j = pictureBoxes.GetLength(1)-1;
            List<PictureBox> list = new List<PictureBox>();
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {
                list.Add(item);
            }
            foreach (var item in list)
            {
                if (i < 0)
                {
                    break;
                }
                pictureBoxes[i, j] = item;
                if (j <= 0)
                {
                    j = pictureBoxes.GetLength(1) - 1;
                    i--;
                }
                else
                {
                    j--;
                }
            }

            for (i = 0; i < pictureBoxes.GetLength(0); i++)
            {
                for (j = 0; j < pictureBoxes.GetLength(1); j++)
                {
                    pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[i, j].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                }
            }
        }
    }
}
