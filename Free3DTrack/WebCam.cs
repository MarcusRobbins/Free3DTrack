using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing;
using System.Drawing.Imaging;

namespace WinFormsGraphicsDevice
{
    class WebCam
    {
        WebCamTracks TrackedPoints = new WebCamTracks();
        public WebCamTracks FilteredTrackedPoints = new WebCamTracks();
        VideoCaptureDevice thisvideoSource;
        public int thresMag = 200;

        public WebCam(string VideoDeviceMoniker)
        {
            thisvideoSource = new VideoCaptureDevice(VideoDeviceMoniker);

            thisvideoSource.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
            thisvideoSource.DesiredFrameRate = 60;
            thisvideoSource.Start();
        }

        public void StopWebCam()
        {
            thisvideoSource.Stop();
            thisvideoSource.WaitForStop();
        }

        void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();

            //Graphics thisGraphics = Graphics.FromImage(img);
            //Pen thisPen = new Pen(Color.Red);




            //Remove first frame from all subsequent ones:

            //Update the appropriate coordinates/images
            //Bitmap background = new Bitmap(img.Width, img.Height);
            //for (int it = 0; it < videoDevices.Count; it++)
            //{
            //    var inneri = it;
            //    if (videoDevices[inneri] != null)
            //    {
            //        if (((VideoCaptureDevice)sender).Source.Equals(videoDevices[inneri].MonikerString))
            //        {
            //            if (firstFrame[inneri])
            //            {
            //                firstFrame[inneri] = false;
            //                initImages[inneri] = img;
            //                return;
            //            }
            //            background = initImages[inneri];                      
            //        }
            //    }
            //}


