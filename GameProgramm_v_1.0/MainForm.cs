using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if(Settings.ChoiceLevels == true)
            {
                Level1Button.Visible = true;
                Level2Button.Visible = true;
                Level3Button.Visible = true;
            }
            else
            {
                Level1Button.Visible = false;
                Level2Button.Visible = false;
                Level3Button.Visible = false;
            }
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Show();
            this.Hide();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            level1.Show();
            this.Hide();
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            level1.Show();
            this.Hide();
        }

        private void Level2Button_Click(object sender, EventArgs e)
        {
            Level2 level2 = new Level2();
            level2.Show();
            this.Hide();
        }

        private void Level3Button_Click(object sender, EventArgs e)
        {
            Level3 level3 = new Level3();
            level3.Show();
            this.Hide();
        }
    }
}
