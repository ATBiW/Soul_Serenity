namespace Soul_Serenity
{
    partial class TraphyForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gradientPanel1 = new GradientPanel();
            gradientPanel2 = new GradientPanel();
            lblNafas = new Label();
            btnMulai = new Guna.UI2.WinForms.Guna2Button();
            lblTimer = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label27 = new Label();
            label7 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            gradientPanel1.SuspendLayout();
            gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // gradientPanel1
            // 
            gradientPanel1.ColorBottom = Color.FromArgb(29, 27, 39);
            gradientPanel1.ColorTop = Color.FromArgb(25, 24, 52);
            gradientPanel1.Controls.Add(gradientPanel2);
            gradientPanel1.Controls.Add(pictureBox1);
            gradientPanel1.Controls.Add(label1);
            gradientPanel1.Controls.Add(label27);
            gradientPanel1.Controls.Add(label7);
            gradientPanel1.Controls.Add(guna2Button1);
            gradientPanel1.Dock = DockStyle.Fill;
            gradientPanel1.Location = new Point(0, 0);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(1924, 1055);
            gradientPanel1.TabIndex = 0;
            // 
            // gradientPanel2
            // 
            gradientPanel2.ColorBottom = Color.FromArgb(29, 27, 39);
            gradientPanel2.ColorTop = Color.FromArgb(25, 24, 52);
            gradientPanel2.Controls.Add(lblNafas);
            gradientPanel2.Controls.Add(btnMulai);
            gradientPanel2.Controls.Add(lblTimer);
            gradientPanel2.Controls.Add(pictureBox2);
            gradientPanel2.Controls.Add(label2);
            gradientPanel2.Controls.Add(label3);
            gradientPanel2.Controls.Add(label4);
            gradientPanel2.Dock = DockStyle.Fill;
            gradientPanel2.Location = new Point(0, 0);
            gradientPanel2.Name = "gradientPanel2";
            gradientPanel2.Size = new Size(1924, 1055);
            gradientPanel2.TabIndex = 24;
            gradientPanel2.Paint += gradientPanel2_Paint;
            // 
            // lblNafas
            // 
            lblNafas.AutoSize = true;
            lblNafas.BackColor = Color.Transparent;
            lblNafas.Font = new Font("Poppins", 30F, FontStyle.Bold, GraphicsUnit.Point);
            lblNafas.ForeColor = Color.White;
            lblNafas.Location = new Point(69, 372);
            lblNafas.Name = "lblNafas";
            lblNafas.Size = new Size(685, 88);
            lblNafas.TabIndex = 25;
            lblNafas.Text = "Tarik nafas pelan - pelan";
            lblNafas.Visible = false;
            // 
            // btnMulai
            // 
            btnMulai.BackColor = Color.Transparent;
            btnMulai.BorderRadius = 8;
            btnMulai.CustomizableEdges = customizableEdges1;
            btnMulai.DisabledState.BorderColor = Color.DarkGray;
            btnMulai.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMulai.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMulai.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMulai.FillColor = Color.FromArgb(51, 138, 202);
            btnMulai.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnMulai.ForeColor = Color.White;
            btnMulai.Location = new Point(795, 931);
            btnMulai.Name = "btnMulai";
            btnMulai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnMulai.Size = new Size(334, 68);
            btnMulai.TabIndex = 0;
            btnMulai.Text = "Ayo Mulai";
            btnMulai.Click += btnMulai_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.Transparent;
            lblTimer.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimer.ForeColor = SystemColors.ControlLight;
            lblTimer.Location = new Point(914, 946);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(101, 36);
            lblTimer.TabIndex = 24;
            lblTimer.Text = "00:00:00";
            lblTimer.Click += lblTimer_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.black_tree;
            pictureBox2.Location = new Point(1412, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(559, 554);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(904, 200);
            label2.Name = "label2";
            label2.Size = new Size(106, 30);
            label2.TabIndex = 22;
            label2.Text = "3 min relax";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(846, 164);
            label3.Name = "label3";
            label3.Size = new Size(229, 30);
            label3.TabIndex = 21;
            label3.Text = "Relax and Breathe deeply";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Poppins SemiBold", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(848, 97);
            label4.Name = "label4";
            label4.Size = new Size(224, 78);
            label4.TabIndex = 16;
            label4.Text = "Sadness";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.black_tree;
            pictureBox1.Location = new Point(1412, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(559, 554);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(904, 200);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 22;
            label1.Text = "3 min relax";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = Color.Transparent;
            label27.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label27.ForeColor = SystemColors.ControlLight;
            label27.Location = new Point(846, 164);
            label27.Name = "label27";
            label27.Size = new Size(229, 30);
            label27.TabIndex = 21;
            label27.Text = "Relax and Breathe deeply";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Poppins SemiBold", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(848, 97);
            label7.Name = "label7";
            label7.Size = new Size(224, 78);
            label7.TabIndex = 16;
            label7.Text = "Sadness";
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 8;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(51, 138, 202);
            guna2Button1.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(795, 931);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(334, 68);
            guna2Button1.TabIndex = 0;
            guna2Button1.Text = "Ayo Mulai";
            // 
            // TraphyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(gradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TraphyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TraphyForm";
            WindowState = FormWindowState.Maximized;
            FormClosing += TraphyForm_FormClosing;
            FormClosed += TraphyForm_FormClosed;
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            gradientPanel2.ResumeLayout(false);
            gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GradientPanel gradientPanel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label7;
        private Label label1;
        private Label label27;
        private GradientPanel gradientPanel2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private Label lblTimer;
        private Guna.UI2.WinForms.Guna2Button btnMulai;
        private Label lblNafas;
    }
}