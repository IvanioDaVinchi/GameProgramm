using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public class Bomb
    {
        int x=0;
        int y=0;
        int timer = 3;
        string path;
        bool exist;
        PictureBox[,] pictureBoxes;
        Random random = new Random();

        public Bomb(PictureBox[,] pictureBoxes)
        {
            this.pictureBoxes = pictureBoxes;
        }

        public Bomb()
        {
        }


        public void RandomPlace(Barrier[] barriersArray,Bot bot)
        {
            Clear();
            bool proxod = false;
            int counter = 0;

            while (proxod == false)
            {
                x = random.Next(0, pictureBoxes.GetLength(0) - 1);
                y = random.Next(0, pictureBoxes.GetLength(1) - 1);

                foreach (var item in barriersArray)
                {
                    if (x == item.X && y == item.Y)
                    {
                        counter++;
                    }
                }

                if (x == bot.row && y == bot.col)
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

            pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\bomb.jpg");
            exist = true;
        }

        public bool Exist()
        {
            return exist ? true : false;
        }

        public void Explosion(Character character,Bot Bot)
        {
            exist = false;
            if (x - 1 > 0 && y - 1 > 0)
            {
                pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                pictureBoxes[x - 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                pictureBoxes[x, y - 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                if (character.row==x && character.col==y || character.row == x-1 && character.col == y || character.row == x+1 && character.col == y || character.row == x && character.col == y-1 || character.row == x && character.col == y+1)
                {
                    character.life--;
                    character.Dead(Bot);
                }
            }
            else
            {
                if (x - 1 < 0 && y - 1 < 0)
                {
                    pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                    pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                    pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                    if (character.row == x && character.col == y || character.row == x + 1 && character.col == y || character.row == x && character.col == y+1)
                    {
                        character.life--;
                        character.Dead(Bot);
                    }
                }
                else
                {
                    if (x - 1 < 0)
                    {
                        pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                        pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                        pictureBoxes[x, y - 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                        pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                        if (character.row == x && character.col == y || character.row == x + 1 && character.col == y || character.row == x && character.col == y - 1 || character.row == x && character.col == y + 1)
                        {
                            character.life--;
                            character.Dead(Bot);
                        }
                    }
                    else
                    {
                        if (y - 1 < 0)
                        {
                            pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                            pictureBoxes[x - 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                            pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                            pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\explosion.jpg");
                            if (character.row == x && character.col == y || character.row == x + 1 && character.col == y || character.row == x-1 && character.col == y || character.row == x && character.col == y + 1)
                            {
                                character.life--;
                                character.Dead(Bot);
                            }
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            if (x - 1 > 0 && y - 1 > 0)
            {
                pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                pictureBoxes[x - 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                pictureBoxes[x, y - 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
            }
            else
            {
                if (x - 1 < 0 && y - 1 < 0)
                {
                    pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                    pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                    pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                }
                else
                {
                    if (x - 1 < 0)
                    {
                        pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                        pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                        pictureBoxes[x, y - 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                        pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                    }
                    else
                    {
                        if (y - 1 < 0)
                        {
                            pictureBoxes[x, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                            pictureBoxes[x - 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                            pictureBoxes[x + 1, y].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                            pictureBoxes[x, y + 1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Kartinki\\пчел.jpg");
                        }
                    }
                }
            }
        }
    }
}
