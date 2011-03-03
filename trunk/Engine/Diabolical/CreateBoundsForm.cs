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
    public partial class CreateBoundsForm : Form
    {
        public CreateBoundsForm()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        public float SmallerWidth
        {
            get { return (float)numericWidth.Value; }
            set { numericWidth.Value = (decimal)value; }
        }

        public float LargerMultiple
        {
            get { return (float)numericMultiple.Value; }
            set { numericMultiple.Value = (decimal)value; }
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
