namespace Maze
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdminAboutUs = new System.Windows.Forms.Button();
            this.AdminAboutSys = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.createPattern = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveToFile = new System.Windows.Forms.Button();
            this.Generate = new System.Windows.Forms.Button();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightUpDown = new System.Windows.Forms.NumericUpDown();
            this.pictureMaze = new System.Windows.Forms.PictureBox();
            this.radioButtonAldousBroder = new System.Windows.Forms.RadioButton();
            this.radioButtonEuler = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.settingMazePanel = new System.Windows.Forms.Panel();
            this.buttonTheme4 = new System.Windows.Forms.Button();
            this.buttonTheme3 = new System.Windows.Forms.Button();
            this.buttonTheme2 = new System.Windows.Forms.Button();
            this.buttonTheme1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nonhanded = new System.Windows.Forms.Button();
            this.handed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMaze)).BeginInit();
            this.settingMazePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminAboutUs
            // 
            this.AdminAboutUs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdminAboutUs.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.AdminAboutUs.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdminAboutUs.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.AdminAboutUs.Location = new System.Drawing.Point(22, 0);
            this.AdminAboutUs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdminAboutUs.Name = "AdminAboutUs";
            this.AdminAboutUs.Size = new System.Drawing.Size(260, 41);
            this.AdminAboutUs.TabIndex = 5;
            this.AdminAboutUs.Text = "О разработчиках";
            this.AdminAboutUs.UseVisualStyleBackColor = false;
            this.AdminAboutUs.Click += new System.EventHandler(this.AdminAboutUs_Click);
            // 
            // AdminAboutSys
            // 
            this.AdminAboutSys.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdminAboutSys.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.AdminAboutSys.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdminAboutSys.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.AdminAboutSys.Location = new System.Drawing.Point(277, 0);
            this.AdminAboutSys.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdminAboutSys.Name = "AdminAboutSys";
            this.AdminAboutSys.Size = new System.Drawing.Size(272, 41);
            this.AdminAboutSys.TabIndex = 6;
            this.AdminAboutSys.Text = "О системе";
            this.AdminAboutSys.UseVisualStyleBackColor = false;
            this.AdminAboutSys.Click += new System.EventHandler(this.AdminAboutSys_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Настройка параметров лабиринта: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // createPattern
            // 
            this.createPattern.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createPattern.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.createPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.createPattern.ForeColor = System.Drawing.SystemColors.InfoText;
            this.createPattern.Location = new System.Drawing.Point(465, 108);
            this.createPattern.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createPattern.Name = "createPattern";
            this.createPattern.Size = new System.Drawing.Size(84, 65);
            this.createPattern.TabIndex = 8;
            this.createPattern.Text = "ОК";
            this.createPattern.UseVisualStyleBackColor = false;
            this.createPattern.Click += new System.EventHandler(this.createPattern_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(22, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ширина лабиринта:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(22, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Высота лабиринта:";
            // 
            // saveToFile
            // 
            this.saveToFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveToFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.saveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.saveToFile.ForeColor = System.Drawing.SystemColors.InfoText;
            this.saveToFile.Location = new System.Drawing.Point(695, 551);
            this.saveToFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(345, 42);
            this.saveToFile.TabIndex = 22;
            this.saveToFile.Text = "Сохранить ";
            this.saveToFile.UseVisualStyleBackColor = false;
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // Generate
            // 
            this.Generate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Generate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.Generate.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Generate.Location = new System.Drawing.Point(695, 505);
            this.Generate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(345, 42);
            this.Generate.TabIndex = 24;
            this.Generate.Text = "Сгенерировать";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Visible = false;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // widthUpDown
            // 
            this.widthUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.widthUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.widthUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.widthUpDown.Location = new System.Drawing.Point(244, 147);
            this.widthUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.widthUpDown.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.widthUpDown.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(189, 26);
            this.widthUpDown.TabIndex = 25;
            this.widthUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // heightUpDown
            // 
            this.heightUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heightUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heightUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.heightUpDown.Location = new System.Drawing.Point(244, 109);
            this.heightUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.heightUpDown.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.heightUpDown.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.heightUpDown.Name = "heightUpDown";
            this.heightUpDown.Size = new System.Drawing.Size(189, 26);
            this.heightUpDown.TabIndex = 26;
            this.heightUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // pictureMaze
            // 
            this.pictureMaze.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureMaze.BackColor = System.Drawing.SystemColors.Control;
            this.pictureMaze.Location = new System.Drawing.Point(596, 11);
            this.pictureMaze.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureMaze.Name = "pictureMaze";
            this.pictureMaze.Size = new System.Drawing.Size(489, 490);
            this.pictureMaze.TabIndex = 27;
            this.pictureMaze.TabStop = false;
            this.pictureMaze.Click += new System.EventHandler(this.pictureMaze_Click);
            // 
            // radioButtonAldousBroder
            // 
            this.radioButtonAldousBroder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonAldousBroder.AutoSize = true;
            this.radioButtonAldousBroder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonAldousBroder.Location = new System.Drawing.Point(13, 249);
            this.radioButtonAldousBroder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonAldousBroder.Name = "radioButtonAldousBroder";
            this.radioButtonAldousBroder.Size = new System.Drawing.Size(288, 29);
            this.radioButtonAldousBroder.TabIndex = 30;
            this.radioButtonAldousBroder.Text = "Алгоритм Олдоса-Бродера";
            this.radioButtonAldousBroder.UseVisualStyleBackColor = true;
            // 
            // radioButtonEuler
            // 
            this.radioButtonEuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonEuler.AutoSize = true;
            this.radioButtonEuler.Checked = true;
            this.radioButtonEuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonEuler.Location = new System.Drawing.Point(13, 216);
            this.radioButtonEuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonEuler.Name = "radioButtonEuler";
            this.radioButtonEuler.Size = new System.Drawing.Size(202, 29);
            this.radioButtonEuler.TabIndex = 30;
            this.radioButtonEuler.TabStop = true;
            this.radioButtonEuler.Text = "Алгоритм Эйлера";
            this.radioButtonEuler.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(527, 46);
            this.label4.TabIndex = 30;
            this.label4.Text = "Способ расстановки входа и выхода:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(527, 46);
            this.label6.TabIndex = 31;
            this.label6.Text = "Алгоритм генерации лабиринта:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settingMazePanel
            // 
            this.settingMazePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.settingMazePanel.Controls.Add(this.buttonTheme4);
            this.settingMazePanel.Controls.Add(this.buttonTheme3);
            this.settingMazePanel.Controls.Add(this.buttonTheme2);
            this.settingMazePanel.Controls.Add(this.buttonTheme1);
            this.settingMazePanel.Controls.Add(this.label5);
            this.settingMazePanel.Controls.Add(this.nonhanded);
            this.settingMazePanel.Controls.Add(this.handed);
            this.settingMazePanel.Controls.Add(this.radioButtonAldousBroder);
            this.settingMazePanel.Controls.Add(this.label6);
            this.settingMazePanel.Controls.Add(this.radioButtonEuler);
            this.settingMazePanel.Controls.Add(this.label4);
            this.settingMazePanel.Location = new System.Drawing.Point(22, 188);
            this.settingMazePanel.Name = "settingMazePanel";
            this.settingMazePanel.Size = new System.Drawing.Size(542, 405);
            this.settingMazePanel.TabIndex = 32;
            this.settingMazePanel.Visible = false;
            // 
            // buttonTheme4
            // 
            this.buttonTheme4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTheme4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTheme4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonTheme4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buttonTheme4.Location = new System.Drawing.Point(412, 345);
            this.buttonTheme4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTheme4.Name = "buttonTheme4";
            this.buttonTheme4.Size = new System.Drawing.Size(112, 42);
            this.buttonTheme4.TabIndex = 39;
            this.buttonTheme4.Text = "Тема1";
            this.buttonTheme4.UseVisualStyleBackColor = false;
            // 
            // buttonTheme3
            // 
            this.buttonTheme3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTheme3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTheme3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonTheme3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buttonTheme3.Location = new System.Drawing.Point(279, 345);
            this.buttonTheme3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTheme3.Name = "buttonTheme3";
            this.buttonTheme3.Size = new System.Drawing.Size(112, 42);
            this.buttonTheme3.TabIndex = 38;
            this.buttonTheme3.Text = "Тема1";
            this.buttonTheme3.UseVisualStyleBackColor = false;
            // 
            // buttonTheme2
            // 
            this.buttonTheme2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTheme2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTheme2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonTheme2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buttonTheme2.Location = new System.Drawing.Point(148, 345);
            this.buttonTheme2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTheme2.Name = "buttonTheme2";
            this.buttonTheme2.Size = new System.Drawing.Size(112, 42);
            this.buttonTheme2.TabIndex = 37;
            this.buttonTheme2.Text = "Тема1";
            this.buttonTheme2.UseVisualStyleBackColor = false;
            // 
            // buttonTheme1
            // 
            this.buttonTheme1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTheme1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTheme1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonTheme1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buttonTheme1.Location = new System.Drawing.Point(18, 345);
            this.buttonTheme1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTheme1.Name = "buttonTheme1";
            this.buttonTheme1.Size = new System.Drawing.Size(112, 42);
            this.buttonTheme1.TabIndex = 36;
            this.buttonTheme1.Text = "Тема1";
            this.buttonTheme1.UseVisualStyleBackColor = false;
            this.buttonTheme1.Click += new System.EventHandler(this.buttonTheme1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(527, 46);
            this.label5.TabIndex = 35;
            this.label5.Text = "Темы лабиринта:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nonhanded
            // 
            this.nonhanded.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nonhanded.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nonhanded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nonhanded.ForeColor = System.Drawing.SystemColors.MenuText;
            this.nonhanded.Location = new System.Drawing.Point(18, 103);
            this.nonhanded.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nonhanded.Name = "nonhanded";
            this.nonhanded.Size = new System.Drawing.Size(509, 42);
            this.nonhanded.TabIndex = 34;
            this.nonhanded.Text = "Автоматический";
            this.nonhanded.UseVisualStyleBackColor = false;
            this.nonhanded.Click += new System.EventHandler(this.nonhanded_Click);
            // 
            // handed
            // 
            this.handed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.handed.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.handed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.handed.ForeColor = System.Drawing.SystemColors.MenuText;
            this.handed.Location = new System.Drawing.Point(18, 48);
            this.handed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.handed.Name = "handed";
            this.handed.Size = new System.Drawing.Size(509, 42);
            this.handed.TabIndex = 33;
            this.handed.Text = "Ручной";
            this.handed.UseVisualStyleBackColor = false;
            this.handed.Click += new System.EventHandler(this.handed_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1108, 633);
            this.Controls.Add(this.settingMazePanel);
            this.Controls.Add(this.pictureMaze);
            this.Controls.Add(this.heightUpDown);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.saveToFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.createPattern);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdminAboutSys);
            this.Controls.Add(this.AdminAboutUs);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMaze)).EndInit();
            this.settingMazePanel.ResumeLayout(false);
            this.settingMazePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AdminAboutUs;
        private System.Windows.Forms.Button AdminAboutSys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveToFile;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.NumericUpDown heightUpDown;
        private System.Windows.Forms.PictureBox pictureMaze;
        private System.Windows.Forms.RadioButton radioButtonAldousBroder;
        private System.Windows.Forms.RadioButton radioButtonEuler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel settingMazePanel;
        private System.Windows.Forms.Button handed;
        private System.Windows.Forms.Button nonhanded;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTheme4;
        private System.Windows.Forms.Button buttonTheme3;
        private System.Windows.Forms.Button buttonTheme2;
        private System.Windows.Forms.Button buttonTheme1;
    }
}