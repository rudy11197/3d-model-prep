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
            this.label8 = new System.Windows.Forms.Label();
            this.numericMass = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericCrouched = new System.Windows.Forms.NumericUpDown();
            this.numericStanding = new System.Windows.Forms.NumericUpDown();
            this.numericRadius = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericCameraShuffle = new System.Windows.Forms.NumericUpDown();
            this.numericBotShuffle = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.numericCameraCrouch = new System.Windows.Forms.NumericUpDown();
            this.numericBotCrouch = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numericCameraRun = new System.Windows.Forms.NumericUpDown();
            this.numericBotRun = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericCameraWalk = new System.Windows.Forms.NumericUpDown();
            this.numericBotWalk = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numericCameraStand = new System.Windows.Forms.NumericUpDown();
            this.numericBotStand = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkUseAsPlayer = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrouched)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStanding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraShuffle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotShuffle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraCrouch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotCrouch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraWalk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotWalk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraStand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotStand)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericMass);
            this.groupBox1.Controls.Add(this.label7);
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
            this.groupBox1.Size = new System.Drawing.Size(425, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sizes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Kg";
            // 
            // numericMass
            // 
            this.numericMass.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericMass.Location = new System.Drawing.Point(117, 138);
            this.numericMass.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMass.Name = "numericMass";
            this.numericMass.Size = new System.Drawing.Size(120, 20);
            this.numericMass.TabIndex = 10;
            this.numericMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Mass, Weight:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Units";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height Crouched:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cylinder Radius:";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(281, 460);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(362, 460);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.numericCameraShuffle);
            this.groupBox2.Controls.Add(this.numericBotShuffle);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.numericCameraCrouch);
            this.groupBox2.Controls.Add(this.numericBotCrouch);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.numericCameraRun);
            this.groupBox2.Controls.Add(this.numericBotRun);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.numericCameraWalk);
            this.groupBox2.Controls.Add(this.numericBotWalk);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.numericCameraStand);
            this.groupBox2.Controls.Add(this.numericBotStand);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 202);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation Angle Adjustments (No Longer Used)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(352, 168);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Degrees";
            // 
            // numericCameraShuffle
            // 
            this.numericCameraShuffle.DecimalPlaces = 1;
            this.numericCameraShuffle.Location = new System.Drawing.Point(250, 166);
            this.numericCameraShuffle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericCameraShuffle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericCameraShuffle.Name = "numericCameraShuffle";
            this.numericCameraShuffle.Size = new System.Drawing.Size(96, 20);
            this.numericCameraShuffle.TabIndex = 24;
            // 
            // numericBotShuffle
            // 
            this.numericBotShuffle.DecimalPlaces = 1;
            this.numericBotShuffle.Location = new System.Drawing.Point(141, 166);
            this.numericBotShuffle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericBotShuffle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericBotShuffle.Name = "numericBotShuffle";
            this.numericBotShuffle.Size = new System.Drawing.Size(96, 20);
            this.numericBotShuffle.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(352, 139);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Degrees";
            // 
            // numericCameraCrouch
            // 
            this.numericCameraCrouch.DecimalPlaces = 1;
            this.numericCameraCrouch.Location = new System.Drawing.Point(250, 137);
            this.numericCameraCrouch.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericCameraCrouch.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericCameraCrouch.Name = "numericCameraCrouch";
            this.numericCameraCrouch.Size = new System.Drawing.Size(96, 20);
            this.numericCameraCrouch.TabIndex = 21;
            // 
            // numericBotCrouch
            // 
            this.numericBotCrouch.DecimalPlaces = 1;
            this.numericBotCrouch.Location = new System.Drawing.Point(141, 137);
            this.numericBotCrouch.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericBotCrouch.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericBotCrouch.Name = "numericBotCrouch";
            this.numericBotCrouch.Size = new System.Drawing.Size(96, 20);
            this.numericBotCrouch.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(352, 113);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "Degrees";
            // 
            // numericCameraRun
            // 
            this.numericCameraRun.DecimalPlaces = 1;
            this.numericCameraRun.Location = new System.Drawing.Point(250, 111);
            this.numericCameraRun.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericCameraRun.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericCameraRun.Name = "numericCameraRun";
            this.numericCameraRun.Size = new System.Drawing.Size(96, 20);
            this.numericCameraRun.TabIndex = 18;
            // 
            // numericBotRun
            // 
            this.numericBotRun.DecimalPlaces = 1;
            this.numericBotRun.Location = new System.Drawing.Point(141, 111);
            this.numericBotRun.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericBotRun.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericBotRun.Name = "numericBotRun";
            this.numericBotRun.Size = new System.Drawing.Size(96, 20);
            this.numericBotRun.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(352, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Degrees";
            // 
            // numericCameraWalk
            // 
            this.numericCameraWalk.DecimalPlaces = 1;
            this.numericCameraWalk.Location = new System.Drawing.Point(250, 81);
            this.numericCameraWalk.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericCameraWalk.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericCameraWalk.Name = "numericCameraWalk";
            this.numericCameraWalk.Size = new System.Drawing.Size(96, 20);
            this.numericCameraWalk.TabIndex = 15;
            // 
            // numericBotWalk
            // 
            this.numericBotWalk.DecimalPlaces = 1;
            this.numericBotWalk.Location = new System.Drawing.Point(141, 81);
            this.numericBotWalk.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericBotWalk.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericBotWalk.Name = "numericBotWalk";
            this.numericBotWalk.Size = new System.Drawing.Size(96, 20);
            this.numericBotWalk.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(352, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Degrees";
            // 
            // numericCameraStand
            // 
            this.numericCameraStand.DecimalPlaces = 1;
            this.numericCameraStand.Location = new System.Drawing.Point(250, 50);
            this.numericCameraStand.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericCameraStand.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericCameraStand.Name = "numericCameraStand";
            this.numericCameraStand.Size = new System.Drawing.Size(96, 20);
            this.numericCameraStand.TabIndex = 12;
            // 
            // numericBotStand
            // 
            this.numericBotStand.DecimalPlaces = 1;
            this.numericBotStand.Location = new System.Drawing.Point(141, 50);
            this.numericBotStand.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericBotStand.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericBotStand.Name = "numericBotStand";
            this.numericBotStand.Size = new System.Drawing.Size(96, 20);
            this.numericBotStand.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(274, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Camera";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(172, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Bot";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Shuffle:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Crouch:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Run:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Walk:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Stand:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkUseAsPlayer);
            this.groupBox3.Location = new System.Drawing.Point(12, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 56);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // checkUseAsPlayer
            // 
            this.checkUseAsPlayer.AutoSize = true;
            this.checkUseAsPlayer.Location = new System.Drawing.Point(10, 25);
            this.checkUseAsPlayer.Name = "checkUseAsPlayer";
            this.checkUseAsPlayer.Size = new System.Drawing.Size(237, 17);
            this.checkUseAsPlayer.TabIndex = 0;
            this.checkUseAsPlayer.Text = "Can be used as a player controlled character";
            this.checkUseAsPlayer.UseVisualStyleBackColor = true;
            // 
            // ModelCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 492);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrouched)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStanding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraShuffle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotShuffle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraCrouch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotCrouch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraWalk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotWalk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCameraStand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBotStand)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericMass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericCameraShuffle;
        private System.Windows.Forms.NumericUpDown numericBotShuffle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericCameraCrouch;
        private System.Windows.Forms.NumericUpDown numericBotCrouch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericCameraRun;
        private System.Windows.Forms.NumericUpDown numericBotRun;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericCameraWalk;
        private System.Windows.Forms.NumericUpDown numericBotWalk;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericCameraStand;
        private System.Windows.Forms.NumericUpDown numericBotStand;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkUseAsPlayer;
    }
}