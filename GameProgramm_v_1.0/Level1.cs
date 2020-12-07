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
        Character character;
        PictureBox[,] pictureBoxes = new PictureBox[6, 6];
        public Level1()
        {
            InitializeComponent();
            SetMasImage(pictureBoxes);
            SetAllPictures("пчел");
            character = new Character(pictureBoxes);
        }

        private void Level1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void SetAllPrep()
        {
            var barrirs = new Barrier();
            var barrirsArray = barrirs.GetBarrier_Level1();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.ToUpper(e.KeyChar)==(char)Keys.D)
            {
                character.Right();
            }
            else
            {
                if (char.ToUpper(e.KeyChar) == (char)Keys.A)
                {
                    character.Left();
                }
                else
                {
                    if (char.ToUpper(e.KeyChar) == (char)Keys.W)
                    {
                        character.Up();
                    }
                    else
                    {
                        if (char.ToUpper(e.KeyChar) == (char)Keys.S)
                        {
                            character.Down();
                        }
                    }
                }
            }
        }
    }
}
