namespace Engine
{
    partial class AttachedBoundsForm
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
            this.numericRadius = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboIDs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.positionOffset = new Engine.PositionControl();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonReverse = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericRadius);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboIDs);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.buttonRemove);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.comboBones);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.positionOffset);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bone Attached Bounding Spheres";
            // 
            // numericRadius
            // 
            this.numericRadius.DecimalPlaces = 2;
            this.numericRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericRadius.Location = new System.Drawing.Point(78, 146);
            this.numericRadius.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.numericRadius.Name = "numericRadius";
            this.numericRadius.Size = new System.Drawing.Size(120, 20);
            this.numericRadius.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Radius:";
            // 
            // comboIDs
            // 
            this.comboIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIDs.FormattingEnabled = true;
            this.comboIDs.Location = new System.Drawing.Point(35, 29);
            this.comboIDs.Name = "comboIDs";
            this.comboIDs.Size = new System.Drawing.Size(163, 21);
            this.comboIDs.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(285, 146);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(285, 28);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(204, 28);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBones
            // 
            this.comboBones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBones.FormattingEnabled = true;
            this.comboBones.Location = new System.Drawing.Point(50, 62);
            this.comboBones.Name = "comboBones";
            this.comboBones.Size = new System.Drawing.Size(148, 21);
            this.comboBones.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bone:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Offset relative to the head of the bone:";
            // 
            // positionOffset
            // 
            this.positionOffset.DecimalPlaces = 2;
            this.positionOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.positionOffset.Location = new System.Drawing.Point(9, 109);
            this.positionOffset.Maximum = new Microsoft.Xna.Framework.Vector3(30000F, 30000F, 30000F);
            this.positionOffset.Minimum = new Microsoft.Xna.Framework.Vector3(-30000F, -30000F, -30000F);
            this.positionOffset.Name = "positionOffset";
            this.positionOffset.Size = new System.Drawing.Size(359, 26);
            this.positionOffset.TabIndex = 15;
            this.positionOffset.Value = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(230, 225);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(311, 225);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonReverse);
            this.groupBox2.Controls.Add(this.buttonRewind);
            this.groupBox2.Controls.Add(this.buttonForward);
            this.groupBox2.Controls.Add(this.buttonPlay);
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Location = new System.Drawing.Point(12, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 50);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Orbit Selected";
            // 
            // buttonReverse
            // 
            this.buttonReverse.Location = new System.Drawing.Point(23, 20);
            this.buttonReverse.Name = "buttonReverse";
            this.buttonReverse.Size = new System.Drawing.Size(28, 23);
            this.buttonReverse.TabIndex = 4;
            this.buttonReverse.Text = "|<";
            this.buttonReverse.UseVisualStyleBackColor = true;
            // 
            // buttonRewind
            // 
            this.buttonRewind.Location = new System.Drawing.Point(57, 20);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(28, 23);
            this.buttonRewind.TabIndex = 3;
            this.buttonRewind.Text = "<";
            this.buttonRewind.UseVisualStyleBackColor = true;
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(159, 20);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(28, 23);
            this.buttonForward.TabIndex = 2;
            this.buttonForward.Text = ">|";
            this.buttonForward.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(125, 20);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(28, 23);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = ">";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(91, 20);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(28, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "[X]";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // AttachedBoundsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 260);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AttachedBoundsForm";
            this.Text = "Attached Bounds";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private PositionControl positionOffset;
        private System.Windows.Forms.ComboBox comboBones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboIDs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonReverse;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
    }
}