﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public partial class Level3 : Form
    {
        Character character;
        PictureBox[,] pictureBoxes = new PictureBox[10, 10];
        Barrier[] barriersArray;
        Bonus bonus = new Bonus();
        Random random = new Random();
        Bot Bot = new Bot();
        Bomb bomb;

        public Level3()
        {
            InitializeComponent();
            SetMasImage(pictureBoxes);
            SetAllPictures("пчел");
            SetAllPrep(pictureBoxes);
            character = new Character(pictureBoxes);
            Bot.SetValues(pictureBoxes);
            bomb = new Bomb(pictureBoxes);
            timer3.Interval = BombSetings.timeExplode * 1000;
            timer4.Interval = Level3Class.Time;
            timer4.Start();
            timer1.Start();
            timer3.Start();
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
            pictureBoxes[pictureBoxes.GetLength(0) - 1, pictureBoxes.GetLength(1) - 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\exit.jpg");
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
                character.Dead(Bot);
                if (character.life == 0)
                {
                    MessageBox.Show("Вы проиграли");
                    this.Close();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Stop();
        }

        private void RandBonus(PictureBox[,] pictureBoxes, Bot bot)
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

                    if (bonus.x == bot.row && bonus.y == bot.col)
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

                character.HoditRight(barriersArray, bonus, timer1, timer2, RandBonus, Bot);
            }
            else
            {
                if (char.ToUpper(e.KeyChar) == (char)Keys.A)
                {
                    character.HoditLeft(barriersArray, bonus, timer1, timer2, RandBonus, Bot);
                }
                else
                {
                    if (char.ToUpper(e.KeyChar) == (char)Keys.W)
                    {
                        character.HoditUp(barriersArray, bonus, timer1, timer2, RandBonus, Bot);
                    }
                    else
                    {
                        if (char.ToUpper(e.KeyChar) == (char)Keys.S)
                        {

                            character.HoditDown(barriersArray, bonus, timer1, timer2, RandBonus, Bot);
                        }
                    }
                }
            }
            if (character.row == pictureBoxes.GetLength(0) - 1 && character.col == pictureBoxes.GetLength(1) - 1)
            {
                MessageBox.Show("Поздровляю вы прошли игру!!!");
                MainForm form = new MainForm();
                form.Show();
                this.Close();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!bomb.Exist())
            {
                bomb.Clear();
                SetAllPrep(pictureBoxes);
                pictureBoxes[bonus.x, bonus.y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bonus.jpg");
                bomb.RandomPlace(barriersArray, Bot);
            }
            else
            {
                timer4.Start();
                timer3.Stop();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            bomb.Explosion(character, Bot);
            timer4.Stop();
            timer3.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Время вышло, игра окончена");
            MainForm form = new MainForm();
            form.Show();
            this.Close();
        }
    }
}
