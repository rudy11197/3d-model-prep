using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Engine
{
    public partial class ModelStructureForm : Form
    {
        public ModelStructureForm()
        {
            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////////
        // == Results and Properties ==
        //
        public int LargeBoundCount
        {
            set { textLargeCount.Text = value.ToString(); }
        }

        public int SmallBoundCount
        {
            set { textSmallCount.Text = value.ToString(); }
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
