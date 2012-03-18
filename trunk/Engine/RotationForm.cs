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
        /// Rotation suitable to change animated models produced using Z as the up axis in Blender 
        /// to XNA which uses the Y as the up axis.
        /// To work with Diabolical The Shooter the characters also have to face backwards!
        /// </summary>
        private void buttonBlenderAnimated_Click(object sender, EventArgs e)
        {
            positionRotation.Value = new Vector3(90, 0, 180);
        }

        /// <summary>
        /// Rotation suitable to change models produced using Z as the up axis in Blender 
        /// to XNA which uses the Y as the up axis.
        /// This is typical for most models but is also specific to Diabolical The Shooter 
        /// to align all weapons the same way.
        /// </summary>
        private void buttonBlenderRigid_Click(object sender, EventArgs e)
        {
            positionRotation.Value = new Vector3(-90, 0, 0);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            positionRotation.Value = Vector3.Zero;
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
