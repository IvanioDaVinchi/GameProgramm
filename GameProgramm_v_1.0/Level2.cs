﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProgramm_v_1._0
{
    public partial class Level2 : Form
    {
        public Level2()
        {
            InitializeComponent();
            
        }
        private void FillPictureArray()
        {
            int i = 5, j = 5;
            PictureBox[,] pictureArray = new PictureBox[8,8];
            foreach (PictureBox item in Controls.OfType<PictureBox>())
            {

            }
        }
    }
}
