#region File Description
//-----------------------------------------------------------------------------
// SpinningTriangleControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
#endregion

namespace WinFormsGraphicsDevice
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to draw animating
    /// 3D graphics inside a WinForms application. It hooks the Application.Idle
    /// event, using this to invalidate the control, which will cause the animation
    /// to constantly redraw.
    /// </summary>
    class SpinningTriangleControl : GraphicsDeviceControl
    {
        BasicEffect effect;
        Stopwatch timer;


        // Vertex positions and colors used to display a spinning triangle.
        public readonly VertexPositionColor[] Vertices =
        {
            new VertexPositionColor(new Vector3(-0.1f, -0.1f, 0), Color.Black),
            new VertexPositionColor(new Vector3( 0.1f, -0.1f, 0), Color.Black),
            new VertexPositionColor(new Vector3( 0,  0.1f, 0), Color.Black),
        };

        // Vertex positions and colors used to display a spinning triangle.
        public readonly VertexPositionColor[] Vertices2 =
        {
            new VertexPositionColor(new Vector3(0, -0.1f, -0.1f), Color.Black),
            new VertexPositionColor(new Vector3( 0, -0.1f, 0.1f), Color.Black),
            new VertexPositionColor(new Vector3( 0,  0.1f, 0), Color.Black),
        };

        // Vertex positions and colors used to display a spinning triangle.
        public readonly VertexPositionColor[] Vertices3 =
        {
            new VertexPositionColor(new Vector3(-0.1f, 0, -0.1f), Color.Black),
            new VertexPositionColor(new Vector3( -0.1f, 0, 0.1f), Color.Black),
            new VertexPositionColor(new Vector3( 0.1f, 0, 0), Color.Black),
        };

        public CameraConfig cameraConfig;

        public float yaw { get; set; }
        public float pitch { get; set; }
        public float roll { get; set; }

        public float dragSensitivity { get; set; }

        public float cameraModelScaling { get; set; }
        public float globalScaling { get; set; }

        public List<WebCam> WebCams = new List<WebCam>();
        public List<WebCamEye> WebCamsEye = new List<WebCamEye>();
        
        public List<int> WebCamPermute;

        public bool AccumulatePoints = false;

        public ServiceContainer Services
        {
            get { return services; }
        }

        ServiceContainer services = new ServiceContainer();

        List<Model> models = new List<Model>();
        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            //new Microsoft.Xna.Framework.Content.ContentReader();
            //IServiceProvider sc = new ServiceContainer();

            //IGraphicsDeviceService gs = (IGraphicsDeviceService)Services.GetService(typeof(GraphicsDeviceService));

            services.AddService<IGraphicsDeviceService>(graphicsDeviceService);

            string folder = @"C:\Users\MRobbins\Dropbox\XNAWinformsExample\WinFormsGraphicsDevice\Content\";
            List<Texture2D> textures = new List<Texture2D>();
            
            ContentManager content = new ContentManager(services, folder);
            //string[] files = Directory.GetFiles(folder, "*.fbx");
            //foreach (string file in files)
            //{
            //    string assetName = Path.GetFileNameWithoutExtension(file);
            //    //textures.Add(content.Load<Texture2D>(assetName));
            //    models.Add(content.Load<Model>(assetName));
            //}

            content.RootDirectory = "Content";

            //models.Add(content.Load<Model>("tree_curvedBack_02"));
            models.Add(content.Load<Model>("maison2"));
            models.Add(content.Load<Model>("quarto01-cycles_2.63"));
            models.Add(content.Load<Model>("green_int"));
            models.Add(content.Load<Model>("model"));
            models.Add(content.Load<Model>("plum blossom in glass cup_fbx"));
            models.Add(content.Load<Model>("eurofighter"));
            models.Add(content.Load<Model>("L200-FBX"));
            
            

            //myModel = Microsoft.Xna.Framework.Content.ContentReader<Model>.Load<Model>("Models\\p1_wedge");

            // Create our effect.
            effect = new BasicEffect(GraphicsDevice);

            effect.VertexColorEnabled = true;

            yaw = 0;
            pitch = 0;
            roll = 0;
            dragSensitivity = 0.01f;
            cameraModelScaling = 1.0f;
            globalScaling = 1.0f;

            // Start the animation timer.
            timer = Stopwatch.StartNew();

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Font1 = Microsoft.Xna.Framework.Content.ContentManager.Load<SpriteFont>("Courier New");
            //SpriteFont font = Microsoft.Xna.Framework.Content.Load(”Georgia”);
            //IServiceProvider sc = new ServiceContainer();
            //ContentManager cm = new ContentManager(sc, "D:\\stuff\\XNAWinformsExample\\WinFormsGraphicsDevice\\Content\\");
            //Font1 = cm.Load<SpriteFont>("hudFont");

            // TODO: Load your game content here            
            //FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
            //    graphics.GraphicsDevice.Viewport.Height / 2);
        }
        SpriteBatch spriteBatch;
        SpriteFont Font1;

        Matrix ViewMatrix;

        public float ModelX = 0.0f;
        public float ModelY = 0.0f;
        public float ModelZ = 0.0f;
        public bool ShowModel = false;

        public float customUpX = 0;
        public float customUpY = 1;
        public float customUpZ = 0;

        public bool IRLocationRender = false;
        public bool ViewTrackModel = true;

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            if (cameraConfig != null)
            {
                float averageX = cameraConfig.Cameras.Select(x => x.PositionVector.X).Average();
                float averageY = cameraConfig.Cameras.Select(x => x.PositionVector.Y).Average();
                float averageZ = cameraConfig.Cameras.Select(x => x.PositionVector.Z).Average();

                if (IRLocationRender)
                {
                    //ViewMatrix = Matrix.CreateTranslation(-currentTrackX, -currentTrackY, -currentTrackZ);
                    //ViewMatrix = ViewMatrix;// * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, roll * dragSensitivity, pitch * dragSensitivity);
                    ViewMatrix = Matrix.Identity;

                    if (ViewTrackModel)
                    {
                        ViewMatrix = ViewMatrix * Matrix.CreateLookAt(new Vector3(currentTrackX, currentTrackY, currentTrackZ), new Vector3(ModelX, ModelY, ModelZ), new Vector3(customUpX, customUpY, customUpZ));
                    }
                    else 
                    {
                        ViewMatrix = Matrix.CreateTranslation(-currentTrackX, -currentTrackY, -currentTrackZ);
                        ViewMatrix = ViewMatrix * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, roll * dragSensitivity, pitch * dragSensitivity);
                    }

                }
                else
                {
                    ViewMatrix = Matrix.CreateTranslation(-averageX, -averageY, -averageZ);
                    ViewMatrix = ViewMatrix * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, roll * dragSensitivity, pitch * dragSensitivity);
                    ViewMatrix = ViewMatrix * Matrix.CreateTranslation(0, 0, -(5 * globalScaling));// *Matrix.CreateReflection(new Plane(new Vector4(1, 1, 0, 0)));
                }
                GraphicsDevice.Clear(Color.CornflowerBlue);

                try
                {
                    if (cameraConfig != null)
                    {
                        IntersectionLines.Clear();

                        for (int i = 0; i < cameraConfig.Cameras.Count; i++)
                        {
                            RegisteredCamera thisCamera = cameraConfig.Cameras[i];
                            drawCamera(thisCamera);
                            //drawCamera2(thisCamera);
                            drawRays(thisCamera, i);
                        }
                        //drawPoints(cameraConfig);
                        drawIntersections();
                        if (ShowModel)
                        {
                            drawModel(ModelX, ModelY, ModelZ);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        List<Point3D> pathPoints = new List<Point3D>();

        private void drawPath()
        {
            for (int i = 0; i < pathPoints.Count; i++)
            {
                Vector3 pointTranslationVector = new Vector3(pathPoints[i].X, pathPoints[i].Y, pathPoints[i].Z);

                // Set transform matrices.
                float aspect = GraphicsDevice.Viewport.AspectRatio;

                effect.World = Matrix.Identity * Matrix.CreateScale(cameraModelScaling * 0.4f);

                effect.World = effect.World * Matrix.CreateTranslation(pointTranslationVector) * Matrix.CreateTranslation(viewTranslationVector);

                //effect.World = effect.World * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity);

                //effect.World = effect.World * Matrix.CreateScale(globalScaling);

                effect.View = Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity) * Matrix.CreateLookAt(new Vector3(0, 0, -5 * globalScaling),
                                                  Vector3.Zero, Vector3.Up);

                effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);

                // Set renderstates.
                GraphicsDevice.RasterizerState = RasterizerState.CullNone;

                // Draw the triangle.
                effect.CurrentTechnique.Passes[0].Apply();

                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                                  Vertices, 0, 1);

            }
        }

        public Vector3 viewTranslationVector = new Vector3(0, 0, 0);

        private void drawPoints(CameraConfig thisCamera)
        {
            for (int i = 0; i < thisCamera.modelPoints.points.Count; i++)
            {
                Vector3 pointTranslationVector = new Vector3(thisCamera.modelPoints.points[i].X, thisCamera.modelPoints.points[i].Y, thisCamera.modelPoints.points[i].Z);

                // Set transform matrices.
                float aspect = GraphicsDevice.Viewport.AspectRatio;

                effect.World = Matrix.Identity * Matrix.CreateScale(cameraModelScaling * 0.4f);

                effect.World = effect.World * Matrix.CreateTranslation(pointTranslationVector) * Matrix.CreateTranslation(viewTranslationVector);

                //effect.World = effect.World * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity);

                //effect.World = effect.World * Matrix.CreateScale(globalScaling);

                effect.View = Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity) * Matrix.CreateLookAt(new Vector3(0, 0, -5 * globalScaling),
                                                  Vector3.Zero, Vector3.Up);

                effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);

                // Set renderstates.
                GraphicsDevice.RasterizerState = RasterizerState.CullNone;

                // Draw the triangle.
                effect.CurrentTechnique.Passes[0].Apply();

                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                                  Vertices, 0, 1);

            }
        }

        private void drawCamera2(RegisteredCamera thisCamera)
        {
            // Set transform matrices.
            float aspect = GraphicsDevice.Viewport.AspectRatio;

            effect.World = Matrix.CreateScale(cameraModelScaling) * thisCamera.RotationMatrix;

            effect.World = effect.World * Matrix.CreateTranslation(thisCamera.TranslationVector);

            effect.World = effect.World * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity);

            effect.World = effect.World * Matrix.CreateScale(globalScaling);

            effect.View = Matrix.CreateLookAt(new Vector3(0, 0, -5),
                                              Vector3.Zero, Vector3.Up);

            effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);

            // Set renderstates.
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            // Draw the triangle.
            effect.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                              Vertices, 0, 1);
        }

        private void drawCamera(RegisteredCamera thisCamera)
        {
            // Set transform matrices.
            float aspect = GraphicsDevice.Viewport.AspectRatio;

            effect.World = Matrix.Identity; //Matrix.CreateScale(cameraModelScaling) * thisCamera.RotationMatrix;

            effect.World = effect.World * Matrix.CreateTranslation(thisCamera.PositionVector);// *Matrix.CreateTranslation(viewTranslationVector);

            //effect.World = effect.World * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity);

            //effect.World = effect.World * Matrix.CreateScale(globalScaling);

            //effect.View = Matrix.CreateLookAt(new Vector3(0, 0, -5),
            //                                  Vector3.Zero, Vector3.Up);

            effect.View = ViewMatrix; //Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity) * Matrix.CreateLookAt(new Vector3(0, 0, -5 * globalScaling),
                          //                    Vector3.Zero, Vector3.Up);


            effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);

            // Set renderstates.
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            // Draw the triangle.
            effect.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                              Vertices, 0, 1);
        }

        public bool negateRot = false;
        public bool invertRot = false;
        public bool invertZ = false;
        public bool transposeRot = false;
        public float rotAngleX = 0.0f;
        public float rotAngleY = 0.0f;
        public float rotAngleZ = 0.0f;

        private void drawRays(RegisteredCamera thisCamera, int i)
        {
            //for each tracked point project from the camera centre to the point:

            float aspect = GraphicsDevice.Viewport.AspectRatio;

            effect.World = Matrix.Identity * Matrix.CreateTranslation(viewTranslationVector);

            //effect.World = effect.World * Matrix.CreateTranslation(thisCamera.PositionVector);

            //effect.World = effect.World * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity);

            //effect.World = effect.World * Matrix.CreateScale(globalScaling);

            //effect.View = Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity) * Matrix.CreateLookAt(new Vector3(0, 0, -5 * globalScaling),
            //                                  Vector3.Zero, Vector3.Up);

            effect.View = ViewMatrix;

            effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);

            

            //for (int i = 0; i < thisCamera.TrackedPoints.Count; i++)
            //{

            //int i = (int)rotAngleX;
            //if (i < thisCamera.TrackedPoints.Count)
            //{


            //TrackedImagePoint thisPoint = thisCamera.TrackedPoints[i];
            int testy = 0;

            //if (WebCamPermute != null)
            //{
                //int thisCamIndex = WebCamPermute[i];
            int thisCamIndex = i;

                if (thisCamIndex < WebCamsEye.Count)
                {
                    if (WebCamsEye[thisCamIndex].FilteredTrackedPoints != null)
                    {
                        if (WebCamsEye[thisCamIndex].FilteredTrackedPoints.TrackedPoints != null)
                        {
                            if (WebCamsEye[thisCamIndex].FilteredTrackedPoints.TrackedPoints.Count > 0)
                            {
                                //if (WebCamPermute.Count > 0)
                               // {
                                    try
                                    {
                                        for (int r = 0; r < WebCamsEye[thisCamIndex].FilteredTrackedPoints.TrackedPoints.Count; r++)
                                        {
                                            WebCamTrack thisTrack = WebCamsEye[thisCamIndex].FilteredTrackedPoints.TrackedPoints[r];

                                            if (thisTrack.Points.Count > 0)
                                            {
                                                Vector3 WordCoordinates = thisCamera.ImageToWorld(thisTrack.Points.Select(x => x.X).Average(), thisTrack.Points.Select(x => x.Y).Average(), -100, transposeRot, negateRot, invertRot, invertZ, rotAngleX, rotAngleY, rotAngleZ);
                                                //Vector3 WordCoordinates = thisCamera.ImageToWorld(thisTrack.Points[0].X, thisTrack.Points[0].Y, -100, transposeRot, negateRot, invertRot, invertZ, rotAngleX, rotAngleY, rotAngleZ);

                                                Vector3 startPoint = new Vector3(thisCamera.PositionVector.X, thisCamera.PositionVector.Y, thisCamera.PositionVector.Z);
                                                Vector3 endPoint = new Vector3(WordCoordinates.X, (float)WordCoordinates.Y, (float)WordCoordinates.Z);

                                                //trackInCamera.Add(thisCamIndex);
                                                IntersectionLines.Add(new Line3D { LineStart = new Point3D(startPoint.X, startPoint.Y, startPoint.Z), LineEnd = new Point3D(endPoint.X, endPoint.Y, endPoint.Z) });

                                                effect.CurrentTechnique.Passes[0].Apply();
                                                var vertices = new[] { new VertexPositionColor(startPoint, Microsoft.Xna.Framework.Color.Red), new VertexPositionColor(endPoint, Microsoft.Xna.Framework.Color.Red) };
                                                effect.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertices, 0, 1);
                                            }
                                            else
                                            {
                                                //trackInCamera[thisCamIndex] = false;
                                            }
                                        }
                                    }
                                    catch (Exception test)
                                    {
                                        testy = 1;
                                    }
                                    return;
                                //}
                            }
                            else
                            {
                                //trackInCamera[thisCamIndex] = false;
                            }
                        }
                    }
                //}
                //IntersectionLines[thisCamIndex].Displ
            }
        }

        //public List<bool> trackInCamera = new List<bool>();

        public List<Line3D> IntersectionLines = new List<Line3D>();
        public List<Point3D> IntersectionAverage = new List<Point3D>();

        //0.00512
        public float IntersectionThreshold = 0.05f;
        //0.0058
        public float ClusterThreshold = 0.05f;

        private void drawIntersections()
        {
            //IntersectionAverage.Clear();

            List<Point3D> thisIntersectionAverage = new List<Point3D>();

            for (int s = 0; s < IntersectionLines.Count; s++)
            {
                for (int d = 0; d < IntersectionLines.Count; d++)
                {
                    if (IntersectionLines[s].LineStart != null && IntersectionLines[d].LineStart != null && s != d)// && trackInCamera[d] && trackInCamera[s])
                    {
                        //Find shortest line between each line pair:
                        Vector3 firstLineStart = new Vector3(IntersectionLines[s].LineStart.X, IntersectionLines[s].LineStart.Y, IntersectionLines[s].LineStart.Z);
                        Vector3 firstLineEnd = new Vector3(IntersectionLines[s].LineEnd.X, IntersectionLines[s].LineEnd.Y, IntersectionLines[s].LineEnd.Z);
                        Vector3 secondLineStart = new Vector3(IntersectionLines[d].LineStart.X, IntersectionLines[d].LineStart.Y, IntersectionLines[d].LineStart.Z);
                        Vector3 secondLineEnd = new Vector3(IntersectionLines[d].LineEnd.X, IntersectionLines[d].LineEnd.Y, IntersectionLines[d].LineEnd.Z);

                        Vector3 shortestLineStart;
                        Vector3 shortestLineEnd;

                        CalculateLineLineIntersection(firstLineStart, firstLineEnd, secondLineStart, secondLineEnd, out shortestLineStart, out shortestLineEnd);

                        Vector3 startPoint = new Vector3(shortestLineStart.X, shortestLineStart.Y, shortestLineStart.Z);
                        Vector3 endPoint = new Vector3(shortestLineEnd.X, shortestLineEnd.Y, shortestLineEnd.Z);

                        effect.CurrentTechnique.Passes[0].Apply();
                        var vertices = new[] { new VertexPositionColor(startPoint, Microsoft.Xna.Framework.Color.Red), new VertexPositionColor(endPoint, Microsoft.Xna.Framework.Color.Red) };
                        //basicEffect.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertices, 0, 1);

                        float lineLength = (shortestLineStart - shortestLineEnd).Length();

                        
                        if (lineLength < IntersectionThreshold)
                        {
                            float lineMiddleX = (shortestLineStart.X + shortestLineEnd.X) / 2.0f;
                            float lineMiddleY = (shortestLineStart.Y + shortestLineEnd.Y) / 2.0f;
                            float lineMiddleZ = (shortestLineStart.Z + shortestLineEnd.Z) / 2.0f;

                            thisIntersectionAverage.Add(new Point3D(lineMiddleX, lineMiddleY, lineMiddleZ));
                        }

                        float test;
                        if (shortestLineStart.X != 0)
                        {
                            test = 3;
                        }
                    }
                }
            }

            //Cluster the intersections:
            List<Cluster> Clusters = new List<Cluster>();
            int numClusters = 0;
            //Remove points which are all alone
            while (thisIntersectionAverage.Count > 0)
            {
                Cluster newCluster = new Cluster();
                newCluster.points = new List<clusterPoints>();
                newCluster.points.Add(new clusterPoints { x = thisIntersectionAverage[0].X, y = thisIntersectionAverage[0].Y, z = thisIntersectionAverage[0].Z });


                int innercount = 1;
                while (innercount < thisIntersectionAverage.Count)
                {
                    double xdeltasq = Math.Pow(thisIntersectionAverage[0].X - thisIntersectionAverage[innercount].X, 2);
                    double ydeltasq = Math.Pow(thisIntersectionAverage[0].Y - thisIntersectionAverage[innercount].Y, 2);
                    double zdeltasq = Math.Pow(thisIntersectionAverage[0].Z - thisIntersectionAverage[innercount].Z, 2);
                    double distance = Math.Sqrt(xdeltasq + ydeltasq + zdeltasq);

                    
                    if (distance < ClusterThreshold)
                    {
                        newCluster.points.Add(new clusterPoints { x = thisIntersectionAverage[innercount].X, y = thisIntersectionAverage[innercount].Y, z = thisIntersectionAverage[innercount].Z });
                        thisIntersectionAverage.RemoveAt(innercount);
                    }
                    else
                    {
                        innercount++;
                    }
                }

                thisIntersectionAverage.RemoveAt(0);

                Clusters.Add(newCluster);
            }

            List<Cluster> Clustersnew = new List<Cluster>();

            //remove clusters with less than 3 points
            for (int p = 0; p < Clusters.Count; p++)
            {
                if (Clusters[p].points.Count > 0)
                {
                    Clustersnew.Add(Clusters[p]);
                }
            }


            //IntersectionAverage = IntersectionAverage.Skip(Math.Max(0, IntersectionAverage.Count() - 5000)).Take(5000).ToList();
            if (!AccumulatePoints)
            {
                //IntersectionAverage.Clear();
            }

            for (int i = 0; i < Clustersnew.Count; i++)
            {
                if (AccumulatePoints)
                {
                    IntersectionAverage.Add(new Point3D(Clustersnew[i].points.Select(x => x.x).Average(), Clustersnew[i].points.Select(x => x.y).Average(), Clustersnew[i].points.Select(x => x.z).Average()));
                }
                else 
                {
                    if (IntersectionAverage.Count > 0)
                    {
                        IntersectionAverage.RemoveAt(IntersectionAverage.Count - 1);
                    }
                    IntersectionAverage.Add(new Point3D(Clustersnew[i].points.Select(x => x.x).Average(), Clustersnew[i].points.Select(x => x.y).Average(), Clustersnew[i].points.Select(x => x.z).Average()));
                }
            }

            //if (Clusters.Count > 0)
            //{
            //    try
            //    {
            //        //IntersectionAverage.Clear();
            //        IntersectionAverage.Add(new Point3D(thisIntersectionAverage.Select(x => x.X).Average(), thisIntersectionAverage.Select(x => x.Y).Average(), thisIntersectionAverage.Select(x => x.Z).Average()));
            //    }
            //    catch (Exception ex)
            //    { 

            //    }
            //}

            //for (int i = 0; i < IntersectionAverage.Count; i++)
            //{
            if (thisIntersectionAverage.Count > 0)
            {
                //IntersectionAverage.Add(new Point3D(thisIntersectionAverage.Select(x => x.X).Average(), thisIntersectionAverage.Select(x => x.Y).Average(), thisIntersectionAverage.Select(x => x.Z).Average()));

            }

            for (int i = 0; i < IntersectionAverage.Count; i++)
            {
                drawPoint(IntersectionAverage[i].X, IntersectionAverage[i].Y, IntersectionAverage[i].Z, 0.015f);
            }

            if (IntersectionAverage.Count > 0)
            {
                currentTrackX = IntersectionAverage[IntersectionAverage.Count - 1].X;
                currentTrackY = IntersectionAverage[IntersectionAverage.Count - 1].Y;
                currentTrackZ = IntersectionAverage[IntersectionAverage.Count - 1].Z;
            }
        }

        public float currentTrackX = 0;
        public float currentTrackY = 0;
        public float currentTrackZ = 0;


        public static bool CalculateLineLineIntersection(Vector3 line1Point1, Vector3 line1Point2,
    Vector3 line2Point1, Vector3 line2Point2, out Vector3 resultSegmentPoint1, out Vector3 resultSegmentPoint2)
        {
            // Algorithm is ported from the C algorithm of 
            // Paul Bourke at http://local.wasp.uwa.edu.au/~pbourke/geometry/lineline3d/
            resultSegmentPoint1 = Vector3.Zero;
            resultSegmentPoint2 = Vector3.Zero;

            Vector3 p1 = line1Point1;
            Vector3 p2 = line1Point2;
            Vector3 p3 = line2Point1;
            Vector3 p4 = line2Point2;
            Vector3 p13 = p1 - p3;
            Vector3 p43 = p4 - p3;

            if (p43.LengthSquared() < float.Epsilon)
            {
                return false;
            }
            Vector3 p21 = p2 - p1;
            if (p21.LengthSquared() < float.Epsilon)
            {
                return false;
            }

            double d1343 = p13.X * (double)p43.X + (double)p13.Y * p43.Y + (double)p13.Z * p43.Z;
            double d4321 = p43.X * (double)p21.X + (double)p43.Y * p21.Y + (double)p43.Z * p21.Z;
            double d1321 = p13.X * (double)p21.X + (double)p13.Y * p21.Y + (double)p13.Z * p21.Z;
            double d4343 = p43.X * (double)p43.X + (double)p43.Y * p43.Y + (double)p43.Z * p43.Z;
            double d2121 = p21.X * (double)p21.X + (double)p21.Y * p21.Y + (double)p21.Z * p21.Z;

            double denom = d2121 * d4343 - d4321 * d4321;
            if (Math.Abs(denom) < float.Epsilon)
            {
                return false;
            }
            double numer = d1343 * d4321 - d1321 * d4343;

            double mua = numer / denom;
            double mub = (d1343 + d4321 * (mua)) / d4343;

            resultSegmentPoint1.X = (float)(p1.X + mua * p21.X);
            resultSegmentPoint1.Y = (float)(p1.Y + mua * p21.Y);
            resultSegmentPoint1.Z = (float)(p1.Z + mua * p21.Z);
            resultSegmentPoint2.X = (float)(p3.X + mub * p43.X);
            resultSegmentPoint2.Y = (float)(p3.Y + mub * p43.Y);
            resultSegmentPoint2.Z = (float)(p3.Z + mub * p43.Z);

            return true;
        }

        public float ModelScale = 1.0f;

        private void drawPoint(float x, float y, float z, float scale)
        {
            // Set transform matrices.
            float aspect = GraphicsDevice.Viewport.AspectRatio;

            effect.World = Matrix.Identity * Matrix.CreateScale(scale); //Matrix.CreateScale(cameraModelScaling) * thisCamera.RotationMatrix;
            effect.World = effect.World * Matrix.CreateTranslation(x, y, z);
            //effect.World = effect.World * Matrix.CreateTranslation(x, y, z) * Matrix.CreateTranslation(-IntersectionAverage.Select(q => q.X).Average(), -IntersectionAverage.Select(q => q.Y).Average(), -IntersectionAverage.Select(q => q.Z).Average()); //* Matrix.CreateTranslation(viewTranslationVector);
            //effect.World = effect.World * Matrix.CreateTranslation(x, y, z) * Matrix.CreateTranslation(-IntersectionAverage[0].X, -IntersectionAverage[0].Y, -IntersectionAverage[0].Z); //* Matrix.CreateTranslation(viewTranslationVector);

            //effect.World = effect.World * Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity);

            //effect.World = effect.World * Matrix.CreateScale(globalScaling);

            //effect.View = Matrix.CreateLookAt(new Vector3(0, 0, -5),
            //                                  Vector3.Zero, Vector3.Up);



            //effect.View = Matrix.CreateFromYawPitchRoll(yaw * dragSensitivity, pitch * dragSensitivity, roll * dragSensitivity) * Matrix.CreateLookAt(new Vector3(IntersectionAverage.Last().X, IntersectionAverage.Last().Y, IntersectionAverage.Last().Z),
            //                            Vector3.Zero, Vector3.Up);

            effect.View = ViewMatrix;


            effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);

            // Set renderstates.
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            // Draw the triangle.
            effect.CurrentTechnique.Passes[0].Apply();

            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                              Vertices, 0, 1);
            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                              Vertices2, 0, 1);
            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList,
                                              Vertices3, 0, 1);

            //Model myModel = models[2];

            //// Copy any parent transforms.
            //Matrix[] transforms = new Matrix[myModel.Bones.Count];
            //myModel.CopyBoneTransformsTo(transforms);

            ////myModel.
            //foreach (ModelMesh mesh in myModel.Meshes)
            //{
            //    // This is where the mesh orientation is set, as well 
            //    // as our camera and projection.
            //    foreach (BasicEffect effect2 in mesh.Effects)
            //    {
            //        effect2.EnableDefaultLighting();
            //        effect2.World = Matrix.Identity * transforms[mesh.ParentBone.Index]; //Matrix.CreateScale(cameraModelScaling) * thisCamera.RotationMatrix;
            //        effect2.World = effect.World * Matrix.CreateScale(ModelScale) * Matrix.CreateTranslation(x, y, z);

            //        effect2.View = ViewMatrix;
            //        effect2.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);
            //        //effect.World = transforms[mesh.ParentBone.Index] *
            //        //    Matrix.CreateRotationY(modelRotation)
            //        //    * Matrix.CreateTranslation(modelPosition);
            //        //effect.View = Matrix.CreateLookAt(cameraPosition,
            //        //    Vector3.Zero, Vector3.Up);
            //        //effect.Projection = Matrix.CreatePerspectiveFieldOfView(
            //        //    MathHelper.ToRadians(45.0f), aspectRatio,
            //        //    1.0f, 10000.0f);
            //    }
            //    // Draw the mesh, using the effects set above.
            //    //mesh.Draw();
            //}
        }

        public int SelectedModel = 3;

        private void drawModel(float x, float y, float z)
        {
            float aspect = GraphicsDevice.Viewport.AspectRatio;

            Model myModel = models[SelectedModel];

            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[myModel.Bones.Count];
            myModel.CopyBoneTransformsTo(transforms);

            //myModel.
            foreach (ModelMesh mesh in myModel.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect2 in mesh.Effects)
                {
                    effect2.EnableDefaultLighting();
                    effect2.World = Matrix.Identity  * transforms[mesh.ParentBone.Index]; //Matrix.CreateScale(cameraModelScaling) * thisCamera.RotationMatrix;
                    effect2.World = effect2.World * Matrix.CreateScale(ModelScale) * Matrix.CreateFromYawPitchRoll(0, 3.14f, 0) * Matrix.CreateTranslation(x, y, z);
                    //effect2.World = effect2.World * Matrix.CreateFromYawPitchRoll(3.14f / 2.0f, 0, 0);

                    effect2.View = ViewMatrix;
                    effect2.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 0.01f, 100);
                    //effect.World = transforms[mesh.ParentBone.Index] *
                    //    Matrix.CreateRotationY(modelRotation)
                    //    * Matrix.CreateTranslation(modelPosition);
                    //effect.View = Matrix.CreateLookAt(cameraPosition,
                    //    Vector3.Zero, Vector3.Up);
                    //effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    //    MathHelper.ToRadians(45.0f), aspectRatio,
                    //    1.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }

    }

    struct clusterPoints
    {
        public float x;
        public float y;
        public float z;
    }

    struct Cluster
    {
        public List<clusterPoints> points;
    }
}
