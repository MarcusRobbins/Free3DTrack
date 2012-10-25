using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsGraphicsDevice
{
    class TrackerMagnitude
    {
        public WebCamTracks FilteredTracks = new WebCamTracks();

        public TrackerMagnitude(WebCamTracks tracks)
        {
            //Remove all tracks except the largest, v.simple fitering
            //Thought about adding an interface for all trackers, but can't be assed

            if (tracks.TrackedPoints.Count > 0)
            {
                int maxCount = 0;
                int maxIndex = -1;

                for (int i = 0; i < tracks.TrackedPoints.Count; i++)
                {
                    if (tracks.TrackedPoints[i].Points.Count > maxCount)
                    {
                        maxCount = tracks.TrackedPoints[i].Points.Count;
                        maxIndex = i;
                    }
                }

                WebCamTrack maxCluster = tracks.TrackedPoints[maxIndex];
                FilteredTracks.TrackedPoints.Add(maxCluster);
            }
        }
    }
}
