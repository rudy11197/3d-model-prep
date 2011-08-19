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
            this.RotationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.loadDiabolicalmodelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDiabolicalmodelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadIndividualClipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveClipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orbitTheModelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.yUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showFloorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAxesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireframeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewingPointMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.invertYControlsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.noBoundsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allLargeBoundsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allSmallBoundsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallBoundsInTheSelectedBoundItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundingCylinderStanding = new System.Windows.Forms.ToolStripMenuItem();
            this.boundingCylinderCrouched = new System.Windows.Forms.ToolStripMenuItem();
            this.boundsAttachedToBonesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.light1EnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.light2EnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseLightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diabolicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelCommonPropertiesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeModelTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelTypePropertiesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.createStructureBoundsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimiseBoundsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.editCharacterBoundsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitFBXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTakesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToClipsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveBoneMapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveBindPoseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PoseHeading = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipNamesComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.statusPanel = new System.Windows.Forms.TextBox();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.numericLarge = new System.Windows.Forms.NumericUpDown();
            this.numericSmall = new System.Windows.Forms.NumericUpDown();
            this.labelLarge = new System.Windows.Forms.Label();
            this.labelSmall = new System.Windows.Forms.Label();
            this.buttonLarge = new System.Windows.Forms.Button();
            this.buttonSmall = new System.Windows.Forms.Button();
            this.modelViewerControl = new Engine.ModelViewerControl();
            this.statusOrbit = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSmall)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1008, 27);
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
            this.RotationMenuItem,
            this.toolStripSeparator4,
            this.loadDiabolicalmodelMenuItem,
            this.saveDiabolicalmodelMenuItem,
            this.toolStripSeparator13,
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
            this.LoadRigidModelMenu.Size = new System.Drawing.Size(230, 22);
            this.LoadRigidModelMenu.Text = "Load &Rigid Model...";
            this.LoadRigidModelMenu.Click += new System.EventHandler(this.OpenRigidModelMenu_Click);
            // 
            // LoadAnimatedModelMenu
            // 
            this.LoadAnimatedModelMenu.BackColor = System.Drawing.SystemColors.Control;
            this.LoadAnimatedModelMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadAnimatedModelMenu.Name = "LoadAnimatedModelMenu";
            this.LoadAnimatedModelMenu.Size = new System.Drawing.Size(230, 22);
            this.LoadAnimatedModelMenu.Text = "Load &Animated Model...";
            this.LoadAnimatedModelMenu.ToolTipText = "Load a 3D model in to the viewer";
            this.LoadAnimatedModelMenu.Click += new System.EventHandler(this.OpenAnimatedModelMenu_Click);
            // 
            // LoadFBXAnimationMenu
            // 
            this.LoadFBXAnimationMenu.Enabled = false;
            this.LoadFBXAnimationMenu.Name = "LoadFBXAnimationMenu";
            this.LoadFBXAnimationMenu.Size = new System.Drawing.Size(230, 22);
            this.LoadFBXAnimationMenu.Text = "Loa&d Animation...";
            this.LoadFBXAnimationMenu.Click += new System.EventHandler(this.LoadFBXAnimationMenu_Click);
            // 
            // RotationMenuItem
            // 
            this.RotationMenuItem.Name = "RotationMenuItem";
            this.RotationMenuItem.Size = new System.Drawing.Size(230, 22);
            this.RotationMenuItem.Text = "&Rotation: X 0.00, Y 0.00, Z 0.00";
            this.RotationMenuItem.Click += new System.EventHandler(this.RotationMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(227, 6);
            // 
            // loadDiabolicalmodelMenuItem
            // 
            this.loadDiabolicalmodelMenuItem.Name = "loadDiabolicalmodelMenuItem";
            this.loadDiabolicalmodelMenuItem.Size = new System.Drawing.Size(230, 22);
            this.loadDiabolicalmodelMenuItem.Text = "&Load Diabolical .model File...";
            this.loadDiabolicalmodelMenuItem.Click += new System.EventHandler(this.loadDiabolicalmodelMenuItem_Click);
            // 
            // saveDiabolicalmodelMenuItem
            // 
            this.saveDiabolicalmodelMenuItem.Name = "saveDiabolicalmodelMenuItem";
            this.saveDiabolicalmodelMenuItem.Size = new System.Drawing.Size(230, 22);
            this.saveDiabolicalmodelMenuItem.Text = "&Save Diabolical .model File...";
            this.saveDiabolicalmodelMenuItem.Click += new System.EventHandler(this.saveDiabolicalmodelMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(227, 6);
            // 
            // LoadIndividualClipMenu
            // 
            this.LoadIndividualClipMenu.Enabled = false;
            this.LoadIndividualClipMenu.Name = "LoadIndividualClipMenu";
            this.LoadIndividualClipMenu.Size = new System.Drawing.Size(230, 22);
            this.LoadIndividualClipMenu.Text = "Load Individual &Clip...";
            this.LoadIndividualClipMenu.Click += new System.EventHandler(this.loadIndividualClip_Click);
            // 
            // SaveClipMenu
            // 
            this.SaveClipMenu.Enabled = false;
            this.SaveClipMenu.Name = "SaveClipMenu";
            this.SaveClipMenu.Size = new System.Drawing.Size(230, 22);
            this.SaveClipMenu.Text = "Save Animation Cli&p...";
            this.SaveClipMenu.ToolTipText = "Save the currently playing animation in AnimationClip format";
            this.SaveClipMenu.Click += new System.EventHandler(this.SaveClip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orbitTheModelMenu,
            this.toolStripSeparator12,
            this.yUpMenuItem,
            this.zUpMenuItem,
            this.zDownMenuItem,
            this.toolStripSeparator1,
            this.showFloorMenuItem,
            this.showAxesMenuItem,
            this.wireframeItem,
            this.toolStripSeparator6,
            this.resetViewingPointMenu,
            this.invertYControlsItem,
            this.toolStripSeparator3,
            this.noBoundsItem,
            this.allLargeBoundsItem,
            this.allSmallBoundsItem,
            this.smallBoundsInTheSelectedBoundItem,
            this.boundingCylinderStanding,
            this.boundingCylinderCrouched,
            this.boundsAttachedToBonesItem,
            this.toolStripSeparator10,
            this.light1EnabledToolStripMenuItem,
            this.light2EnabledToolStripMenuItem,
            this.reverseLightingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // orbitTheModelMenu
            // 
            this.orbitTheModelMenu.Name = "orbitTheModelMenu";
            this.orbitTheModelMenu.Size = new System.Drawing.Size(267, 22);
            this.orbitTheModelMenu.Text = "&Orbit The Model                        Key O";
            this.orbitTheModelMenu.Click += new System.EventHandler(this.orbitTheModelMenu_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(264, 6);
            // 
            // yUpMenuItem
            // 
            this.yUpMenuItem.Checked = true;
            this.yUpMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yUpMenuItem.Name = "yUpMenuItem";
            this.yUpMenuItem.Size = new System.Drawing.Size(267, 22);
            this.yUpMenuItem.Text = "Y Up  (&XNA Default)";
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
            // showAxesMenuItem
            // 
            this.showAxesMenuItem.Checked = true;
            this.showAxesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAxesMenuItem.Name = "showAxesMenuItem";
            this.showAxesMenuItem.Size = new System.Drawing.Size(267, 22);
            this.showAxesMenuItem.Text = "S&how Axes";
            this.showAxesMenuItem.Click += new System.EventHandler(this.showAxesMenuItem_Click);
            // 
            // wireframeItem
            // 
            this.wireframeItem.Name = "wireframeItem";
            this.wireframeItem.Size = new System.Drawing.Size(267, 22);
            this.wireframeItem.Text = "&Wireframe Model View";
            this.wireframeItem.Click += new System.EventHandler(this.wireframeItem_Click);
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
            this.resetViewingPointMenu.Text = "&Reset Viewing Point                   Key R";
            this.resetViewingPointMenu.Click += new System.EventHandler(this.resetViewingPoint_Click);
            // 
            // invertYControlsItem
            // 
            this.invertYControlsItem.Name = "invertYControlsItem";
            this.invertYControlsItem.Size = new System.Drawing.Size(267, 22);
            this.invertYControlsItem.Text = "Invert &Y Controls";
            this.invertYControlsItem.Click += new System.EventHandler(this.invertYControlsItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(264, 6);
            // 
            // noBoundsItem
            // 
            this.noBoundsItem.Name = "noBoundsItem";
            this.noBoundsItem.Size = new System.Drawing.Size(267, 22);
            this.noBoundsItem.Text = "&No Bounds";
            this.noBoundsItem.Click += new System.EventHandler(this.noBoundsItem_Click);
            // 
            // allLargeBoundsItem
            // 
            this.allLargeBoundsItem.Name = "allLargeBoundsItem";
            this.allLargeBoundsItem.Size = new System.Drawing.Size(267, 22);
            this.allLargeBoundsItem.Text = "All &Large Bounds";
            this.allLargeBoundsItem.Click += new System.EventHandler(this.allLargeBoundsItem_Click);
            // 
            // allSmallBoundsItem
            // 
            this.allSmallBoundsItem.Name = "allSmallBoundsItem";
            this.allSmallBoundsItem.Size = new System.Drawing.Size(267, 22);
            this.allSmallBoundsItem.Text = "&All Small Bounds";
            this.allSmallBoundsItem.Click += new System.EventHandler(this.allSmallBoundsItem_Click);
            // 
            // smallBoundsInTheSelectedBoundItem
            // 
            this.smallBoundsInTheSelectedBoundItem.Name = "smallBoundsInTheSelectedBoundItem";
            this.smallBoundsInTheSelectedBoundItem.Size = new System.Drawing.Size(267, 22);
            this.smallBoundsInTheSelectedBoundItem.Text = "Small Bounds &In The Selected Bound";
            this.smallBoundsInTheSelectedBoundItem.Click += new System.EventHandler(this.smallBoundsInTheSelectedBoundItem_Click);
            // 
            // boundingCylinderStanding
            // 
            this.boundingCylinderStanding.Name = "boundingCylinderStanding";
            this.boundingCylinderStanding.Size = new System.Drawing.Size(267, 22);
            this.boundingCylinderStanding.Text = "Bo&unding Cylinder Standing";
            this.boundingCylinderStanding.Click += new System.EventHandler(this.boundingCylinderStanding_Click);
            // 
            // boundingCylinderCrouched
            // 
            this.boundingCylinderCrouched.Name = "boundingCylinderCrouched";
            this.boundingCylinderCrouched.Size = new System.Drawing.Size(267, 22);
            this.boundingCylinderCrouched.Text = "Bounding &Cylinder Crouched";
            this.boundingCylinderCrouched.Click += new System.EventHandler(this.boundingCylinderCrouched_Click);
            // 
            // boundsAttachedToBonesItem
            // 
            this.boundsAttachedToBonesItem.Name = "boundsAttachedToBonesItem";
            this.boundsAttachedToBonesItem.Size = new System.Drawing.Size(267, 22);
            this.boundsAttachedToBonesItem.Text = "Bounds Attached To &Bones";
            this.boundsAttachedToBonesItem.Click += new System.EventHandler(this.boundsAttachedToBonesItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(264, 6);
            // 
            // light1EnabledToolStripMenuItem
            // 
            this.light1EnabledToolStripMenuItem.Checked = true;
            this.light1EnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.light1EnabledToolStripMenuItem.Name = "light1EnabledToolStripMenuItem";
            this.light1EnabledToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.light1EnabledToolStripMenuItem.Text = "Light &1 Enabled";
            this.light1EnabledToolStripMenuItem.Click += new System.EventHandler(this.light1EnabledToolStripMenuItem_Click);
            // 
            // light2EnabledToolStripMenuItem
            // 
            this.light2EnabledToolStripMenuItem.Checked = true;
            this.light2EnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.light2EnabledToolStripMenuItem.Name = "light2EnabledToolStripMenuItem";
            this.light2EnabledToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.light2EnabledToolStripMenuItem.Text = "Light &2 Enabled";
            this.light2EnabledToolStripMenuItem.Click += new System.EventHandler(this.light2EnabledToolStripMenuItem_Click);
            // 
            // reverseLightingToolStripMenuItem
            // 
            this.reverseLightingToolStripMenuItem.Checked = true;
            this.reverseLightingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reverseLightingToolStripMenuItem.Name = "reverseLightingToolStripMenuItem";
            this.reverseLightingToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.reverseLightingToolStripMenuItem.Text = "&Reverse Lighting";
            this.reverseLightingToolStripMenuItem.Click += new System.EventHandler(this.reverseLightingToolStripMenuItem_Click);
            // 
            // diabolicalToolStripMenuItem
            // 
            this.diabolicalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modelCommonPropertiesItem,
            this.changeModelTypeItem,
            this.modelTypePropertiesItem,
            this.toolStripSeparator9,
            this.createStructureBoundsItem,
            this.optimiseBoundsItem,
            this.toolStripSeparator11,
            this.editCharacterBoundsMenu});
            this.diabolicalToolStripMenuItem.Name = "diabolicalToolStripMenuItem";
            this.diabolicalToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.diabolicalToolStripMenuItem.Text = "&Diabolical";
            // 
            // modelCommonPropertiesItem
            // 
            this.modelCommonPropertiesItem.Name = "modelCommonPropertiesItem";
            this.modelCommonPropertiesItem.Size = new System.Drawing.Size(237, 22);
            this.modelCommonPropertiesItem.Text = "Model &Common Properties";
            this.modelCommonPropertiesItem.Click += new System.EventHandler(this.modelCommonPropertiesItem_Click);
            // 
            // changeModelTypeItem
            // 
            this.changeModelTypeItem.Name = "changeModelTypeItem";
            this.changeModelTypeItem.Size = new System.Drawing.Size(237, 22);
            this.changeModelTypeItem.Text = "Change Model &Type";
            this.changeModelTypeItem.Click += new System.EventHandler(this.changeModelTypeItem_Click);
            // 
            // modelTypePropertiesItem
            // 
            this.modelTypePropertiesItem.Name = "modelTypePropertiesItem";
            this.modelTypePropertiesItem.Size = new System.Drawing.Size(237, 22);
            this.modelTypePropertiesItem.Text = "Model Type Specific &Properties";
            this.modelTypePropertiesItem.Click += new System.EventHandler(this.modelTypePropertiesItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(234, 6);
            // 
            // createStructureBoundsItem
            // 
            this.createStructureBoundsItem.Name = "createStructureBoundsItem";
            this.createStructureBoundsItem.Size = new System.Drawing.Size(237, 22);
            this.createStructureBoundsItem.Text = "Create Structure &Bounds";
            this.createStructureBoundsItem.Click += new System.EventHandler(this.createStructureBoundsItem_Click);
            // 
            // optimiseBoundsItem
            // 
            this.optimiseBoundsItem.Name = "optimiseBoundsItem";
            this.optimiseBoundsItem.Size = new System.Drawing.Size(237, 22);
            this.optimiseBoundsItem.Text = "&Optimise Bounds (Essential)";
            this.optimiseBoundsItem.Click += new System.EventHandler(this.optimiseBoundsItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(234, 6);
            // 
            // editCharacterBoundsMenu
            // 
            this.editCharacterBoundsMenu.Name = "editCharacterBoundsMenu";
            this.editCharacterBoundsMenu.Size = new System.Drawing.Size(237, 22);
            this.editCharacterBoundsMenu.Text = "&Edit Character Bounds";
            this.editCharacterBoundsMenu.Click += new System.EventHandler(this.createOrEditCharacterBoundsToolStripMenuItem_Click);
            // 
            // ToolsMenuItem
            // 
            this.ToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitFBXMenuItem,
            this.openTakesToolStripMenuItem,
            this.mergeToClipsMenuItem,
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
            this.splitFBXMenuItem.Size = new System.Drawing.Size(230, 22);
            this.splitFBXMenuItem.Text = "&Split FBX files...";
            this.splitFBXMenuItem.ToolTipText = "Split FBX Model files to have only one take per file";
            this.splitFBXMenuItem.Click += new System.EventHandler(this.SplitFBXMenu_Click);
            // 
            // openTakesToolStripMenuItem
            // 
            this.openTakesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openTakesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openTakesToolStripMenuItem.Name = "openTakesToolStripMenuItem";
            this.openTakesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.openTakesToolStripMenuItem.Text = "Batch &Extract Takes To Clips...";
            this.openTakesToolStripMenuItem.ToolTipText = "Load a list of animation takes from an FBX file and save them in a keyframe forma" +
    "t";
            this.openTakesToolStripMenuItem.Click += new System.EventHandler(this.OpenTakesMenu_Click);
            // 
            // mergeToClipsMenuItem
            // 
            this.mergeToClipsMenuItem.Name = "mergeToClipsMenuItem";
            this.mergeToClipsMenuItem.Size = new System.Drawing.Size(230, 22);
            this.mergeToClipsMenuItem.Text = "&Merge Animations To Clips...";
            this.mergeToClipsMenuItem.Click += new System.EventHandler(this.mergeToClipsMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(227, 6);
            // 
            // SaveBoneMapMenu
            // 
            this.SaveBoneMapMenu.Enabled = false;
            this.SaveBoneMapMenu.Name = "SaveBoneMapMenu";
            this.SaveBoneMapMenu.Size = new System.Drawing.Size(230, 22);
            this.SaveBoneMapMenu.Text = "Save Bone &Map...";
            this.SaveBoneMapMenu.ToolTipText = "Save a list of bone names with their numeric index and thier parent bone";
            this.SaveBoneMapMenu.Click += new System.EventHandler(this.SaveBoneMapMenu_Click);
            // 
            // SaveBindPoseMenuItem
            // 
            this.SaveBindPoseMenuItem.Enabled = false;
            this.SaveBindPoseMenuItem.Name = "SaveBindPoseMenuItem";
            this.SaveBindPoseMenuItem.Size = new System.Drawing.Size(230, 22);
            this.SaveBindPoseMenuItem.Text = "Save Bind &Pose...";
            this.SaveBindPoseMenuItem.ToolTipText = "Save the matrix of each bone while it is at rest";
            this.SaveBindPoseMenuItem.Click += new System.EventHandler(this.SaveBindPoseMenu_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(227, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
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
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
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
            this.ClipNamesComboBox.Size = new System.Drawing.Size(201, 23);
            this.ClipNamesComboBox.Text = "Pose";
            this.ClipNamesComboBox.Visible = false;
            this.ClipNamesComboBox.TextChanged += new System.EventHandler(this.ClipNamesComboBox_Changed);
            // 
            // statusPanel
            // 
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Enabled = false;
            this.statusPanel.Location = new System.Drawing.Point(0, 672);
            this.statusPanel.Margin = new System.Windows.Forms.Padding(12);
            this.statusPanel.Multiline = true;
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.ReadOnly = true;
            this.statusPanel.Size = new System.Drawing.Size(1008, 121);
            this.statusPanel.TabIndex = 2;
            this.statusPanel.TabStop = false;
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(12, 681);
            this.textStatus.Multiline = true;
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textStatus.Size = new System.Drawing.Size(755, 100);
            this.textStatus.TabIndex = 3;
            this.textStatus.TabStop = false;
            // 
            // numericLarge
            // 
            this.numericLarge.CausesValidation = false;
            this.numericLarge.InterceptArrowKeys = false;
            this.numericLarge.Location = new System.Drawing.Point(830, 682);
            this.numericLarge.Name = "numericLarge";
            this.numericLarge.Size = new System.Drawing.Size(90, 20);
            this.numericLarge.TabIndex = 40;
            // 
            // numericSmall
            // 
            this.numericSmall.CausesValidation = false;
            this.numericSmall.InterceptArrowKeys = false;
            this.numericSmall.Location = new System.Drawing.Point(830, 708);
            this.numericSmall.Name = "numericSmall";
            this.numericSmall.Size = new System.Drawing.Size(90, 20);
            this.numericSmall.TabIndex = 42;
            // 
            // labelLarge
            // 
            this.labelLarge.AutoSize = true;
            this.labelLarge.Location = new System.Drawing.Point(787, 684);
            this.labelLarge.Name = "labelLarge";
            this.labelLarge.Size = new System.Drawing.Size(37, 13);
            this.labelLarge.TabIndex = 6;
            this.labelLarge.Text = "Large:";
            // 
            // labelSmall
            // 
            this.labelSmall.AutoSize = true;
            this.labelSmall.Location = new System.Drawing.Point(789, 710);
            this.labelSmall.Name = "labelSmall";
            this.labelSmall.Size = new System.Drawing.Size(35, 13);
            this.labelSmall.TabIndex = 7;
            this.labelSmall.Text = "Small:";
            // 
            // buttonLarge
            // 
            this.buttonLarge.Location = new System.Drawing.Point(926, 680);
            this.buttonLarge.Name = "buttonLarge";
            this.buttonLarge.Size = new System.Drawing.Size(51, 23);
            this.buttonLarge.TabIndex = 41;
            this.buttonLarge.Text = "Go";
            this.buttonLarge.UseVisualStyleBackColor = true;
            this.buttonLarge.Click += new System.EventHandler(this.buttonLarge_Click);
            // 
            // buttonSmall
            // 
            this.buttonSmall.Location = new System.Drawing.Point(926, 706);
            this.buttonSmall.Name = "buttonSmall";
            this.buttonSmall.Size = new System.Drawing.Size(51, 23);
            this.buttonSmall.TabIndex = 43;
            this.buttonSmall.Text = "Go";
            this.buttonSmall.UseVisualStyleBackColor = true;
            this.buttonSmall.Click += new System.EventHandler(this.buttonSmall_Click);
            // 
            // modelViewerControl
            // 
            this.modelViewerControl.AutoRotateSpeed = 0F;
            this.modelViewerControl.CurrentMoveSpeed = 0.6F;
            this.modelViewerControl.CurrentTurnSpeed = 1F;
            this.modelViewerControl.DiffuseColour = new Microsoft.Xna.Framework.Vector3(1F, 1F, 1F);
            this.modelViewerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.modelViewerControl.EmissiveColour = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            this.modelViewerControl.IsAnimated = false;
            this.modelViewerControl.Light1Enabled = true;
            this.modelViewerControl.Light2Enabled = true;
            this.modelViewerControl.Location = new System.Drawing.Point(0, 27);
            this.modelViewerControl.Name = "modelViewerControl";
            this.modelViewerControl.Options = Engine.ModelViewerControl.DrawOptions.None;
            this.modelViewerControl.OrbitMode = false;
            this.modelViewerControl.PauseInput = true;
            this.modelViewerControl.ReverseLighting = true;
            this.modelViewerControl.SelectedBound = -1;
            this.modelViewerControl.ShowAxes = true;
            this.modelViewerControl.Size = new System.Drawing.Size(1008, 648);
            this.modelViewerControl.SpecularColour = new Microsoft.Xna.Framework.Vector3(0.25F, 0.25F, 0.25F);
            this.modelViewerControl.SpecularPower = 16F;
            this.modelViewerControl.TabIndex = 1;
            this.modelViewerControl.Text = "modelViewerControl";
            this.modelViewerControl.ViewUp = 1;
            // 
            // statusOrbit
            // 
            this.statusOrbit.AutoSize = true;
            this.statusOrbit.Location = new System.Drawing.Point(792, 758);
            this.statusOrbit.Name = "statusOrbit";
            this.statusOrbit.Size = new System.Drawing.Size(59, 13);
            this.statusOrbit.TabIndex = 45;
            this.statusOrbit.Text = "Orbit Mode";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1008, 793);
            this.Controls.Add(this.statusOrbit);
            this.Controls.Add(this.buttonSmall);
            this.Controls.Add(this.buttonLarge);
            this.Controls.Add(this.labelSmall);
            this.Controls.Add(this.labelLarge);
            this.Controls.Add(this.numericSmall);
            this.Controls.Add(this.numericLarge);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.modelViewerControl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "3D Model Prep  __  [John C Brown http://www.MistyManor.co.uk]";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSmall)).EndInit();
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
        private System.Windows.Forms.TextBox statusPanel;
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
        private System.Windows.Forms.ToolStripComboBox ClipNamesComboBox;
        private System.Windows.Forms.ToolStripMenuItem PoseHeading;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SaveClipMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem LoadFBXAnimationMenu;
        private System.Windows.Forms.ToolStripMenuItem RotationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFloorMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem resetViewingPointMenu;
        private System.Windows.Forms.ToolStripMenuItem diabolicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelCommonPropertiesItem;
        private System.Windows.Forms.ToolStripMenuItem noBoundsItem;
        private System.Windows.Forms.ToolStripMenuItem allLargeBoundsItem;
        private System.Windows.Forms.ToolStripMenuItem allSmallBoundsItem;
        private System.Windows.Forms.ToolStripMenuItem smallBoundsInTheSelectedBoundItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeModelTypeItem;
        private System.Windows.Forms.ToolStripMenuItem boundingCylinderStanding;
        private System.Windows.Forms.ToolStripMenuItem boundsAttachedToBonesItem;
        private System.Windows.Forms.ToolStripMenuItem wireframeItem;
        private System.Windows.Forms.ToolStripMenuItem invertYControlsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem createStructureBoundsItem;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.NumericUpDown numericLarge;
        private System.Windows.Forms.NumericUpDown numericSmall;
        private System.Windows.Forms.Label labelLarge;
        private System.Windows.Forms.Label labelSmall;
        private System.Windows.Forms.ToolStripMenuItem optimiseBoundsItem;
        private System.Windows.Forms.Button buttonLarge;
        private System.Windows.Forms.Button buttonSmall;
        private System.Windows.Forms.ToolStripMenuItem showAxesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelTypePropertiesItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem light1EnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem light2EnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseLightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeToClipsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundingCylinderCrouched;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem editCharacterBoundsMenu;
        private System.Windows.Forms.ToolStripMenuItem orbitTheModelMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.Label statusOrbit;
        private System.Windows.Forms.ToolStripMenuItem loadDiabolicalmodelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDiabolicalmodelMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;

    }
}

