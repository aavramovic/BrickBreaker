namespace BrickBreaker
{
    partial class LevelForm
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
            this.LevelPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LevelPanel
            // 
            this.LevelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LevelPanel.Location = new System.Drawing.Point(0, 0);
            this.LevelPanel.Name = "LevelPanel";
            this.LevelPanel.Size = new System.Drawing.Size(800, 450);
            this.LevelPanel.TabIndex = 0;
            this.LevelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelPanel_Paint);
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LevelPanel);
            this.DoubleBuffered = true;
            this.Name = "LevelForm";
            this.Text = "LevelForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LevelPanel;
    }
}