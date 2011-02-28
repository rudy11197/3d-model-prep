namespace Engine
{
    partial class PositionControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.numericZ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZ)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(3, 5);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(120, 5);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(238, 5);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 13);
            this.labelZ.TabIndex = 2;
            this.labelZ.Text = "Z";
            // 
            // numericX
            // 
            this.numericX.DecimalPlaces = 2;
            this.numericX.Location = new System.Drawing.Point(20, 3);
            this.numericX.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericX.Minimum = new decimal(new int[] {
            30000,
            0,
            0,
            -2147483648});
            this.numericX.Name = "numericX";
            this.numericX.Size = new System.Drawing.Size(96, 20);
            this.numericX.TabIndex = 4;
            // 
            // numericY
            // 
            this.numericY.DecimalPlaces = 2;
            this.numericY.Location = new System.Drawing.Point(138, 3);
            this.numericY.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericY.Minimum = new decimal(new int[] {
            30000,
            0,
            0,
            -2147483648});
            this.numericY.Name = "numericY";
            this.numericY.Size = new System.Drawing.Size(96, 20);
            this.numericY.TabIndex = 5;
            // 
            // numericZ
            // 
            this.numericZ.DecimalPlaces = 2;
            this.numericZ.Location = new System.Drawing.Point(256, 3);
            this.numericZ.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericZ.Minimum = new decimal(new int[] {
            30000,
            0,
            0,
            -2147483648});
            this.numericZ.Name = "numericZ";
            this.numericZ.Size = new System.Drawing.Size(96, 20);
            this.numericZ.TabIndex = 6;
            // 
            // PositionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericZ);
            this.Controls.Add(this.numericY);
            this.Controls.Add(this.numericX);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Name = "PositionControl";
            this.Size = new System.Drawing.Size(359, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.NumericUpDown numericX;
        private System.Windows.Forms.NumericUpDown numericY;
        private System.Windows.Forms.NumericUpDown numericZ;
    }
}
