﻿namespace ThumperLevelEditor {
    partial class ThumperLevelEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThumperLevelEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblThumps = new System.Windows.Forms.Label();
            this.lblBars = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.pnlTimeline = new System.Windows.Forms.Panel();
            this.dgvObstacles = new System.Windows.Forms.DataGridView();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblWarnings = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTentacles = new System.Windows.Forms.Label();
            this.lblLaser = new System.Windows.Forms.Label();
            this.lblGamma = new System.Windows.Forms.Label();
            this.lblTunnels = new System.Windows.Forms.Label();
            this.lblTrackColor = new System.Windows.Forms.Label();
            this.lblStalactites = new System.Windows.Forms.Label();
            this.pnlLaneControlsTexts = new System.Windows.Forms.Panel();
            this.lblDBars = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSnakes = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLeafLength = new System.Windows.Forms.Label();
            this.dgvGeneral = new System.Windows.Forms.DataGridView();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObstacles)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLaneControlsTexts.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThumps
            // 
            resources.ApplyResources(this.lblThumps, "lblThumps");
            this.lblThumps.BackColor = System.Drawing.Color.Transparent;
            this.lblThumps.Name = "lblThumps";
            this.lblThumps.UseWaitCursor = true;
            // 
            // lblBars
            // 
            resources.ApplyResources(this.lblBars, "lblBars");
            this.lblBars.BackColor = System.Drawing.Color.Transparent;
            this.lblBars.Name = "lblBars";
            this.lblBars.UseWaitCursor = true;
            // 
            // lblTurn
            // 
            resources.ApplyResources(this.lblTurn, "lblTurn");
            this.lblTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.UseWaitCursor = true;
            // 
            // lblPitch
            // 
            resources.ApplyResources(this.lblPitch, "lblPitch");
            this.lblPitch.BackColor = System.Drawing.Color.Transparent;
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.UseWaitCursor = true;
            // 
            // pnlTimeline
            // 
            this.pnlTimeline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pnlTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimeline.Controls.Add(this.dgvGeneral);
            this.pnlTimeline.Controls.Add(this.dgvObstacles);
            this.pnlTimeline.Controls.Add(this.pnlWarnings);
            this.pnlTimeline.Controls.Add(this.panel3);
            this.pnlTimeline.Controls.Add(this.panel1);
            this.pnlTimeline.Controls.Add(this.pnlLaneControlsTexts);
            resources.ApplyResources(this.pnlTimeline, "pnlTimeline");
            this.pnlTimeline.Name = "pnlTimeline";
            // 
            // dgvObstacles
            // 
            this.dgvObstacles.AllowUserToAddRows = false;
            this.dgvObstacles.AllowUserToDeleteRows = false;
            this.dgvObstacles.AllowUserToResizeColumns = false;
            this.dgvObstacles.AllowUserToResizeRows = false;
            this.dgvObstacles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(29)))));
            this.dgvObstacles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvObstacles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvObstacles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvObstacles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvObstacles.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObstacles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvObstacles.EnableHeadersVisualStyles = false;
            this.dgvObstacles.GridColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.dgvObstacles, "dgvObstacles");
            this.dgvObstacles.MultiSelect = false;
            this.dgvObstacles.Name = "dgvObstacles";
            this.dgvObstacles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvObstacles.RowHeadersVisible = false;
            this.dgvObstacles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvObstacles.RowTemplate.Height = 200;
            this.dgvObstacles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObstacles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvObstacles.VirtualMode = true;
            this.dgvObstacles.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvObstacles_CellValuePushed);
            this.dgvObstacles.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvObstacles_RowPrePaint);
            // 
            // pnlWarnings
            // 
            this.pnlWarnings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            resources.ApplyResources(this.pnlWarnings, "pnlWarnings");
            this.pnlWarnings.Name = "pnlWarnings";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblWarnings);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // lblWarnings
            // 
            resources.ApplyResources(this.lblWarnings, "lblWarnings");
            this.lblWarnings.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnings.ForeColor = System.Drawing.Color.Red;
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.UseWaitCursor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTentacles);
            this.panel1.Controls.Add(this.lblLaser);
            this.panel1.Controls.Add(this.lblGamma);
            this.panel1.Controls.Add(this.lblTunnels);
            this.panel1.Controls.Add(this.lblTrackColor);
            this.panel1.Controls.Add(this.lblStalactites);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lblTentacles
            // 
            resources.ApplyResources(this.lblTentacles, "lblTentacles");
            this.lblTentacles.BackColor = System.Drawing.Color.Transparent;
            this.lblTentacles.Name = "lblTentacles";
            this.lblTentacles.UseWaitCursor = true;
            // 
            // lblLaser
            // 
            resources.ApplyResources(this.lblLaser, "lblLaser");
            this.lblLaser.BackColor = System.Drawing.Color.Transparent;
            this.lblLaser.Name = "lblLaser";
            this.lblLaser.UseWaitCursor = true;
            // 
            // lblGamma
            // 
            resources.ApplyResources(this.lblGamma, "lblGamma");
            this.lblGamma.BackColor = System.Drawing.Color.Transparent;
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.UseWaitCursor = true;
            // 
            // lblTunnels
            // 
            resources.ApplyResources(this.lblTunnels, "lblTunnels");
            this.lblTunnels.BackColor = System.Drawing.Color.Transparent;
            this.lblTunnels.Name = "lblTunnels";
            this.lblTunnels.UseWaitCursor = true;
            // 
            // lblTrackColor
            // 
            resources.ApplyResources(this.lblTrackColor, "lblTrackColor");
            this.lblTrackColor.BackColor = System.Drawing.Color.Transparent;
            this.lblTrackColor.ForeColor = System.Drawing.Color.Red;
            this.lblTrackColor.Name = "lblTrackColor";
            this.lblTrackColor.UseWaitCursor = true;
            // 
            // lblStalactites
            // 
            resources.ApplyResources(this.lblStalactites, "lblStalactites");
            this.lblStalactites.BackColor = System.Drawing.Color.Transparent;
            this.lblStalactites.Name = "lblStalactites";
            this.lblStalactites.UseWaitCursor = true;
            // 
            // pnlLaneControlsTexts
            // 
            this.pnlLaneControlsTexts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.pnlLaneControlsTexts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLaneControlsTexts.Controls.Add(this.lblDBars);
            this.pnlLaneControlsTexts.Controls.Add(this.label1);
            this.pnlLaneControlsTexts.Controls.Add(this.lblThumps);
            this.pnlLaneControlsTexts.Controls.Add(this.lblBars);
            this.pnlLaneControlsTexts.Controls.Add(this.lblSnakes);
            this.pnlLaneControlsTexts.Controls.Add(this.lblTurn);
            this.pnlLaneControlsTexts.Controls.Add(this.lblPitch);
            resources.ApplyResources(this.pnlLaneControlsTexts, "pnlLaneControlsTexts");
            this.pnlLaneControlsTexts.Name = "pnlLaneControlsTexts";
            // 
            // lblDBars
            // 
            resources.ApplyResources(this.lblDBars, "lblDBars");
            this.lblDBars.BackColor = System.Drawing.Color.Transparent;
            this.lblDBars.Name = "lblDBars";
            this.lblDBars.UseWaitCursor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            this.label1.UseWaitCursor = true;
            // 
            // lblSnakes
            // 
            resources.ApplyResources(this.lblSnakes, "lblSnakes");
            this.lblSnakes.BackColor = System.Drawing.Color.Transparent;
            this.lblSnakes.ForeColor = System.Drawing.Color.Red;
            this.lblSnakes.Name = "lblSnakes";
            this.lblSnakes.UseWaitCursor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            resources.ApplyResources(this.loadToolStripMenuItem, "loadToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblLeafLength);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lblLeafLength
            // 
            resources.ApplyResources(this.lblLeafLength, "lblLeafLength");
            this.lblLeafLength.BackColor = System.Drawing.Color.Transparent;
            this.lblLeafLength.Name = "lblLeafLength";
            this.lblLeafLength.UseWaitCursor = true;
            // 
            // dgvGeneral
            // 
            this.dgvGeneral.AllowUserToAddRows = false;
            this.dgvGeneral.AllowUserToDeleteRows = false;
            this.dgvGeneral.AllowUserToResizeColumns = false;
            this.dgvGeneral.AllowUserToResizeRows = false;
            this.dgvGeneral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(29)))));
            this.dgvGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGeneral.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGeneral.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGeneral.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeneral.EnableHeadersVisualStyles = false;
            this.dgvGeneral.GridColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.dgvGeneral, "dgvGeneral");
            this.dgvGeneral.MultiSelect = false;
            this.dgvGeneral.Name = "dgvGeneral";
            this.dgvGeneral.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGeneral.RowHeadersVisible = false;
            this.dgvGeneral.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvGeneral.RowTemplate.Height = 200;
            this.dgvGeneral.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGeneral.VirtualMode = true;
            this.dgvGeneral.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvGeneral_CellValuePushed);
            this.dgvGeneral.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvGeneral_RowPrePaint);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            this.label2.UseWaitCursor = true;
            // 
            // ThumperLevelEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTimeline);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ThumperLevelEditor";
            this.Load += new System.EventHandler(this.ThumperLevelEditor_Load);
            this.pnlTimeline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObstacles)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLaneControlsTexts.ResumeLayout(false);
            this.pnlLaneControlsTexts.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThumps;
        private System.Windows.Forms.Label lblBars;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.Panel pnlTimeline;
        private System.Windows.Forms.Panel pnlLaneControlsTexts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.Label lblTunnels;
        private System.Windows.Forms.Label lblStalactites;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblTentacles;
        private System.Windows.Forms.Panel pnlWarnings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblWarnings;
        private System.Windows.Forms.Label lblLaser;
        private System.Windows.Forms.Label lblTrackColor;
        private System.Windows.Forms.Label lblSnakes;
        private System.Windows.Forms.Label lblDBars;
        private System.Windows.Forms.DataGridView dgvObstacles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLeafLength;
        private System.Windows.Forms.DataGridView dgvGeneral;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}

