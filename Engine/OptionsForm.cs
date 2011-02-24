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
            get { return (float)numericSpeed.Value; }
            set { numericSpeed.Value = (decimal)value; }
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
