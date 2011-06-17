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
        //
        /////////////////////////////////////////////////////////////////////

    }
}
