namespace Soul_Serenity
{
    partial class Login
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
            label7 = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            labelRegistrasi = new Label();
            btnLogin = new Button();
            checkPassword = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins SemiBold", 28F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(79, 149, 208);
            label7.Location = new Point(643, 82);
            label7.Name = "label7";
            label7.Size = new Size(345, 82);
            label7.TabIndex = 5;
            label7.Text = "Soul Serenity";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUsername.Location = new Point(643, 329);
            textBoxUsername.Multiline = true;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(513, 43);
            textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(643, 454);
            textBoxPassword.Multiline = true;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(513, 43);
            textBoxPassword.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(643, 164);
            label4.Name = "label4";
            label4.Size = new Size(200, 30);
            label4.TabIndex = 27;
            label4.Text = "Belum memiliki akun?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(643, 285);
            label1.Name = "label1";
            label1.Size = new Size(118, 36);
            label1.TabIndex = 28;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(643, 413);
            label2.Name = "label2";
            label2.Size = new Size(111, 36);
            label2.TabIndex = 29;
            label2.Text = "Password";
            // 
            // labelRegistrasi
            // 
            labelRegistrasi.AutoSize = true;
            labelRegistrasi.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelRegistrasi.ForeColor = Color.DeepSkyBlue;
            labelRegistrasi.Location = new Point(836, 164);
            labelRegistrasi.Name = "labelRegistrasi";
            labelRegistrasi.Size = new Size(94, 30);
            labelRegistrasi.TabIndex = 30;
            labelRegistrasi.Text = "Registrasi";
            labelRegistrasi.Click += labelRegistrasi_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(79, 149, 208);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(643, 572);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(513, 56);
            btnLogin.TabIndex = 31;
            btnLogin.Text = "Masuk";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // checkPassword
            // 
            checkPassword.AutoSize = true;
            checkPassword.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkPassword.Location = new Point(997, 503);
            checkPassword.Name = "checkPassword";
            checkPassword.Size = new Size(159, 30);
            checkPassword.TabIndex = 32;
            checkPassword.Text = "Check Password";
            checkPassword.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login_ilustrator;
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(580, 757);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 33;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1224, 756);
            Controls.Add(pictureBox1);
            Controls.Add(checkPassword);
            Controls.Add(btnLogin);
            Controls.Add(labelRegistrasi);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label labelRegistrasi;
        private Button btnLogin;
        private CheckBox checkPassword;
        private PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuTrackbar bunifuTrackbar1;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuRange bunifuRange1;
    }
}