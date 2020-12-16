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

        private void SetAllPrep(PictureBox[,] pictureBox)
        {
            var barrirs = new Barrier();
            barriersArray = barrirs.GetBarrier_Level1();
            foreach (var item in barriersArray)
            {
                pictureBox[item.X, item.Y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bar.jpg");
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
                pictureBoxes[j, i] = item;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bot.Move(character.col, barriersArray);
            if (Bot.col == character.col && Bot.row == character.row)
            {
                character.Dead();
                if (character.life == 0)
                {
                    MessageBox.Show("Вы проиграли");
                    this.Close();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Stop();
        }

        private void RandBonus(PictureBox[,] pictureBoxes)
        {
            if (bonus.exist == false)
            {
                bool proxod = false;
                int counter = 0;

                while (proxod == false)
                {
                    bonus.x = random.Next(0, pictureBoxes.GetLength(0) - 1);
                    bonus.y = random.Next(0, pictureBoxes.GetLength(1) - 1);

                    foreach (var item in barriersArray)
                    {
                        if (bonus.x == item.X && bonus.y == item.Y)
                        {
                            counter++;
                        }
                    }

                    if (bonus.x == Bot.row && bonus.y == Bot.col)
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

                pictureBoxes[bonus.x, bonus.y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bonus.jpg");
                bonus.exist = true;
            }
        }

        private void Level3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.ToUpper(e.KeyChar) == (char)Keys.D)
            {

                character.HoditRight(barriersArray, bonus, timer1, timer2, RandBonus);
            }
            else
            {
                if (char.ToUpper(e.KeyChar) == (char)Keys.A)
                {
                    character.HoditLeft(barriersArray, bonus, timer1, timer2, RandBonus);
                }
                else
                {
                    if (char.ToUpper(e.KeyChar) == (char)Keys.W)
                    {
                        character.HoditUp(barriersArray, bonus, timer1, timer2, RandBonus);
                    }
                    else
                    {
                        if (char.ToUpper(e.KeyChar) == (char)Keys.S)
                        {

                            character.HoditDown(barriersArray, bonus, timer1, timer2, RandBonus);
                        }
                    }

                }
            }
            if (character.row == 5 && character.col == 5)
            {
                MessageBox.Show("Поздровляю вы прошли уровень!!!");
            }
        }
    }
}
