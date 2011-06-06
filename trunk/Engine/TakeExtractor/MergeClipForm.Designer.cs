namespace Engine
{
    partial class MergeClipForm
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
            this.buttonMerge = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTypical = new System.Windows.Forms.Button();
            this.comboBones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboUpper = new System.Windows.Forms.ComboBox();
            this.comboLower = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMerge
            // 
            this.buttonMerge.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonMerge.Location = new System.Drawing.Point(581, 377);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(75, 23);
            this.buttonMerge.TabIndex = 50;
            this.buttonMerge.Text = "Save...";
            this.buttonMerge.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(662, 377);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonRemove);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBones);
            this.groupBox1.Controls.Add(this.buttonTypical);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBones);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 252);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upper Body Bones";
            // 
            // textBones
            // 
            this.textBones.Location = new System.Drawing.Point(6, 49);
            this.textBones.Multiline = true;
            this.textBones.Name = "textBones";
            this.textBones.Size = new System.Drawing.Size(712, 143);
            this.textBones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of bones to be included from the upper body animation:";
            // 
            // buttonTypical
            // 
            this.buttonTypical.Location = new System.Drawing.Point(196, 212);
            this.buttonTypical.Name = "buttonTypical";
            this.buttonTypical.Size = new System.Drawing.Size(75, 23);
            this.buttonTypical.TabIndex = 2;
            this.buttonTypical.Text = "Typical";
            this.buttonTypical.UseVisualStyleBackColor = true;
            // 
            // comboBones
            // 
            this.comboBones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBones.FormattingEnabled = true;
            this.comboBones.Location = new System.Drawing.Point(374, 214);
            this.comboBones.Name = "comboBones";
            this.comboBones.Size = new System.Drawing.Size(182, 21);
            this.comboBones.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Include bones with typical names:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(562, 212);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(643, 212);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Individual:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboLower);
            this.groupBox2.Controls.Add(this.comboUpper);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 100);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animations";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Upper Body Animation: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Lower Body Animation:";
            // 
            // comboUpper
            // 
            this.comboUpper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUpper.FormattingEnabled = true;
            this.comboUpper.Location = new System.Drawing.Point(149, 25);
            this.comboUpper.Name = "comboUpper";
            this.comboUpper.Size = new System.Drawing.Size(241, 21);
            this.comboUpper.TabIndex = 2;
            // 
            // comboLower
            // 
            this.comboLower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLower.FormattingEnabled = true;
            this.comboLower.Location = new System.Drawing.Point(149, 56);
            this.comboLower.Name = "comboLower";
            this.comboLower.Size = new System.Drawing.Size(241, 21);
            this.comboLower.TabIndex = 3;
            // 
            // MergeClipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 411);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMerge);
            this.Name = "MergeClipForm";
            this.Text = "Merge Clips";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBones;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBones;
        private System.Windows.Forms.Button buttonTypical;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboLower;
        private System.Windows.Forms.ComboBox comboUpper;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}