using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameProgramm_v_1._0
{
    public partial class Level1 : Form
    {
        PictureBox[,] pictureBoxes = new PictureBox[6, 6];
        public Level1()
        {
            InitializeComponent();
        }

        private void Level1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMasImage();
        }

        private void SetMasImage()
        {
            int i = 5, j = 5;
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
                    j = 5;
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
