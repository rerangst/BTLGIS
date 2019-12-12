namespace MapWinGIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axMap1 = new AxMapWinGIS.AxMap();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_open = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.zoom_in = new System.Windows.Forms.ToolStripButton();
            this.zoom_out = new System.Windows.Forms.ToolStripButton();
            this.pan = new System.Windows.Forms.ToolStripButton();
            this.zoom_more = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAnotation = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVP = new System.Windows.Forms.ToolStripButton();
            this.btnShowCellInfo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvListLayer = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axMap1
            // 
            this.axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(0, 0);
            this.axMap1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(563, 468);
            this.axMap1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(765, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_open,
            this.infoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menu_open
            // 
            this.menu_open.Name = "menu_open";
            this.menu_open.Size = new System.Drawing.Size(216, 26);
            this.menu_open.Text = "Open";
            this.menu_open.Click += new System.EventHandler(this.menu_open_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom_in,
            this.zoom_out,
            this.pan,
            this.zoom_more,
            this.toolStripSeparator2,
            this.btnAnotation,
            this.btnExport,
            this.btnImport,
            this.toolStripSeparator1,
            this.btnVP,
            this.btnShowCellInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(40, 493);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // zoom_in
            // 
            this.zoom_in.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoom_in.Image = ((System.Drawing.Image)(resources.GetObject("zoom_in.Image")));
            this.zoom_in.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoom_in.Name = "zoom_in";
            this.zoom_in.Size = new System.Drawing.Size(38, 24);
            this.zoom_in.Text = "toolStripButton1";
            this.zoom_in.Click += new System.EventHandler(this.zoom_in_Click);
            // 
            // zoom_out
            // 
            this.zoom_out.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoom_out.Image = ((System.Drawing.Image)(resources.GetObject("zoom_out.Image")));
            this.zoom_out.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoom_out.Name = "zoom_out";
            this.zoom_out.Size = new System.Drawing.Size(38, 24);
            this.zoom_out.Text = "toolStripButton2";
            this.zoom_out.Click += new System.EventHandler(this.zoom_out_Click);
            // 
            // pan
            // 
            this.pan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pan.Image = ((System.Drawing.Image)(resources.GetObject("pan.Image")));
            this.pan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(38, 24);
            this.pan.Text = "toolStripButton3";
            this.pan.Click += new System.EventHandler(this.pan_Click);
            // 
            // zoom_more
            // 
            this.zoom_more.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoom_more.Image = ((System.Drawing.Image)(resources.GetObject("zoom_more.Image")));
            this.zoom_more.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoom_more.Name = "zoom_more";
            this.zoom_more.Size = new System.Drawing.Size(38, 24);
            this.zoom_more.Text = "toolStripButton4";
            this.zoom_more.Click += new System.EventHandler(this.zoom_more_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(38, 6);
            // 
            // btnAnotation
            // 
            this.btnAnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnotation.Image = ((System.Drawing.Image)(resources.GetObject("btnAnotation.Image")));
            this.btnAnotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnotation.Name = "btnAnotation";
            this.btnAnotation.Size = new System.Drawing.Size(38, 24);
            this.btnAnotation.Text = "Gán nhãn dữ liệu";
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(38, 24);
            this.btnExport.Text = "Export ra file txt";
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(38, 24);
            this.btnImport.Text = "Import dữ liệu từ file txt";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(38, 6);
            // 
            // btnVP
            // 
            this.btnVP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVP.Image = ((System.Drawing.Image)(resources.GetObject("btnVP.Image")));
            this.btnVP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVP.Name = "btnVP";
            this.btnVP.Size = new System.Drawing.Size(38, 24);
            this.btnVP.Text = "Tạo mặt cắt dọc";
            // 
            // btnShowCellInfo
            // 
            this.btnShowCellInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowCellInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCellInfo.Image")));
            this.btnShowCellInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowCellInfo.Name = "btnShowCellInfo";
            this.btnShowCellInfo.Size = new System.Drawing.Size(38, 24);
            this.btnShowCellInfo.Text = "Hiển thị thông tin band";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(40, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(725, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(128, 20);
            this.toolStripStatusLabel3.Text = "Hệ tọa độ WGS84";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 20);
            this.toolStripStatusLabel1.Text = "Kinh độ: ";
            // 
            // tvListLayer
            // 
            this.tvListLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvListLayer.Location = new System.Drawing.Point(0, 0);
            this.tvListLayer.Name = "tvListLayer";
            this.tvListLayer.Size = new System.Drawing.Size(158, 468);
            this.tvListLayer.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(40, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvListLayer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMap1);
            this.splitContainer1.Size = new System.Drawing.Size(725, 468);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMapWinGIS.AxMap axMap1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_open;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton zoom_in;
        private System.Windows.Forms.ToolStripButton zoom_out;
        private System.Windows.Forms.ToolStripButton pan;
        private System.Windows.Forms.ToolStripButton zoom_more;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton btnAnotation;
        private System.Windows.Forms.ToolStripButton btnVP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.TreeView tvListLayer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowCellInfo;
    }
}

