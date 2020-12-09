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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void PersonButton_Click(object sender, EventArgs e)
        {
            PersonPanel.Visible = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void PersonButton_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory(); 
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            Settings.PathCharacterTexture = filename;
        }

        private void BotButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            Settings.PathBotTexture = filename;
        }

        private void LifeButton_Click(object sender, EventArgs e)
        {
            if(LifeTextBox.Text != "")
            {
                Settings.CountLife = int.Parse(LifeTextBox.Text);
            }
        }

        private void TimeButton_Click(object sender, EventArgs e)
        {
            if (TimeTextBox1.Text != "" && TimeTextBox2.Text != "" && TimeTextBox3.Text != "")
            {
                Level1Class.Time = int.Parse(TimeTextBox1.Text);
                Level2Class.Time = int.Parse(TimeTextBox2.Text);
                Level3Class.Time = int.Parse(TimeTextBox3.Text);
            }
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (MapRadioButton1.Checked == true)
            {
                Level1Class.Map = filename;
            }
            if (MapRadioButton2.Checked == true)
            {
                Level2Class.Map = filename;
            }
            if(MapRadioButton3.Checked == true)
            {
                Level3Class.Map = filename;
            }
        }

        private void BotMoveButton_Click(object sender, EventArgs e)
        {
            if(MoveBotTextBox1.Text != "" && MoveBotTextBox2.Text != "" && MoveBotTextBox3.Text != "")
            {
                Level1Class.TimeBotMove = int.Parse(MoveBotTextBox1.Text);
                Level2Class.TimeBotMove = int.Parse(MoveBotTextBox2.Text);
                Level3Class.TimeBotMove = int.Parse(MoveBotTextBox3.Text);
            }
        }

        private void BombButton_Click(object sender, EventArgs e)
        {
            if(TimeBombTextBox.Text != "")
            {
                Bomb.TimeExplode = int.Parse(TimeBombTextBox.Text);
            }
        }

        private void LevelButton_Click(object sender, EventArgs e)
        {
            if (CanLevelTrueRadioButton.Checked == true)
            {
                Settings.ChoiceLevels = true;
            }
            if(CanLevelFalseRadioButton.Checked == true)
            {
                Settings.ChoiceLevels = false;
            }
        }
    }
}
