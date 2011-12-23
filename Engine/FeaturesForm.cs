using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Engine
{
    public partial class FeaturesForm : Form
    {
        public FeaturesForm()
        {
            InitializeComponent();
        }

        private void linkDiabolical_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkDiabolical.Text);
        }

        private void linkTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((string)linkTwitter.Tag);
        }

        private void linkSkinningSample_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkSkinningSample.Text);
        }
    }
}
