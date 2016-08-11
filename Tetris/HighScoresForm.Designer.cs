namespace Tetris
{
    partial class HighScoresForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScoresForm));
            this.highScores_TextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // highScores_TextBox
            // 
            this.highScores_TextBox.BackColor = System.Drawing.Color.Black;
            this.highScores_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.highScores_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScores_TextBox.ForeColor = System.Drawing.Color.Blue;
            this.highScores_TextBox.Location = new System.Drawing.Point(12, 12);
            this.highScores_TextBox.Name = "highScores_TextBox";
            this.highScores_TextBox.ReadOnly = true;
            this.highScores_TextBox.Size = new System.Drawing.Size(419, 250);
            this.highScores_TextBox.TabIndex = 3;
            this.highScores_TextBox.Text = "";
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(443, 274);
            this.Controls.Add(this.highScores_TextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HighScoresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HighScores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox highScores_TextBox;
    }
}