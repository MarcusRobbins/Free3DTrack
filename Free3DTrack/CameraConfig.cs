using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WinFormsGraphicsDevice
{
    class CameraConfig
    {
        public string ConfigFile { get; set; }

        public List<RegisteredCamera> Cameras = new List<RegisteredCamera>();

        public CameraMatches modelPoints = new CameraMatches();

        public CameraConfig(string configFile, string configtype)
        {
            ConfigFile = configFile;
            CreateFromFile(ConfigFile, configtype);
        }

        private void CreateFromFile(string configFile, string configtype)
        {
            switch (configtype)
            { 
                case ConfigFileType.Bundler:
                    CreateFromBundlerFile(configFile);
                    break;
            }
        }

        private void CreateFromBundlerFile(string configFile)
        {
            string text = System.IO.File.ReadAllText(configFile);
            string[] lines = text.Split('\r');


            int numCameras = int.Parse(lines[1].Split(' ')[0]);
            int numPoints = int.Parse(lines[1].Split(' ')[1]);

            for (int i = 0; i < numCameras; i++)
            {
                //Extract the focal length and the radial distrortion cooefficients
                string[] line1split = lines[2 + i*5].Split(' ');
                float focalLength = float.Parse(line1split[0]);
                float k1 = float.Parse(line1split[1]);
                float k2 = float.Parse(line1split[2]);

                //Camera Rotation matrix
                //m1, m2, m3
                //m4, m5, m6
                //m7, m8, m9

                string[] line2split = lines[3 + i * 5].Split(' ');
                float m1 = float.Parse(line2split[0]);
                float m2 = float.Parse(line2split[1]);
                float m3 = float.Parse(line2split[2]);

                string[] line3split = lines[4 + i * 5].Split(' ');
                float m4 = float.Parse(line3split[0]);
                float m5 = float.Parse(line3split[1]);
                float m6 = float.Parse(line3split[2]);

                string[] line4split = lines[5 + i * 5].Split(' ');
                float m7 = float.Parse(line4split[0]);
                float m8 = float.Parse(line4split[1]);
                float m9 = float.Parse(line4split[2]);

                //Camera Translation Matrix
                string[] line5split = lines[6 + i * 5].Split(' ');
                float t1 = float.Parse(line5split[0]);
                float t2 = float.Parse(line5split[1]);
                float t3 = float.Parse(line5split[2]);

                //Create the new camera and store:
                Matrix RotationMatrix = new Matrix(m1, m2, m3, 0, m4, m5, m6, 0, m7, m8, m9, 0, 0, 0 , 0, 1);
                Vector3 TranslationVector = new Vector3(t1, t2, t3);
                RegisteredCamera thisCamera = new RegisteredCamera(focalLength, k1, k2, RotationMatrix, TranslationVector, 480, 640);
                //thisCamera.TrackedPoints.Add(new TrackedImagePoint(320, 240));
                //thisCamera.TrackedPoints.Add(new TrackedImagePoint(320, -240));
                //thisCamera.TrackedPoints.Add(new TrackedImagePoint(-320, 240));
                //thisCamera.TrackedPoints.Add(new TrackedImagePoint(-320, -240));
                //thisCamera.TrackedPoints.Add(new TrackedImagePoint(0, 0));

                //Add some matched image points, to check the calibration...
                System.IO.DirectoryInfo thisDIR = System.IO.Directory.GetParent(configFile);
                System.IO.DirectoryInfo upDIR = System.IO.Directory.GetParent(thisDIR.ToString());

                string sDIR = upDIR.ToString();
                string keyText = System.IO.File.ReadAllText(sDIR + "\\" + i + ".key");

                string[] keyLines = keyText.Split('\r');

                for (int y = 0; y < 20; y++)
                {
                    string[] matchcoords = keyLines[1+(y*8)].Split(' ');
                    float matchY = float.Parse(matchcoords[0]);
                    float matchX = 640 - float.Parse(matchcoords[1]);
                    thisCamera.TrackedPoints.Add(new TrackedImagePoint(matchX, matchY));
                }

                Cameras.Add(thisCamera);
            }

            int startLine = 1 + 6 + (numCameras - 1) * 5;
            CameraMatches cameraMatches = new CameraMatches();

            //Get the model points
            for (int i = 0; i < numPoints; i++)
            {
                string[] linesplit = lines[startLine + i * 3].Split(' ');
                float x = float.Parse(linesplit[0]);
                float y = float.Parse(linesplit[1]);
                float z = float.Parse(linesplit[2]);
                Point3D thisPoint = new Point3D(x, y, z);
                cameraMatches.points.Add(thisPoint);
            }

            modelPoints = cameraMatches;
        }
    }
}

struct ConfigFileType
{
    public const string Bundler = "Bundler";
}