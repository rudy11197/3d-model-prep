namespace Engine
{
    partial class BoneFilterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoneMap = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonHeadBones = new System.Windows.Forms.Button();
            this.buttonArmBones = new System.Windows.Forms.Button();
            this.buttonAllBones = new System.Windows.Forms.Button();
            this.listBoneFilter = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericCentreFrame = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCentreFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "List the names of the bones you want to include when exporting the clip.  If the " +
    "list is empty all bones will be included in the clip.";
            // 
            // listBoneMap
            // 
            this.listBoneMap.FormattingEnabled = true;
            this.listBoneMap.Location = new System.Drawing.Point(333, 84);
            this.listBoneMap.Name = "listBoneMap";
            this.listBoneMap.ScrollAlwaysVisible = true;
            this.listBoneMap.Size = new System.Drawing.Size(171, 394);
            this.listBoneMap.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valid Bone Names:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Include Bones:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(433, 550);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(352, 550);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Presets:";
            // 
            // buttonHeadBones
            // 
            this.buttonHeadBones.Location = new System.Drawing.Point(223, 383);
            this.buttonHeadBones.Name = "buttonHeadBones";
            this.buttonHeadBones.Size = new System.Drawing.Size(75, 23);
            this.buttonHeadBones.TabIndex = 20;
            this.buttonHeadBones.Text = "Head Bones";
            this.buttonHeadBones.UseVisualStyleBackColor = true;
            this.buttonHeadBones.Click += new System.EventHandler(this.buttonHeadBones_Click);
            // 
            // buttonArmBones
            // 
            this.buttonArmBones.Location = new System.Drawing.Point(223, 412);
            this.buttonArmBones.Name = "buttonArmBones";
            this.buttonArmBones.Size = new System.Drawing.Size(75, 23);
            this.buttonArmBones.TabIndex = 21;
            this.buttonArmBones.Text = "Arm Bones";
            this.buttonArmBones.UseVisualStyleBackColor = true;
            this.buttonArmBones.Click += new System.EventHandler(this.buttonArmBones_Click);
            // 
            // buttonAllBones
            // 
            this.buttonAllBones.Location = new System.Drawing.Point(223, 441);
            this.buttonAllBones.Name = "buttonAllBones";
            this.buttonAllBones.Size = new System.Drawing.Size(75, 23);
            this.buttonAllBones.TabIndex = 22;
            this.buttonAllBones.Text = "All Bones";
            this.buttonAllBones.UseVisualStyleBackColor = true;
            this.buttonAllBones.Click += new System.EventHandler(this.buttonAllBones_Click);
            // 
            // listBoneFilter
            // 
            this.listBoneFilter.FormattingEnabled = true;
            this.listBoneFilter.Location = new System.Drawing.Point(15, 84);
            this.listBoneFilter.Name = "listBoneFilter";
            this.listBoneFilter.ScrollAlwaysVisible = true;
            this.listBoneFilter.Size = new System.Drawing.Size(171, 394);
            this.listBoneFilter.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(223, 144);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "<-- Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(223, 188);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "Remove -->";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericCentreFrame);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(15, 484);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 59);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header Information";
            // 
            // numericCentreFrame
            // 
            this.numericCentreFrame.DecimalPlaces = 2;
            this.numericCentreFrame.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericCentreFrame.Location = new System.Drawing.Point(105, 20);
            this.numericCentreFrame.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericCentreFrame.Name = "numericCentreFrame";
            this.numericCentreFrame.Size = new System.Drawing.Size(120, 20);
            this.numericCentreFrame.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Centre Frame:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Based on the first frame being frame 1.";
            // 
            // BoneFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoneFilter);
            this.Controls.Add(this.buttonAllBones);
            this.Controls.Add(this.buttonArmBones);
            this.Controls.Add(this.buttonHeadBones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoneMap);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoneFilterForm";
            this.Text = "Bone Filters";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCentreFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoneMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonHeadBones;
        private System.Windows.Forms.Button buttonArmBones;
        private System.Windows.Forms.Button buttonAllBones;
        private System.Windows.Forms.ListBox listBoneFilter;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericCentreFrame;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}