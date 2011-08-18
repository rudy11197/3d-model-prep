namespace Engine
{
    partial class ModelWeaponForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.positionMuzzle = new Engine.PositionControl();
            this.numericHalfWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboAmmoType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericClipCapacity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericMaximum = new System.Windows.Forms.NumericUpDown();
            this.checkAutoFire = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericRateOfFire = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericReloadTime = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboSoundReload = new System.Windows.Forms.ComboBox();
            this.comboSoundEmpty = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericRangeClosest = new System.Windows.Forms.NumericUpDown();
            this.numericRangeFarthest = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericRecoil = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.listZoom = new System.Windows.Forms.ListBox();
            this.listCrosshairs = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericHalfWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClipCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRateOfFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReloadTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRangeClosest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRangeFarthest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecoil)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(413, 620);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 60;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(494, 620);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 61;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Muzzle Offset:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Half Width:";
            // 
            // positionMuzzle
            // 
            this.positionMuzzle.DecimalPlaces = 2;
            this.positionMuzzle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.positionMuzzle.Location = new System.Drawing.Point(107, 24);
            this.positionMuzzle.Maximum = new Microsoft.Xna.Framework.Vector3(30000F, 30000F, 30000F);
            this.positionMuzzle.Minimum = new Microsoft.Xna.Framework.Vector3(-30000F, -30000F, -30000F);
            this.positionMuzzle.Name = "positionMuzzle";
            this.positionMuzzle.Size = new System.Drawing.Size(359, 26);
            this.positionMuzzle.TabIndex = 4;
            this.positionMuzzle.Value = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            // 
            // numericHalfWidth
            // 
            this.numericHalfWidth.DecimalPlaces = 4;
            this.numericHalfWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericHalfWidth.Location = new System.Drawing.Point(107, 64);
            this.numericHalfWidth.Name = "numericHalfWidth";
            this.numericHalfWidth.Size = new System.Drawing.Size(120, 20);
            this.numericHalfWidth.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboSoundEmpty);
            this.groupBox1.Controls.Add(this.comboSoundReload);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numericReloadTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericRateOfFire);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkAutoFire);
            this.groupBox1.Controls.Add(this.numericMaximum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericClipCapacity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboAmmoType);
            this.groupBox1.Location = new System.Drawing.Point(15, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 264);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ammunition";
            // 
            // comboAmmoType
            // 
            this.comboAmmoType.FormattingEnabled = true;
            this.comboAmmoType.Location = new System.Drawing.Point(117, 35);
            this.comboAmmoType.Name = "comboAmmoType";
            this.comboAmmoType.Size = new System.Drawing.Size(183, 21);
            this.comboAmmoType.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ammo Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Magazine Capacity";
            // 
            // numericClipCapacity
            // 
            this.numericClipCapacity.Location = new System.Drawing.Point(117, 84);
            this.numericClipCapacity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericClipCapacity.Name = "numericClipCapacity";
            this.numericClipCapacity.Size = new System.Drawing.Size(83, 20);
            this.numericClipCapacity.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Maximum Carried";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rounds:";
            // 
            // numericMaximum
            // 
            this.numericMaximum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMaximum.Location = new System.Drawing.Point(231, 84);
            this.numericMaximum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericMaximum.Name = "numericMaximum";
            this.numericMaximum.Size = new System.Drawing.Size(83, 20);
            this.numericMaximum.TabIndex = 15;
            // 
            // checkAutoFire
            // 
            this.checkAutoFire.AutoSize = true;
            this.checkAutoFire.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkAutoFire.Location = new System.Drawing.Point(6, 117);
            this.checkAutoFire.Name = "checkAutoFire";
            this.checkAutoFire.Size = new System.Drawing.Size(71, 17);
            this.checkAutoFire.TabIndex = 18;
            this.checkAutoFire.Text = "Auto Fire:";
            this.checkAutoFire.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Rate Of Fire:";
            // 
            // numericRateOfFire
            // 
            this.numericRateOfFire.DecimalPlaces = 2;
            this.numericRateOfFire.Location = new System.Drawing.Point(117, 144);
            this.numericRateOfFire.Name = "numericRateOfFire";
            this.numericRateOfFire.Size = new System.Drawing.Size(120, 20);
            this.numericRateOfFire.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Shots per second";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Time To Reload:";
            // 
            // numericReloadTime
            // 
            this.numericReloadTime.DecimalPlaces = 2;
            this.numericReloadTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericReloadTime.Location = new System.Drawing.Point(117, 170);
            this.numericReloadTime.Name = "numericReloadTime";
            this.numericReloadTime.Size = new System.Drawing.Size(120, 20);
            this.numericReloadTime.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(256, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Seconds";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Sounds:";
            // 
            // comboSoundReload
            // 
            this.comboSoundReload.FormattingEnabled = true;
            this.comboSoundReload.Location = new System.Drawing.Point(117, 221);
            this.comboSoundReload.Name = "comboSoundReload";
            this.comboSoundReload.Size = new System.Drawing.Size(183, 21);
            this.comboSoundReload.TabIndex = 25;
            // 
            // comboSoundEmpty
            // 
            this.comboSoundEmpty.FormattingEnabled = true;
            this.comboSoundEmpty.Location = new System.Drawing.Point(325, 221);
            this.comboSoundEmpty.Name = "comboSoundEmpty";
            this.comboSoundEmpty.Size = new System.Drawing.Size(183, 21);
            this.comboSoundEmpty.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(181, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Reload";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(393, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Empty";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 405);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "Optimum Ranges:";
            // 
            // numericRangeClosest
            // 
            this.numericRangeClosest.DecimalPlaces = 2;
            this.numericRangeClosest.Location = new System.Drawing.Point(117, 403);
            this.numericRangeClosest.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericRangeClosest.Name = "numericRangeClosest";
            this.numericRangeClosest.Size = new System.Drawing.Size(120, 20);
            this.numericRangeClosest.TabIndex = 40;
            // 
            // numericRangeFarthest
            // 
            this.numericRangeFarthest.DecimalPlaces = 2;
            this.numericRangeFarthest.Location = new System.Drawing.Point(274, 403);
            this.numericRangeFarthest.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericRangeFarthest.Name = "numericRangeFarthest";
            this.numericRangeFarthest.Size = new System.Drawing.Size(120, 20);
            this.numericRangeFarthest.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(156, 387);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 60;
            this.label15.Text = "Closest";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(316, 387);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "Farthest";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 440);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "Recoil:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(408, 405);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 13);
            this.label18.TabIndex = 63;
            this.label18.Text = "Metres";
            // 
            // numericRecoil
            // 
            this.numericRecoil.DecimalPlaces = 2;
            this.numericRecoil.Location = new System.Drawing.Point(117, 438);
            this.numericRecoil.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericRecoil.Name = "numericRecoil";
            this.numericRecoil.Size = new System.Drawing.Size(120, 20);
            this.numericRecoil.TabIndex = 44;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(243, 440);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 65;
            this.label19.Text = "Degrees";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.listCrosshairs);
            this.groupBox2.Controls.Add(this.listZoom);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(15, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 141);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sights";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Zoom Multipliers:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(226, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Crosshairs:";
            // 
            // listZoom
            // 
            this.listZoom.FormatString = "N2";
            this.listZoom.FormattingEnabled = true;
            this.listZoom.Location = new System.Drawing.Point(117, 19);
            this.listZoom.Name = "listZoom";
            this.listZoom.Size = new System.Drawing.Size(73, 95);
            this.listZoom.TabIndex = 52;
            // 
            // listCrosshairs
            // 
            this.listCrosshairs.FormatString = "N0";
            this.listCrosshairs.FormattingEnabled = true;
            this.listCrosshairs.Location = new System.Drawing.Point(304, 19);
            this.listCrosshairs.Name = "listCrosshairs";
            this.listCrosshairs.Size = new System.Drawing.Size(59, 95);
            this.listCrosshairs.TabIndex = 54;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(383, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 95);
            this.label22.TabIndex = 4;
            this.label22.Text = "Crosshairs are pre-defined types.  Enter an integer to correspond with the type t" +
    "o use at each zoom level.\r\n";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(6, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 62);
            this.label23.TabIndex = 55;
            this.label23.Text = "Multiplier should be between 1 and about 5.\r\n";
            // 
            // ModelWeaponForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 654);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.numericRecoil);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericRangeFarthest);
            this.Controls.Add(this.numericRangeClosest);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericHalfWidth);
            this.Controls.Add(this.positionMuzzle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "ModelWeaponForm";
            this.Text = "Weapon Properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericHalfWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClipCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRateOfFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReloadTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRangeClosest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRangeFarthest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecoil)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private PositionControl positionMuzzle;
        private System.Windows.Forms.NumericUpDown numericHalfWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboAmmoType;
        private System.Windows.Forms.NumericUpDown numericClipCapacity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericMaximum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericReloadTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericRateOfFire;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkAutoFire;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboSoundEmpty;
        private System.Windows.Forms.ComboBox comboSoundReload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericRangeClosest;
        private System.Windows.Forms.NumericUpDown numericRangeFarthest;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericRecoil;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listCrosshairs;
        private System.Windows.Forms.ListBox listZoom;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
    }
}