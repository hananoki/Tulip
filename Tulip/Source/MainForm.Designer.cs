
using HananokiLib;
using System.Windows.Forms;

namespace Tulip {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listView_Files = new Tulip.ListView_Files();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.pictureBox_CoverArt = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.listView_cueSheetRow = new Tulip.ListView_CueSheetRow();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_CDArcive = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_ConvM4A = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
			this.panelRoot = new System.Windows.Forms.Panel();
			this.panelSettings = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.textBox_foobar2000 = new HananokiLib.TextBoxGuide();
			this.label_foobar2000 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.textBox_flac = new HananokiLib.TextBoxGuide();
			this.label_flac = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.textBox_7z = new HananokiLib.TextBoxGuide();
			this.label_7z = new System.Windows.Forms.Label();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.panel8 = new System.Windows.Forms.Panel();
			this.textBox_shntool = new HananokiLib.TextBoxGuide();
			this.label_shntool = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.textBox_neroAacEnc = new HananokiLib.TextBoxGuide();
			this.label_neroAacEnc = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.textBox_mp3gain = new HananokiLib.TextBoxGuide();
			this.label_mp3gain = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_CoverArt)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panelRoot.SuspendLayout();
			this.panelSettings.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(584, 322);
			this.panel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 4);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 4, 4);
			this.splitContainer1.Size = new System.Drawing.Size(584, 322);
			this.splitContainer1.SplitterDistance = 194;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(4, 2);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listView_Files);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pictureBox_CoverArt);
			this.splitContainer2.Size = new System.Drawing.Size(190, 316);
			this.splitContainer2.SplitterDistance = 115;
			this.splitContainer2.TabIndex = 0;
			// 
			// listView_Files
			// 
			this.listView_Files.AllowDrop = true;
			this.listView_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
			this.listView_Files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_Files.FullRowSelect = true;
			this.listView_Files.GridLines = true;
			this.listView_Files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listView_Files.LabelEdit = true;
			this.listView_Files.Location = new System.Drawing.Point(0, 0);
			this.listView_Files.Name = "listView_Files";
			this.listView_Files.Size = new System.Drawing.Size(190, 115);
			this.listView_Files.TabIndex = 0;
			this.listView_Files.UseCompatibleStateImageBehavior = false;
			this.listView_Files.View = System.Windows.Forms.View.Details;
			this.listView_Files.VirtualMode = true;
			this.listView_Files.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_Files_AfterLabelEdit);
			this.listView_Files.SelectedIndexChanged += new System.EventHandler(this.listView_Files_SelectedIndexChanged);
			this.listView_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_Files_DragDrop);
			this.listView_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_Files_DragEnter);
			this.listView_Files.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_Files_DragEnter);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Cue";
			// 
			// pictureBox_CoverArt
			// 
			this.pictureBox_CoverArt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pictureBox_CoverArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_CoverArt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox_CoverArt.Location = new System.Drawing.Point(0, 0);
			this.pictureBox_CoverArt.Name = "pictureBox_CoverArt";
			this.pictureBox_CoverArt.Size = new System.Drawing.Size(190, 197);
			this.pictureBox_CoverArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox_CoverArt.TabIndex = 0;
			this.pictureBox_CoverArt.TabStop = false;
			this.pictureBox_CoverArt.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_CoverArt_DragDrop);
			this.pictureBox_CoverArt.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_CoverArt_DragEnter);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.listView_cueSheetRow);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 84);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(382, 234);
			this.panel3.TabIndex = 1;
			// 
			// listView_cueSheetRow
			// 
			this.listView_cueSheetRow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listView_cueSheetRow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_cueSheetRow.GridLines = true;
			this.listView_cueSheetRow.Location = new System.Drawing.Point(0, 0);
			this.listView_cueSheetRow.Name = "listView_cueSheetRow";
			this.listView_cueSheetRow.Size = new System.Drawing.Size(382, 234);
			this.listView_cueSheetRow.TabIndex = 0;
			this.listView_cueSheetRow.UseCompatibleStateImageBehavior = false;
			this.listView_cueSheetRow.View = System.Windows.Forms.View.Details;
			this.listView_cueSheetRow.VirtualMode = true;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "#";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "TITLE";
			this.columnHeader2.Width = 200;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "PERFORMER";
			this.columnHeader3.Width = 200;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.propertyGrid1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.panel2.Size = new System.Drawing.Size(382, 82);
			this.panel2.TabIndex = 0;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
			this.propertyGrid1.Size = new System.Drawing.Size(382, 80);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.ToolbarVisible = false;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 347);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(584, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_CDArcive,
            this.toolStripSeparator1,
            this.toolStripButton_ConvM4A,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton_Refresh});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(584, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton_CDArcive
			// 
			this.toolStripButton_CDArcive.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_CDArcive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_CDArcive.Image")));
			this.toolStripButton_CDArcive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_CDArcive.Name = "toolStripButton_CDArcive";
			this.toolStripButton_CDArcive.Size = new System.Drawing.Size(86, 22);
			this.toolStripButton_CDArcive.Text = "CDアーカイブ";
			this.toolStripButton_CDArcive.Click += new System.EventHandler(this.toolStripButton_CDArcive_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_ConvM4A
			// 
			this.toolStripButton_ConvM4A.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_ConvM4A.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ConvM4A.Image")));
			this.toolStripButton_ConvM4A.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_ConvM4A.Name = "toolStripButton_ConvM4A";
			this.toolStripButton_ConvM4A.Size = new System.Drawing.Size(105, 22);
			this.toolStripButton_ConvM4A.Text = "トラック毎に変換";
			this.toolStripButton_ConvM4A.Click += new System.EventHandler(this.toolStripButton_ConvM4A_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(51, 22);
			this.toolStripButton3.Text = "設定";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_Refresh
			// 
			this.toolStripButton_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Refresh.Image")));
			this.toolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Refresh.Name = "toolStripButton_Refresh";
			this.toolStripButton_Refresh.Size = new System.Drawing.Size(118, 22);
			this.toolStripButton_Refresh.Text = "最新の情報に更新";
			this.toolStripButton_Refresh.Click += new System.EventHandler(this.toolStripButton_Refresh_Click);
			// 
			// panelRoot
			// 
			this.panelRoot.Controls.Add(this.panel1);
			this.panelRoot.Controls.Add(this.toolStrip1);
			this.panelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRoot.Location = new System.Drawing.Point(0, 0);
			this.panelRoot.Margin = new System.Windows.Forms.Padding(0);
			this.panelRoot.Name = "panelRoot";
			this.panelRoot.Size = new System.Drawing.Size(584, 347);
			this.panelRoot.TabIndex = 1;
			// 
			// panelSettings
			// 
			this.panelSettings.Controls.Add(this.panel4);
			this.panelSettings.Controls.Add(this.toolStrip2);
			this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSettings.Location = new System.Drawing.Point(0, 0);
			this.panelSettings.Name = "panelSettings";
			this.panelSettings.Size = new System.Drawing.Size(584, 347);
			this.panelSettings.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.panel7);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Controls.Add(this.panel8);
			this.panel4.Controls.Add(this.panel10);
			this.panel4.Controls.Add(this.panel9);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 25);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(584, 322);
			this.panel4.TabIndex = 1;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.textBox_foobar2000);
			this.panel7.Controls.Add(this.label_foobar2000);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 255);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(4);
			this.panel7.Size = new System.Drawing.Size(584, 51);
			this.panel7.TabIndex = 2;
			// 
			// textBox_foobar2000
			// 
			this.textBox_foobar2000.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_foobar2000.Location = new System.Drawing.Point(4, 21);
			this.textBox_foobar2000.Name = "textBox_foobar2000";
			this.textBox_foobar2000.Size = new System.Drawing.Size(576, 23);
			this.textBox_foobar2000.TabIndex = 1;
			// 
			// label_foobar2000
			// 
			this.label_foobar2000.AutoSize = true;
			this.label_foobar2000.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_foobar2000.Location = new System.Drawing.Point(4, 4);
			this.label_foobar2000.Name = "label_foobar2000";
			this.label_foobar2000.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label_foobar2000.Size = new System.Drawing.Size(157, 17);
			this.label_foobar2000.TabIndex = 0;
			this.label_foobar2000.Text = "foobar2000 (foobar2000.exe)";
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.textBox_flac);
			this.panel6.Controls.Add(this.label_flac);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 153);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(4);
			this.panel6.Size = new System.Drawing.Size(584, 51);
			this.panel6.TabIndex = 1;
			// 
			// textBox_flac
			// 
			this.textBox_flac.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_flac.Location = new System.Drawing.Point(4, 21);
			this.textBox_flac.Name = "textBox_flac";
			this.textBox_flac.Size = new System.Drawing.Size(576, 23);
			this.textBox_flac.TabIndex = 1;
			// 
			// label_flac
			// 
			this.label_flac.AutoSize = true;
			this.label_flac.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_flac.Location = new System.Drawing.Point(4, 4);
			this.label_flac.Name = "label_flac";
			this.label_flac.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label_flac.Size = new System.Drawing.Size(77, 17);
			this.label_flac.TabIndex = 0;
			this.label_flac.Text = "flac (flac.exe)";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.textBox_7z);
			this.panel5.Controls.Add(this.label_7z);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 204);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(4);
			this.panel5.Size = new System.Drawing.Size(584, 51);
			this.panel5.TabIndex = 0;
			// 
			// textBox_7z
			// 
			this.textBox_7z.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_7z.Location = new System.Drawing.Point(4, 21);
			this.textBox_7z.Name = "textBox_7z";
			this.textBox_7z.Size = new System.Drawing.Size(576, 23);
			this.textBox_7z.TabIndex = 1;
			// 
			// label_7z
			// 
			this.label_7z.AutoSize = true;
			this.label_7z.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_7z.Location = new System.Drawing.Point(4, 4);
			this.label_7z.Name = "label_7z";
			this.label_7z.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label_7z.Size = new System.Drawing.Size(78, 17);
			this.label_7z.TabIndex = 0;
			this.label_7z.Text = "7-Zip (7z.exe)";
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(584, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(48, 22);
			this.toolStripButton2.Text = "戻る";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.textBox_shntool);
			this.panel8.Controls.Add(this.label_shntool);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(0, 102);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(4);
			this.panel8.Size = new System.Drawing.Size(584, 51);
			this.panel8.TabIndex = 3;
			// 
			// textBox_shntool
			// 
			this.textBox_shntool.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_shntool.Location = new System.Drawing.Point(4, 21);
			this.textBox_shntool.Name = "textBox_shntool";
			this.textBox_shntool.Size = new System.Drawing.Size(576, 23);
			this.textBox_shntool.TabIndex = 1;
			// 
			// label_shntool
			// 
			this.label_shntool.AutoSize = true;
			this.label_shntool.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_shntool.Location = new System.Drawing.Point(4, 4);
			this.label_shntool.Name = "label_shntool";
			this.label_shntool.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label_shntool.Size = new System.Drawing.Size(119, 17);
			this.label_shntool.TabIndex = 0;
			this.label_shntool.Text = "shntool (shntool.exe)";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.textBox_neroAacEnc);
			this.panel9.Controls.Add(this.label_neroAacEnc);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(4);
			this.panel9.Size = new System.Drawing.Size(584, 51);
			this.panel9.TabIndex = 4;
			// 
			// textBox_neroAacEnc
			// 
			this.textBox_neroAacEnc.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_neroAacEnc.Location = new System.Drawing.Point(4, 21);
			this.textBox_neroAacEnc.Name = "textBox_neroAacEnc";
			this.textBox_neroAacEnc.Size = new System.Drawing.Size(576, 23);
			this.textBox_neroAacEnc.TabIndex = 1;
			// 
			// label_neroAacEnc
			// 
			this.label_neroAacEnc.AutoSize = true;
			this.label_neroAacEnc.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_neroAacEnc.Location = new System.Drawing.Point(4, 4);
			this.label_neroAacEnc.Name = "label_neroAacEnc";
			this.label_neroAacEnc.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label_neroAacEnc.Size = new System.Drawing.Size(194, 17);
			this.label_neroAacEnc.TabIndex = 0;
			this.label_neroAacEnc.Text = "NeroDigitalAudio (neroAacEnc.exe)";
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.textBox_mp3gain);
			this.panel10.Controls.Add(this.label_mp3gain);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(0, 51);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(4);
			this.panel10.Size = new System.Drawing.Size(584, 51);
			this.panel10.TabIndex = 5;
			// 
			// textBox_mp3gain
			// 
			this.textBox_mp3gain.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_mp3gain.Location = new System.Drawing.Point(4, 21);
			this.textBox_mp3gain.Name = "textBox_mp3gain";
			this.textBox_mp3gain.Size = new System.Drawing.Size(576, 23);
			this.textBox_mp3gain.TabIndex = 1;
			// 
			// label_mp3gain
			// 
			this.label_mp3gain.AutoSize = true;
			this.label_mp3gain.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_mp3gain.Location = new System.Drawing.Point(4, 4);
			this.label_mp3gain.Name = "label_mp3gain";
			this.label_mp3gain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label_mp3gain.Size = new System.Drawing.Size(133, 17);
			this.label_mp3gain.TabIndex = 0;
			this.label_mp3gain.Text = "MP3Gain (mp3gain.exe)";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 369);
			this.Controls.Add(this.panelSettings);
			this.Controls.Add(this.panelRoot);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Tulip";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_CoverArt)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panelRoot.ResumeLayout(false);
			this.panelRoot.PerformLayout();
			this.panelSettings.ResumeLayout(false);
			this.panelSettings.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Panel panel1;
		private SplitContainer splitContainer1;
		private SplitContainer splitContainer2;
		private ListView_Files listView_Files;
		private PictureBox pictureBox_CoverArt;
		private Panel panel3;
		private ListView_CueSheetRow listView_cueSheetRow;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private Panel panel2;
		private PropertyGrid propertyGrid1;
		private StatusStrip statusStrip1;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton_CDArcive;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton toolStripButton_ConvM4A;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ColumnHeader columnHeader4;
		private ToolStripButton toolStripButton3;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton toolStripButton_Refresh;
		private Panel panelRoot;
		private Panel panelSettings;
		private Panel panel4;
		private ToolStrip toolStrip2;
		private ToolStripButton toolStripButton2;
		private Panel panel5;
		private TextBoxGuide textBox_7z;
		private Label label_7z;
		private Panel panel6;
		private TextBoxGuide textBox_flac;
		private Label label_flac;
		private Panel panel7;
		private TextBoxGuide textBox_foobar2000;
		private Label label_foobar2000;
		private Panel panel8;
		private TextBoxGuide textBox_shntool;
		private Label label_shntool;
		private Panel panel9;
		private TextBoxGuide textBox_neroAacEnc;
		private Label label_neroAacEnc;
		private Panel panel10;
		private TextBoxGuide textBox_mp3gain;
		private Label label_mp3gain;
	}
}