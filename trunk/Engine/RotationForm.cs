using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Engine
{
    public partial class RotationForm : Form
    {
        public RotationForm()
        {
            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////////
        // == Results and Properties ==
        //
        public Vector3 ModelRotation
        {
            get { return positionRotation.Value; }
            set { positionRotation.Value = value; }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Changes ==
        //
        /// <summary>
        /// Rotation suitable to change models produced using Z as the up axis to XNA which uses the Y as the up axis.
        /// For some reason rigid model exported from Blender are a different way up to animated models.
        /// Animated Blender to XNA.
        /// </summary>
        private void buttonBlenderAnimated_Click(object sender, EventArgs e)
        {
            // 90 0 180
            positionRotation.Value = new Vector3(90, 0, 180);
        }

        /// Rotation suitable to change models produced using Z as the up axis to XNA which uses the Y as the up axis.
        /// For some reason rigid model exported from Blender are a different way up to animated models.
        /// Rigid Blender to XNA.
        private void buttonBlenderRigid_Click(object sender, EventArgs e)
        {
            // -90 0 180
            positionRotation.Value = new Vector3(-90, 0, 180);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            positionRotation.Value = Vector3.Zero;
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
