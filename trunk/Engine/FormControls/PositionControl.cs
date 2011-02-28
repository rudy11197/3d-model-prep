//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Control for entering vectors
//-----------------------------------------------------------------------------

#region MIT License
/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Xna.Framework;


namespace Engine
{
    public partial class PositionControl : UserControl
    {
        public PositionControl()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        public Vector3 Value
        {
            get 
            {
                Vector3 result = Vector3.Zero;
                result.X = (float)numericX.Value;
                result.Y = (float)numericY.Value;
                result.Z = (float)numericZ.Value;
                return result;
            }
            set
            {
                numericX.Value = (decimal)value.X;
                numericY.Value = (decimal)value.Y;
                numericZ.Value = (decimal)value.Z;
            }
        }

        /// <summary>
        /// Get or Set if you can tab to this control
        /// </summary>
        public new bool TabStop
        {
            get { return base.TabStop; }
            set
            {
                base.TabStop = value;
                numericX.TabStop = value;
                numericY.TabStop = value;
                numericZ.TabStop = value;
            }
        }

        /// <summary>
        /// Get the highest tab index used by the control or Set the lowest tab index to use for this control
        /// </summary>
        public new int TabIndex
        {
            get { return numericZ.TabIndex; }
            set
            {
                TabStop = true;
                base.TabIndex = value;
                numericX.TabIndex = base.TabIndex + 1;
                numericY.TabIndex = numericX.TabIndex + 1;
                numericZ.TabIndex = numericY.TabIndex + 1;
            }
        }
        /// <summary>
        /// Gets or sets the number of decimal places to display in the spin boxes 
        /// (also known as an up-down control).
        /// </summary>
        public int DecimalPlaces
        {
            get
            {
                return numericX.DecimalPlaces;
            }
            set
            {
                numericX.DecimalPlaces = value;
                numericY.DecimalPlaces = value;
                numericY.DecimalPlaces = value;
            }
        }
        /// <summary>
        /// Gets or sets the maximum value for the spin boxes (also known as an up-down control).
        /// </summary>
        public Vector3 Maximum
        {
            get
            {
                Vector3 limits = Vector3.Zero;
                limits.X = (float)numericX.Maximum;
                limits.Y = (float)numericY.Maximum;
                limits.Z = (float)numericZ.Maximum;
                return limits;
            }
            set
            {
                numericX.Maximum = (decimal)value.X;
                numericY.Maximum = (decimal)value.Y;
                numericZ.Maximum = (decimal)value.Z;
            }
        }
        /// <summary>
        /// Gets or sets the minimum value for the spin boxes (also known as an up-down control).
        /// </summary>
        public Vector3 Minimum
        {
            get
            {
                Vector3 limits = Vector3.Zero;
                limits.X = (float)numericX.Minimum;
                limits.Y = (float)numericY.Minimum;
                limits.Z = (float)numericZ.Minimum;
                return limits;
            }
            set
            {
                numericX.Minimum = (decimal)value.X;
                numericY.Minimum = (decimal)value.Y;
                numericZ.Minimum = (decimal)value.Z;
            }
        }
        /// <summary>
        /// Gets or sets the value to increment or decrement the spin box (also known
        /// as an up-down control) when the up or down buttons are clicked.
        /// </summary>
        public decimal Increment
        {
            get
            {
                return numericX.Increment;
            }
            set
            {
                numericX.Increment = value;
                numericY.Increment = value;
                numericZ.Increment = value;
            }
        }
        //
        //////////////////////////////////////////////////////////////////////



    }
}
