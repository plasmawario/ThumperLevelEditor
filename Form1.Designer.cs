namespace ThumperLevelEditor {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThumperLevelEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeafEditor = new System.Windows.Forms.Panel();
            this.combType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combLane = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResetPlayback = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvObstacles = new System.Windows.Forms.DataGridView();
            this.numLeafLength = new System.Windows.Forms.NumericUpDown();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.leafFileEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLeafLength = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLevelEditor = new System.Windows.Forms.Panel();
            this.numLeafDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.numDefaultValue = new System.Windows.Forms.NumericUpDown();
            this.lblLog = new System.Windows.Forms.Label();
            this.pnlLeafEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObstacles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeafLength)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnl.SuspendLayout();
            this.pnlLevelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLeafDelay)).BeginInit();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeafEditor
            // 
            this.pnlLeafEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pnlLeafEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeafEditor.Controls.Add(this.numDefaultValue);
            this.pnlLeafEditor.Controls.Add(this.label8);
            this.pnlLeafEditor.Controls.Add(this.combType);
            this.pnlLeafEditor.Controls.Add(this.label7);
            this.pnlLeafEditor.Controls.Add(this.combLane);
            this.pnlLeafEditor.Controls.Add(this.label6);
            this.pnlLeafEditor.Controls.Add(this.button1);
            this.pnlLeafEditor.Controls.Add(this.btnResetPlayback);
            this.pnlLeafEditor.Controls.Add(this.label5);
            this.pnlLeafEditor.Controls.Add(this.dgvObstacles);
            this.pnlLeafEditor.Controls.Add(this.numLeafLength);
            this.pnlLeafEditor.Controls.Add(this.menuStrip2);
            this.pnlLeafEditor.Controls.Add(this.lblLeafLength);
            resources.ApplyResources(this.pnlLeafEditor, "pnlLeafEditor");
            this.pnlLeafEditor.Name = "pnlLeafEditor";
            // 
            // combType
            // 
            this.combType.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.combType, "combType");
            this.combType.FormattingEnabled = true;
            this.combType.Name = "combType";
            this.combType.SelectionChangeCommitted += new System.EventHandler(this.combType_SelectionChangeCommitted);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // combLane
            // 
            this.combLane.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.combLane, "combLane");
            this.combLane.FormattingEnabled = true;
            this.combLane.Name = "combLane";
            this.combLane.SelectionChangeCommitted += new System.EventHandler(this.combLane_SelectionChangeCommitted);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnResetPlayback
            // 
            this.btnResetPlayback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            resources.ApplyResources(this.btnResetPlayback, "btnResetPlayback");
            this.btnResetPlayback.Name = "btnResetPlayback";
            this.btnResetPlayback.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // dgvObstacles
            // 
            this.dgvObstacles.AllowUserToAddRows = false;
            this.dgvObstacles.AllowUserToDeleteRows = false;
            this.dgvObstacles.AllowUserToResizeColumns = false;
            this.dgvObstacles.AllowUserToResizeRows = false;
            this.dgvObstacles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvObstacles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvObstacles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvObstacles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObstacles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgvObstacles, "dgvObstacles");
            this.dgvObstacles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Format = "N1";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObstacles.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvObstacles.EnableHeadersVisualStyles = false;
            this.dgvObstacles.GridColor = System.Drawing.Color.Black;
            this.dgvObstacles.MultiSelect = false;
            this.dgvObstacles.Name = "dgvObstacles";
            this.dgvObstacles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObstacles.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvObstacles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvObstacles.RowTemplate.Height = 200;
            this.dgvObstacles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObstacles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvObstacles.VirtualMode = true;
            this.dgvObstacles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvObstacles_CellMouseDoubleClick);
            this.dgvObstacles.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvObstacles_CellValueNeeded);
            this.dgvObstacles.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvObstacles_CellValuePushed);
            this.dgvObstacles.CurrentCellChanged += new System.EventHandler(this.dgvObstacles_CurrentCellChanged);
            // 
            // numLeafLength
            // 
            this.numLeafLength.BackColor = System.Drawing.Color.DimGray;
            this.numLeafLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.numLeafLength, "numLeafLength");
            this.numLeafLength.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numLeafLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLeafLength.Name = "numLeafLength";
            this.numLeafLength.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numLeafLength.ValueChanged += new System.EventHandler(this.numLeafLength_ValueChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            resources.ApplyResources(this.menuStrip2, "menuStrip2");
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leafFileEditorToolStripMenuItem,
            this.fileToolStripMenuItem1});
            this.menuStrip2.Name = "menuStrip2";
            // 
            // leafFileEditorToolStripMenuItem
            // 
            this.leafFileEditorToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.leafFileEditorToolStripMenuItem, "leafFileEditorToolStripMenuItem");
            this.leafFileEditorToolStripMenuItem.Name = "leafFileEditorToolStripMenuItem";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem1,
            this.exportToolStripMenuItem1});
            this.fileToolStripMenuItem1.ForeColor = System.Drawing.Color.Silver;
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            resources.ApplyResources(this.fileToolStripMenuItem1, "fileToolStripMenuItem1");
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            resources.ApplyResources(this.loadToolStripMenuItem1, "loadToolStripMenuItem1");
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            resources.ApplyResources(this.exportToolStripMenuItem1, "exportToolStripMenuItem1");
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // lblLeafLength
            // 
            resources.ApplyResources(this.lblLeafLength, "lblLeafLength");
            this.lblLeafLength.BackColor = System.Drawing.Color.Transparent;
            this.lblLeafLength.Name = "lblLeafLength";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactToolStripMenuItem,
            this.changelogToolStripMenuItem,
            this.formatToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            resources.ApplyResources(this.contactToolStripMenuItem, "contactToolStripMenuItem");
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.contactToolStripMenuItem_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            resources.ApplyResources(this.changelogToolStripMenuItem, "changelogToolStripMenuItem");
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            resources.ApplyResources(this.formatToolStripMenuItem, "formatToolStripMenuItem");
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl.Controls.Add(this.lblLog);
            this.pnl.Controls.Add(this.label1);
            this.pnl.Controls.Add(this.label2);
            resources.ApplyResources(this.pnl, "pnl");
            this.pnl.Name = "pnl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // pnlLevelEditor
            // 
            this.pnlLevelEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pnlLevelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLevelEditor.Controls.Add(this.numLeafDelay);
            this.pnlLevelEditor.Controls.Add(this.label4);
            this.pnlLevelEditor.Controls.Add(this.label3);
            this.pnlLevelEditor.Controls.Add(this.menuStrip3);
            resources.ApplyResources(this.pnlLevelEditor, "pnlLevelEditor");
            this.pnlLevelEditor.Name = "pnlLevelEditor";
            // 
            // numLeafDelay
            // 
            this.numLeafDelay.BackColor = System.Drawing.Color.DimGray;
            this.numLeafDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.numLeafDelay, "numLeafDelay");
            this.numLeafDelay.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numLeafDelay.Name = "numLeafDelay";
            this.numLeafDelay.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            resources.ApplyResources(this.menuStrip3, "menuStrip3");
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip3.Name = "menuStrip3";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            // 
            // numDefaultValue
            // 
            this.numDefaultValue.BackColor = System.Drawing.Color.DimGray;
            this.numDefaultValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDefaultValue.DecimalPlaces = 2;
            resources.ApplyResources(this.numDefaultValue, "numDefaultValue");
            this.numDefaultValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numDefaultValue.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numDefaultValue.Name = "numDefaultValue";
            this.numDefaultValue.ValueChanged += new System.EventHandler(this.numDefaultValue_ValueChanged);
            // 
            // lblLog
            // 
            this.lblLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblLog.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblLog, "lblLog");
            this.lblLog.Name = "lblLog";
            // 
            // ThumperLevelEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.pnlLevelEditor);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.pnlLeafEditor);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ThumperLevelEditor";
            this.Load += new System.EventHandler(this.ThumperLevelEditor_Load);
            this.pnlLeafEditor.ResumeLayout(false);
            this.pnlLeafEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObstacles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeafLength)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.pnlLevelEditor.ResumeLayout(false);
            this.pnlLevelEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLeafDelay)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeafEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvObstacles;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lblLeafLength;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numLeafLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem leafFileEditorToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnResetPlayback;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlLevelEditor;
        private System.Windows.Forms.NumericUpDown numLeafDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ComboBox combLane;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numDefaultValue;
        private System.Windows.Forms.Label lblLog;
    }
}

