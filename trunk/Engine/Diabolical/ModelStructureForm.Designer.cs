namespace Engine
{
    partial class ModelStructureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelStructureForm));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textModelFile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.labelCommonNote = new System.Windows.Forms.Label();
            this.buttonBlender = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.positionRotation = new Engine.PositionControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSpecular = new System.Windows.Forms.Button();
            this.buttonBump = new System.Windows.Forms.Button();
            this.textSpecularFile = new System.Windows.Forms.TextBox();
            this.textBumpFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericSpecularPower = new System.Windows.Forms.NumericUpDown();
            this.numericSpecularIntensity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboEffect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textSmallCount = new System.Windows.Forms.TextBox();
            this.textLargeCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecularPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecularIntensity)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(747, 456);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(828, 456);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textModelFile);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.buttonReload);
            this.groupBox1.Controls.Add(this.buttonZero);
            this.groupBox1.Controls.Add(this.labelCommonNote);
            this.groupBox1.Controls.Add(this.buttonBlender);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.positionRotation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(646, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "Calculated when the settings file is saved.";
            // 
            // textModelFile
            // 
            this.textModelFile.Location = new System.Drawing.Point(161, 23);
            this.textModelFile.Name = "textModelFile";
            this.textModelFile.ReadOnly = true;
            this.textModelFile.Size = new System.Drawing.Size(478, 20);
            this.textModelFile.TabIndex = 56;
            this.textModelFile.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Model relative file location:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(748, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Using these settings";
            // 
            // buttonReload
            // 
            this.buttonReload.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonReload.Location = new System.Drawing.Point(667, 53);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 7;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            // 
            // buttonZero
            // 
            this.buttonZero.Location = new System.Drawing.Point(564, 53);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(75, 23);
            this.buttonZero.TabIndex = 6;
            this.buttonZero.Text = "Zero";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // labelCommonNote
            // 
            this.labelCommonNote.Location = new System.Drawing.Point(6, 91);
            this.labelCommonNote.Name = "labelCommonNote";
            this.labelCommonNote.Size = new System.Drawing.Size(879, 63);
            this.labelCommonNote.TabIndex = 5;
            this.labelCommonNote.Text = resources.GetString("labelCommonNote.Text");
            // 
            // buttonBlender
            // 
            this.buttonBlender.Location = new System.Drawing.Point(480, 53);
            this.buttonBlender.Name = "buttonBlender";
            this.buttonBlender.Size = new System.Drawing.Size(75, 23);
            this.buttonBlender.TabIndex = 5;
            this.buttonBlender.Text = "Z To Y Up";
            this.buttonBlender.UseVisualStyleBackColor = true;
            this.buttonBlender.Click += new System.EventHandler(this.buttonBlender_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rotation:";
            // 
            // positionRotation
            // 
            this.positionRotation.DecimalPlaces = 0;
            this.positionRotation.Increment = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.positionRotation.Location = new System.Drawing.Point(115, 52);
            this.positionRotation.Maximum = new Microsoft.Xna.Framework.Vector3(180F, 180F, 180F);
            this.positionRotation.Minimum = new Microsoft.Xna.Framework.Vector3(-180F, -180F, -180F);
            this.positionRotation.Name = "positionRotation";
            this.positionRotation.Size = new System.Drawing.Size(359, 26);
            this.positionRotation.TabIndex = 4;
            this.positionRotation.Value = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.buttonSpecular);
            this.groupBox2.Controls.Add(this.buttonBump);
            this.groupBox2.Controls.Add(this.textSpecularFile);
            this.groupBox2.Controls.Add(this.textBumpFile);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericSpecularPower);
            this.groupBox2.Controls.Add(this.numericSpecularIntensity);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboEffect);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(891, 169);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effect";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(561, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Must be in the same folder as the model.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(561, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Must be in the same folder as the model.";
            // 
            // buttonSpecular
            // 
            this.buttonSpecular.Location = new System.Drawing.Point(480, 128);
            this.buttonSpecular.Name = "buttonSpecular";
            this.buttonSpecular.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecular.TabIndex = 17;
            this.buttonSpecular.Text = "Browse";
            this.buttonSpecular.UseVisualStyleBackColor = true;
            this.buttonSpecular.Click += new System.EventHandler(this.buttonSpecular_Click);
            // 
            // buttonBump
            // 
            this.buttonBump.Location = new System.Drawing.Point(480, 58);
            this.buttonBump.Name = "buttonBump";
            this.buttonBump.Size = new System.Drawing.Size(75, 23);
            this.buttonBump.TabIndex = 13;
            this.buttonBump.Text = "Browse";
            this.buttonBump.UseVisualStyleBackColor = true;
            this.buttonBump.Click += new System.EventHandler(this.buttonBump_Click);
            // 
            // textSpecularFile
            // 
            this.textSpecularFile.Location = new System.Drawing.Point(189, 130);
            this.textSpecularFile.Name = "textSpecularFile";
            this.textSpecularFile.Size = new System.Drawing.Size(285, 20);
            this.textSpecularFile.TabIndex = 16;
            // 
            // textBumpFile
            // 
            this.textBumpFile.Location = new System.Drawing.Point(189, 60);
            this.textBumpFile.Name = "textBumpFile";
            this.textBumpFile.Size = new System.Drawing.Size(285, 20);
            this.textBumpFile.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Specular Map Filename:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Bump or Normal Map Filename:";
            // 
            // numericSpecularPower
            // 
            this.numericSpecularPower.Location = new System.Drawing.Point(405, 95);
            this.numericSpecularPower.Name = "numericSpecularPower";
            this.numericSpecularPower.Size = new System.Drawing.Size(120, 20);
            this.numericSpecularPower.TabIndex = 15;
            // 
            // numericSpecularIntensity
            // 
            this.numericSpecularIntensity.DecimalPlaces = 1;
            this.numericSpecularIntensity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericSpecularIntensity.Location = new System.Drawing.Point(130, 95);
            this.numericSpecularIntensity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericSpecularIntensity.Name = "numericSpecularIntensity";
            this.numericSpecularIntensity.Size = new System.Drawing.Size(120, 20);
            this.numericSpecularIntensity.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Specular Power:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Specular Intensity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Used for special shader effects such as Normal mapping or Bump mapping.";
            // 
            // comboEffect
            // 
            this.comboEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEffect.FormattingEnabled = true;
            this.comboEffect.Location = new System.Drawing.Point(130, 25);
            this.comboEffect.Name = "comboEffect";
            this.comboEffect.Size = new System.Drawing.Size(158, 21);
            this.comboEffect.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Effect Type:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textSmallCount);
            this.groupBox3.Controls.Add(this.textLargeCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 350);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(891, 100);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Structure";
            // 
            // textSmallCount
            // 
            this.textSmallCount.Location = new System.Drawing.Point(189, 58);
            this.textSmallCount.Name = "textSmallCount";
            this.textSmallCount.ReadOnly = true;
            this.textSmallCount.Size = new System.Drawing.Size(100, 20);
            this.textSmallCount.TabIndex = 55;
            this.textSmallCount.TabStop = false;
            // 
            // textLargeCount
            // 
            this.textLargeCount.Location = new System.Drawing.Point(188, 24);
            this.textLargeCount.Name = "textLargeCount";
            this.textLargeCount.ReadOnly = true;
            this.textLargeCount.Size = new System.Drawing.Size(100, 20);
            this.textLargeCount.TabIndex = 2;
            this.textLargeCount.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Small Bounding Sphere Count:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Large Bounding Sphere Count:";
            // 
            // ModelStructureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 491);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelStructureForm";
            this.Text = "Structure Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecularPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecularIntensity)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBlender;
        private System.Windows.Forms.Label label1;
        private PositionControl positionRotation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboEffect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericSpecularPower;
        private System.Windows.Forms.NumericUpDown numericSpecularIntensity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonBump;
        private System.Windows.Forms.TextBox textBumpFile;
        private System.Windows.Forms.Button buttonSpecular;
        private System.Windows.Forms.TextBox textSpecularFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCommonNote;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textSmallCount;
        private System.Windows.Forms.TextBox textLargeCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textModelFile;
        private System.Windows.Forms.Label label13;
    }
}