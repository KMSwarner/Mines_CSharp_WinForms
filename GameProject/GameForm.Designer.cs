namespace GameProject
{
    partial class GameForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gameMItemROOT = new System.Windows.Forms.ToolStripMenuItem();
            this.newMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginnerMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retryMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scoresMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMItemROOT = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameMItemROOT,
            this.helpMItemROOT});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(193, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gameMItemROOT
            // 
            this.gameMItemROOT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMItem,
            this.retryMItem,
            this.toolStripSeparator1,
            this.scoresMItem,
            this.exitMItem});
            this.gameMItemROOT.Name = "gameMItemROOT";
            this.gameMItemROOT.Size = new System.Drawing.Size(50, 20);
            this.gameMItemROOT.Text = "Game";
            // 
            // newMItem
            // 
            this.newMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginnerMItem,
            this.intermediateMItem,
            this.expertMItem});
            this.newMItem.Name = "newMItem";
            this.newMItem.Size = new System.Drawing.Size(137, 22);
            this.newMItem.Text = "New...";
            // 
            // beginnerMItem
            // 
            this.beginnerMItem.Name = "beginnerMItem";
            this.beginnerMItem.Size = new System.Drawing.Size(193, 22);
            this.beginnerMItem.Text = "Beginner ( 9 x 9 )";
            this.beginnerMItem.Click += new System.EventHandler(this.beginnerMItem_Click);
            //this.beginnerMItem.Click += new System.EventHandler(this.beginnerMItem_Click);
            // 
            // intermediateMItem
            // 
            this.intermediateMItem.Name = "intermediateMItem";
            this.intermediateMItem.Size = new System.Drawing.Size(193, 22);
            this.intermediateMItem.Text = "Intermediate ( 16 x 16 )";
            this.intermediateMItem.Click += new System.EventHandler(this.intermediateMItem_Click);
            // 
            // expertMItem
            // 
            this.expertMItem.Name = "expertMItem";
            this.expertMItem.Size = new System.Drawing.Size(193, 22);
            this.expertMItem.Text = "Expert ( 30 x 16 )";
            this.expertMItem.Click += new System.EventHandler(this.expertMItem_Click);
            // 
            // retryMItem
            // 
            this.retryMItem.Name = "retryMItem";
            this.retryMItem.Size = new System.Drawing.Size(137, 22);
            this.retryMItem.Text = "Retry";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // scoresMItem
            // 
            this.scoresMItem.Name = "scoresMItem";
            this.scoresMItem.Size = new System.Drawing.Size(137, 22);
            this.scoresMItem.Text = "High Scores";
            this.scoresMItem.Click += new System.EventHandler(this.scoresMItem_Click);
            // 
            // exitMItem
            // 
            this.exitMItem.Name = "exitMItem";
            this.exitMItem.Size = new System.Drawing.Size(137, 22);
            this.exitMItem.Text = "Exit";
            this.exitMItem.Click += new System.EventHandler(this.exitMItem_Click);
            // 
            // helpMItemROOT
            // 
            this.helpMItemROOT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesMItem,
            this.aboutMItem});
            this.helpMItemROOT.Name = "helpMItemROOT";
            this.helpMItemROOT.Size = new System.Drawing.Size(44, 20);
            this.helpMItemROOT.Text = "Help";
            // 
            // rulesMItem
            // 
            this.rulesMItem.Name = "rulesMItem";
            this.rulesMItem.Size = new System.Drawing.Size(107, 22);
            this.rulesMItem.Text = "Rules";
            // 
            // aboutMItem
            // 
            this.aboutMItem.Name = "aboutMItem";
            this.aboutMItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMItem.Text = "About";
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStripTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 68);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(193, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStripTime
            // 
            this.lblStripTime.Name = "lblStripTime";
            this.lblStripTime.Size = new System.Drawing.Size(49, 17);
            this.lblStripTime.Text = "00:00:00";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 90);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mines";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameMItemROOT;
        private System.Windows.Forms.ToolStripMenuItem newMItem;
        private System.Windows.Forms.ToolStripMenuItem retryMItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem scoresMItem;
        private System.Windows.Forms.ToolStripMenuItem exitMItem;
        private System.Windows.Forms.ToolStripMenuItem helpMItemROOT;
        private System.Windows.Forms.ToolStripMenuItem rulesMItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMItem;
        private System.Windows.Forms.ToolStripMenuItem beginnerMItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateMItem;
        private System.Windows.Forms.ToolStripMenuItem expertMItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStripTime;
    }
}