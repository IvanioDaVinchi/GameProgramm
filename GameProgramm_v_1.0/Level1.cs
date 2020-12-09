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
        Barrier[] barriersArray;
        int counter = 0;
        Random random;
        public Level1()
        {
            InitializeComponent();
            SetMasImage(pictureBoxes);
            SetAllPictures("пчел");
            SetAllPrep(pictureBoxes);
            character = new Character(pictureBoxes);
            Bot.SetValues(pictureBoxes);
            timer1.Start();
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
            pictureBoxes[5, 5].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\exit.jpg");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
       
        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool hodit = true;
            
            if (char.ToUpper(e.KeyChar) == (char)Keys.D)
            {
                foreach (var item in barriersArray)
                {
                    if (character.row == item.X && character.col + 1 == item.Y)
                    {
                        hodit = false;
                    }
                }
                if (hodit == true)
                {
                    character.Right();
                }
            }
            else
            {
                if (char.ToUpper(e.KeyChar) == (char)Keys.A)
                {
                    foreach (var item in barriersArray)
                    {
                        if (character.col - 1 == item.Y && character.row==item.X)
                        {
                            hodit = false;
                        }
                    }
                    if (hodit == true)
                    {
                        character.Left();
                    }
                }
                else
                {
                    if (char.ToUpper(e.KeyChar) == (char)Keys.W)
                    {
                        foreach (var item in barriersArray)
                        {
                            if (character.row - 1 == item.X && character.col==item.Y)
                            {
                                hodit = false;
                            }
                        }
                        if (hodit == true)
                        {
                            character.Up();
                        }
                    }
                    else
                    {
                        if (char.ToUpper(e.KeyChar) == (char)Keys.S)
                        {

                            foreach (var item in barriersArray)
                            {
                                if (character.row + 1 == item.X && character.col==item.Y)
                                {
                                    hodit = false;
                                }
                            }
                            if (hodit == true)
                            {
                                character.Down();
                            }
                        }
                        
                    }
                    
                }
            }
            if (character.row == 5 && character.col == 5)
            {
                MessageBox.Show("Поздровляю вы прошли уровень!!!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bot.Move(character.col,barriersArray);
            if (Bot.col == character.col && Bot.row == character.row)
            {
                character.Dead();
                if (character.life==0)
                {
                    MessageBox.Show("Вы проиграли");
                    this.Close();
                }
            }
        }
    }
}
