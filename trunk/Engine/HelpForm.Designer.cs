namespace Engine
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNavigation = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelLoading = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelDiabolicalHelp = new System.Windows.Forms.Label();
            this.linkDiabolical = new System.Windows.Forms.LinkLabel();
            this.labelDiabolicalDescription = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNavigation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Navigation";
            // 
            // labelNavigation
            // 
            this.labelNavigation.Location = new System.Drawing.Point(6, 16);
            this.labelNavigation.Name = "labelNavigation";
            this.labelNavigation.Size = new System.Drawing.Size(693, 81);
            this.labelNavigation.TabIndex = 0;
            this.labelNavigation.Text = resources.GetString("labelNavigation.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelLoading);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loading";
            // 
            // labelLoading
            // 
            this.labelLoading.Location = new System.Drawing.Point(6, 16);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(693, 81);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = resources.GetString("labelLoading.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelDiabolicalHelp);
            this.groupBox3.Controls.Add(this.linkDiabolical);
            this.groupBox3.Controls.Add(this.labelDiabolicalDescription);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 184);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Diabolical";
            // 
            // labelDiabolicalHelp
            // 
            this.labelDiabolicalHelp.Location = new System.Drawing.Point(6, 68);
            this.labelDiabolicalHelp.Name = "labelDiabolicalHelp";
            this.labelDiabolicalHelp.Size = new System.Drawing.Size(693, 113);
            this.labelDiabolicalHelp.TabIndex = 2;
            this.labelDiabolicalHelp.Text = resources.GetString("labelDiabolicalHelp.Text");
            // 
            // linkDiabolical
            // 
            this.linkDiabolical.AutoSize = true;
            this.linkDiabolical.Location = new System.Drawing.Point(6, 41);
            this.linkDiabolical.Name = "linkDiabolical";
            this.linkDiabolical.Size = new System.Drawing.Size(169, 13);
            this.linkDiabolical.TabIndex = 0;
            this.linkDiabolical.TabStop = true;
            this.linkDiabolical.Text = "http://www.DiabolicalGame.co.uk";
            this.linkDiabolical.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDiabolical_LinkClicked);
            // 
            // labelDiabolicalDescription
            // 
            this.labelDiabolicalDescription.Location = new System.Drawing.Point(6, 16);
            this.labelDiabolicalDescription.Name = "labelDiabolicalDescription";
            this.labelDiabolicalDescription.Size = new System.Drawing.Size(693, 25);
            this.labelDiabolicalDescription.TabIndex = 0;
            this.labelDiabolicalDescription.Text = "\'Diabolical: The Shooter\' is a SciFi first person controlled game which will be a" +
    "vailable on the Xbox 360 Indie Channel.";
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(642, 414);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 51;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 449);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.Text = "Help";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNavigation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelDiabolicalHelp;
        private System.Windows.Forms.LinkLabel linkDiabolical;
        private System.Windows.Forms.Label labelDiabolicalDescription;
        private System.Windows.Forms.Button buttonClose;
    }
}