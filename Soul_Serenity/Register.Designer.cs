namespace Soul_Serenity
{
    partial class Register
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
            pictureBox1 = new PictureBox();
            checkPassword = new CheckBox();
            btnRegister = new Button();
            labelLogin = new Label();
            label1 = new Label();
            label4 = new Label();
            textBoxEmail = new TextBox();
            label7 = new Label();
            label3 = new Label();
            textBoxUsername = new TextBox();
            label6 = new Label();
            label8 = new Label();
            textBoxKonfirmasi = new TextBox();
            textBoxPassword = new TextBox();
            textBoxRole = new TextBox();
            panel1 = new Panel();
            label2 = new Label();
            pictureProfile = new PictureBox();
            btnCariGambar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureProfile).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login_ilustrator;
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(580, 757);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 43;
            pictureBox1.TabStop = false;
            // 
            // checkPassword
            // 
            checkPassword.AutoSize = true;
            checkPassword.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkPassword.Location = new Point(1002, 619);
            checkPassword.Name = "checkPassword";
            checkPassword.Size = new Size(159, 30);
            checkPassword.TabIndex = 42;
            checkPassword.Text = "Check Password";
            checkPassword.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(79, 149, 208);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(648, 672);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(513, 56);
            btnRegister.TabIndex = 41;
            btnRegister.Text = "Masuk";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelLogin.ForeColor = Color.DeepSkyBlue;
            labelLogin.Location = new Point(210, 91);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(57, 30);
            labelLogin.TabIndex = 40;
            labelLogin.Text = "Login";
            labelLogin.Click += labelLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(648, 202);
            label1.Name = "label1";
            label1.Size = new Size(70, 36);
            label1.TabIndex = 38;
            label1.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 91);
            label4.Name = "label4";
            label4.Size = new Size(200, 30);
            label4.TabIndex = 37;
            label4.Text = "Sudah memiliki akun?";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.Location = new Point(648, 241);
            textBoxEmail.Multiline = true;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(513, 43);
            textBoxEmail.TabIndex = 35;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins SemiBold", 28F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(79, 149, 208);
            label7.Location = new Point(17, 16);
            label7.Name = "label7";
            label7.Size = new Size(345, 82);
            label7.TabIndex = 34;
            label7.Text = "Soul Serenity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(648, 306);
            label3.Name = "label3";
            label3.Size = new Size(118, 36);
            label3.TabIndex = 47;
            label3.Text = "Username";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUsername.Location = new Point(648, 345);
            textBoxUsername.Multiline = true;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(513, 43);
            textBoxUsername.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(648, 522);
            label6.Name = "label6";
            label6.Size = new Size(223, 36);
            label6.TabIndex = 51;
            label6.Text = "Konfirmasi Password";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(648, 413);
            label8.Name = "label8";
            label8.Size = new Size(111, 36);
            label8.TabIndex = 50;
            label8.Text = "Password";
            // 
            // textBoxKonfirmasi
            // 
            textBoxKonfirmasi.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxKonfirmasi.Location = new Point(648, 561);
            textBoxKonfirmasi.Multiline = true;
            textBoxKonfirmasi.Name = "textBoxKonfirmasi";
            textBoxKonfirmasi.Size = new Size(513, 43);
            textBoxKonfirmasi.TabIndex = 49;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(648, 452);
            textBoxPassword.Multiline = true;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(513, 43);
            textBoxPassword.TabIndex = 48;
            // 
            // textBoxRole
            // 
            textBoxRole.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxRole.Location = new Point(418, 47);
            textBoxRole.Multiline = true;
            textBoxRole.Name = "textBoxRole";
            textBoxRole.Size = new Size(62, 43);
            textBoxRole.TabIndex = 52;
            textBoxRole.Text = "user";
            textBoxRole.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBoxRole);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(labelLogin);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(523, 142);
            panel1.TabIndex = 53;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins SemiBold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(1033, 28);
            label2.Name = "label2";
            label2.Size = new Size(128, 65);
            label2.TabIndex = 34;
            label2.Text = "Login";
            // 
            // pictureProfile
            // 
            pictureProfile.Location = new Point(839, 48);
            pictureProfile.Name = "pictureProfile";
            pictureProfile.Size = new Size(125, 101);
            pictureProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureProfile.TabIndex = 54;
            pictureProfile.TabStop = false;
            // 
            // btnCariGambar
            // 
            btnCariGambar.FlatStyle = FlatStyle.Flat;
            btnCariGambar.Font = new Font("Poppins", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnCariGambar.Location = new Point(839, 149);
            btnCariGambar.Name = "btnCariGambar";
            btnCariGambar.Size = new Size(125, 35);
            btnCariGambar.TabIndex = 55;
            btnCariGambar.Text = "Pilih Gambar";
            btnCariGambar.UseVisualStyleBackColor = true;
            btnCariGambar.Click += btnCariGambar_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1224, 756);
            Controls.Add(btnCariGambar);
            Controls.Add(pictureProfile);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(textBoxKonfirmasi);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxUsername);
            Controls.Add(pictureBox1);
            Controls.Add(checkPassword);
            Controls.Add(btnRegister);
            Controls.Add(label1);
            Controls.Add(textBoxEmail);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox checkPassword;
        private Button btnRegister;
        private Label labelLogin;
        private Label label1;
        private Label label4;
        private TextBox textBoxEmail;
        private Label label7;
        private Label label3;
        private TextBox textBoxUsername;
        private Label label6;
        private Label label8;
        private TextBox textBoxKonfirmasi;
        private TextBox textBoxPassword;
        private TextBox textBoxRole;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureProfile;
        private Button btnCariGambar;
    }
}