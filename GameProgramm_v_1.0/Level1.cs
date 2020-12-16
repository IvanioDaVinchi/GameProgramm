﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public partial class Level1 : Form
    {
        Character character;
        PictureBox[,] pictureBoxes = new PictureBox[6, 6];
        Barrier[] barriersArray;
        Bonus bonus = new Bonus();
        Random random = new Random();
        Bot bot = new Bot();
        public Level1()
        {
            InitializeComponent();
            SetMasImage(pictureBoxes);
            SetAllPictures("пчел");
            SetAllPrep(pictureBoxes);
            character = new Character(pictureBoxes);
            bot.SetValues(pictureBoxes);
            timer1.Start();
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
            pictureBoxes[pictureBoxes.GetLength(0)-1, pictureBoxes.GetLength(1) - 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\exit.jpg");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
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
            if (character.row == pictureBoxes.GetLength(0)-1 && character.col == pictureBoxes.GetLength(1) - 1)
            {
                MessageBox.Show("Поздровляю вы прошли уровень!!!");
                Level2 level2 = new Level2();
                level2.Show();
                this.Hide();
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bot.Move(character.col, barriersArray);
            if (bot.col == character.col && bot.row == character.row)
            {
                character.Dead(bot);
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
    }
}
