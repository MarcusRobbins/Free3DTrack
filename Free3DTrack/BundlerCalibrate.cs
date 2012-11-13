using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace WinFormsGraphicsDevice
{
    class BundlerCalibrate
    {
        static string picdir = "D:\\bundler-v0.3-binary\\examples\\test2";

        static public void Calibrate(List<WebCamTrack> lCalibrationTracks, string CalibName)
        {
            //Get any existing calibrations 

            picdir = Directory.GetCurrentDirectory() + "\\Calibrations\\" + CalibName;

            //Save calibration information

            //Create the directory if necessary
            if (!Directory.Exists(picdir))
            {
                Directory.CreateDirectory(picdir);
            }

            //clear the current directory
            System.IO.DirectoryInfo filesInfo = new DirectoryInfo(picdir);

            foreach (FileInfo file in filesInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in filesInfo.GetDirectories())
            {
                dir.Delete(true);
            }

            while (System.IO.Directory.Exists(picdir + "\\bundle"))
            {

            }

            //Create the bundle directory:
            System.IO.Directory.CreateDirectory(picdir + "\\bundle");

            int numCameras = lCalibrationTracks.Count;
            int imageWidth = 640;
            int imageHeight = 480;
            int numPoints = lCalibrationTracks[0].Points.Count;
            //int numPoints = 50;
            int numSiftHist = 128;

            Random random = new Random();

            List<Double> lYLocation = new List<double>();
            List<Double> lXLocation = new List<double>();

            //Create some sensible test points
            for (int n = 0; n < numPoints; n++)
            {
                double yLocation = Math.Round(random.NextDouble() * imageHeight - 40, 2);
                double xLocation = Math.Round(random.NextDouble() * imageWidth - 40, 2);

                lYLocation.Add(yLocation);
                lXLocation.Add(xLocation);
            }

            //Create x blank images where x is the number of cameras
            for (int i = 0; i < numCameras; i++)
            {
                Bitmap thisImage = new Bitmap(imageWidth, imageHeight);
                thisImage.Save(picdir + "\\" + i.ToString() + ".jpg", ImageFormat.Jpeg);

                //Create the key files

                //Create this key file:
                StringBuilder thisKeys = new StringBuilder();

                //Append the number of points and the dummy number of sift boxes
                thisKeys.AppendLine(numPoints.ToString() + " " + numSiftHist);

                for (int t = 0; t < numPoints; t++)
                {
                    //double yLocation = Math.Round(random.NextDouble() * imageHeight, 2);
                    //double xLocation = Math.Round(random.NextDouble() * imageWidth, 2);

                    //double yLocation = (lYLocation[t] + (i * 5));
                    //double xLocation = (lXLocation[t] + (i * 5));


                    double yLocation;
                    double xLocation;

                    xLocation = Math.Round(lCalibrationTracks[i].Points[t].X, 2);
                    yLocation = Math.Round(lCalibrationTracks[i].Points[t].Y, 2);

                    double rnd1 = Math.Round(random.NextDouble() * 20, 2);
                    double rnd2 = Math.Round(random.NextDouble() * 20, 2);

                    //thisKeys.AppendLine(yLocation.ToString() + " " + xLocation.ToString() + " " + rnd1.ToString() + " " + rnd2.ToString());

                    thisKeys.AppendLine(yLocation.ToString() + " " + xLocation.ToString() + " " + rnd1.ToString() + " " + rnd2.ToString());

                    for (int s = 0; s < numSiftHist; s++)
                    {
                        thisKeys.Append(" ");

                        int tempRand = random.Next(128);
                        thisKeys.Append(tempRand.ToString());

                        if (s % 20 == 0 && s != 0)
                        {
                            thisKeys.Append("\r\n");
                        }
                        else if (s == numSiftHist - 1)
                        {
                            thisKeys.Append("\r\n");
                        }
                    }
                }

                System.IO.File.WriteAllText(picdir + "\\" + i.ToString() + ".key", thisKeys.ToString());
            }

            //Create the matches file:
            StringBuilder matchesInit = new StringBuilder();
            for (int a = 0; a < numCameras; a++)
            {
                for (int b = 0; b < numCameras; b++)
                {
                    if (a != b)
                    {
                        //For each camera pair add the matches
                        //simple in this case because we know all the points match in thier initial order
                        matchesInit.AppendLine(a.ToString() + " " + b.ToString());
                        matchesInit.AppendLine(numPoints.ToString());

                        for (int c = 0; c < numPoints; c++)
                        {
                            matchesInit.AppendLine(c.ToString() + " " + c.ToString());
                        }
                    }
                }
            }
            System.IO.File.WriteAllText(picdir + "\\" + "matches.init.txt", matchesInit.ToString());

            //Create the list file, which shows all of the images
            StringBuilder list = new StringBuilder();
            for (int i = 0; i < numCameras; i++)
            {
                //./kermit000.jpg 0 660.80306
                list.AppendLine("./" + i.ToString() + ".jpg 0 768");
            }
            System.IO.File.WriteAllText(picdir + "\\" + "list.txt", list.ToString());

            //Creatre the options file:
            StringBuilder options = new StringBuilder();
            options.AppendLine("--match_table matches.init.txt");
            options.AppendLine("--output bundle.out");
            options.AppendLine("--output_all bundle_");
            options.AppendLine("--output_dir bundle");
            options.AppendLine("--variable_focal_length");
            options.AppendLine("--use_focal_estimate");
            options.AppendLine("--constrain_focal");
            options.AppendLine("--constrain_focal_weight 0.0001");
            options.AppendLine("--estimate_distortion");
            options.AppendLine("--run_bundle");
            System.IO.File.WriteAllText(picdir + "\\" + "options.txt", options.ToString());

            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = true;
            //p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WorkingDirectory = picdir;
            p.StartInfo.FileName = Directory.GetCurrentDirectory() + @"\bundler.exe"; //@"D:\bundler-v0.3-binary\bin\bundler.exe";
            p.StartInfo.Arguments = "list.txt --options_file options.txt";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            //string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Process pm = new Process();
            // Redirect the output stream of the child process.
            pm.StartInfo.UseShellExecute = true;
            //p.StartInfo.RedirectStandardOutput = true;
            pm.StartInfo.WorkingDirectory = picdir;
            pm.StartInfo.FileName = @"C:\Program Files (x86)\VCG\MeshLab\meshlab.exe";

            if (numCameras != 2)
            {
                pm.StartInfo.Arguments = picdir + @"\bundle\points00" + numCameras + ".ply";
            }
            else
            {
                pm.StartInfo.Arguments = picdir + @"\bundle\points001.ply";
            }

            pm.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            //string output = p.StandardOutput.ReadToEnd();
            //pm.WaitForExit();

        }
    }
}
