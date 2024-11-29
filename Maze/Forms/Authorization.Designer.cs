namespace Maze
{
    partial class Authorization
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
            this.label1 = new System.Windows.Forms.Label();
            this.AInputLogin = new System.Windows.Forms.TextBox();
            this.AInputPassword = new System.Windows.Forms.TextBox();
            this.Entry = new System.Windows.Forms.Button();
            this.Reg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Montserrat ExtraBold", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(348, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // AInputLogin
            // 
            this.AInputLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AInputLogin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AInputLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AInputLogin.Location = new System.Drawing.Point(82, 76);
            this.AInputLogin.MaximumSize = new System.Drawing.Size(500, 90);
            this.AInputLogin.Multiline = true;
            this.AInputLogin.Name = "AInputLogin";
            this.AInputLogin.Size = new System.Drawing.Size(362, 36);
            this.AInputLogin.TabIndex = 1;
            // 
            // AInputPassword
            // 
            this.AInputPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AInputPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AInputPassword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AInputPassword.Location = new System.Drawing.Point(82, 160);
            this.AInputPassword.MaximumSize = new System.Drawing.Size(500, 90);
            this.AInputPassword.Multiline = true;
            this.AInputPassword.Name = "AInputPassword";
            this.AInputPassword.PasswordChar = '*';
            this.AInputPassword.Size = new System.Drawing.Size(362, 36);
            this.AInputPassword.TabIndex = 2;
            // 
            // Entry
            // 
            this.Entry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Entry.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Entry.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold);
            this.Entry.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Entry.Location = new System.Drawing.Point(118, 225);
            this.Entry.Name = "Entry";
            this.Entry.Size = new System.Drawing.Size(279, 58);
            this.Entry.TabIndex = 3;
            this.Entry.Text = "Войти";
            this.Entry.UseVisualStyleBackColor = false;
            this.Entry.Click += new System.EventHandler(this.Entry_Click);
            // 
            // Reg
            // 
            this.Reg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Reg.BackColor = System.Drawing.SystemColors.Window;
            this.Reg.Font = new System.Drawing.Font("Montserrat", 10.8F);
            this.Reg.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Reg.Location = new System.Drawing.Point(276, 502);
            this.Reg.Name = "Reg";
            this.Reg.Size = new System.Drawing.Size(529, 57);
            this.Reg.TabIndex = 4;
            this.Reg.Text = "Регистрация";
            this.Reg.UseVisualStyleBackColor = false;
            this.Reg.Click += new System.EventHandler(this.Reg_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Montserrat", 10.8F);
            this.label3.Location = new System.Drawing.Point(78, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Введите пароль:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(78, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Введите логин:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Entry);
            this.panel1.Controls.Add(this.AInputPassword);
            this.panel1.Controls.Add(this.AInputLogin);
            this.panel1.Location = new System.Drawing.Point(276, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 321);
            this.panel1.TabIndex = 9;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1104, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Reg);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Authorization";
            this.Text = "Авторизация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AInputLogin;
        private System.Windows.Forms.TextBox AInputPassword;
        private System.Windows.Forms.Button Entry;
        private System.Windows.Forms.Button Reg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}

