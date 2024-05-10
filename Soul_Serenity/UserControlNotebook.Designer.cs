namespace Soul_Serenity
{
    partial class UserControlNotebook
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
            labelTitle = new Label();
            labelJenis = new Guna.UI2.WinForms.Guna2Button();
            labelTanggal = new Label();
            labelDescription = new Label();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Poppins SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(22, 27);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(381, 119);
            labelTitle.TabIndex = 17;
            labelTitle.Text = "Judul Catatan";
            // 
            // labelJenis
            // 
            labelJenis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelJenis.CustomizableEdges = customizableEdges1;
            labelJenis.DisabledState.BorderColor = Color.DarkGray;
            labelJenis.DisabledState.CustomBorderColor = Color.DarkGray;
            labelJenis.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            labelJenis.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            labelJenis.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelJenis.ForeColor = Color.White;
            labelJenis.Location = new Point(304, 403);
            labelJenis.Name = "labelJenis";
            labelJenis.ShadowDecoration.CustomizableEdges = customizableEdges2;
            labelJenis.Size = new Size(99, 42);
            labelJenis.TabIndex = 20;
            labelJenis.Text = "Bagus";
            // 
            // labelTanggal
            // 
            labelTanggal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTanggal.AutoSize = true;
            labelTanggal.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTanggal.ForeColor = Color.White;
            labelTanggal.Location = new Point(22, 415);
            labelTanggal.Name = "labelTanggal";
            labelTanggal.Size = new Size(149, 30);
            labelTanggal.TabIndex = 21;
            labelTanggal.Text = "24 Januari 2024";
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelDescription.Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.ForeColor = Color.White;
            labelDescription.Location = new Point(22, 173);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(381, 150);
            labelDescription.TabIndex = 22;
            labelDescription.Text = "Aku kemarin baru saja menang juara 1\r\ndi sekolah ku, aku mendapat banyak\r\npujian saat memenangkan kejuaran itu,\r\naku sangat senang dan dapat banyak\r\npengalaman yang baik.\r\n";
            // 
            // UserControlNotebook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 35, 52);
            Controls.Add(labelDescription);
            Controls.Add(labelTanggal);
            Controls.Add(labelJenis);
            Controls.Add(labelTitle);
            Name = "UserControlNotebook";
            Size = new Size(430, 482);
            Load += UserControlNotebook_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Guna.UI2.WinForms.Guna2Button labelJenis;
        public Label labelTanggal;
        public Label labelDescription;
    }
}
