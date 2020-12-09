namespace GameProgramm_v_1._0
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.Level1Button = new System.Windows.Forms.Button();
            this.Level2Button = new System.Windows.Forms.Button();
            this.Level3Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingButton
            // 
            this.SettingButton.BackColor = System.Drawing.Color.MediumPurple;
            this.SettingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SettingButton.Location = new System.Drawing.Point(12, 12);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(101, 30);
            this.SettingButton.TabIndex = 0;
            this.SettingButton.Text = "Настройки";
            this.SettingButton.UseVisualStyleBackColor = false;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.MediumPurple;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayButton.Location = new System.Drawing.Point(495, 12);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(218, 30);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Играть";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Level1Button
            // 
            this.Level1Button.BackColor = System.Drawing.Color.MediumPurple;
            this.Level1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Level1Button.Location = new System.Drawing.Point(495, 112);
            this.Level1Button.Name = "Level1Button";
            this.Level1Button.Size = new System.Drawing.Size(218, 30);
            this.Level1Button.TabIndex = 2;
            this.Level1Button.Text = "Уровень 1";
            this.Level1Button.UseVisualStyleBackColor = false;
            this.Level1Button.Click += new System.EventHandler(this.Level1Button_Click);
            // 
            // Level2Button
            // 
            this.Level2Button.BackColor = System.Drawing.Color.MediumPurple;
            this.Level2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Level2Button.Location = new System.Drawing.Point(495, 187);
            this.Level2Button.Name = "Level2Button";
            this.Level2Button.Size = new System.Drawing.Size(218, 30);
            this.Level2Button.TabIndex = 3;
            this.Level2Button.Text = "Уровень 2";
            this.Level2Button.UseVisualStyleBackColor = false;
            this.Level2Button.Click += new System.EventHandler(this.Level2Button_Click);
            // 
            // Level3Button
            // 
            this.Level3Button.BackColor = System.Drawing.Color.MediumPurple;
            this.Level3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Level3Button.Location = new System.Drawing.Point(495, 269);
            this.Level3Button.Name = "Level3Button";
            this.Level3Button.Size = new System.Drawing.Size(218, 30);
            this.Level3Button.TabIndex = 4;
            this.Level3Button.Text = "Уровень 3";
            this.Level3Button.UseVisualStyleBackColor = false;
            this.Level3Button.Click += new System.EventHandler(this.Level3Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.Level3Button);
            this.Controls.Add(this.Level2Button);
            this.Controls.Add(this.Level1Button);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.SettingButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button Level1Button;
        private System.Windows.Forms.Button Level2Button;
        private System.Windows.Forms.Button Level3Button;
    }
}

