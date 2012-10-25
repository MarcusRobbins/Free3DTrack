#region File Description
//-----------------------------------------------------------------------------
// MainForm.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Windows.Forms;
using System.Linq;
using AForge.Video;
using AForge.Video.DirectShow;
#endregion

namespace WinFormsGraphicsDevice
{
    // System.Drawing and the XNA Framework both define Color types.
    // To avoid conflicts, we define shortcut names for them both.
    using GdiColor = System.Drawing.Color;
    using XnaColor = Microsoft.Xna.Framework.Color;
    using System.Collections.Generic;
    using System;
    using System.Drawing.Imaging;
    using System.Drawing;
    using System.IO;

    
    /// <summary>
    /// Custom form provides the main user interface for the program.
    /// In this sample we used the designer to add a splitter pane to the form,
    /// which contains a SpriteFontControl and a SpinningTriangleControl.
    /// </summary>
    public partial class MainForm : Form
    {
        int numCameras;
        List<PictureBox> lSimpleTrackPictureBox = new List<PictureBox>();
        private Timer trackImagesTimer;

        public MainForm()
        {
            InitializeComponent();
            this.Closing += MainForm_Closing;

            //spinningTriangleControl.MouseDown += new MouseEventHandler(spinningTriangleControl_MouseDown);
            spinningTriangleControl.MouseMove +=new MouseEventHandler(spinningTriangleControl_MouseMove);
            spinningTriangleControl.MouseWheel += new MouseEventHandler(spinningTriangleControl_MouseWheel);

            //Get the number of Cameras available
            numCameras = WebCamEye.GetNumCameras();

            //create listbox items
            int simpletrakerImageHeight = 150;

            for (int i = 0; i < numCameras; i++)
            {
                WebCamEye thiscam = new WebCamEye(i);
                lCalibTracks.Add(new WebCamTrack());
                lWebCams.Add(thiscam);
                
                //Fill in the checklist
                lstBoxCameras.Items.Add("Camera " + i);

                PictureBox thisPictureBox = new PictureBox();
                thisPictureBox.Top = i * (simpletrakerImageHeight + 5);
                thisPictureBox.Width = simpletrakerImageHeight;
                thisPictureBox.Height = simpletrakerImageHeight;
                Bitmap thisbitmap = new Bitmap(simpletrakerImageHeight, simpletrakerImageHeight);
                thisPictureBox.Image = thisbitmap;                
                lSimpleTrackPictureBox.Add(thisPictureBox);
                pnlWebCamTrack.Controls.Add(thisPictureBox);
            }

            //Setup a thread to update the simple track images periodically
            trackImagesTimer = new Timer();
            trackImagesTimer.Tick += new EventHandler(Update_SimpleTrackImages);
            trackImagesTimer.Interval = 100; // in miliseconds
            trackImagesTimer.Start();

            //If the directory for the calibrations does not exist, create it
            if (!System.IO.Directory.Exists(Directory.GetCurrentDirectory() + @"\Calibrations"))
            {
                System.IO.Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Calibrations");
            }

            //read the calibration file to add previous calibrations:
            ReadCalibrationsfile();

            //chkListBoxCameras.SelectedIndex = 0;
            if (lWebCams.Count > 0)
            {
                trackBarThreshold.Value = lWebCams[0].thresMag;
                trk2DClusterThreshold.Value = lWebCams[0].ClusterDistance;
            }
        }

        private List<string> CalibrationPaths = new List<string>();

        private void ReadCalibrationsfile()
        {
            lstCalibrations.Items.Clear();
            CalibrationPaths.Clear();

            bool fileExists = System.IO.File.Exists(Directory.GetCurrentDirectory() + @"\Calibrations.txt");
            if (fileExists)
            {
                string text = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\Calibrations.txt");
                string[] lineSplit = text.Split('\r');

                foreach (string thisLine in lineSplit)
                {
                    string[] itemSplit = thisLine.Split('\t');
                    //lstCalibrations.Items.Add(itemSplit);
                    for (int i = 0; i < itemSplit.Length; i++)
                    {
                        if (i == 0)
                        {
                            lstCalibrations.Items.Add(itemSplit[i]);
                            CalibrationPaths.Add(itemSplit[i]);
                        }
                    }
                }
            }
            else
            {
                System.IO.File.Create(Directory.GetCurrentDirectory() + @"\Calibrations.txt");
            }
        }

