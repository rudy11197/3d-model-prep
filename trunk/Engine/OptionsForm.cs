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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////
        // == Results == 
        //
        public float MovementSpeed
        {
            get { return (float)numericMove.Value; }
            set { numericMove.Value = (decimal)value; }
        }

        public float TurnSpeed
        {
            get { return (float)numericTurn.Value; }
            set { numericTurn.Value = (decimal)value; }
        }

        public string GridSquareWidth
        {
            set { textGridScale.Text = value; }
        }

        public float EmissiveLevel
        {
            get { return (float)numericEmissive.Value; }
            set { numericEmissive.Value = (decimal)value; }
        }

        public float AmbientLevel
        {
            get { return (float)numericAmbient.Value; }
            set { numericAmbient.Value = (decimal)value; }
        }

        public float DiffuseLevel
        {
            get { return (float)numericDiffuse.Value; }
            set { numericDiffuse.Value = (decimal)value; }
        }

        // Use to trap the change value event
        public NumericUpDown Emissive
        {
            get { return numericEmissive; }
        }

        public NumericUpDown Ambient
        {
            get { return numericAmbient; }
        }

        public NumericUpDown Diffuse
        {
            get { return numericDiffuse; }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Changes ==
        //
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            EmissiveLevel = GlobalSettings.defaultEmissive;
            AmbientLevel = GlobalSettings.defaultAmbient;
            DiffuseLevel = GlobalSettings.defaultDiffuse;
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
