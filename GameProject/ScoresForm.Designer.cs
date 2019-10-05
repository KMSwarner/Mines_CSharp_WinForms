namespace GameProject
{
    partial class ScoresForm
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
            this.lblBeginner = new System.Windows.Forms.Label();
            this.lblIntermediate = new System.Windows.Forms.Label();
            this.lblExpert = new System.Windows.Forms.Label();
            this.lblHighScores = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblBeginnerScore = new System.Windows.Forms.Label();
            this.lblIntermediateScore = new System.Windows.Forms.Label();
            this.lblExpertScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBeginner
            // 
            this.lblBeginner.AutoSize = true;
            this.lblBeginner.Location = new System.Drawing.Point(63, 58);
            this.lblBeginner.Name = "lblBeginner";
            this.lblBeginner.Size = new System.Drawing.Size(52, 13);
            this.lblBeginner.TabIndex = 3;
            this.lblBeginner.Text = "Beginner:";
            // 
            // lblIntermediate
            // 
            this.lblIntermediate.AutoSize = true;
            this.lblIntermediate.Location = new System.Drawing.Point(47, 87);
            this.lblIntermediate.Name = "lblIntermediate";
            this.lblIntermediate.Size = new System.Drawing.Size(68, 13);
            this.lblIntermediate.TabIndex = 4;
            this.lblIntermediate.Text = "Intermediate:";
            // 
            // lblExpert
            // 
            this.lblExpert.AutoSize = true;
            this.lblExpert.Location = new System.Drawing.Point(75, 118);
            this.lblExpert.Name = "lblExpert";
            this.lblExpert.Size = new System.Drawing.Size(40, 13);
            this.lblExpert.TabIndex = 5;
            this.lblExpert.Text = "Expert:";
            // 
            // lblHighScores
            // 
            this.lblHighScores.AutoSize = true;
            this.lblHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScores.Location = new System.Drawing.Point(58, 9);
            this.lblHighScores.Name = "lblHighScores";
            this.lblHighScores.Size = new System.Drawing.Size(113, 24);
            this.lblHighScores.TabIndex = 6;
            this.lblHighScores.Text = "Best Times";
            this.lblHighScores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(77, 149);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset TImes";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblBeginnerScore
            // 
            this.lblBeginnerScore.AutoSize = true;
            this.lblBeginnerScore.Location = new System.Drawing.Point(121, 58);
            this.lblBeginnerScore.Name = "lblBeginnerScore";
            this.lblBeginnerScore.Size = new System.Drawing.Size(0, 13);
            this.lblBeginnerScore.TabIndex = 8;
            this.lblBeginnerScore.Tag = "beginnerScore";
            // 
            // lblIntermediateScore
            // 
            this.lblIntermediateScore.AutoSize = true;
            this.lblIntermediateScore.Location = new System.Drawing.Point(121, 87);
            this.lblIntermediateScore.Name = "lblIntermediateScore";
            this.lblIntermediateScore.Size = new System.Drawing.Size(0, 13);
            this.lblIntermediateScore.TabIndex = 9;
            this.lblIntermediateScore.Tag = "intermediateScore";
            // 
            // lblExpertScore
            // 
            this.lblExpertScore.AutoSize = true;
            this.lblExpertScore.Location = new System.Drawing.Point(121, 118);
            this.lblExpertScore.Name = "lblExpertScore";
            this.lblExpertScore.Size = new System.Drawing.Size(0, 13);
            this.lblExpertScore.TabIndex = 10;
            this.lblExpertScore.Tag = "expertScore";
            // 
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 186);
            this.Controls.Add(this.lblExpertScore);
            this.Controls.Add(this.lblIntermediateScore);
            this.Controls.Add(this.lblBeginnerScore);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblHighScores);
            this.Controls.Add(this.lblExpert);
            this.Controls.Add(this.lblIntermediate);
            this.Controls.Add(this.lblBeginner);
            this.Name = "ScoresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScoresForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBeginner;
        private System.Windows.Forms.Label lblIntermediate;
        private System.Windows.Forms.Label lblExpert;
        private System.Windows.Forms.Label lblHighScores;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblBeginnerScore;
        private System.Windows.Forms.Label lblIntermediateScore;
        private System.Windows.Forms.Label lblExpertScore;
    }
}