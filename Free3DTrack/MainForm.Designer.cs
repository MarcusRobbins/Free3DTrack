namespace WinFormsGraphicsDevice
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.chkInvertZ = new System.Windows.Forms.CheckBox();
            this.chkTransposeRot = new System.Windows.Forms.CheckBox();
            this.chkNegateRot = new System.Windows.Forms.CheckBox();
            this.chkInverseRot = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblCalibPointsCaptured = new System.Windows.Forms.Label();
            this.btnStartCalibration = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.txtCalibrationName = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLoadCalibration = new System.Windows.Forms.Button();
            this.lstCalibrations = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBackgroundSub = new System.Windows.Forms.Button();
            this.lstBoxCameras = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenCameraDialog = new System.Windows.Forms.Button();
            this.btnAutoExposure = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.trk2DClusterThreshold = new System.Windows.Forms.TrackBar();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.trkClusterThreshold = new System.Windows.Forms.TrackBar();
            this.trkIntersectionThreshold = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlWebCamTrack = new System.Windows.Forms.Panel();
            this.Drawing = new System.Windows.Forms.TabPage();
            this.txtTrackZ = new System.Windows.Forms.TextBox();
            this.txtTrackY = new System.Windows.Forms.TextBox();
            this.txtTrackX = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkRenderAtIR = new System.Windows.Forms.CheckBox();
            this.trkModelScale = new System.Windows.Forms.TrackBar();
            this.chkModelShow = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnClearPaint = new System.Windows.Forms.Button();
            this.checkDraw = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTrackStart = new System.Windows.Forms.Button();
            this.txtRotAngleY = new System.Windows.Forms.TextBox();
            this.txtRotAngleX = new System.Windows.Forms.TextBox();
            this.txtRotAngleZ = new System.Windows.Forms.TextBox();
            this.btnCameraPermute = new System.Windows.Forms.Button();
            this.chkTrackModel = new System.Windows.Forms.CheckBox();
            this.spinningTriangleControl = new WinFormsGraphicsDevice.SpinningTriangleControl();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk2DClusterThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkClusterThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkIntersectionThreshold)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.Drawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkModelScale)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Location = new System.Drawing.Point(3, 19);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.Size = new System.Drawing.Size(226, 20);
            this.txtConfigFile.TabIndex = 5;
            this.txtConfigFile.Text = "D:\\bundler-v0.3-binary\\examples\\test2\\bundle\\bundle.out";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(235, 19);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(24, 20);
            this.btnOpenFile.TabIndex = 6;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(265, 19);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chkInvertZ
            // 
            this.chkInvertZ.AutoSize = true;
            this.chkInvertZ.Checked = true;
            this.chkInvertZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvertZ.Location = new System.Drawing.Point(39, 109);
            this.chkInvertZ.Name = "chkInvertZ";
            this.chkInvertZ.Size = new System.Drawing.Size(63, 17);
            this.chkInvertZ.TabIndex = 8;
            this.chkInvertZ.Text = "Invert Z";
            this.chkInvertZ.UseVisualStyleBackColor = true;
            this.chkInvertZ.Visible = false;
            this.chkInvertZ.CheckedChanged += new System.EventHandler(this.chkInvertZ_CheckedChanged);
            // 
            // chkTransposeRot
            // 
            this.chkTransposeRot.AutoSize = true;
            this.chkTransposeRot.Location = new System.Drawing.Point(39, 132);
            this.chkTransposeRot.Name = "chkTransposeRot";
            this.chkTransposeRot.Size = new System.Drawing.Size(96, 17);
            this.chkTransposeRot.TabIndex = 9;
            this.chkTransposeRot.Text = "Transpose Rot";
            this.chkTransposeRot.UseVisualStyleBackColor = true;
            this.chkTransposeRot.Visible = false;
            this.chkTransposeRot.CheckedChanged += new System.EventHandler(this.chkTransposeRot_CheckedChanged);
            // 
            // chkNegateRot
            // 
            this.chkNegateRot.AutoSize = true;
            this.chkNegateRot.Location = new System.Drawing.Point(39, 155);
            this.chkNegateRot.Name = "chkNegateRot";
            this.chkNegateRot.Size = new System.Drawing.Size(81, 17);
            this.chkNegateRot.TabIndex = 10;
            this.chkNegateRot.Text = "Negate Rot";
            this.chkNegateRot.UseVisualStyleBackColor = true;
            this.chkNegateRot.Visible = false;
            this.chkNegateRot.CheckedChanged += new System.EventHandler(this.chkNegateRot_CheckedChanged);
            // 
            // chkInverseRot
            // 
            this.chkInverseRot.AutoSize = true;
            this.chkInverseRot.Checked = true;
            this.chkInverseRot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInverseRot.Location = new System.Drawing.Point(39, 178);
            this.chkInverseRot.Name = "chkInverseRot";
            this.chkInverseRot.Size = new System.Drawing.Size(81, 17);
            this.chkInverseRot.TabIndex = 11;
            this.chkInverseRot.Text = "Inverse Rot";
            this.chkInverseRot.UseVisualStyleBackColor = true;
            this.chkInverseRot.Visible = false;
            this.chkInverseRot.CheckedChanged += new System.EventHandler(this.chkInverseRot_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 962);
            this.panel1.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.spinningTriangleControl);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 962);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 45;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.Drawing);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 962);
            this.tabControl1.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.lblCalibPointsCaptured);
            this.tabPage1.Controls.Add(this.btnStartCalibration);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.btnCalibrate);
            this.tabPage1.Controls.Add(this.txtCalibrationName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 936);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Calibration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(61, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Calibrations will appear on the next tab: Load Config";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Multi Track must be disabled to enable calibration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Calibration Name";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(93, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Multi Tracking";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblCalibPointsCaptured
            // 
            this.lblCalibPointsCaptured.AutoSize = true;
            this.lblCalibPointsCaptured.Location = new System.Drawing.Point(6, 198);
            this.lblCalibPointsCaptured.Name = "lblCalibPointsCaptured";
            this.lblCalibPointsCaptured.Size = new System.Drawing.Size(118, 13);
            this.lblCalibPointsCaptured.TabIndex = 42;
            this.lblCalibPointsCaptured.Text = "Calib points captured: 0";
            // 
            // btnStartCalibration
            // 
            this.btnStartCalibration.Location = new System.Drawing.Point(166, 113);
            this.btnStartCalibration.Name = "btnStartCalibration";
            this.btnStartCalibration.Size = new System.Drawing.Size(146, 23);
            this.btnStartCalibration.TabIndex = 36;
            this.btnStartCalibration.Text = "Start Calibration Capture";
            this.btnStartCalibration.UseVisualStyleBackColor = true;
            this.btnStartCalibration.Click += new System.EventHandler(this.btnStartCalibration_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(166, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 23);
            this.button3.TabIndex = 41;
            this.button3.Text = "Stop Calibration Capture";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(192, 185);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(120, 23);
            this.btnCalibrate.TabIndex = 24;
            this.btnCalibrate.Text = "Begin Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // txtCalibrationName
            // 
            this.txtCalibrationName.Location = new System.Drawing.Point(99, 80);
            this.txtCalibrationName.Name = "txtCalibrationName";
            this.txtCalibrationName.Size = new System.Drawing.Size(213, 20);
            this.txtCalibrationName.TabIndex = 40;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.btnLoadCalibration);
            this.tabPage5.Controls.Add(this.lstCalibrations);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(292, 936);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Load Config";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(129, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 39);
            this.label9.TabIndex = 45;
            this.label9.Text = "Select a Calibration to load. \r\nAfter loading tracked points will appear \r\nin the" +
                " blue 3D view to the right.";
            // 
            // btnLoadCalibration
            // 
            this.btnLoadCalibration.Location = new System.Drawing.Point(8, 112);
            this.btnLoadCalibration.Name = "btnLoadCalibration";
            this.btnLoadCalibration.Size = new System.Drawing.Size(91, 23);
            this.btnLoadCalibration.TabIndex = 39;
            this.btnLoadCalibration.Text = "Load Calibration";
            this.btnLoadCalibration.UseVisualStyleBackColor = true;
            this.btnLoadCalibration.Click += new System.EventHandler(this.btnLoadCalibration_Click);
            // 
            // lstCalibrations
            // 
            this.lstCalibrations.FormattingEnabled = true;
            this.lstCalibrations.Location = new System.Drawing.Point(6, 6);
            this.lstCalibrations.Name = "lstCalibrations";
            this.lstCalibrations.Size = new System.Drawing.Size(120, 95);
            this.lstCalibrations.TabIndex = 38;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBackgroundSub);
            this.tabPage2.Controls.Add(this.lstBoxCameras);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnOpenCameraDialog);
            this.tabPage2.Controls.Add(this.btnAutoExposure);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 936);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Webcams";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBackgroundSub
            // 
            this.btnBackgroundSub.Location = new System.Drawing.Point(16, 188);
            this.btnBackgroundSub.Name = "btnBackgroundSub";
            this.btnBackgroundSub.Size = new System.Drawing.Size(120, 23);
            this.btnBackgroundSub.TabIndex = 48;
            this.btnBackgroundSub.Text = "Subtract Background";
            this.btnBackgroundSub.UseVisualStyleBackColor = true;
            this.btnBackgroundSub.Click += new System.EventHandler(this.btnBackgroundSub_Click);
            // 
            // lstBoxCameras
            // 
            this.lstBoxCameras.FormattingEnabled = true;
            this.lstBoxCameras.Location = new System.Drawing.Point(16, 6);
            this.lstBoxCameras.Name = "lstBoxCameras";
            this.lstBoxCameras.Size = new System.Drawing.Size(120, 95);
            this.lstBoxCameras.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(142, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 26);
            this.label10.TabIndex = 46;
            this.label10.Text = "Use this button to view a feed from the\r\nwebcam selected from the list above.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(142, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 26);
            this.label7.TabIndex = 45;
            this.label7.Text = "This automatically adjusts camera exposure,\r\nmake sure any tracking LEDs are not " +
                "visible.";
            // 
            // btnOpenCameraDialog
            // 
            this.btnOpenCameraDialog.Location = new System.Drawing.Point(16, 111);
            this.btnOpenCameraDialog.Name = "btnOpenCameraDialog";
            this.btnOpenCameraDialog.Size = new System.Drawing.Size(120, 23);
            this.btnOpenCameraDialog.TabIndex = 34;
            this.btnOpenCameraDialog.Text = "Open Camera";
            this.btnOpenCameraDialog.UseVisualStyleBackColor = true;
            this.btnOpenCameraDialog.Click += new System.EventHandler(this.btnOpenCameraDialog_Click);
            // 
            // btnAutoExposure
            // 
            this.btnAutoExposure.Location = new System.Drawing.Point(16, 140);
            this.btnAutoExposure.Name = "btnAutoExposure";
            this.btnAutoExposure.Size = new System.Drawing.Size(120, 23);
            this.btnAutoExposure.TabIndex = 35;
            this.btnAutoExposure.Text = "Auto Set Exposure";
            this.btnAutoExposure.UseVisualStyleBackColor = true;
            this.btnAutoExposure.Click += new System.EventHandler(this.btnAutoExposure_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.trk2DClusterThreshold);
            this.tabPage3.Controls.Add(this.trackBarThreshold);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(292, 936);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "2D Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(115, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 52);
            this.label12.TabIndex = 48;
            this.label12.Text = "This is the minimum distance between tracked\r\nlight sources. Adjust this so that " +
                "close points are \r\nstill considered separate and so that a single point\r\nis stil" +
                "l considered as distinct.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(115, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 52);
            this.label11.TabIndex = 47;
            this.label11.Text = "Adjust the point tracking sensitivity\r\nof the Webcams. Use the Camera view \r\nor T" +
                "rack View to make sure that you are \r\ndetecting only your tracking light/s.";
            // 
            // trk2DClusterThreshold
            // 
            this.trk2DClusterThreshold.LargeChange = 45;
            this.trk2DClusterThreshold.Location = new System.Drawing.Point(118, 153);
            this.trk2DClusterThreshold.Maximum = 100;
            this.trk2DClusterThreshold.Name = "trk2DClusterThreshold";
            this.trk2DClusterThreshold.Size = new System.Drawing.Size(243, 45);
            this.trk2DClusterThreshold.SmallChange = 45;
            this.trk2DClusterThreshold.TabIndex = 30;
            this.trk2DClusterThreshold.TickFrequency = 45;
            this.trk2DClusterThreshold.Scroll += new System.EventHandler(this.trk2DClusterThreshold_Scroll);
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.LargeChange = 45;
            this.trackBarThreshold.Location = new System.Drawing.Point(118, 13);
            this.trackBarThreshold.Maximum = 255;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(243, 45);
            this.trackBarThreshold.TabIndex = 14;
            this.trackBarThreshold.TickFrequency = 45;
            this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tracking Threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "2D Cluster Threshold";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.trkClusterThreshold);
            this.tabPage4.Controls.Add(this.trkIntersectionThreshold);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(292, 936);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "3D Config";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(141, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(224, 65);
            this.label14.TabIndex = 49;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(141, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 65);
            this.label13.TabIndex = 48;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // trkClusterThreshold
            // 
            this.trkClusterThreshold.LargeChange = 45;
            this.trkClusterThreshold.Location = new System.Drawing.Point(144, 148);
            this.trkClusterThreshold.Maximum = 100;
            this.trkClusterThreshold.Name = "trkClusterThreshold";
            this.trkClusterThreshold.Size = new System.Drawing.Size(217, 45);
            this.trkClusterThreshold.SmallChange = 45;
            this.trkClusterThreshold.TabIndex = 16;
            this.trkClusterThreshold.TickFrequency = 45;
            this.trkClusterThreshold.Scroll += new System.EventHandler(this.trkClusterThreshold_Scroll);
            // 
            // trkIntersectionThreshold
            // 
            this.trkIntersectionThreshold.LargeChange = 45;
            this.trkIntersectionThreshold.Location = new System.Drawing.Point(144, 10);
            this.trkIntersectionThreshold.Maximum = 100;
            this.trkIntersectionThreshold.Name = "trkIntersectionThreshold";
            this.trkIntersectionThreshold.Size = new System.Drawing.Size(217, 45);
            this.trkIntersectionThreshold.SmallChange = 45;
            this.trkIntersectionThreshold.TabIndex = 15;
            this.trkIntersectionThreshold.TickFrequency = 45;
            this.trkIntersectionThreshold.Scroll += new System.EventHandler(this.trkIntersectionThreshold_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Ray Intersection Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "3D Cluster Threshold";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.pnlWebCamTrack);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(292, 936);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Track View";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(8, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(258, 52);
            this.label15.TabIndex = 49;
            this.label15.Text = "This is a quick view of all of the tracks from each \r\ncamera. They are updated ev" +
                "ery 1/10th of a second,\r\nthis frame rate does not reflect the tracking frame\r\nra" +
                "te.";
            // 
            // pnlWebCamTrack
            // 
            this.pnlWebCamTrack.AutoScroll = true;
            this.pnlWebCamTrack.Location = new System.Drawing.Point(3, 58);
            this.pnlWebCamTrack.Name = "pnlWebCamTrack";
            this.pnlWebCamTrack.Size = new System.Drawing.Size(282, 679);
            this.pnlWebCamTrack.TabIndex = 37;
            // 
            // Drawing
            // 
            this.Drawing.Controls.Add(this.textBox4);
            this.Drawing.Controls.Add(this.chkTrackModel);
            this.Drawing.Controls.Add(this.txtTrackZ);
            this.Drawing.Controls.Add(this.txtTrackY);
            this.Drawing.Controls.Add(this.txtTrackX);
            this.Drawing.Controls.Add(this.textBox3);
            this.Drawing.Controls.Add(this.textBox2);
            this.Drawing.Controls.Add(this.textBox1);
            this.Drawing.Controls.Add(this.chkRenderAtIR);
            this.Drawing.Controls.Add(this.trkModelScale);
            this.Drawing.Controls.Add(this.chkModelShow);
            this.Drawing.Controls.Add(this.label17);
            this.Drawing.Controls.Add(this.button4);
            this.Drawing.Controls.Add(this.label16);
            this.Drawing.Controls.Add(this.btnClearPaint);
            this.Drawing.Controls.Add(this.checkDraw);
            this.Drawing.Location = new System.Drawing.Point(4, 22);
            this.Drawing.Name = "Drawing";
            this.Drawing.Size = new System.Drawing.Size(292, 936);
            this.Drawing.TabIndex = 6;
            this.Drawing.Text = "Draw";
            this.Drawing.UseVisualStyleBackColor = true;
            // 
            // txtTrackZ
            // 
            this.txtTrackZ.Location = new System.Drawing.Point(16, 548);
            this.txtTrackZ.Name = "txtTrackZ";
            this.txtTrackZ.Size = new System.Drawing.Size(100, 20);
            this.txtTrackZ.TabIndex = 61;
            // 
            // txtTrackY
            // 
            this.txtTrackY.Location = new System.Drawing.Point(16, 522);
            this.txtTrackY.Name = "txtTrackY";
            this.txtTrackY.Size = new System.Drawing.Size(100, 20);
            this.txtTrackY.TabIndex = 60;
            // 
            // txtTrackX
            // 
            this.txtTrackX.Location = new System.Drawing.Point(16, 496);
            this.txtTrackX.Name = "txtTrackX";
            this.txtTrackX.Size = new System.Drawing.Size(100, 20);
            this.txtTrackX.TabIndex = 59;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 434);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 58;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 408);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 57;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 382);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 56;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // chkRenderAtIR
            // 
            this.chkRenderAtIR.AutoSize = true;
            this.chkRenderAtIR.Location = new System.Drawing.Point(16, 334);
            this.chkRenderAtIR.Name = "chkRenderAtIR";
            this.chkRenderAtIR.Size = new System.Drawing.Size(127, 17);
            this.chkRenderAtIR.TabIndex = 55;
            this.chkRenderAtIR.Text = "Render at IR location";
            this.chkRenderAtIR.UseVisualStyleBackColor = true;
            this.chkRenderAtIR.CheckedChanged += new System.EventHandler(this.chkRenderAtIR_CheckedChanged);
            // 
            // trkModelScale
            // 
            this.trkModelScale.Location = new System.Drawing.Point(3, 260);
            this.trkModelScale.Maximum = 200;
            this.trkModelScale.Name = "trkModelScale";
            this.trkModelScale.Size = new System.Drawing.Size(280, 45);
            this.trkModelScale.TabIndex = 54;
            this.trkModelScale.Value = 1;
            this.trkModelScale.Scroll += new System.EventHandler(this.trkModelScale_Scroll);
            // 
            // chkModelShow
            // 
            this.chkModelShow.AutoSize = true;
            this.chkModelShow.Location = new System.Drawing.Point(16, 203);
            this.chkModelShow.Name = "chkModelShow";
            this.chkModelShow.Size = new System.Drawing.Size(85, 17);
            this.chkModelShow.TabIndex = 53;
            this.chkModelShow.Text = "Show Model";
            this.chkModelShow.UseVisualStyleBackColor = true;
            this.chkModelShow.CheckedChanged += new System.EventHandler(this.chkModelShow_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(13, 170);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(228, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "This will add a model at the current IR location.";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 51;
            this.button4.Text = "Add Model";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(13, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(270, 39);
            this.label16.TabIndex = 50;
            this.label16.Text = "Checking Draw will allow you to draw in 3D space using\r\nthe tracked light source." +
                " The Clear Paint button allows\r\nyou to clear any tracked points.";
            // 
            // btnClearPaint
            // 
            this.btnClearPaint.Location = new System.Drawing.Point(16, 15);
            this.btnClearPaint.Name = "btnClearPaint";
            this.btnClearPaint.Size = new System.Drawing.Size(75, 23);
            this.btnClearPaint.TabIndex = 22;
            this.btnClearPaint.Text = "Clear Paint";
            this.btnClearPaint.UseVisualStyleBackColor = true;
            this.btnClearPaint.Click += new System.EventHandler(this.btnClearPaint_Click);
            // 
            // checkDraw
            // 
            this.checkDraw.AutoSize = true;
            this.checkDraw.Location = new System.Drawing.Point(97, 19);
            this.checkDraw.Name = "checkDraw";
            this.checkDraw.Size = new System.Drawing.Size(51, 17);
            this.checkDraw.TabIndex = 32;
            this.checkDraw.Text = "Draw";
            this.checkDraw.UseVisualStyleBackColor = true;
            this.checkDraw.CheckedChanged += new System.EventHandler(this.checkDraw_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.txtConfigFile);
            this.panel2.Controls.Add(this.btnOpenFile);
            this.panel2.Controls.Add(this.btnTrackStart);
            this.panel2.Controls.Add(this.chkInverseRot);
            this.panel2.Controls.Add(this.txtRotAngleY);
            this.panel2.Controls.Add(this.chkNegateRot);
            this.panel2.Controls.Add(this.txtRotAngleX);
            this.panel2.Controls.Add(this.chkTransposeRot);
            this.panel2.Controls.Add(this.txtRotAngleZ);
            this.panel2.Controls.Add(this.chkInvertZ);
            this.panel2.Controls.Add(this.btnCameraPermute);
            this.panel2.Location = new System.Drawing.Point(610, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 295);
            this.panel2.TabIndex = 44;
            this.panel2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "WebCamStart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Track Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTrackStart
            // 
            this.btnTrackStart.Location = new System.Drawing.Point(265, 55);
            this.btnTrackStart.Name = "btnTrackStart";
            this.btnTrackStart.Size = new System.Drawing.Size(75, 23);
            this.btnTrackStart.TabIndex = 19;
            this.btnTrackStart.Text = "Track Start";
            this.btnTrackStart.UseVisualStyleBackColor = true;
            this.btnTrackStart.Click += new System.EventHandler(this.btnTrackStart_Click);
            // 
            // txtRotAngleY
            // 
            this.txtRotAngleY.Location = new System.Drawing.Point(265, 170);
            this.txtRotAngleY.Name = "txtRotAngleY";
            this.txtRotAngleY.Size = new System.Drawing.Size(100, 20);
            this.txtRotAngleY.TabIndex = 17;
            this.txtRotAngleY.TextChanged += new System.EventHandler(this.txtRotAngleY_TextChanged);
            // 
            // txtRotAngleX
            // 
            this.txtRotAngleX.Location = new System.Drawing.Point(265, 119);
            this.txtRotAngleX.Name = "txtRotAngleX";
            this.txtRotAngleX.Size = new System.Drawing.Size(100, 20);
            this.txtRotAngleX.TabIndex = 13;
            this.txtRotAngleX.TextChanged += new System.EventHandler(this.txtRotAngleX_TextChanged);
            // 
            // txtRotAngleZ
            // 
            this.txtRotAngleZ.Location = new System.Drawing.Point(265, 221);
            this.txtRotAngleZ.Name = "txtRotAngleZ";
            this.txtRotAngleZ.Size = new System.Drawing.Size(100, 20);
            this.txtRotAngleZ.TabIndex = 18;
            this.txtRotAngleZ.TextChanged += new System.EventHandler(this.txtRotAngleZ_TextChanged);
            // 
            // btnCameraPermute
            // 
            this.btnCameraPermute.Location = new System.Drawing.Point(39, 66);
            this.btnCameraPermute.Name = "btnCameraPermute";
            this.btnCameraPermute.Size = new System.Drawing.Size(75, 23);
            this.btnCameraPermute.TabIndex = 21;
            this.btnCameraPermute.Text = "Camera Permute";
            this.btnCameraPermute.UseVisualStyleBackColor = true;
            this.btnCameraPermute.Click += new System.EventHandler(this.btnCameraPermute_Click);
            // 
            // chkTrackModel
            // 
            this.chkTrackModel.AutoSize = true;
            this.chkTrackModel.Checked = true;
            this.chkTrackModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackModel.Location = new System.Drawing.Point(156, 203);
            this.chkTrackModel.Name = "chkTrackModel";
            this.chkTrackModel.Size = new System.Drawing.Size(86, 17);
            this.chkTrackModel.TabIndex = 62;
            this.chkTrackModel.Text = "Track Model";
            this.chkTrackModel.UseVisualStyleBackColor = true;
            this.chkTrackModel.CheckedChanged += new System.EventHandler(this.chkTrackModel_CheckedChanged);
            // 
            // spinningTriangleControl
            // 
            this.spinningTriangleControl.cameraModelScaling = 0F;
            this.spinningTriangleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinningTriangleControl.dragSensitivity = 0F;
            this.spinningTriangleControl.globalScaling = 0F;
            this.spinningTriangleControl.Location = new System.Drawing.Point(0, 0);
            this.spinningTriangleControl.Name = "spinningTriangleControl";
            this.spinningTriangleControl.pitch = 0F;
            this.spinningTriangleControl.roll = 0F;
            this.spinningTriangleControl.Size = new System.Drawing.Size(725, 962);
            this.spinningTriangleControl.TabIndex = 20;
            this.spinningTriangleControl.Text = "spinningTriangleControl1";
            this.spinningTriangleControl.yaw = 0F;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(156, 633);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 63;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 962);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "WinForms Graphics Device";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk2DClusterThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkClusterThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkIntersectionThreshold)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.Drawing.ResumeLayout(false);
            this.Drawing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkModelScale)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox chkInvertZ;
        private System.Windows.Forms.CheckBox chkTransposeRot;
        private System.Windows.Forms.CheckBox chkNegateRot;
        private System.Windows.Forms.CheckBox chkInverseRot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRotAngleX;
        private System.Windows.Forms.TrackBar trackBarThreshold;
        private System.Windows.Forms.Button btnTrackStart;
        private SpinningTriangleControl spinningTriangleControl;
        private System.Windows.Forms.Button btnCameraPermute;
        private System.Windows.Forms.Button btnClearPaint;
        private System.Windows.Forms.TextBox txtRotAngleZ;
        private System.Windows.Forms.TextBox txtRotAngleY;
        private System.Windows.Forms.TrackBar trkClusterThreshold;
        private System.Windows.Forms.TrackBar trkIntersectionThreshold;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trk2DClusterThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkDraw;
        private System.Windows.Forms.Button btnOpenCameraDialog;
        private System.Windows.Forms.Button btnAutoExposure;
        private System.Windows.Forms.Button btnStartCalibration;
        private System.Windows.Forms.Panel pnlWebCamTrack;
        private System.Windows.Forms.ListBox lstCalibrations;
        private System.Windows.Forms.Button btnLoadCalibration;
        private System.Windows.Forms.TextBox txtCalibrationName;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lblCalibPointsCaptured;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage Drawing;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lstBoxCameras;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkModelShow;
        public System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar trkModelScale;
        private System.Windows.Forms.CheckBox chkRenderAtIR;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtTrackZ;
        private System.Windows.Forms.TextBox txtTrackY;
        private System.Windows.Forms.TextBox txtTrackX;
        private System.Windows.Forms.Button btnBackgroundSub;
        private System.Windows.Forms.CheckBox chkTrackModel;
        private System.Windows.Forms.TextBox textBox4;
    }
}

