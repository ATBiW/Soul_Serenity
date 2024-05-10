namespace Soul_Serenity
{
    partial class ToastForms
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToastForms));
            lblType = new Label();
            lblMessage = new Label();
            toastTimer = new System.Windows.Forms.Timer(components);
            toastHide = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblType.ForeColor = Color.White;
            lblType.Location = new Point(47, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(127, 26);
            lblType.TabIndex = 0;
            lblType.Text = "Daily Reminder";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(47, 25);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(176, 26);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Jangan Lupa Istirahat";
            // 
            // toastTimer
            // 
            toastTimer.Enabled = true;
            toastTimer.Interval = 10;
            toastTimer.Tick += toastTimer_Tick;
            // 
            // toastHide
            // 
            toastHide.Interval = 10;
            toastHide.Tick += toastHide_Tick;
            // 
            // ToastForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(406, 60);
            Controls.Add(lblMessage);
            Controls.Add(lblType);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToastForms";
            Text = "ToastForms";
            Load += ToastForms_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblType;
        private Label lblMessage;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Timer toastHide;
    }
}