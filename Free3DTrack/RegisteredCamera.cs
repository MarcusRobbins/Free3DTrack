using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
//using MathNet.Numerics.LinearAlgebra.Double;

namespace WinFormsGraphicsDevice
{
    class RegisteredCamera
    {
        float FocalLength { get; set; }
        float k1 { get; set; }
        float k2 { get; set; }
        public Matrix RotationMatrix { get; set; }
        public MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseRotationMatrix;
        public MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseTranslationMatrix;
        public Vector3 TranslationVector { get; set; }
        public Vector3 PositionVector { get; set; }
        public List<TrackedImagePoint> TrackedPoints = new List<TrackedImagePoint>();
        public int ImageHeight;
        public int ImageWidth;

        public RegisteredCamera(float FocalLength, float k1, float k2, Matrix RotationMatrix, Vector3 TranslationVector, int ImageHeight, int ImageWidth)
        {
            this.FocalLength = FocalLength;
            this.k1 = k1;
            this.k2 = k2;
            this.RotationMatrix = RotationMatrix;
            this.TranslationVector = TranslationVector;
            this.ImageHeight = ImageHeight;
            this.ImageWidth = ImageWidth;

            Double[,] aTranslationMatrix = new Double[3, 1];
            aTranslationMatrix[0, 0] = TranslationVector.X;
            aTranslationMatrix[1, 0] = TranslationVector.Y;
            aTranslationMatrix[2, 0] = TranslationVector.Z;


            Double[,] aRotationMatrix = new Double[3, 3];
            aRotationMatrix[0, 0] = RotationMatrix.M11;
            aRotationMatrix[0, 1] = RotationMatrix.M12;
            aRotationMatrix[0, 2] = RotationMatrix.M13;
            aRotationMatrix[1, 0] = RotationMatrix.M21;
            aRotationMatrix[1, 1] = RotationMatrix.M22;
            aRotationMatrix[1, 2] = RotationMatrix.M23;
            aRotationMatrix[2, 0] = RotationMatrix.M31;
            aRotationMatrix[2, 1] = RotationMatrix.M32;
            aRotationMatrix[2, 2] = RotationMatrix.M33;

            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseRotationMatrix = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(aRotationMatrix);
            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseTranslationMatrix = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(aTranslationMatrix);

            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix densePositionVector = (-(MathNet.Numerics.LinearAlgebra.Double.DenseMatrix)denseRotationMatrix.Transpose()) * denseTranslationMatrix;

            PositionVector = new Vector3((float)densePositionVector[0, 0], (float)densePositionVector[1, 0], (float)densePositionVector[2, 0]);

            //denseTranslationMatrix = -(MathNet.Numerics.LinearAlgebra.Double.DenseMatrix)denseRotationMatrix.Transpose() * denseTranslationMatrix;

            //TranslationVector.X = (float)denseTranslationMatrix[0, 0];
            //TranslationVector.Y = (float)denseTranslationMatrix[1, 0];
            //TranslationVector.Z = (float)denseTranslationMatrix[2, 0];


        }

        public Vector3 ImageToWorld(double u, double v, double w, bool transposeRot, bool negateRot, bool invertRot, bool invertZ, float rotAngleX, float rotAngleY, float rotAngleZ)
        {
            double xprime = (u - ((float)(ImageWidth / 2))) / FocalLength;
            double yprime = (v - ((float)(ImageHeight / 2))) / FocalLength;

            //double xprime = (u) / FocalLength;
            //double yprime = (v) / FocalLength;

            if (invertZ)
            {
                w = -w;                
            }

            double x = xprime * w;
            double y = yprime * w;
            double z = w;

            Double[,] homoXYZ = new Double[3, 1];
            homoXYZ[0, 0] = x;
            homoXYZ[1, 0] = y;
            homoXYZ[2, 0] = z;

            Double[,] TranslationMatrix = new Double[3, 1];
            TranslationMatrix[0, 0] = PositionVector.X;
            TranslationMatrix[1, 0] = PositionVector.Y;
            TranslationMatrix[2, 0] = PositionVector.Z;


            Double[,] aRotationMatrix = new Double[3, 3];
            aRotationMatrix[0, 0] = RotationMatrix.M11;
            aRotationMatrix[0, 1] = RotationMatrix.M12;
            aRotationMatrix[0, 2] = RotationMatrix.M13;
            aRotationMatrix[1, 0] = RotationMatrix.M21;
            aRotationMatrix[1, 1] = RotationMatrix.M22;
            aRotationMatrix[1, 2] = RotationMatrix.M23;
            aRotationMatrix[2, 0] = RotationMatrix.M31;
            aRotationMatrix[2, 1] = RotationMatrix.M32;
            aRotationMatrix[2, 2] = RotationMatrix.M33;

            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseHomoXYZ = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(homoXYZ);
            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseTranslationMatrix = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(TranslationMatrix);
            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseRotationMatrix = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(aRotationMatrix);

            if (transposeRot)
            {
                denseRotationMatrix = (MathNet.Numerics.LinearAlgebra.Double.DenseMatrix)denseRotationMatrix.Transpose();
            }

            if (invertRot)
            {
                denseRotationMatrix = (MathNet.Numerics.LinearAlgebra.Double.DenseMatrix)denseRotationMatrix.Inverse();
            }
            denseRotationMatrix = (MathNet.Numerics.LinearAlgebra.Double.DenseMatrix)denseRotationMatrix.Inverse();

            if (negateRot)
            {
                denseRotationMatrix = -denseRotationMatrix;
            }

            //Double[,] TranslationMatrix = new Double[3, 1];
            //TranslationMatrix[0, 0] = TranslationVector.X;
            //TranslationMatrix[1, 0] = TranslationVector.Y;
            //TranslationMatrix[2, 0] = TranslationVector.Z;

            //denseRotationMatrix = denseRotationMatrix.Transpose() * 
            
            //MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseWorldCoordinates = InverseRotationMatrix * (denseHomoXYZ - TranslationMatrix);
            MathNet.Numerics.LinearAlgebra.Double.DenseMatrix denseWorldCoordinates = (MathNet.Numerics.LinearAlgebra.Double.DenseMatrix)(denseRotationMatrix) * (denseHomoXYZ - denseTranslationMatrix);

            float worldX = (float)denseWorldCoordinates[0, 0];
            float worldY = (float)denseWorldCoordinates[1, 0];
            float worldZ = (float)denseWorldCoordinates[2, 0];


            
            //Microsoft.Xna.Framework.Matrix rotX;
            //Microsoft.Xna.Framework.Matrix rotY;
            //Microsoft.Xna.Framework.Matrix rotZ;
            //Vector3 origin = new Vector3(0, 0, 0);
            //Microsoft.Xna.Framework.Matrix.CreateRotationX((float)rotAngleX, out rotX);
            //Microsoft.Xna.Framework.Matrix.CreateRotationY((float)rotAngleY, out rotY);
            //Microsoft.Xna.Framework.Matrix.CreateRotationZ((float)rotAngleZ, out rotZ);
            //Vector3 tempV = new Vector3((float)worldX, (float)worldY, (float)worldZ);
            //tempV = Vector3.Transform(tempV, rotX);
            //tempV = Vector3.Transform(tempV, rotY);
            //tempV = Vector3.Transform(tempV, rotZ);



            //worldX = tempV.X;
            //worldY = tempV.Y;
            //worldZ = tempV.Z;


            Vector3 WorldCoodrinates = new Vector3(worldX, worldY, worldZ);

            return WorldCoodrinates;
        }
    }
}
