using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsGraphicsDevice
{
    public partial class WebCamForm : Form
    {
        WinFormsGraphicsDevice.WebCamEye.trkExposureCallback callback;

        public WebCamForm(WinFormsGraphicsDevice.WebCamEye.trkExposureCallback callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void trkExposure_Scroll(object sender, EventArgs e)
        {
            callback(trkExposure.Value);
        }
    }
}
