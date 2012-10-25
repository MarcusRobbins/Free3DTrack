using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsGraphicsDevice
{
    public class WebCamEye
    {
        #region [ Camera Parameters ]
        // camera color mode
        public enum CLEyeCameraColorMode
        {
            CLEYE_MONO_PROCESSED,
            CLEYE_COLOR_PROCESSED,
            CLEYE_MONO_RAW,
            CLEYE_COLOR_RAW,
            CLEYE_BAYER_RAW
        };

        // camera resolution
        public enum CLEyeCameraResolution
        {
            CLEYE_QVGA,
            CLEYE_VGA
        };
        // camera parameters
        public enum CLEyeCameraParameter
        {
            // camera sensor parameters
            CLEYE_AUTO_GAIN,			// [false, true]
            CLEYE_GAIN,					// [0, 79]
            CLEYE_AUTO_EXPOSURE,		// [false, true]
            CLEYE_EXPOSURE,				// [0, 511]
            CLEYE_AUTO_WHITEBALANCE,	// [false, true]
            CLEYE_WHITEBALANCE_RED,		// [0, 255]
            CLEYE_WHITEBALANCE_GREEN,	// [0, 255]
            CLEYE_WHITEBALANCE_BLUE,	// [0, 255]
            // camera linear transform parameters
            CLEYE_HFLIP,				// [false, true]
            CLEYE_VFLIP,				// [false, true]
            CLEYE_HKEYSTONE,			// [-500, 500]
            CLEYE_VKEYSTONE,			// [-500, 500]
            CLEYE_XOFFSET,				// [-500, 500]
            CLEYE_YOFFSET,				// [-500, 500]
            CLEYE_ROTATION,				// [-500, 500]
            CLEYE_ZOOM,					// [-500, 500]
            // camera non-linear transform parameters
            CLEYE_LENSCORRECTION1,		// [-500, 500]
            CLEYE_LENSCORRECTION2,		// [-500, 500]
            CLEYE_LENSCORRECTION3,		// [-500, 500]
            CLEYE_LENSBRIGHTNESS		// [-500, 500]
        };
        #endregion

        #region [ CLEyeMulticam Imports ]
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CLEyeGetCameraCount();
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid CLEyeGetCameraUUID(int camId);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CLEyeCreateCamera(Guid camUUID, CLEyeCameraColorMode mode, CLEyeCameraResolution res, float frameRate);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeDestroyCamera(IntPtr camera);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeCameraStart(IntPtr camera);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeCameraStop(IntPtr camera);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeCameraLED(IntPtr camera, bool on);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeSetCameraParameter(IntPtr camera, CLEyeCameraParameter param, int value);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CLEyeGetCameraParameter(IntPtr camera, CLEyeCameraParameter param);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeCameraGetFrameDimensions(IntPtr camera, ref int width, ref int height);
        [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CLEyeCameraGetFrame(IntPtr camera, IntPtr pData, int waitTimeout);
        #endregion

        #region webcam properties
        public bool AutoGain
        {
            get
            {
                if (_camera == null) return false;
                return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_GAIN) != 0;
            }
            set
            {
                if (_camera == null) return;
                CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_GAIN, value ? 1 : 0);
            }
        }
        public int Gain
        {
            get
            {
                if (_camera == null) return 0;
                return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_GAIN);
            }
            set
            {
                if (_camera == null) return;
                CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_GAIN, value);
            }
        }
        public bool AutoExposure
        {
            get
            {
                if (_camera == null) return false;
                return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_EXPOSURE) != 0;
            }
            set
            {
                if (_camera == null) return;
                CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_EXPOSURE, value ? 1 : 0);
            }
        }
        public int Exposure
        {
            get
            {
                if (_camera == null) return 0;
                return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_EXPOSURE);
            }
            set
            {
                if (_camera == null) return;
                CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_EXPOSURE, value);

                //Also upsate the form trakbar
                if (_form != null)
                {
                    if (_form.Visible)
                    {
                        _form.BeginInvoke(
                                (MethodInvoker)delegate()
                                {
                                    _form.trkExposure.Value = value;
                                });
                    }
                }
            }
        }
        public bool AutoWhiteBalance
        {
            get
            {
                if (_camera == null) return true;
                return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_WHITEBALANCE) != 0;
            }
            set
            {
                if (_camera == null) return;
                CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_WHITEBALANCE, value ? 1 : 0);
            }
        }
        public int WhiteBalanceRed
        {
            get
            {
                if (_camera == null) return 0;
                return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_RED);
            }
            set
            {
                if (_camera == null) return;
                CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_RED, value);
            }
        }
        #endregion

        public delegate void trkExposureCallback(int exposureValue);

        public void setExposure(int exposureValue)
        {
            Exposure = exposureValue;
        }

        WebCamForm _form;
        IntPtr _ptrBmpPixels;
        bool _threadRunning;
        ManualResetEvent _exitEvent;
        IntPtr _camera;
        public int CameraID;
        public static int CameraCount { get { return CLEyeGetCameraCount(); } }
        public static Guid CameraUUID(int idx) { return CLEyeGetCameraUUID(idx); }

        Graphics thisGraphics;
        Pen thisPen = new Pen(Color.Red);

        public WebCamTrack CumulativeTrackedPoints = new WebCamTrack();
        public WebCamTracks FilteredTrackedPoints = new WebCamTracks();
        VideoCaptureDevice thisvideoSource;
        public int thresMag = 250;
        public int ClusterDistance = 25;
        public bool ExposureCalibrationComplete;
        public int ExposureCalibrationSuccessFrames = 0;

        public bool multiPoint = false;

        public static int GetNumCameras()
        {
            return CameraCount;
        }

        public WebCamEye(int CameraID)
        {
            _form = new WebCamForm(new trkExposureCallback(setExposure));

            _camera = CLEyeCreateCamera(CameraUUID(CameraID), CLEyeCameraColorMode.CLEYE_MONO_PROCESSED, CLEyeCameraResolution.CLEYE_VGA, 60);
            this.CameraID = CameraID;

            int w = 0, h = 0;

            if (_camera == IntPtr.Zero) return;
            CLEyeCameraGetFrameDimensions(_camera, ref w, ref h);
            CreateBitmap(w, h);
            // create thread exit event
            _exitEvent = new ManualResetEvent(false);
            // start capture here
            ThreadPool.QueueUserWorkItem(Capture);

            //AutoExposure = false;
            //AutoGain = false;
            //AutoWhiteBalance = false;
            _form.trkExposure.Value = Exposure;

            ExposureCalibrationComplete = false;
        }

        public void Show()
        {
            if (_form != null)
            {
                _form = new WebCamForm(new trkExposureCallback(setExposure));
                _form.trkExposure.Value = Exposure;
            }
            _form.TopMost = true;
            _form.Show();
        }

        public void Hide()
        {
            _form.Hide();
        }

        bool CameraEnabled = true;
        public void StartCapture()
        {
            _threadRunning = true;
            //ThreadPool.QueueUserWorkItem(Capture);
        }

        public void StopCapture()
        {
            _threadRunning = false;
        }

        int numFrames = 0;

        // capture thread
        void Capture(object obj)
        {
            _threadRunning = true;
            //Random rng = new Random();
            CLEyeCameraStart(_camera);
            while (_threadRunning)
            {
                if (CLEyeCameraGetFrame(_camera, _ptrBmpPixels, 500))
                {
                    numFrames++;

                    Bitmap bmpIn = new Bitmap(640, 480, 640, PixelFormat.Format8bppIndexed, _ptrBmpPixels);

                    ColorPalette GrayPalette = bmpIn.Palette;
                    for (int i = 0; i < GrayPalette.Entries.Length; i++)
                        GrayPalette.Entries[i] = Color.FromArgb(i, i, i);
                    bmpIn.Palette = GrayPalette;

                    Bitmap converted = new Bitmap(bmpIn.Width, bmpIn.Height, PixelFormat.Format24bppRgb);
                    using (Graphics g = Graphics.FromImage(converted))
                    {
                        // Prevent DPI conversion
                        g.PageUnit = GraphicsUnit.Pixel;
                        // Draw the image
                        g.DrawImageUnscaled(bmpIn, 0, 0);
                    }

                    BitmapData bmd = ((Bitmap)converted).LockBits(new Rectangle(0, 0, converted.Width, converted.Height), ImageLockMode.ReadWrite, converted.PixelFormat);

                    List<int> thresholdxs = new List<int>();
                    List<int> thresholdys = new List<int>();
                    unsafe
                    {
                        int PixelSize = 3;
                        for (int y = 0; y < bmd.Height; y++)
                        {
                            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
                            //byte* backgroundRow = (byte*)backgroundData.Scan0 + (y * backgroundData.Stride);
                            for (int x = 0; x < bmd.Width; x++)
                            {
                                if (thresholdxs.Count < 10000)
                                {
                                    if (row[x * PixelSize] > thresMag)// && row[(x * PixelSize) + 1] > thresMag && row[(x * PixelSize) + 2] > thresMag)
                                    {
                                        //row[x * PixelSize] = 150;
                                        //row[(x * PixelSize) + 1] = 0;
                                        //row[(x * PixelSize) + 2] = 255;
                                        thresholdxs.Add(x);
                                        thresholdys.Add(y);
                                    }
                                }
                            }
                        }
                    }

                    converted.UnlockBits(bmd);

                    if (multiPoint)
                    {
                        WebCamTracks Clusters = new WebCamTracks();

                        int numClusters = 0;
                        //Remove points which are all alone

                        while (thresholdxs.Count > 0)
                        {
                            WebCamTrack newCluster = new WebCamTrack();
                            newCluster.Points.Add(new Point2D { X = thresholdxs[0], Y = thresholdys[0], Magnitude = 0 });

                            int innercount = 1;
                            while (innercount < thresholdxs.Count)
                            {
                                double xdeltasq = Math.Pow(thresholdxs[0] - thresholdxs[innercount], 2);
                                double ydeltasq = Math.Pow(thresholdys[0] - thresholdys[innercount], 2);
                                double distance = Math.Sqrt(xdeltasq + ydeltasq);

                                if (distance < ClusterDistance)
                                {
                                    newCluster.Points.Add(new Point2D { X = thresholdxs[innercount], Y = thresholdys[innercount], Magnitude = 0 });
                                    thresholdxs.RemoveAt(innercount);
                                    thresholdys.RemoveAt(innercount);
                                }
                                else
                                {
                                    innercount++;
                                }
                            }

                            thresholdxs.RemoveAt(0);
                            thresholdys.RemoveAt(0);

                            Clusters.TrackedPoints.Add(newCluster);
                        }

                        Graphics thisGraphics = Graphics.FromImage(converted);
                        Pen thisPen = new Pen(Color.Red);

                        for (int i = 0; i < Clusters.TrackedPoints.Count; i++)
                        {
                            thisGraphics.DrawRectangle(thisPen, ((float)Clusters.TrackedPoints[i].GetCentroid().X - (float)8), (float)(float)Clusters.TrackedPoints[i].GetCentroid().Y - 8, 16, 16);
                        }


                        FilteredTrackedPoints = Clusters;
                    }
                    else
                    {
                        thisGraphics = Graphics.FromImage(converted);

                        float centroidx;
                        float centroidy;

                        if (thresholdxs.Count > 0)
                        {
                            if (ExposureCalibrationComplete)
                            {
                                centroidx = (float)thresholdxs.Average();
                                centroidy = (float)thresholdys.Average();

                                WebCamTrack thisTrack = new WebCamTrack();
                                thisTrack.Points.Add(new Point2D(centroidx, centroidy, 0));
                                thisTrack.CameraID = CameraID;

                                FilteredTrackedPoints.TrackedPoints.Clear();
                                FilteredTrackedPoints.TrackedPoints.Add(thisTrack);

                                CumulativeTrackedPoints.Points.Add(new Point2D(centroidx, centroidy, 0, DateTime.Now));

                                if (_form.Visible == true)
                                {
                                    thisGraphics.DrawRectangle(thisPen, ((float)(float)centroidx - (float)8), (float)centroidy - 8, 16, 16);
                                }
                            }
                            else
                            {
                                if (!ExposureCalibrationComplete)
                                {
                                    if (Exposure - 10 > 0)
                                    {
                                        Exposure = Exposure - 10;
                                    }
                                    else
                                    {
                                        ExposureCalibrationComplete = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            FilteredTrackedPoints.TrackedPoints.Clear();
                            ExposureCalibrationSuccessFrames++;
                            if (ExposureCalibrationSuccessFrames >= 10)
                            {
                                ExposureCalibrationComplete = true;
                                ExposureCalibrationSuccessFrames = 0;
                            }
                        }
                    }

                    try
                    {
                        _form.pictureBox1.Image = converted;
                    }
                    catch(Exception ex)
                    {
                    
                    }
                    _form.pictureBox1.Invalidate();
                }
            }
            CLEyeCameraStop(_camera);
            CLEyeDestroyCamera(_camera);
            _exitEvent.Set();
        }

        void CreateBitmap(int w, int h)
        {
            // allocate bitmap memory
            _ptrBmpPixels = Marshal.AllocHGlobal(w * h);
            // create bitmap object
            Bitmap bmpGraph = new Bitmap(w, h, w, PixelFormat.Format8bppIndexed, _ptrBmpPixels);

            // setup gray-scale palette
            ColorPalette GrayPalette = bmpGraph.Palette;
            for (int i = 0; i < GrayPalette.Entries.Length; i++)
                GrayPalette.Entries[i] = Color.FromArgb(i, i, i);
            bmpGraph.Palette = GrayPalette;

            // set bitmap to the picture box
            _form.pictureBox1.Image = bmpGraph;
        }



    }
}
