namespace Engine
{
    partial class ModelCommonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelCommonForm));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.positionRotation = new Engine.PositionControl();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBlenderAnimated = new System.Windows.Forms.Button();
            this.labelCommonNote = new System.Windows.Forms.Label();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textModelFile = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonBlenderRigid = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textDisplayName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEffect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericSpecularPower = new System.Windows.Forms.NumericUpDown();
            this.labelNormalMapHeading = new System.Windows.Forms.Label();
            this.textNormalMapFile = new System.Windows.Forms.TextBox();
            this.buttonNormalMapFileBrowse = new System.Windows.Forms.Button();
            this.labelNormalMapNote = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSpecularColour = new System.Windows.Forms.Button();
            this.buttonSpecularDefault = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonSpecFabric = new System.Windows.Forms.Button();
            this.buttonSpecDefault = new System.Windows.Forms.Button();
            this.buttonSpecMetal = new System.Windows.Forms.Button();
            this.buttonSpecPolished = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDiffuseColour = new System.Windows.Forms.Button();
            this.buttonEmissiveColour = new System.Windows.Forms.Button();
            this.buttonDiffuseDefault = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonEmissiveDefault = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupMaterial = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecularPower)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(747, 564);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(828, 564);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // positionRotation
            // 
            this.positionRotation.DecimalPlaces = 0;
            this.positionRotation.Increment = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.positionRotation.Location = new System.Drawing.Point(116, 107);
            this.positionRotation.Maximum = new Microsoft.Xna.Framework.Vector3(180F, 180F, 180F);
            this.positionRotation.Minimum = new Microsoft.Xna.Framework.Vector3(-180F, -180F, -180F);
            this.positionRotation.Name = "positionRotation";
            this.positionRotation.Size = new System.Drawing.Size(359, 26);
            this.positionRotation.TabIndex = 9;
            this.positionRotation.Value = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rotation:";
            // 
            // buttonBlenderAnimated
            // 
            this.buttonBlenderAnimated.Location = new System.Drawing.Point(573, 108);
            this.buttonBlenderAnimated.Name = "buttonBlenderAnimated";
            this.buttonBlenderAnimated.Size = new System.Drawing.Size(140, 23);
            this.buttonBlenderAnimated.TabIndex = 8;
            this.buttonBlenderAnimated.Text = "Diabolical Animated";
            this.buttonBlenderAnimated.UseVisualStyleBackColor = true;
            this.buttonBlenderAnimated.Click += new System.EventHandler(this.buttonBlenderAnimated_Click);
            // 
            // labelCommonNote
            // 
            this.labelCommonNote.Location = new System.Drawing.Point(7, 146);
            this.labelCommonNote.Name = "labelCommonNote";
            this.labelCommonNote.Size = new System.Drawing.Size(594, 63);
            this.labelCommonNote.TabIndex = 5;
            this.labelCommonNote.Text = resources.GetString("labelCommonNote.Text");
            // 
            // buttonZero
            // 
            this.buttonZero.Location = new System.Drawing.Point(492, 108);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(75, 23);
            this.buttonZero.TabIndex = 7;
            this.buttonZero.Text = "Zero";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonReload.Location = new System.Drawing.Point(666, 171);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 10;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(749, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Using these settings";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Model relative file location:";
            // 
            // textModelFile
            // 
            this.textModelFile.Location = new System.Drawing.Point(162, 78);
            this.textModelFile.Name = "textModelFile";
            this.textModelFile.ReadOnly = true;
            this.textModelFile.Size = new System.Drawing.Size(478, 20);
            this.textModelFile.TabIndex = 56;
            this.textModelFile.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(647, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "Calculated when the settings file is saved.";
            // 
            // buttonBlenderRigid
            // 
            this.buttonBlenderRigid.Location = new System.Drawing.Point(719, 108);
            this.buttonBlenderRigid.Name = "buttonBlenderRigid";
            this.buttonBlenderRigid.Size = new System.Drawing.Size(140, 23);
            this.buttonBlenderRigid.TabIndex = 9;
            this.buttonBlenderRigid.Text = "Diabolical Rigid";
            this.buttonBlenderRigid.UseVisualStyleBackColor = true;
            this.buttonBlenderRigid.Click += new System.EventHandler(this.buttonBlenderRigid_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 13);
            this.label18.TabIndex = 86;
            this.label18.Text = "Display Name (optional):";
            // 
            // textDisplayName
            // 
            this.textDisplayName.Location = new System.Drawing.Point(162, 18);
            this.textDisplayName.Name = "textDisplayName";
            this.textDisplayName.Size = new System.Drawing.Size(376, 20);
            this.textDisplayName.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(598, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(197, 13);
            this.label19.TabIndex = 88;
            this.label19.Text = "Used to provide details for some models.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textDescription);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textDisplayName);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.buttonBlenderRigid);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textModelFile);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.buttonReload);
            this.groupBox1.Controls.Add(this.buttonZero);
            this.groupBox1.Controls.Add(this.labelCommonNote);
            this.groupBox1.Controls.Add(this.buttonBlenderAnimated);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.positionRotation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common";
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(162, 49);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(697, 20);
            this.textDescription.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 13);
            this.label20.TabIndex = 89;
            this.label20.Text = "Description (optional):";
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
            // comboEffect
            // 
            this.comboEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEffect.FormattingEnabled = true;
            this.comboEffect.Location = new System.Drawing.Point(130, 25);
            this.comboEffect.Name = "comboEffect";
            this.comboEffect.Size = new System.Drawing.Size(158, 21);
            this.comboEffect.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Which shader effect to load with this model.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Specular Power:";
            // 
            // numericSpecularPower
            // 
            this.numericSpecularPower.Location = new System.Drawing.Point(130, 97);
            this.numericSpecularPower.Name = "numericSpecularPower";
            this.numericSpecularPower.Size = new System.Drawing.Size(120, 20);
            this.numericSpecularPower.TabIndex = 13;
            this.numericSpecularPower.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // labelNormalMapHeading
            // 
            this.labelNormalMapHeading.AutoSize = true;
            this.labelNormalMapHeading.Location = new System.Drawing.Point(6, 62);
            this.labelNormalMapHeading.Name = "labelNormalMapHeading";
            this.labelNormalMapHeading.Size = new System.Drawing.Size(112, 13);
            this.labelNormalMapHeading.TabIndex = 11;
            this.labelNormalMapHeading.Text = "Normal Map Filename:";
            // 
            // textNormalMapFile
            // 
            this.textNormalMapFile.Location = new System.Drawing.Point(189, 60);
            this.textNormalMapFile.Name = "textNormalMapFile";
            this.textNormalMapFile.Size = new System.Drawing.Size(285, 20);
            this.textNormalMapFile.TabIndex = 11;
            // 
            // buttonNormalMapFileBrowse
            // 
            this.buttonNormalMapFileBrowse.Location = new System.Drawing.Point(480, 58);
            this.buttonNormalMapFileBrowse.Name = "buttonNormalMapFileBrowse";
            this.buttonNormalMapFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonNormalMapFileBrowse.TabIndex = 12;
            this.buttonNormalMapFileBrowse.Text = "Browse";
            this.buttonNormalMapFileBrowse.UseVisualStyleBackColor = true;
            this.buttonNormalMapFileBrowse.Click += new System.EventHandler(this.buttonNormalMap_Click);
            // 
            // labelNormalMapNote
            // 
            this.labelNormalMapNote.AutoSize = true;
            this.labelNormalMapNote.Location = new System.Drawing.Point(561, 63);
            this.labelNormalMapNote.Name = "labelNormalMapNote";
            this.labelNormalMapNote.Size = new System.Drawing.Size(197, 13);
            this.labelNormalMapNote.TabIndex = 55;
            this.labelNormalMapNote.Text = "Must be in the same folder as the model.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(466, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(419, 118);
            this.label4.TabIndex = 56;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Specular Colour:";
            // 
            // buttonSpecularColour
            // 
            this.buttonSpecularColour.BackColor = System.Drawing.Color.White;
            this.buttonSpecularColour.Location = new System.Drawing.Point(130, 136);
            this.buttonSpecularColour.Name = "buttonSpecularColour";
            this.buttonSpecularColour.Size = new System.Drawing.Size(144, 23);
            this.buttonSpecularColour.TabIndex = 14;
            this.buttonSpecularColour.UseVisualStyleBackColor = false;
            this.buttonSpecularColour.Click += new System.EventHandler(this.buttonSpecularColour_Click);
            // 
            // buttonSpecularDefault
            // 
            this.buttonSpecularDefault.Location = new System.Drawing.Point(316, 136);
            this.buttonSpecularDefault.Name = "buttonSpecularDefault";
            this.buttonSpecularDefault.Size = new System.Drawing.Size(131, 23);
            this.buttonSpecularDefault.TabIndex = 15;
            this.buttonSpecularDefault.Text = "Default Colour Grey";
            this.buttonSpecularDefault.UseVisualStyleBackColor = true;
            this.buttonSpecularDefault.Click += new System.EventHandler(this.buttonSpecularDefault_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "or";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(256, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "How tight the hightlight is.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 178);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "Presets:";
            // 
            // buttonSpecFabric
            // 
            this.buttonSpecFabric.Location = new System.Drawing.Point(129, 173);
            this.buttonSpecFabric.Name = "buttonSpecFabric";
            this.buttonSpecFabric.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecFabric.TabIndex = 16;
            this.buttonSpecFabric.Text = "Fabric";
            this.buttonSpecFabric.UseVisualStyleBackColor = true;
            this.buttonSpecFabric.Click += new System.EventHandler(this.buttonSpecFabric_Click);
            // 
            // buttonSpecDefault
            // 
            this.buttonSpecDefault.Location = new System.Drawing.Point(210, 173);
            this.buttonSpecDefault.Name = "buttonSpecDefault";
            this.buttonSpecDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecDefault.TabIndex = 17;
            this.buttonSpecDefault.Text = "Default";
            this.buttonSpecDefault.UseVisualStyleBackColor = true;
            this.buttonSpecDefault.Click += new System.EventHandler(this.buttonSpecDefault_Click);
            // 
            // buttonSpecMetal
            // 
            this.buttonSpecMetal.Location = new System.Drawing.Point(291, 172);
            this.buttonSpecMetal.Name = "buttonSpecMetal";
            this.buttonSpecMetal.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecMetal.TabIndex = 18;
            this.buttonSpecMetal.Text = "Gun Metal";
            this.buttonSpecMetal.UseVisualStyleBackColor = true;
            this.buttonSpecMetal.Click += new System.EventHandler(this.buttonSpecMetal_Click);
            // 
            // buttonSpecPolished
            // 
            this.buttonSpecPolished.Location = new System.Drawing.Point(372, 173);
            this.buttonSpecPolished.Name = "buttonSpecPolished";
            this.buttonSpecPolished.Size = new System.Drawing.Size(75, 23);
            this.buttonSpecPolished.TabIndex = 19;
            this.buttonSpecPolished.Text = "Polished";
            this.buttonSpecPolished.UseVisualStyleBackColor = true;
            this.buttonSpecPolished.Click += new System.EventHandler(this.buttonSpecPolished_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSpecPolished);
            this.groupBox2.Controls.Add(this.buttonSpecMetal);
            this.groupBox2.Controls.Add(this.buttonSpecDefault);
            this.groupBox2.Controls.Add(this.buttonSpecFabric);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.buttonSpecularDefault);
            this.groupBox2.Controls.Add(this.buttonSpecularColour);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelNormalMapNote);
            this.groupBox2.Controls.Add(this.buttonNormalMapFileBrowse);
            this.groupBox2.Controls.Add(this.textNormalMapFile);
            this.groupBox2.Controls.Add(this.labelNormalMapHeading);
            this.groupBox2.Controls.Add(this.numericSpecularPower);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboEffect);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(891, 218);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effect";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Diffuse Colour:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Emissive Colour:";
            // 
            // buttonDiffuseColour
            // 
            this.buttonDiffuseColour.BackColor = System.Drawing.Color.White;
            this.buttonDiffuseColour.Location = new System.Drawing.Point(130, 23);
            this.buttonDiffuseColour.Name = "buttonDiffuseColour";
            this.buttonDiffuseColour.Size = new System.Drawing.Size(144, 23);
            this.buttonDiffuseColour.TabIndex = 20;
            this.buttonDiffuseColour.UseVisualStyleBackColor = false;
            this.buttonDiffuseColour.Click += new System.EventHandler(this.buttonDiffuseColour_Click);
            // 
            // buttonEmissiveColour
            // 
            this.buttonEmissiveColour.BackColor = System.Drawing.Color.Black;
            this.buttonEmissiveColour.Location = new System.Drawing.Point(130, 61);
            this.buttonEmissiveColour.Name = "buttonEmissiveColour";
            this.buttonEmissiveColour.Size = new System.Drawing.Size(144, 23);
            this.buttonEmissiveColour.TabIndex = 22;
            this.buttonEmissiveColour.UseVisualStyleBackColor = false;
            this.buttonEmissiveColour.Click += new System.EventHandler(this.buttonEmissiveColour_Click);
            // 
            // buttonDiffuseDefault
            // 
            this.buttonDiffuseDefault.Location = new System.Drawing.Point(316, 23);
            this.buttonDiffuseDefault.Name = "buttonDiffuseDefault";
            this.buttonDiffuseDefault.Size = new System.Drawing.Size(131, 23);
            this.buttonDiffuseDefault.TabIndex = 21;
            this.buttonDiffuseDefault.Text = "Default Colour White";
            this.buttonDiffuseDefault.UseVisualStyleBackColor = true;
            this.buttonDiffuseDefault.Click += new System.EventHandler(this.buttonDiffuseDefault_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "or";
            // 
            // buttonEmissiveDefault
            // 
            this.buttonEmissiveDefault.Location = new System.Drawing.Point(316, 61);
            this.buttonEmissiveDefault.Name = "buttonEmissiveDefault";
            this.buttonEmissiveDefault.Size = new System.Drawing.Size(131, 23);
            this.buttonEmissiveDefault.TabIndex = 23;
            this.buttonEmissiveDefault.Text = "Default Colour Black";
            this.buttonEmissiveDefault.UseVisualStyleBackColor = true;
            this.buttonEmissiveDefault.Click += new System.EventHandler(this.buttonEmissiveDefault_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(294, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "or";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(469, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(416, 61);
            this.label15.TabIndex = 65;
            this.label15.Text = "Unless you want to create a specific effect it is likely that the material colour" +
    "s should remain at their defaults so that the colour of the object is taken from" +
    " the texture applied to the model.";
            // 
            // groupMaterial
            // 
            this.groupMaterial.Controls.Add(this.label15);
            this.groupMaterial.Controls.Add(this.label11);
            this.groupMaterial.Controls.Add(this.buttonEmissiveDefault);
            this.groupMaterial.Controls.Add(this.label10);
            this.groupMaterial.Controls.Add(this.buttonDiffuseDefault);
            this.groupMaterial.Controls.Add(this.buttonEmissiveColour);
            this.groupMaterial.Controls.Add(this.buttonDiffuseColour);
            this.groupMaterial.Controls.Add(this.label8);
            this.groupMaterial.Controls.Add(this.label7);
            this.groupMaterial.Location = new System.Drawing.Point(12, 458);
            this.groupMaterial.Name = "groupMaterial";
            this.groupMaterial.Size = new System.Drawing.Size(891, 100);
            this.groupMaterial.TabIndex = 20;
            this.groupMaterial.TabStop = false;
            this.groupMaterial.Text = "Material";
            // 
            // ModelCommonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 599);
            this.Controls.Add(this.groupMaterial);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelCommonForm";
            this.Text = "Common Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecularPower)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupMaterial.ResumeLayout(false);
            this.groupMaterial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private PositionControl positionRotation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBlenderAnimated;
        private System.Windows.Forms.Label labelCommonNote;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textModelFile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonBlenderRigid;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textDisplayName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEffect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericSpecularPower;
        private System.Windows.Forms.Label labelNormalMapHeading;
        private System.Windows.Forms.TextBox textNormalMapFile;
        private System.Windows.Forms.Button buttonNormalMapFileBrowse;
        private System.Windows.Forms.Label labelNormalMapNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSpecularColour;
        private System.Windows.Forms.Button buttonSpecularDefault;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonSpecFabric;
        private System.Windows.Forms.Button buttonSpecDefault;
        private System.Windows.Forms.Button buttonSpecMetal;
        private System.Windows.Forms.Button buttonSpecPolished;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDiffuseColour;
        private System.Windows.Forms.Button buttonEmissiveColour;
        private System.Windows.Forms.Button buttonDiffuseDefault;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonEmissiveDefault;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupMaterial;

    }
}