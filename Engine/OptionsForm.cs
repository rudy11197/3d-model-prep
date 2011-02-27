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
        //
        //////////////////////////////////////////////////////////////////////

    }
}
