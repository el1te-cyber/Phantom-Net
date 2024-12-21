namespace Rat_Server
{
    partial class Form1
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
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandExecutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.persistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableRecoveryEnvironmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableRecoveryEnvironmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableCMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableTasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTaskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromStartuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grabTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(163, 52);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandExecutionToolStripMenuItem,
            this.persistanceToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(162, 48);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // commandExecutionToolStripMenuItem
            // 
            this.commandExecutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMDToolStripMenuItem,
            this.powershellToolStripMenuItem});
            this.commandExecutionToolStripMenuItem.Name = "commandExecutionToolStripMenuItem";
            this.commandExecutionToolStripMenuItem.Size = new System.Drawing.Size(459, 54);
            this.commandExecutionToolStripMenuItem.Text = "Command Execution";
            // 
            // cMDToolStripMenuItem
            // 
            this.cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
            this.cMDToolStripMenuItem.Size = new System.Drawing.Size(326, 54);
            this.cMDToolStripMenuItem.Text = "CMD";
            this.cMDToolStripMenuItem.Click += new System.EventHandler(this.CmdCommand_Click);
            // 
            // powershellToolStripMenuItem
            // 
            this.powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
            this.powershellToolStripMenuItem.Size = new System.Drawing.Size(326, 54);
            this.powershellToolStripMenuItem.Text = "Powershell";
            this.powershellToolStripMenuItem.Click += new System.EventHandler(this.PowershellCommand_Click);
            // 
            // persistanceToolStripMenuItem
            // 
            this.persistanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableRecoveryEnvironmentToolStripMenuItem,
            this.enableRecoveryEnvironmentToolStripMenuItem,
            this.disableCMDToolStripMenuItem,
            this.enableCMDToolStripMenuItem,
            this.disableTasToolStripMenuItem,
            this.enableTaskManagerToolStripMenuItem,
            this.addToStartupToolStripMenuItem,
            this.removeFromStartuToolStripMenuItem});
            this.persistanceToolStripMenuItem.Name = "persistanceToolStripMenuItem";
            this.persistanceToolStripMenuItem.Size = new System.Drawing.Size(459, 54);
            this.persistanceToolStripMenuItem.Text = "Persistance";
            // 
            // disableRecoveryEnvironmentToolStripMenuItem
            // 
            this.disableRecoveryEnvironmentToolStripMenuItem.Name = "disableRecoveryEnvironmentToolStripMenuItem";
            this.disableRecoveryEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.disableRecoveryEnvironmentToolStripMenuItem.Text = "Disable Recovery Environment";
            this.disableRecoveryEnvironmentToolStripMenuItem.Click += new System.EventHandler(this.ReagentcDisable_Click);
            // 
            // enableRecoveryEnvironmentToolStripMenuItem
            // 
            this.enableRecoveryEnvironmentToolStripMenuItem.Name = "enableRecoveryEnvironmentToolStripMenuItem";
            this.enableRecoveryEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.enableRecoveryEnvironmentToolStripMenuItem.Text = "Enable Recovery Environment";
            this.enableRecoveryEnvironmentToolStripMenuItem.Click += new System.EventHandler(this.ReagentcEnable_Click);
            // 
            // disableCMDToolStripMenuItem
            // 
            this.disableCMDToolStripMenuItem.Name = "disableCMDToolStripMenuItem";
            this.disableCMDToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.disableCMDToolStripMenuItem.Text = "Disable CMD";
            this.disableCMDToolStripMenuItem.Click += new System.EventHandler(this.DisableCmd_Click);
            // 
            // enableCMDToolStripMenuItem
            // 
            this.enableCMDToolStripMenuItem.Name = "enableCMDToolStripMenuItem";
            this.enableCMDToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.enableCMDToolStripMenuItem.Text = "Enable CMD";
            this.enableCMDToolStripMenuItem.Click += new System.EventHandler(this.EnableCmd_Click);
            // 
            // disableTasToolStripMenuItem
            // 
            this.disableTasToolStripMenuItem.Name = "disableTasToolStripMenuItem";
            this.disableTasToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.disableTasToolStripMenuItem.Text = "Disable Task Manager";
            this.disableTasToolStripMenuItem.Click += new System.EventHandler(this.DisableTaskManager_Click);
            // 
            // enableTaskManagerToolStripMenuItem
            // 
            this.enableTaskManagerToolStripMenuItem.Name = "enableTaskManagerToolStripMenuItem";
            this.enableTaskManagerToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.enableTaskManagerToolStripMenuItem.Text = "Enable Task Manager";
            this.enableTaskManagerToolStripMenuItem.Click += new System.EventHandler(this.EnableTaskManager_Click);
            // 
            // addToStartupToolStripMenuItem
            // 
            this.addToStartupToolStripMenuItem.Name = "addToStartupToolStripMenuItem";
            this.addToStartupToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.addToStartupToolStripMenuItem.Text = "Add To Startup";
            this.addToStartupToolStripMenuItem.DisplayStyleChanged += new System.EventHandler(this.AddToStartup_Click);
            // 
            // removeFromStartuToolStripMenuItem
            // 
            this.removeFromStartuToolStripMenuItem.Name = "removeFromStartuToolStripMenuItem";
            this.removeFromStartuToolStripMenuItem.Size = new System.Drawing.Size(584, 54);
            this.removeFromStartuToolStripMenuItem.Text = "Remove From Startup";
            this.removeFromStartuToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromStartup_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabTokensToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(459, 54);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // grabTokensToolStripMenuItem
            // 
            this.grabTokensToolStripMenuItem.Name = "grabTokensToolStripMenuItem";
            this.grabTokensToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.grabTokensToolStripMenuItem.Text = "Grab Tokens";
            this.grabTokensToolStripMenuItem.Click += new System.EventHandler(this.GetDiscordTokens_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1073);
            this.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandExecutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powershellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem persistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableRecoveryEnvironmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableRecoveryEnvironmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableCMDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableCMDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableTasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTaskManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromStartuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grabTokensToolStripMenuItem;
    }
}

