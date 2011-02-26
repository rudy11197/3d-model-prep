namespace Engine
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadRigidModelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadAnimatedModelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFBXAnimationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetNoRotationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetZUpToYUpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.XComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.YComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ZComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadIndividualClipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveClipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewingPointMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.noBoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allLargeBoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allSmallBoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedLargeBoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallBoundsInTheSelectedBoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diabolicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadmodelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savemodelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.modelPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitFBXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTakesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveBoneMapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveBindPoseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PoseHeading = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipNamesComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.modelViewerControl = new Engine.ModelViewerControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.diabolicalToolStripMenuItem,
            this.ToolsMenuItem,
            this.windowToolStripMenuItem,
            this.PoseHeading,
            this.ClipNamesComboBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadRigidModelMenu,
            this.LoadAnimatedModelMenu,
            this.LoadFBXAnimationMenu,
            this.PresetNoRotationMenu,
            this.PresetZUpToYUpMenu,
            this.XComboBox,
            this.YComboBox,
            this.ZComboBox,
            this.toolStripSeparator4,
            this.LoadIndividualClipMenu,
            this.SaveClipMenu,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // LoadRigidModelMenu
            // 
            this.LoadRigidModelMenu.Name = "LoadRigidModelMenu";
            this.LoadRigidModelMenu.Size = new System.Drawing.Size(201, 22);
            this.LoadRigidModelMenu.Text = "Load &Rigid Model...";
            this.LoadRigidModelMenu.Click += new System.EventHandler(this.OpenRigidModelMenu_Click);
            // 
            // LoadAnimatedModelMenu
            // 
            this.LoadAnimatedModelMenu.BackColor = System.Drawing.SystemColors.Control;
            this.LoadAnimatedModelMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadAnimatedModelMenu.Name = "LoadAnimatedModelMenu";
            this.LoadAnimatedModelMenu.Size = new System.Drawing.Size(201, 22);
            this.LoadAnimatedModelMenu.Text = "Load &Animated Model...";
            this.LoadAnimatedModelMenu.ToolTipText = "Load a 3D model in to the viewer";
            this.LoadAnimatedModelMenu.Click += new System.EventHandler(this.OpenAnimatedModelMenu_Click);
            // 
            // LoadFBXAnimationMenu
            // 
            this.LoadFBXAnimationMenu.Enabled = false;
            this.LoadFBXAnimationMenu.Name = "LoadFBXAnimationMenu";
            this.LoadFBXAnimationMenu.Size = new System.Drawing.Size(201, 22);
            this.LoadFBXAnimationMenu.Text = "&Load Animation...";
            this.LoadFBXAnimationMenu.Click += new System.EventHandler(this.LoadFBXAnimationMenu_Click);
            // 
            // PresetNoRotationMenu
            // 
            this.PresetNoRotationMenu.Name = "PresetNoRotationMenu";
            this.PresetNoRotationMenu.Size = new System.Drawing.Size(201, 22);
            this.PresetNoRotationMenu.Text = "> Preset: &No Rotation <";
            this.PresetNoRotationMenu.Click += new System.EventHandler(this.PresetNoRotation_Click);
            // 
            // PresetZUpToYUpMenu
            // 
            this.PresetZUpToYUpMenu.Name = "PresetZUpToYUpMenu";
            this.PresetZUpToYUpMenu.Size = new System.Drawing.Size(201, 22);
            this.PresetZUpToYUpMenu.Text = "> Preset: &Z Up to Y Up <";
            this.PresetZUpToYUpMenu.Click += new System.EventHandler(this.PresetZUpToYUp_Click);
            // 
            // XComboBox
            // 
            this.XComboBox.AccessibleDescription = "";
            this.XComboBox.AccessibleName = "";
            this.XComboBox.Items.AddRange(new object[] {
            "X 0",
            "X 90",
            "X 180",
            "X 270"});
            this.XComboBox.Name = "XComboBox";
            this.XComboBox.Size = new System.Drawing.Size(121, 23);
            this.XComboBox.Tag = "";
            this.XComboBox.Text = "X 0";
            this.XComboBox.ToolTipText = "Rotate model while loading";
            this.XComboBox.TextChanged += new System.EventHandler(this.XComboBox_Changed);
            // 
            // YComboBox
            // 
            this.YComboBox.Items.AddRange(new object[] {
            "Y 0",
            "Y 90",
            "Y 180",
            "Y 270"});
            this.YComboBox.Name = "YComboBox";
            this.YComboBox.Size = new System.Drawing.Size(121, 23);
            this.YComboBox.Text = "Y 0";
            this.YComboBox.ToolTipText = "Rotate model while loading";
            this.YComboBox.TextChanged += new System.EventHandler(this.YComboBox_Changed);
            // 
            // ZComboBox
            // 
            this.ZComboBox.Items.AddRange(new object[] {
            "Z 0",
            "Z 90",
            "Z 180",
            "Z 270"});
            this.ZComboBox.Name = "ZComboBox";
            this.ZComboBox.Size = new System.Drawing.Size(121, 23);
            this.ZComboBox.Text = "Z 0";
            this.ZComboBox.ToolTipText = "Rotate model while loading";
            this.ZComboBox.TextChanged += new System.EventHandler(this.ZComboBox_Changed);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(198, 6);
            // 
            // LoadIndividualClipMenu
            // 
            this.LoadIndividualClipMenu.Enabled = false;
            this.LoadIndividualClipMenu.Name = "LoadIndividualClipMenu";
            this.LoadIndividualClipMenu.Size = new System.Drawing.Size(201, 22);
            this.LoadIndividualClipMenu.Text = "Load Individual &Clip...";
            this.LoadIndividualClipMenu.Click += new System.EventHandler(this.loadIndividualClip_Click);
            // 
            // SaveClipMenu
            // 
            this.SaveClipMenu.Enabled = false;
            this.SaveClipMenu.Name = "SaveClipMenu";
            this.SaveClipMenu.Size = new System.Drawing.Size(201, 22);
            this.SaveClipMenu.Text = "&Save Animation Clip...";
            this.SaveClipMenu.ToolTipText = "Save the currently playing animation in AnimationClip format";
            this.SaveClipMenu.Click += new System.EventHandler(this.SaveClip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yUpMenuItem,
            this.zUpMenuItem,
            this.zDownMenuItem,
            this.toolStripSeparator1,
            this.showFloorMenuItem,
            this.toolStripSeparator6,
            this.resetViewingPointMenu,
            this.toolStripSeparator3,
            this.noBoundsToolStripMenuItem,
            this.allLargeBoundsToolStripMenuItem,
            this.allSmallBoundsToolStripMenuItem,
            this.selectedLargeBoundToolStripMenuItem,
            this.smallBoundsInTheSelectedBoundToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // yUpMenuItem
            // 
            this.yUpMenuItem.Checked = true;
            this.yUpMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yUpMenuItem.Name = "yUpMenuItem";
            this.yUpMenuItem.Size = new System.Drawing.Size(267, 22);
            this.yUpMenuItem.Text = "&Y Up  (XNA Default)";
            this.yUpMenuItem.Click += new System.EventHandler(this.yUp_Click);
            // 
            // zUpMenuItem
            // 
            this.zUpMenuItem.Name = "zUpMenuItem";
            this.zUpMenuItem.Size = new System.Drawing.Size(267, 22);
            this.zUpMenuItem.Text = "Z &Up  (Blender Default)";
            this.zUpMenuItem.Click += new System.EventHandler(this.zUp_Click);
            // 
            // zDownMenuItem
            // 
            this.zDownMenuItem.Name = "zDownMenuItem";
            this.zDownMenuItem.Size = new System.Drawing.Size(267, 22);
            this.zDownMenuItem.Text = "Z &Down";
            this.zDownMenuItem.Click += new System.EventHandler(this.zDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(264, 6);
            // 
            // showFloorMenuItem
            // 
            this.showFloorMenuItem.Name = "showFloorMenuItem";
            this.showFloorMenuItem.Size = new System.Drawing.Size(267, 22);
            this.showFloorMenuItem.Text = "Show &Floor";
            this.showFloorMenuItem.Click += new System.EventHandler(this.showFloor_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(264, 6);
            // 
            // resetViewingPointMenu
            // 
            this.resetViewingPointMenu.Name = "resetViewingPointMenu";
            this.resetViewingPointMenu.Size = new System.Drawing.Size(267, 22);
            this.resetViewingPointMenu.Text = "&Reset Viewing Point";
            this.resetViewingPointMenu.Click += new System.EventHandler(this.resetViewingPoint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(264, 6);
            // 
            // noBoundsToolStripMenuItem
            // 
            this.noBoundsToolStripMenuItem.Name = "noBoundsToolStripMenuItem";
            this.noBoundsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.noBoundsToolStripMenuItem.Text = "&No Bounds";
            // 
            // allLargeBoundsToolStripMenuItem
            // 
            this.allLargeBoundsToolStripMenuItem.Name = "allLargeBoundsToolStripMenuItem";
            this.allLargeBoundsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.allLargeBoundsToolStripMenuItem.Text = "All &Large Bounds";
            // 
            // allSmallBoundsToolStripMenuItem
            // 
            this.allSmallBoundsToolStripMenuItem.Name = "allSmallBoundsToolStripMenuItem";
            this.allSmallBoundsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.allSmallBoundsToolStripMenuItem.Text = "&All Small Bounds";
            // 
            // selectedLargeBoundToolStripMenuItem
            // 
            this.selectedLargeBoundToolStripMenuItem.Name = "selectedLargeBoundToolStripMenuItem";
            this.selectedLargeBoundToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.selectedLargeBoundToolStripMenuItem.Text = "&Selected Large Bound";
            // 
            // smallBoundsInTheSelectedBoundToolStripMenuItem
            // 
            this.smallBoundsInTheSelectedBoundToolStripMenuItem.Name = "smallBoundsInTheSelectedBoundToolStripMenuItem";
            this.smallBoundsInTheSelectedBoundToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.smallBoundsInTheSelectedBoundToolStripMenuItem.Text = "Small Bounds &In The Selected Bound";
            // 
            // diabolicalToolStripMenuItem
            // 
            this.diabolicalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadmodelFileToolStripMenuItem,
            this.savemodelFileToolStripMenuItem,
            this.toolStripSeparator7,
            this.modelPropertiesToolStripMenuItem});
            this.diabolicalToolStripMenuItem.Name = "diabolicalToolStripMenuItem";
            this.diabolicalToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.diabolicalToolStripMenuItem.Text = "&Diabolical";
            // 
            // loadmodelFileToolStripMenuItem
            // 
            this.loadmodelFileToolStripMenuItem.Name = "loadmodelFileToolStripMenuItem";
            this.loadmodelFileToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.loadmodelFileToolStripMenuItem.Text = "&Load .model File...";
            this.loadmodelFileToolStripMenuItem.Click += new System.EventHandler(this.loadmodelFileToolStripMenuItem_Click);
            // 
            // savemodelFileToolStripMenuItem
            // 
            this.savemodelFileToolStripMenuItem.Name = "savemodelFileToolStripMenuItem";
            this.savemodelFileToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.savemodelFileToolStripMenuItem.Text = "&Save .model File...";
            this.savemodelFileToolStripMenuItem.Click += new System.EventHandler(this.savemodelFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(167, 6);
            // 
            // modelPropertiesToolStripMenuItem
            // 
            this.modelPropertiesToolStripMenuItem.Name = "modelPropertiesToolStripMenuItem";
            this.modelPropertiesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.modelPropertiesToolStripMenuItem.Text = "Model &Properties";
            this.modelPropertiesToolStripMenuItem.Click += new System.EventHandler(this.modelPropertiesToolStripMenuItem_Click);
            // 
            // ToolsMenuItem
            // 
            this.ToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitFBXMenuItem,
            this.openTakesToolStripMenuItem,
            this.toolStripSeparator5,
            this.SaveBoneMapMenu,
            this.SaveBindPoseMenuItem,
            this.toolStripSeparator8,
            this.optionsToolStripMenuItem});
            this.ToolsMenuItem.Name = "ToolsMenuItem";
            this.ToolsMenuItem.Size = new System.Drawing.Size(48, 23);
            this.ToolsMenuItem.Text = "&Tools";
            // 
            // splitFBXMenuItem
            // 
            this.splitFBXMenuItem.Name = "splitFBXMenuItem";
            this.splitFBXMenuItem.Size = new System.Drawing.Size(174, 22);
            this.splitFBXMenuItem.Text = "&Split FBX files...";
            this.splitFBXMenuItem.ToolTipText = "Split FBX Model files to have only one take per file";
            this.splitFBXMenuItem.Click += new System.EventHandler(this.SplitFBXMenu_Click);
            // 
            // openTakesToolStripMenuItem
            // 
            this.openTakesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openTakesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openTakesToolStripMenuItem.Name = "openTakesToolStripMenuItem";
            this.openTakesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openTakesToolStripMenuItem.Text = "&Extract FBX Takes...";
            this.openTakesToolStripMenuItem.ToolTipText = "Load a list of animation takes from an FBX file and save them in a keyframe forma" +
                "t";
            this.openTakesToolStripMenuItem.Click += new System.EventHandler(this.OpenTakesMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(171, 6);
            // 
            // SaveBoneMapMenu
            // 
            this.SaveBoneMapMenu.Enabled = false;
            this.SaveBoneMapMenu.Name = "SaveBoneMapMenu";
            this.SaveBoneMapMenu.Size = new System.Drawing.Size(174, 22);
            this.SaveBoneMapMenu.Text = "Save Bone &Map...";
            this.SaveBoneMapMenu.ToolTipText = "Save a list of bone names with their numeric index and thier parent bone";
            this.SaveBoneMapMenu.Click += new System.EventHandler(this.SaveBoneMapMenu_Click);
            // 
            // SaveBindPoseMenuItem
            // 
            this.SaveBindPoseMenuItem.Enabled = false;
            this.SaveBindPoseMenuItem.Name = "SaveBindPoseMenuItem";
            this.SaveBindPoseMenuItem.Size = new System.Drawing.Size(174, 22);
            this.SaveBindPoseMenuItem.Text = "Save Bind &Pose...";
            this.SaveBindPoseMenuItem.ToolTipText = "Save the matrix of each bone while it is at rest";
            this.SaveBindPoseMenuItem.Click += new System.EventHandler(this.SaveBindPoseMenu_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(171, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // PoseHeading
            // 
            this.PoseHeading.Name = "PoseHeading";
            this.PoseHeading.Size = new System.Drawing.Size(141, 23);
            this.PoseHeading.Text = "|      &Animation or Pose:";
            this.PoseHeading.Visible = false;
            // 
            // ClipNamesComboBox
            // 
            this.ClipNamesComboBox.Enabled = false;
            this.ClipNamesComboBox.Name = "ClipNamesComboBox";
            this.ClipNamesComboBox.Size = new System.Drawing.Size(221, 23);
            this.ClipNamesComboBox.Text = "Pose";
            this.ClipNamesComboBox.Visible = false;
            this.ClipNamesComboBox.TextChanged += new System.EventHandler(this.ClipNamesComboBox_Changed);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // messageBox
            // 
            this.messageBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.messageBox.Location = new System.Drawing.Point(0, 537);
            this.messageBox.Margin = new System.Windows.Forms.Padding(12);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(792, 93);
            this.messageBox.TabIndex = 2;
            this.messageBox.TabStop = false;
            // 
            // modelViewerControl
            // 
            this.modelViewerControl.CurrentMoveSpeed = 0.6F;
            this.modelViewerControl.CurrentTurnSpeed = 1F;
            this.modelViewerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.modelViewerControl.IsAnimated = false;
            this.modelViewerControl.Location = new System.Drawing.Point(0, 27);
            this.modelViewerControl.Name = "modelViewerControl";
            this.modelViewerControl.Size = new System.Drawing.Size(792, 507);
            this.modelViewerControl.TabIndex = 1;
            this.modelViewerControl.Text = "modelViewerControl";
            this.modelViewerControl.ViewUp = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(792, 630);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.modelViewerControl);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "3D Model Prep  __  [John C Brown http://www.MistyManor.co.uk]";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadAnimatedModelMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private ModelViewerControl modelViewerControl;
        private System.Windows.Forms.ToolStripMenuItem openTakesToolStripMenuItem;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SaveBoneMapMenu;
        private System.Windows.Forms.ToolStripMenuItem splitFBXMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadRigidModelMenu;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yUpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zUpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadIndividualClipMenu;
        private System.Windows.Forms.ToolStripMenuItem zDownMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveBindPoseMenuItem;
        private System.Windows.Forms.ToolStripComboBox XComboBox;
        private System.Windows.Forms.ToolStripComboBox YComboBox;
        private System.Windows.Forms.ToolStripComboBox ZComboBox;
        private System.Windows.Forms.ToolStripComboBox ClipNamesComboBox;
        private System.Windows.Forms.ToolStripMenuItem PoseHeading;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SaveClipMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem LoadFBXAnimationMenu;
        private System.Windows.Forms.ToolStripMenuItem PresetZUpToYUpMenu;
        private System.Windows.Forms.ToolStripMenuItem PresetNoRotationMenu;
        private System.Windows.Forms.ToolStripMenuItem showFloorMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem resetViewingPointMenu;
        private System.Windows.Forms.ToolStripMenuItem diabolicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadmodelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savemodelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem modelPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noBoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allLargeBoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allSmallBoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedLargeBoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallBoundsInTheSelectedBoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;

    }
}

