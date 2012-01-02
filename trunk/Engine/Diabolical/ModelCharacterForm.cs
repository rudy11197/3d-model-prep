using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Engine
{
    public partial class ModelCharacterForm : Form
    {
        public ModelCharacterForm()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        public float CylinderRadius
        {
            get { return (float)numericRadius.Value; }
            set { numericRadius.Value = (decimal)value; }
        }

        public float HeightStanding
        {
            get { return (float)numericStanding.Value; }
            set { numericStanding.Value = (decimal)value; }
        }

        public float HeightCrouched
        {
            get { return (float)numericCrouched.Value; }
            set { numericCrouched.Value = (decimal)value; }
        }

        public float HeightMinimumCover
        {
            get { return (float)numericMinimumCover.Value; }
            set { numericMinimumCover.Value = (decimal)value; }
        }

        public float Mass
        {
            get { return (float)numericMass.Value; }
            set { numericMass.Value = (decimal)value; }
        }

        public bool UseAsPlayer
        {
            get { return checkUseAsPlayer.Checked; }
            set { checkUseAsPlayer.Checked = value; }
        }

        public float BotAngleStand
        {
            get { return (float)numericBotStand.Value; }
            set { numericBotStand.Value = (decimal)value; }
        }

        public float BotAngleWalk
        {
            get { return (float)numericBotWalk.Value; }
            set { numericBotWalk.Value = (decimal)value; }
        }

        public float BotAngleRun
        {
            get { return (float)numericBotRun.Value; }
            set { numericBotRun.Value = (decimal)value; }
        }

        public float BotAngleCrouch
        {
            get { return (float)numericBotCrouch.Value; }
            set { numericBotCrouch.Value = (decimal)value; }
        }

        public float BotAngleShuffle
        {
            get { return (float)numericBotShuffle.Value; }
            set { numericBotShuffle.Value = (decimal)value; }
        }

        public float CameraAngleStand
        {
            get { return (float)numericCameraStand.Value; }
            set { numericCameraStand.Value = (decimal)value; }
        }

        public float CameraAngleWalk
        {
            get { return (float)numericCameraWalk.Value; }
            set { numericCameraWalk.Value = (decimal)value; }
        }

        public float CameraAngleRun
        {
            get { return (float)numericCameraRun.Value; }
            set { numericCameraRun.Value = (decimal)value; }
        }

        public float CameraAngleCrouch
        {
            get { return (float)numericCameraCrouch.Value; }
            set { numericCameraCrouch.Value = (decimal)value; }
        }

        public float CameraAngleShuffle
        {
            get { return (float)numericCameraShuffle.Value; }
            set { numericCameraShuffle.Value = (decimal)value; }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Buttons ==
        //
        private void buttonTypicalCover_Click(object sender, EventArgs e)
        {
            HeightMinimumCover = HeightCrouched * 0.75f;
        }
        //
        /////////////////////////////////////////////////////////////////////

    }
}
