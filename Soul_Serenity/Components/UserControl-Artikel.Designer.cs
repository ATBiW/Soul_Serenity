namespace Soul_Serenity.Components
{
    partial class UserControl_Artikel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Artikel));
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.strech_post;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(762, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Poppins Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(16, 486);
            label7.Name = "label7";
            label7.Size = new Size(527, 80);
            label7.TabIndex = 34;
            label7.Text = "Lorem ipsum dolor sit amet, consectetur\r\nadipiscing elit, sed do eiusmod.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(16, 592);
            label5.Name = "label5";
            label5.Size = new Size(697, 180);
            label5.TabIndex = 36;
            label5.Text = resources.GetString("label5.Text");
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(79, 149, 208);
            button1.Location = new Point(16, 422);
            button1.Name = "button1";
            button1.Size = new Size(205, 46);
            button1.TabIndex = 37;
            button1.Text = "Stigma dan Kesadaran";
            button1.UseVisualStyleBackColor = true;
            // 
            // UserControl_Artikel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Name = "UserControl_Artikel";
            Size = new Size(759, 993);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label7;
        private Label label5;
        private Button button1;
    }
}
