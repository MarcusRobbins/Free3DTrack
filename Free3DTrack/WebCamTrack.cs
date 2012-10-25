using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsGraphicsDevice
{
    public class WebCamTrack
    {
        public List<Point2D> Points = new List<Point2D>();
        public int CameraID;

        public Point2D GetCentroid()
        {
            float centroidx = (float)Points.Select(x => x.X).Sum() / (float)Points.Count;
            float centroidy = (float)Points.Select(x => x.Y).Sum() / (float)Points.Count;

            return new Point2D(centroidx, centroidy, 0);
        }
    }
}
