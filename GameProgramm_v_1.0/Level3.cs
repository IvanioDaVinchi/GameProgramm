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
    public partial class Level3 : Form
    {
        Character character;
        PictureBox[,] pictureBoxes = new PictureBox[10, 10];
        Barrier[] barriersArray;
        Bonus bonus = new Bonus();
        Random random = new Random();

        public Level3()
        {
            InitializeComponent();
            SetMasImage(pictureBoxes);
            SetAllPictures("пчел");
            //SetAllPrep(pictureBoxes);
            character = new Character(pictureBoxes);
            Bot.SetValues(pictureBoxes);
            //timer1.Start();
        }
        private void SetAllPictures(string picName)
        {
            for (int i = 0; i < pictureBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < pictureBoxes.GetLength(1); j++)
                {
                    pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[i, j].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\{picName}.jpg");
                }
            }
        }

        private void SetMasImage(PictureBox[,] pictureBoxes)
        {
            int i = pictureBoxes.GetLength(0) - 1, j = pictureBoxes.GetLength(1) - 1;
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
        }
    }
}
