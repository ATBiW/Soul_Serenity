namespace Soul_Serenity
{
    partial class UserControlChat2
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
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labelChat2 = new Label();
            panel1 = new Panel();
            pictureBoxProfileChat = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2Panel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfileChat).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.White;
            guna2Panel1.BorderRadius = 100;
            guna2Panel1.Controls.Add(flowLayoutPanel1);
            guna2Panel1.Controls.Add(labelChat2);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Right;
            guna2Panel1.Location = new Point(72, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(519, 75);
            guna2Panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(38, 16);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(8, 8);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // labelChat2
            // 
            labelChat2.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelChat2.ForeColor = Color.Black;
            labelChat2.Location = new Point(3, 22);
            labelChat2.Name = "labelChat2";
            labelChat2.Size = new Size(494, 28);
            labelChat2.TabIndex = 5;
            labelChat2.Text = "Dashboard";
            labelChat2.Click += labelChat2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBoxProfileChat);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(66, 75);
            panel1.TabIndex = 6;
            // 
            // pictureBoxProfileChat
            // 
            pictureBoxProfileChat.FillColor = Color.LightSeaGreen;
            pictureBoxProfileChat.ImageRotate = 0F;
            pictureBoxProfileChat.Location = new Point(7, 12);
            pictureBoxProfileChat.Name = "pictureBoxProfileChat";
            pictureBoxProfileChat.ShadowDecoration.CustomizableEdges = customizableEdges3;
            pictureBoxProfileChat.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            pictureBoxProfileChat.Size = new Size(50, 50);
            pictureBoxProfileChat.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfileChat.TabIndex = 3;
            pictureBoxProfileChat.TabStop = false;
            // 
            // UserControlChat2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(guna2Panel1);
            Name = "UserControlChat2";
            Size = new Size(591, 75);
            Load += UserControlChat2_Load;
            guna2Panel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfileChat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Label labelChat2;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureBoxProfileChat;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