            //BitmapData backgroundData = background.LockBits(new Rectangle(0, 0, background.Width, background.Height), ImageLockMode.ReadWrite, background.PixelFormat);
            BitmapData bmd = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);

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
                            if (row[x * PixelSize] > thresMag && row[(x * PixelSize) + 1] > thresMag && row[(x * PixelSize) + 2] > thresMag)
                            {
                                thresholdxs.Add(x);
                                thresholdys.Add(y);
                            }
                        }
                    }
                }
            }

            img.UnlockBits(bmd);
            img.Dispose();

            //background.UnlockBits(backgroundData);

            WebCamTracks Clusters = new WebCamTracks();
            int numClusters = 0;
            //Remove points which are all alone

            while (thresholdxs.Count > 0)
            {
                WebCamTrack newCluster = new WebCamTrack();
                newCluster.Points.Add(new Point2D { X = 640 - thresholdxs[0], Y = thresholdys[0], Magnitude = 0 });

                int innercount = 1;
                while (innercount < thresholdxs.Count)
                {
                    double xdeltasq = Math.Pow(thresholdxs[0] - thresholdxs[innercount], 2);
                    double ydeltasq = Math.Pow(thresholdys[0] - thresholdys[innercount], 2);
                    double distance = Math.Sqrt(xdeltasq + ydeltasq);

                    if (distance < 25)
                    {
                        newCluster.Points.Add(new Point2D { X = 640 - thresholdxs[innercount], Y = thresholdys[innercount], Magnitude = 0 });
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

                //if(newCluster.points

                Clusters.TrackedPoints.Add(newCluster);
            }

            //for (int i = 0; i < indexesToRemove.Count; i++)
            //{
            //    thresholdxs.RemoveAt(indexesToRemove[indexesToRemove.Count - i - 1]);
            //    thresholdys.RemoveAt(indexesToRemove[indexesToRemove.Count - i - 1]);
            //}

            ////Remove naughty clusters
            //List<int> indexsToRemove = new List<int>();
            //for (int p = 0; p < clustersToRemove.Count; p++)
            //{
            //    for (int q = 0; q < Clusters.Count; q++)
            //    {
            //        float clustcentroidx = (float)Clusters[q].points.Select(x => x.x).Sum() / (float)Clusters[q].points.Count;
            //        float clustcentroidy = (float)Clusters[q].points.Select(x => x.y).Sum() / (float)Clusters[q].points.Count;

            //        double xdeltasq = Math.Pow(clustersToRemove[p].x - clustcentroidx, 2);
            //        double ydeltasq = Math.Pow(clustersToRemove[p].y - clustcentroidy, 2);
            //        double distance = Math.Sqrt(xdeltasq + ydeltasq);

            //        if (distance < 50)
            //        {
            //            indexsToRemove.Add(q);
            //        }
            //    }
            //}
            //indexsToRemove = indexsToRemove.GroupBy(x => x).Select(y => y.First()).ToList();
            //indexsToRemove.Sort();
            //for (int p = 0; p < indexsToRemove.Count; p++)
            //{
            //    Clusters.RemoveAt(indexsToRemove[indexsToRemove.Count - p - 1]);
            //}

            //find the largest cluster:   

            double lcentroidx = -1;
            double lcentroidy = -1;

            //Apply the filter:

            TrackerMagnitude newTracker = new TrackerMagnitude(Clusters);

            //if (newTracker.FilteredTracks.TrackedPoints.Count > 0)
            //{

            if (Clusters.TrackedPoints.Count > 0)
            {

                int maxCount = 0;
                int maxIndex = -1;

                FilteredTrackedPoints = Clusters;
                //FilteredTrackedPoints = newTracker.FilteredTracks;

                //for (int i = 0; i < Clusters.TrackedPoints.Count; i++)
                //{
                //    if (Clusters.TrackedPoints[i].Points.Count > maxCount)
                //    {
                //        maxCount = Clusters.TrackedPoints[i].Points.Count;
                //        maxIndex = i;
                //    }
                //}

                //WebCamTrack maxCluster = Clusters.TrackedPoints[maxIndex];



                //if (maxCluster.Points.Count > 1)
                //{
                //    lcentroidx = (float)maxCluster.Points.Select(x => x.X).Sum() / (float)maxCluster.Points.Count;
                //    lcentroidy = (float)maxCluster.Points.Select(x => x.Y).Sum() / (float)maxCluster.Points.Count;
                //}

                //if (lcentroidx != -1 && lcentroidy != -1)
                //{



                //    //float centroidx = (float)lcentroidx;
                //    //float centroidy = (float)lcentroidy;

                //    //for (int i = 0; i < videoDevices.Count; i++)
                //    //{
                //    //    if (videoDevices[i] != null)
                //    //    {
                //    //        if (((VideoCaptureDevice)sender).Source.Equals(videoDevices[i].MonikerString))
                //    //        {
                //    //            spinningTriangleControl.cameraConfig.Cameras[i].TrackedPoints.Clear();
                //    //            spinningTriangleControl.cameraConfig.Cameras[i].TrackedPoints.Add(new TrackedImagePoint(640 - centroidx, centroidy));
                //    //        }
                //    //    }
                //    //}
                //}
                //else
                //{
                //    //for (int i = 0; i < videoDevices.Count; i++)
                //    //{
                //    //    if (videoDevices[i] != null)
                //    //    {
                //    //        if (((VideoCaptureDevice)sender).Source.Equals(videoDevices[i].MonikerString))
                //    //        {
                //    //            spinningTriangleControl.cameraConfig.Cameras[i].TrackedPoints.Clear();
                //    //            //spinningTriangleControl.cameraConfig.Cameras[i].TrackedPoints.Add(new TrackedImagePoint(centroidx, centroidy));
                //    //        }
                //    //    }
                //    //}
                //}
            }
            else 
            {
                FilteredTrackedPoints.TrackedPoints.Clear();
            }

            ////Update the appropriate coordinates/images
            //for (int it = 0; it < videoDevices.Count; it++)
            //{
            //    var inneri = it;
            //    if (videoDevices[inneri] != null)
            //    {
            //        if (((VideoCaptureDevice)sender).Source.Equals(videoDevices[inneri].MonikerString))
            //        {

            //            counters[inneri]++;
            //            this.BeginInvoke(
            //            (MethodInvoker)delegate()
            //            {
            //                ((TextBox)(this.Controls.Find("txtbox" + inneri, true).First())).Text = lcentroidx.ToString() + ", " + lcentroidy.ToString();
            //                ((PictureBox)(this.Controls.Find("pictureBox" + inneri, true).First())).Image = img;
            //                //pictureBox1.Image = img;
            //            });
            //        }
            //    }
            //}

            //thisGraphics.Dispose();

            //pictureBox1.Image = img;
        }


    }
}
