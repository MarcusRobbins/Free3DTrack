using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsGraphicsDevice
{
    public class Point2D
    {
        public float X;
        public float Y;
        public float Magnitude;
        public DateTime timestamp;

        public Point2D()
        {
        }

        public Point2D(float X, float Y, float Magnitude)
        {
            this.X = X;
            this.Y = Y;
            this.Magnitude = Magnitude;
        }

        public Point2D(float X, float Y, float Magnitude, DateTime timestamp)
        {
            this.X = X;
            this.Y = Y;
            this.Magnitude = Magnitude;
            this.timestamp = timestamp;
        }
    }
}