        private void Update_SimpleTrackImages(object sender, EventArgs e)
        {
            Pen thisPen = new Pen(Color.Red);

            for (int i = 0; i < lSimpleTrackPictureBox.Count; i++)
            {
                Bitmap thisBitmap = (Bitmap)lSimpleTrackPictureBox[i].Image;

                Graphics g = Graphics.FromImage(thisBitmap);
                g.Clear(Color.White);

                for(int t = 0; t < lWebCams[i].FilteredTrackedPoints.TrackedPoints.Count; t++)
                {
                    float X = lWebCams[i].FilteredTrackedPoints.TrackedPoints[t].Points.Select(x=>x.X).Average();
                    float Y = lWebCams[i].FilteredTrackedPoints.TrackedPoints[t].Points.Select(x=>x.Y).Average();

                    X = X / 640.0f * thisBitmap.Width;
                    Y = Y / 480.0f * thisBitmap.Width;
                    g.DrawRectangle(thisPen, X - 5, Y - 5, 10, 10); 
                }

                lSimpleTrackPictureBox[i].Image = thisBitmap;
                g.Dispose();
            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int i = 0; i < spinningTriangleControl.WebCams.Count; i++)
            {
                spinningTriangleControl.WebCams[i].StopWebCam();                
            }
        }

        private int mouseDownX = 0;
        private int mouseDownY = 0;

        void spinningTriangleControl_MouseWheel(object sender, MouseEventArgs e)
        {
            spinningTriangleControl.globalScaling += e.Delta / 800.0f;
        }

        void spinningTriangleControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                spinningTriangleControl.yaw += e.X - mouseDownX;
                spinningTriangleControl.pitch += e.Y - mouseDownY;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                spinningTriangleControl.globalScaling += (e.Y / 800.0f) - (mouseDownY / 800.0f);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                spinningTriangleControl.viewTranslationVector.X += (e.X / 80.0f) - (mouseDownX / 80.0f);
                spinningTriangleControl.viewTranslationVector.Z += (e.Y / 80.0f) - (mouseDownY / 80.0f);
            }

