﻿namespace Engine
{
    partial class RotationForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupRotate = new System.Windows.Forms.GroupBox();
            this.labelDegrees = new System.Windows.Forms.Label();
            this.labelPreset = new System.Windows.Forms.Label();
            this.buttonBlenderRigid = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.labelCommonNote = new System.Windows.Forms.Label();
            this.buttonBlenderAnimated = new System.Windows.Forms.Button();
            this.positionRotation = new Engine.PositionControl();
            this.groupRotate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(370, 178);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(451, 178);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupRotate
            // 
            this.groupRotate.Controls.Add(this.labelDegrees);
            this.groupRotate.Controls.Add(this.labelPreset);
            this.groupRotate.Controls.Add(this.buttonBlenderRigid);
            this.groupRotate.Controls.Add(this.buttonZero);
            this.groupRotate.Controls.Add(this.labelCommonNote);
            this.groupRotate.Controls.Add(this.buttonBlenderAnimated);
            this.groupRotate.Controls.Add(this.positionRotation);
            this.groupRotate.Location = new System.Drawing.Point(12, 12);
            this.groupRotate.Name = "groupRotate";
            this.groupRotate.Size = new System.Drawing.Size(514, 160);
            this.groupRotate.TabIndex = 0;
            this.groupRotate.TabStop = false;
            this.groupRotate.Text = "Rotate the model while loading";
            // 
            // labelDegrees
            // 
            this.labelDegrees.AutoSize = true;
            this.labelDegrees.Location = new System.Drawing.Point(6, 28);
            this.labelDegrees.Name = "labelDegrees";
            this.labelDegrees.Size = new System.Drawing.Size(50, 13);
            this.labelDegrees.TabIndex = 60;
            this.labelDegrees.Text = "Degrees:";
            // 
            // labelPreset
            // 
            this.labelPreset.AutoSize = true;
            this.labelPreset.Location = new System.Drawing.Point(6, 61);
            this.labelPreset.Name = "labelPreset";
            this.labelPreset.Size = new System.Drawing.Size(45, 13);
            this.labelPreset.TabIndex = 59;
            this.labelPreset.Text = "Presets:";
            // 
            // buttonBlenderRigid
            // 
            this.buttonBlenderRigid.Location = new System.Drawing.Point(239, 56);
            this.buttonBlenderRigid.Name = "buttonBlenderRigid";
            this.buttonBlenderRigid.Size = new System.Drawing.Size(75, 23);
            this.buttonBlenderRigid.TabIndex = 9;
            this.buttonBlenderRigid.Text = "-Z To Y Up";
            this.buttonBlenderRigid.UseVisualStyleBackColor = true;
            this.buttonBlenderRigid.Click += new System.EventHandler(this.buttonBlenderRigid_Click);
            // 
            // buttonZero
            // 
            this.buttonZero.Location = new System.Drawing.Point(77, 56);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(75, 23);
            this.buttonZero.TabIndex = 7;
            this.buttonZero.Text = "Zero";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // labelCommonNote
            // 
            this.labelCommonNote.Location = new System.Drawing.Point(6, 91);
            this.labelCommonNote.Name = "labelCommonNote";
            this.labelCommonNote.Size = new System.Drawing.Size(486, 56);
            this.labelCommonNote.TabIndex = 5;
            this.labelCommonNote.Text = "The rotation is applied as the model is loaded.  This rotates all the vertices an" +
    "d animations.\r\n\r\nBlender animated models usually require +Z to Y up and rigid mo" +
    "dels typically require -Z to Y up!";
            // 
            // buttonBlenderAnimated
            // 
            this.buttonBlenderAnimated.Location = new System.Drawing.Point(158, 56);
            this.buttonBlenderAnimated.Name = "buttonBlenderAnimated";
            this.buttonBlenderAnimated.Size = new System.Drawing.Size(75, 23);
            this.buttonBlenderAnimated.TabIndex = 8;
            this.buttonBlenderAnimated.Text = "+Z To Y Up";
            this.buttonBlenderAnimated.UseVisualStyleBackColor = true;
            this.buttonBlenderAnimated.Click += new System.EventHandler(this.buttonBlenderAnimated_Click);
            // 
            // positionRotation
            // 
            this.positionRotation.DecimalPlaces = 0;
            this.positionRotation.Increment = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.positionRotation.Location = new System.Drawing.Point(72, 24);
            this.positionRotation.Maximum = new Microsoft.Xna.Framework.Vector3(180F, 180F, 180F);
            this.positionRotation.Minimum = new Microsoft.Xna.Framework.Vector3(-180F, -180F, -180F);
            this.positionRotation.Name = "positionRotation";
            this.positionRotation.Size = new System.Drawing.Size(359, 26);
            this.positionRotation.TabIndex = 9;
            this.positionRotation.Value = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            // 
            // RotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 213);
            this.Controls.Add(this.groupRotate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotationForm";
            this.Text = "Rotation";
            this.groupRotate.ResumeLayout(false);
            this.groupRotate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupRotate;
        private System.Windows.Forms.Button buttonBlenderAnimated;
        private PositionControl positionRotation;
        private System.Windows.Forms.Label labelCommonNote;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonBlenderRigid;
        private System.Windows.Forms.Label labelDegrees;
        private System.Windows.Forms.Label labelPreset;
    }
}