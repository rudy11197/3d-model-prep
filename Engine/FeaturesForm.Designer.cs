namespace Engine
{
    partial class FeaturesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeaturesForm));
            this.groupDescription = new System.Windows.Forms.GroupBox();
            this.linkTwitter = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkSkinningSample = new System.Windows.Forms.LinkLabel();
            this.labelContinue = new System.Windows.Forms.Label();
            this.linkDiabolical = new System.Windows.Forms.LinkLabel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupTechnical = new System.Windows.Forms.GroupBox();
            this.labelTechnicalFeatures = new System.Windows.Forms.Label();
            this.groupUsability = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUserFeatures = new System.Windows.Forms.Label();
            this.groupDiabolical = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDiabolical = new System.Windows.Forms.Label();
            this.groupDescription.SuspendLayout();
            this.groupTechnical.SuspendLayout();
            this.groupUsability.SuspendLayout();
            this.groupDiabolical.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDescription
            // 
            this.groupDescription.Controls.Add(this.linkTwitter);
            this.groupDescription.Controls.Add(this.label1);
            this.groupDescription.Controls.Add(this.linkSkinningSample);
            this.groupDescription.Controls.Add(this.labelContinue);
            this.groupDescription.Controls.Add(this.linkDiabolical);
            this.groupDescription.Controls.Add(this.labelDescription);
            this.groupDescription.Location = new System.Drawing.Point(12, 12);
            this.groupDescription.Name = "groupDescription";
            this.groupDescription.Size = new System.Drawing.Size(857, 169);
            this.groupDescription.TabIndex = 0;
            this.groupDescription.TabStop = false;
            this.groupDescription.Text = "3D Model Preparation";
            // 
            // linkTwitter
            // 
            this.linkTwitter.AutoSize = true;
            this.linkTwitter.Location = new System.Drawing.Point(336, 65);
            this.linkTwitter.Name = "linkTwitter";
            this.linkTwitter.Size = new System.Drawing.Size(72, 13);
            this.linkTwitter.TabIndex = 2;
            this.linkTwitter.TabStop = true;
            this.linkTwitter.Tag = "http://twitter.com/#!/MistyManor";
            this.linkTwitter.Text = "@MistyManor";
            this.linkTwitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTwitter_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "and on Twitter follow: ";
            // 
            // linkSkinningSample
            // 
            this.linkSkinningSample.AutoSize = true;
            this.linkSkinningSample.Location = new System.Drawing.Point(6, 132);
            this.linkSkinningSample.Name = "linkSkinningSample";
            this.linkSkinningSample.Size = new System.Drawing.Size(360, 13);
            this.linkSkinningSample.TabIndex = 3;
            this.linkSkinningSample.TabStop = true;
            this.linkSkinningSample.Text = "http://create.msdn.com/en-US/education/catalog/sample/skinned_model";
            this.linkSkinningSample.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSkinningSample_LinkClicked);
            // 
            // labelContinue
            // 
            this.labelContinue.Location = new System.Drawing.Point(6, 93);
            this.labelContinue.Name = "labelContinue";
            this.labelContinue.Size = new System.Drawing.Size(845, 39);
            this.labelContinue.TabIndex = 2;
            this.labelContinue.Text = resources.GetString("labelContinue.Text");
            // 
            // linkDiabolical
            // 
            this.linkDiabolical.AutoSize = true;
            this.linkDiabolical.Location = new System.Drawing.Point(6, 65);
            this.linkDiabolical.Name = "linkDiabolical";
            this.linkDiabolical.Size = new System.Drawing.Size(169, 13);
            this.linkDiabolical.TabIndex = 1;
            this.linkDiabolical.TabStop = true;
            this.linkDiabolical.Text = "http://www.DiabolicalGame.co.uk";
            this.linkDiabolical.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDiabolical_LinkClicked);
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(6, 26);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(845, 36);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "This utility is to help prepare models for use in an XNA game.  Its main purpose " +
    "is to convert animations and to add bounds to models for use in Diabolical: The " +
    "Shooter.  For more details see:";
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(794, 523);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // groupTechnical
            // 
            this.groupTechnical.Controls.Add(this.labelTechnicalFeatures);
            this.groupTechnical.Location = new System.Drawing.Point(12, 446);
            this.groupTechnical.Name = "groupTechnical";
            this.groupTechnical.Size = new System.Drawing.Size(857, 71);
            this.groupTechnical.TabIndex = 2;
            this.groupTechnical.TabStop = false;
            this.groupTechnical.Text = "Technical Features";
            // 
            // labelTechnicalFeatures
            // 
            this.labelTechnicalFeatures.AutoSize = true;
            this.labelTechnicalFeatures.Location = new System.Drawing.Point(6, 28);
            this.labelTechnicalFeatures.Name = "labelTechnicalFeatures";
            this.labelTechnicalFeatures.Size = new System.Drawing.Size(401, 26);
            this.labelTechnicalFeatures.TabIndex = 0;
            this.labelTechnicalFeatures.Text = "- Display a set of axes to show which way the camera is facing\r\n- Restricted to 6" +
    "0 frames per second to avoid an annoying noise from some monitors";
            // 
            // groupUsability
            // 
            this.groupUsability.Controls.Add(this.label2);
            this.groupUsability.Controls.Add(this.labelUserFeatures);
            this.groupUsability.Location = new System.Drawing.Point(12, 187);
            this.groupUsability.Name = "groupUsability";
            this.groupUsability.Size = new System.Drawing.Size(857, 117);
            this.groupUsability.TabIndex = 3;
            this.groupUsability.TabStop = false;
            this.groupUsability.Text = "Usable Features";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 65);
            this.label2.TabIndex = 1;
            this.label2.Text = "- Look and zoom using the mouse and keyboard\r\n- Load animations from FBX files\r\n-" +
    " Split FBX files in to one file per animation\r\n- Show or hide a floor\r\n- View mo" +
    "dels in wireframe";
            // 
            // labelUserFeatures
            // 
            this.labelUserFeatures.AutoSize = true;
            this.labelUserFeatures.Location = new System.Drawing.Point(6, 26);
            this.labelUserFeatures.Name = "labelUserFeatures";
            this.labelUserFeatures.Size = new System.Drawing.Size(396, 78);
            this.labelUserFeatures.TabIndex = 0;
            this.labelUserFeatures.Text = resources.GetString("labelUserFeatures.Text");
            // 
            // groupDiabolical
            // 
            this.groupDiabolical.Controls.Add(this.label3);
            this.groupDiabolical.Controls.Add(this.labelDiabolical);
            this.groupDiabolical.Location = new System.Drawing.Point(12, 310);
            this.groupDiabolical.Name = "groupDiabolical";
            this.groupDiabolical.Size = new System.Drawing.Size(857, 130);
            this.groupDiabolical.TabIndex = 4;
            this.groupDiabolical.TabStop = false;
            this.groupDiabolical.Text = "Features Unique To Diabolical: The Shooter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 91);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // labelDiabolical
            // 
            this.labelDiabolical.AutoSize = true;
            this.labelDiabolical.Location = new System.Drawing.Point(6, 25);
            this.labelDiabolical.Name = "labelDiabolical";
            this.labelDiabolical.Size = new System.Drawing.Size(355, 65);
            this.labelDiabolical.TabIndex = 0;
            this.labelDiabolical.Text = resources.GetString("labelDiabolical.Text");
            // 
            // FeaturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 558);
            this.Controls.Add(this.groupDiabolical);
            this.Controls.Add(this.groupUsability);
            this.Controls.Add(this.groupTechnical);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupDescription);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeaturesForm";
            this.Text = "Features";
            this.groupDescription.ResumeLayout(false);
            this.groupDescription.PerformLayout();
            this.groupTechnical.ResumeLayout(false);
            this.groupTechnical.PerformLayout();
            this.groupUsability.ResumeLayout(false);
            this.groupUsability.PerformLayout();
            this.groupDiabolical.ResumeLayout(false);
            this.groupDiabolical.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkSkinningSample;
        private System.Windows.Forms.Label labelContinue;
        private System.Windows.Forms.LinkLabel linkDiabolical;
        private System.Windows.Forms.GroupBox groupTechnical;
        private System.Windows.Forms.GroupBox groupUsability;
        private System.Windows.Forms.LinkLabel linkTwitter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTechnicalFeatures;
        private System.Windows.Forms.Label labelUserFeatures;
        private System.Windows.Forms.GroupBox groupDiabolical;
        private System.Windows.Forms.Label labelDiabolical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}