            mouseDownX = e.X;
            mouseDownY = e.Y;
        }

        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtConfigFile.Text = openFileDialog1.FileName;
        }

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            CameraConfig thisConfig = new CameraConfig(txtConfigFile.Text, "Bundler");
            spinningTriangleControl.cameraConfig = thisConfig;
            spinningTriangleControl.Focus();
        }

        private void chkInvertZ_CheckedChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.invertZ = chkInvertZ.Checked;
        }

        private void chkTransposeRot_CheckedChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.transposeRot = chkTransposeRot.Checked;
        }

        private void chkNegateRot_CheckedChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.negateRot = chkNegateRot.Checked;
        }

        private void chkInverseRot_CheckedChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.invertRot = chkInverseRot.Checked;
        }

        private void txtRotAngleX_TextChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.rotAngleX = (float.Parse(txtRotAngleX.Text)) / 3;
        }


        private void txtRotAngleY_TextChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.rotAngleY = (float.Parse(txtRotAngleY.Text) / 360.0f) * 2.0f * (float)System.Math.PI;
        }

        private void txtRotAngleZ_TextChanged(object sender, System.EventArgs e)
        {
            spinningTriangleControl.rotAngleZ = (float.Parse(txtRotAngleZ.Text) / 360.0f) * 2.0f * (float)System.Math.PI;
        }



        //List<VideoCaptureDevice> videoSources = new List<VideoCaptureDevice>();
        //FilterInfoCollection videoDevices;   

        List<string> CamPermutations = new List<string>();

        private void btnTrackStart_Click(object sender, System.EventArgs e)
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            for (int i = 0; i < videoDevices.Count; i++)
            {
                if (videoDevices[i] != null)
                {
                    WebCam thisWebCam = new WebCam(videoDevices[i].MonikerString);
                    spinningTriangleControl.WebCams.Add(thisWebCam);
                }
            }

            List<string> myString = new List<string>();

            for (int i = 0; i < videoDevices.Count; i++)
            {
                myString.Add(i.ToString());
            }

            var result = from a in myString
                            from b in myString
                         from c in myString
                            where a != b && a != c && b != c
                         select a + "," + b + "," + c;

            CamPermutations = result.ToList();

            List<int> temp = CamPermutations[camPerm % 6].Split(',').Select(x => int.Parse(x)).ToList();
            spinningTriangleControl.WebCamPermute = temp;
            camPerm++;

            //spinningTriangleControl.IntersectionLines.Clear();
            //for (int i = 0; i < spinningTriangleControl.WebCams.Count; i++)
            //{
            //    spinningTriangleControl.IntersectionLines.Add(new Line3D());
            //    spinningTriangleControl.trackInCamera.Add(false);
            //}

            //spinningTriangleControl.IntersectionLines = new List<Line3D>();
            //spinningTriangleControl.IntersectionAverage = new List<Point3D>(spinningTriangleControl.WebCams.Count);

        }

        struct clusterPoints
        {
            public double x;
            public double y;
        }

        struct Cluster
        {
            public List<clusterPoints> points;
        }

        int camPerm = 0;

        private void btnCameraPermute_Click(object sender, EventArgs e)
        {
            List<int> temp = CamPermutations[camPerm % 2].Split(',').Select(x => int.Parse(x)).ToList();
            spinningTriangleControl.WebCamPermute = temp;
            camPerm++;
        }

        private void btnClearPaint_Click(object sender, EventArgs e)
        {
            spinningTriangleControl.IntersectionAverage.Clear();
        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            for (int i = 0; i < lWebCams.Count; i++)
            {
                lWebCams[i].thresMag = trackBarThreshold.Value;
            }
        }

        private void trkIntersectionThreshold_Scroll(object sender, EventArgs e)
        {
            spinningTriangleControl.IntersectionThreshold = trkIntersectionThreshold.Value / 1000.0f;
        }

        private void trkClusterThreshold_Scroll(object sender, EventArgs e)
        {
            spinningTriangleControl.ClusterThreshold = trkClusterThreshold.Value / 1000.0f;
        }
        
        private Timer timer1;
        private Timer timerFPS;
        static List<WebCamEye> lWebCams = new List<WebCamEye>();
        static List<WebCamTrack> lCalibTracks = new List<WebCamTrack>();

        private void button1_Click(object sender, EventArgs e)
        {
            WebCamEye thiscam1 = new WebCamEye(0);
            WebCamEye thiscam2 = new WebCamEye(1);
            WebCamEye thiscam3 = new WebCamEye(2);
            WebCamEye thiscam4 = new WebCamEye(3);

            lCalibTracks.Add(new WebCamTrack());
            lCalibTracks.Add(new WebCamTrack());
            lCalibTracks.Add(new WebCamTrack());
            lCalibTracks.Add(new WebCamTrack());

            lWebCams.Add(thiscam1);
            lWebCams.Add(thiscam2);
            lWebCams.Add(thiscam3);
            lWebCams.Add(thiscam4);

            trackBarThreshold.Value = lWebCams[0].thresMag;

            trk2DClusterThreshold.Value = lWebCams[0].ClusterDistance;
        }


        private void grabCalibrationPoint(object sender, EventArgs e)
        {
            bool allCamerasHaveTrack = true;
            foreach (WebCamEye thisWebCam in lWebCams)
            {
                if (thisWebCam.FilteredTrackedPoints.TrackedPoints.Count != 1)
                {
                    allCamerasHaveTrack = false;
                }
                else
                {
                    if (thisWebCam.FilteredTrackedPoints.TrackedPoints[0].Points.Count != 1)
                    {
                        allCamerasHaveTrack = false;
                    }
                }
            }

            if (allCamerasHaveTrack)
            {
                for(int i = 0; i < lWebCams.Count; i++)
                {                
                    lCalibTracks[i].Points.AddRange(lWebCams[i].FilteredTrackedPoints.TrackedPoints[0].Points);
                }

                lblCalibPointsCaptured.Text = "Calib points captured: " + lCalibTracks[0].Points.Count;
                
                    
            }
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            if (txtCalibrationName.Text != "")
            {
                if (!System.IO.Directory.Exists(Directory.GetCurrentDirectory() + @"\Calibrations\" + txtCalibrationName.Text))
                {
                    BundlerCalibrate.Calibrate(lCalibTracks, txtCalibrationName.Text);

                    //Add entry for this calibration into the calibration file:
                    string contents = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\Calibrations.txt");
                    contents += txtCalibrationName.Text + "\r";
                    System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\Calibrations.txt", contents);
                    ReadCalibrationsfile();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("A calibration with this name already exists.");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please enter a name for the calibration.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //for (int i = 0; i < videoDevices.Count; i++)
            //{
            //    if (videoDevices[i] != null)
            //    {
            //        WebCam thisWebCam = new WebCam(videoDevices[i].MonikerString);
            //        spinningTriangleControl.WebCams.Add(thisWebCam);
            //    }
            //}

            CameraConfig thisConfig = new CameraConfig(txtConfigFile.Text, "Bundler");
            spinningTriangleControl.cameraConfig = thisConfig;
            spinningTriangleControl.Focus();

            spinningTriangleControl.WebCamsEye.AddRange(lWebCams);
            

            List<string> myString = new List<string>();

            for (int i = 0; i < lWebCams.Count; i++)
            {
                myString.Add(i.ToString());
            }

            var result = from a in myString
                         from b in myString
                         from c in myString
                         where a != b && b!=c && a!=c
                         select a + "," + b + "," + c;

            CamPermutations = result.ToList();

            List<int> temp = CamPermutations[camPerm % lWebCams.Count].Split(',').Select(x => int.Parse(x)).ToList();
            spinningTriangleControl.WebCamPermute = temp;
            //camPerm++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < lWebCams.Count; i++)
            {
                lWebCams[i].multiPoint = ((CheckBox)sender).Checked;
            }            
        }

        private void trk2DClusterThreshold_Scroll(object sender, EventArgs e)
        {
            for (int i = 0; i < lWebCams.Count; i++)
            {
                lWebCams[i].ClusterDistance = ((TrackBar)sender).Value;
            }   
        }

        private void checkDraw_CheckedChanged(object sender, EventArgs e)
        {
            spinningTriangleControl.AccumulatePoints = checkDraw.Checked;
        }

        private void btnOpenCameraDialog_Click(object sender, EventArgs e)
        {
            if (lstBoxCameras.SelectedIndex != -1)
            {
                for (int i = 0; i < lWebCams.Count; i++)
                {
                    lWebCams[i].Hide();
                }
                lWebCams[lstBoxCameras.SelectedIndex].Show();
            }
        }

        private void btnAutoExposure_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lWebCams.Count; i++)
            {
                lWebCams[i].ExposureCalibrationSuccessFrames = 0;
                lWebCams[i].Exposure = 511;
            }

            System.Threading.Thread.Sleep(1000);

            for (int i = 0; i < lWebCams.Count; i++)
            {
                lWebCams[i].ExposureCalibrationComplete = false;
            }
        }

        private void btnLoadCalibration_Click(object sender, EventArgs e)
        {
            if (lstCalibrations.SelectedIndex != -1)
            {
                CameraConfig thisConfig = new CameraConfig(Directory.GetCurrentDirectory() + "\\Calibrations\\" + CalibrationPaths[lstCalibrations.SelectedIndex] + "\\bundle\\bundle.out", "Bundler");
                spinningTriangleControl.cameraConfig = thisConfig;
                spinningTriangleControl.Focus();

                spinningTriangleControl.WebCamsEye.Clear();
                spinningTriangleControl.WebCamsEye.AddRange(lWebCams);


                trkIntersectionThreshold.Value = (int)Math.Round(spinningTriangleControl.IntersectionThreshold * 1000);
                trkClusterThreshold.Value = (int)Math.Round(spinningTriangleControl.ClusterThreshold * 1000);
            }
        }

        private void btnStartCalibration_Click(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(grabCalibrationPoint);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

    }    
}
