namespace Soul_Serenity
{
    partial class UserControlPostingan
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            labelUserPost = new Label();
            profilePost = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            labelTimePost = new Label();
            labelDescriptionPost = new Label();
            pcitureBoxPost = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)profilePost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcitureBoxPost).BeginInit();
            SuspendLayout();
            // 
            // labelUserPost
            // 
            labelUserPost.AutoSize = true;
            labelUserPost.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelUserPost.ForeColor = Color.White;
            labelUserPost.Location = new Point(108, 32);
            labelUserPost.Name = "labelUserPost";
            labelUserPost.Size = new Size(213, 36);
            labelUserPost.TabIndex = 6;
            labelUserPost.Text = "Andreas Trihananto";
            // 
            // profilePost
            // 
            profilePost.FillColor = Color.Transparent;
            profilePost.ImageRotate = 0F;
            profilePost.Location = new Point(52, 36);
            profilePost.Name = "profilePost";
            profilePost.ShadowDecoration.CustomizableEdges = customizableEdges1;
            profilePost.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            profilePost.Size = new Size(50, 50);
            profilePost.SizeMode = PictureBoxSizeMode.Zoom;
            profilePost.TabIndex = 5;
            profilePost.TabStop = false;
            // 
            // labelTimePost
            // 
            labelTimePost.AutoSize = true;
            labelTimePost.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTimePost.ForeColor = Color.White;
            labelTimePost.Location = new Point(108, 66);
            labelTimePost.Name = "labelTimePost";
            labelTimePost.Size = new Size(116, 30);
            labelTimePost.TabIndex = 7;
            labelTimePost.Text = "4 Hours Ago";
            // 
            // labelDescriptionPost
            // 
            labelDescriptionPost.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescriptionPost.ForeColor = Color.White;
            labelDescriptionPost.Location = new Point(52, 132);
            labelDescriptionPost.Name = "labelDescriptionPost";
            labelDescriptionPost.Size = new Size(847, 87);
            labelDescriptionPost.TabIndex = 8;
            labelDescriptionPost.Text = "Ocean breaze bla bla bla aoakoak n asd";
            // 
            // pcitureBoxPost
            // 
            pcitureBoxPost.CustomizableEdges = customizableEdges2;
            pcitureBoxPost.FillColor = Color.Transparent;
            pcitureBoxPost.ImageRotate = 0F;
            pcitureBoxPost.Location = new Point(52, 240);
            pcitureBoxPost.Name = "pcitureBoxPost";
            pcitureBoxPost.ShadowDecoration.CustomizableEdges = customizableEdges3;
            pcitureBoxPost.Size = new Size(847, 332);
            pcitureBoxPost.SizeMode = PictureBoxSizeMode.Zoom;
            pcitureBoxPost.TabIndex = 9;
            pcitureBoxPost.TabStop = false;
            pcitureBoxPost.Click += pcitureBoxPost_Click;
            // 
            // UserControlPostingan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(58, 57, 74);
            Controls.Add(pcitureBoxPost);
            Controls.Add(labelDescriptionPost);
            Controls.Add(labelTimePost);
            Controls.Add(labelUserPost);
            Controls.Add(profilePost);
            Name = "UserControlPostingan";
            Size = new Size(949, 617);
            Load += UserControlPostingan_Load;
            ((System.ComponentModel.ISupportInitialize)profilePost).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcitureBoxPost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label labelUserPost;
        public Guna.UI2.WinForms.Guna2CirclePictureBox profilePost;
        public Label labelTimePost;
        public Label labelDescriptionPost;
        private Guna.UI2.WinForms.Guna2PictureBox pcitureBoxPost;
    }
}
