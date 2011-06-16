namespace Engine
{
    partial class ModelCharacterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericRadius = new System.Windows.Forms.NumericUpDown();
            this.numericStanding = new System.Windows.Forms.NumericUpDown();
            this.numericCrouched = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStanding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrouched)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericCrouched);
            this.groupBox1.Controls.Add(this.numericStanding);
            this.groupBox1.Controls.Add(this.numericRadius);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sizes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cylinder Radius:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height Standing:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height Crouched:";
            // 
            // numericRadius
            // 
            this.numericRadius.DecimalPlaces = 2;
            this.numericRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericRadius.Location = new System.Drawing.Point(117, 24);
            this.numericRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericRadius.Name = "numericRadius";
            this.numericRadius.Size = new System.Drawing.Size(120, 20);
            this.numericRadius.TabIndex = 3;
            this.numericRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericStanding
            // 
            this.numericStanding.DecimalPlaces = 2;
            this.numericStanding.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericStanding.Location = new System.Drawing.Point(117, 55);
            this.numericStanding.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericStanding.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericStanding.Name = "numericStanding";
            this.numericStanding.Size = new System.Drawing.Size(120, 20);
            this.numericStanding.TabIndex = 4;
            this.numericStanding.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericCrouched
            // 
            this.numericCrouched.DecimalPlaces = 2;
            this.numericCrouched.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericCrouched.Location = new System.Drawing.Point(117, 85);
            this.numericCrouched.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericCrouched.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericCrouched.Name = "numericCrouched";
            this.numericCrouched.Size = new System.Drawing.Size(120, 20);
            this.numericCrouched.TabIndex = 5;
            this.numericCrouched.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(281, 227);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(362, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Units";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Units";
            // 
            // ModelCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 262);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelCharacterForm";
            this.Text = "Character Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStanding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrouched)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericCrouched;
        private System.Windows.Forms.NumericUpDown numericStanding;
        private System.Windows.Forms.NumericUpDown numericRadius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}