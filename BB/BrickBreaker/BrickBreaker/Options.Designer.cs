namespace BrickBreaker
{
    partial class Options
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.difficultyGroupBox = new System.Windows.Forms.GroupBox();
            this.rookieRadioButton = new System.Windows.Forms.RadioButton();
            this.advancedRadioButton = new System.Windows.Forms.RadioButton();
            this.proRadioButton = new System.Windows.Forms.RadioButton();
            this.brickColorGroupBox = new System.Windows.Forms.GroupBox();
            this.redRadioButton = new System.Windows.Forms.RadioButton();
            this.greenRadioButton = new System.Windows.Forms.RadioButton();
            this.blueRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.difficultyGroupBox.SuspendLayout();
            this.brickColorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.difficultyGroupBox);
            this.panel1.Controls.Add(this.brickColorGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // difficultyGroupBox
            // 
            this.difficultyGroupBox.Controls.Add(this.rookieRadioButton);
            this.difficultyGroupBox.Controls.Add(this.advancedRadioButton);
            this.difficultyGroupBox.Controls.Add(this.proRadioButton);
            this.difficultyGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.difficultyGroupBox.Location = new System.Drawing.Point(457, 60);
            this.difficultyGroupBox.Name = "difficultyGroupBox";
            this.difficultyGroupBox.Size = new System.Drawing.Size(307, 155);
            this.difficultyGroupBox.TabIndex = 5;
            this.difficultyGroupBox.TabStop = false;
            this.difficultyGroupBox.Text = "Difficulty";
            // 
            // rookieRadioButton
            // 
            this.rookieRadioButton.AutoSize = true;
            this.rookieRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rookieRadioButton.ForeColor = System.Drawing.Color.White;
            this.rookieRadioButton.Location = new System.Drawing.Point(6, 40);
            this.rookieRadioButton.Name = "rookieRadioButton";
            this.rookieRadioButton.Size = new System.Drawing.Size(93, 29);
            this.rookieRadioButton.TabIndex = 6;
            this.rookieRadioButton.Text = "Rookie";
            this.rookieRadioButton.UseVisualStyleBackColor = true;
            // 
            // advancedRadioButton
            // 
            this.advancedRadioButton.AutoSize = true;
            this.advancedRadioButton.Checked = true;
            this.advancedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedRadioButton.ForeColor = System.Drawing.Color.White;
            this.advancedRadioButton.Location = new System.Drawing.Point(6, 75);
            this.advancedRadioButton.Name = "advancedRadioButton";
            this.advancedRadioButton.Size = new System.Drawing.Size(122, 29);
            this.advancedRadioButton.TabIndex = 7;
            this.advancedRadioButton.TabStop = true;
            this.advancedRadioButton.Text = "Advanced";
            this.advancedRadioButton.UseVisualStyleBackColor = true;
            // 
            // proRadioButton
            // 
            this.proRadioButton.AutoSize = true;
            this.proRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proRadioButton.ForeColor = System.Drawing.Color.White;
            this.proRadioButton.Location = new System.Drawing.Point(6, 110);
            this.proRadioButton.Name = "proRadioButton";
            this.proRadioButton.Size = new System.Drawing.Size(63, 29);
            this.proRadioButton.TabIndex = 8;
            this.proRadioButton.Text = "Pro";
            this.proRadioButton.UseVisualStyleBackColor = true;
            // 
            // brickColorGroupBox
            // 
            this.brickColorGroupBox.Controls.Add(this.redRadioButton);
            this.brickColorGroupBox.Controls.Add(this.greenRadioButton);
            this.brickColorGroupBox.Controls.Add(this.blueRadioButton);
            this.brickColorGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brickColorGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.brickColorGroupBox.Location = new System.Drawing.Point(69, 60);
            this.brickColorGroupBox.Name = "brickColorGroupBox";
            this.brickColorGroupBox.Size = new System.Drawing.Size(282, 155);
            this.brickColorGroupBox.TabIndex = 4;
            this.brickColorGroupBox.TabStop = false;
            this.brickColorGroupBox.Text = "Brick Color";
            // 
            // redRadioButton
            // 
            this.redRadioButton.AutoSize = true;
            this.redRadioButton.Checked = true;
            this.redRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redRadioButton.ForeColor = System.Drawing.Color.Red;
            this.redRadioButton.Location = new System.Drawing.Point(6, 40);
            this.redRadioButton.Name = "redRadioButton";
            this.redRadioButton.Size = new System.Drawing.Size(68, 29);
            this.redRadioButton.TabIndex = 0;
            this.redRadioButton.TabStop = true;
            this.redRadioButton.Text = "Red";
            this.redRadioButton.UseVisualStyleBackColor = true;
            // 
            // greenRadioButton
            // 
            this.greenRadioButton.AutoSize = true;
            this.greenRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenRadioButton.ForeColor = System.Drawing.Color.Green;
            this.greenRadioButton.Location = new System.Drawing.Point(6, 75);
            this.greenRadioButton.Name = "greenRadioButton";
            this.greenRadioButton.Size = new System.Drawing.Size(87, 29);
            this.greenRadioButton.TabIndex = 1;
            this.greenRadioButton.Text = "Green";
            this.greenRadioButton.UseVisualStyleBackColor = true;
            // 
            // blueRadioButton
            // 
            this.blueRadioButton.AutoSize = true;
            this.blueRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueRadioButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.blueRadioButton.Location = new System.Drawing.Point(6, 110);
            this.blueRadioButton.Name = "blueRadioButton";
            this.blueRadioButton.Size = new System.Drawing.Size(72, 29);
            this.blueRadioButton.TabIndex = 2;
            this.blueRadioButton.Text = "Blue";
            this.blueRadioButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.DimGray;
            this.okButton.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.LavenderBlush;
            this.okButton.Location = new System.Drawing.Point(113, 301);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(173, 81);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DimGray;
            this.cancelButton.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.LavenderBlush;
            this.cancelButton.Location = new System.Drawing.Point(516, 301);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(173, 81);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.MenuBackgroundImage;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Options";
            this.Text = "Options";
            this.panel1.ResumeLayout(false);
            this.difficultyGroupBox.ResumeLayout(false);
            this.difficultyGroupBox.PerformLayout();
            this.brickColorGroupBox.ResumeLayout(false);
            this.brickColorGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton blueRadioButton;
        private System.Windows.Forms.RadioButton greenRadioButton;
        private System.Windows.Forms.RadioButton redRadioButton;
        private System.Windows.Forms.GroupBox difficultyGroupBox;
        private System.Windows.Forms.RadioButton rookieRadioButton;
        private System.Windows.Forms.RadioButton advancedRadioButton;
        private System.Windows.Forms.RadioButton proRadioButton;
        private System.Windows.Forms.GroupBox brickColorGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}