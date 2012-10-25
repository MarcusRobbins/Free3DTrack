using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsGraphicsDevice
{
    class TrackedImagePoint
    {
        public float X {get; set;}
        public float Y { get; set; }

        public TrackedImagePoint(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
