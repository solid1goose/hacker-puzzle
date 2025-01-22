namespace testWinForms
{
    partial class HackForm
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
            panelLabel = new Label();
            SuspendLayout();
            // 
            // panelLabel
            // 
            panelLabel.AutoSize = true;
            panelLabel.Font = new Font("Constantia", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            panelLabel.Location = new Point(27, 29);
            panelLabel.Name = "panelLabel";
            panelLabel.Size = new Size(0, 45);
            panelLabel.TabIndex = 0;
            // 
            // HackForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(212, 137);
            Controls.Add(panelLabel);
            Name = "HackForm";
            Text = "panel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label panelLabel;
    }
}