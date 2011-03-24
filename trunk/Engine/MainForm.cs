#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
// Modified from the samples provided by
// Microsoft XNA Community Game Platform
//-----------------------------------------------------------------------------
#endregion

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using AssetData;
using AssetContent;

namespace Engine
{
    /// <summary>
    /// Custom form provides the main user interface for the program.
    /// In this sample we used the designer to fill the entire form with a
    /// ModelViewerControl, except for the menu bar which provides the
    /// "File / Open..." option.
    /// </summary>
    public partial class MainForm : Form
    {
        private ContentBuilder contentBuilder;
        private ContentManager contentManager;

        private string defaultFileFolder = "";
        public string DefaultFileFolder
        {
            get { return defaultFileFolder; }
        }

        private string lastLoadedFile = "";

        private string rotateX = "0";
        private string rotateY = "0";
        private string rotateZ = "0";

        private Dictionary<string, AnimationClip> loadedClips = new Dictionary<string,AnimationClip>();
        private List<string> clipNames = new List<string>();
        private string currentClipName = "";

        private DiabolicalManager diabolical;

        /// <summary>
        /// Constructs the main form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            contentBuilder = new ContentBuilder();

            contentManager = new ContentManager(modelViewerControl.Services,
                                                contentBuilder.OutputDirectory);
            // A folder in the users MyDocuments
            defaultFileFolder = GetSavePath();

            UpdateMenuItemVisibility();

            modelViewerControl.StepUp += new EventHandler<EventArgs>(modelViewerControl_StepUp);
            modelViewerControl.StepDown += new EventHandler<EventArgs>(modelViewerControl_StepDown);
            modelViewerControl.DeleteBound += new EventHandler<EventArgs>(modelViewerControl_DeleteBound);
            
        }

        private void buttonLarge_Click(object sender, EventArgs e)
        {
            diabolical.CurrentLargerBound = (int)numericLarge.Value;
            ChangeSelectedBound(0);
            ShowBoundSelections();
        }

        private void buttonSmall_Click(object sender, EventArgs e)
        {
            diabolical.CurrentSmallerBound = (int)numericSmall.Value;
            ChangeSelectedBound(0);
            ShowBoundSelections();
        }

        private void modelViewerControl_DeleteBound(object sender, EventArgs e)
        {
            DeleteSelectedBound();
        }

        private void modelViewerControl_StepDown(object sender, EventArgs e)
        {
            ChangeSelectedBound(-1);
        }

        private void modelViewerControl_StepUp(object sender, EventArgs e)
        {
            ChangeSelectedBound(1);
        }

        private void ChangeSelectedBound(int increment)
        {
            if (diabolical == null || noBoundsItem.Checked)
            {
                return;
            }
            if (allLargeBoundsItem.Checked)
            {
                diabolical.ChangeLargerShowLarger(increment);
            }
            else if (allSmallBoundsItem.Checked)
            {
                diabolical.ChangeSmallerShowSmaller(increment);
            }
            else if (smallBoundsInTheSelectedBoundItem.Checked)
            {
                diabolical.ChangeSmallerInLargerShowInLarger(increment);
            }
            ShowBoundSelections();
        }

        private void DeleteSelectedBound()
        {
            if (diabolical == null || noBoundsItem.Checked)
            {
                return;
            }
            if (allLargeBoundsItem.Checked)
            {
                WarnBeforeDeleteLargerBound();
            }
            else if (allSmallBoundsItem.Checked)
            {
                diabolical.DeleteSelectedSmallerBound();
                ChangeSelectedBound(-1);
            }
            else if (smallBoundsInTheSelectedBoundItem.Checked)
            {
                diabolical.DeleteSelectedSmallerBound();
                ChangeSelectedBound(-1);
            }
        }

        private void WarnBeforeDeleteLargerBound()
        {
            if (MessageBox.Show("Manually deleting the larger bounds can leave orphaned smaller\n" +
                "bounds which will create holes in the collision model.\n" +
                "It is recommended that you delete only smaller bounds and let\n" +
                "the optimisation method remove empty larger bounds.\n" +
                "Are you sure you want to continue?", "Delete Larger Bounds!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                diabolical.DeleteSelectedLargerBound();
                ChangeSelectedBound(-1);
            }
        }

        /// <summary>
        /// See also DefaultFileFolder
        /// </summary>
        public static string GetSavePath()
        {
            string result = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                GlobalSettings.pathSaveGameFolder, GlobalSettings.pathSaveDataFolder);
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
        }

        //////////////////////////////////////////////////////////////////////
        // == Setup ==
        //
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Used for loading, saving and setting the properties of models for using in Diabolical:The Shooter
            diabolical = new DiabolicalManager(this, modelViewerControl.DebugShapes);

            ShowFloor(true);
            ShowAxes(true);
            modelViewerControl.PauseInput = false;
            menuStrip1.MenuActivate += new EventHandler(menuStrip1_MenuActivate);
            menuStrip1.MenuDeactivate += new EventHandler(menuStrip1_MenuDeactivate);
        }

        private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
        {
            PauseGameInput(false);
        }

        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            PauseGameInput(true);
        }

        private void PauseGameInput(bool change)
        {
            modelViewerControl.PauseInput = change;
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == File ==
        //
        private void OpenRigidModelMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Load Rigid Model";

            fileDialog.Filter = "Model Files (*.fbx;*.x)|*.fbx;*.x|" +
                                "FBX Files (*.fbx)|*.fbx|" +
                                "X Files (*.x)|*.x|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                lastLoadedFile = fileDialog.FileName;
                LoadModel(fileDialog.FileName);
            }
            AddMessageLine("== Finished ==");
            UpdateMenuItemVisibility();
        }

        /// <summary>
        /// Event handler for the Open menu option.
        /// </summary>
        private void OpenAnimatedModelMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Load Animated Model";

            fileDialog.Filter = "Model Files (*.fbx;*.x)|*.fbx;*.x|" +
                                "FBX Files (*.fbx)|*.fbx|" +
                                "X Files (*.x)|*.x|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                lastLoadedFile = fileDialog.FileName;
                LoadModel(true, fileDialog.FileName, rotateX, rotateY, rotateZ);
                //LoadAnimatedModel(contentManager, true, fileDialog.FileName, "90", "0", "180");
            }
            AddMessageLine("== Finished ==");
            UpdateMenuItemVisibility();
        }

        private void loadIndividualClip_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Load an individual animation clip";

            fileDialog.Filter = "Animation Files (*.clip)|*.clip|" +
                                //"Part Files (*.head;*.arms)|*.head;*.arms|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                LoadClip(fileDialog.FileName);
            }
            AddMessageLine("== Finished ==");
        }

        /*
        private void loadBlenderAction_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Load a Blender Action";

            fileDialog.Filter = "Animation Files (*.action)|*.action|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                LoadActions(fileDialog.FileName);
            }
            AddMessageLine("== Finished ==");
        }
        */

        private void LoadFBXAnimationMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Load FBX or X Animation";

            fileDialog.Filter = "Animation (*.fbx;*.x)|*.fbx;*.x|" +
                    "FBX Animation (*.fbx)|*.fbx|" +
                    "X Animation (*.x)|*.x|" +
                    "All Files (*.*)|*.*";


            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                LoadAnimationTakes(fileDialog.FileName, rotateX, rotateY, rotateZ);
            }
            AddMessageLine("== Finished ==");
        }

        private void SplitFBXMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Split FBX Model files to have only one take per file";

            fileDialog.Filter = "FBX Files (*.fbx)|*.fbx|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                lastLoadedFile = fileDialog.FileName;
                SplitFBX(fileDialog.FileName);
            }
            AddMessageLine("== Finished ==");
            UpdateMenuItemVisibility();
        }

        private void OpenTakesMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = defaultFileFolder;

            fileDialog.Title = "Load a list of animation takes and save them in a keyframe format";

            fileDialog.Filter = "Takes Files (*.takes)|*.takes|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearMessages();
                lastLoadedFile = fileDialog.FileName;
                LoadTakes(fileDialog.FileName);
            }
            AddMessageLine("== Finished ==");
            UpdateMenuItemVisibility();
        }

        private void SaveBoneMapMenu_Click(object sender, EventArgs e)
        {
            if (modelViewerControl.Model == null)
            {
                // Can only save one if we have a model
                return;
            }
            SkinningData skinData = (SkinningData)modelViewerControl.Model.Tag;
            if (skinData == null)
            {
                AddMessageLine("Not an animated model!");
                SaveBoneMapMenu.Enabled = false;
                SaveBindPoseMenuItem.Enabled = false;
                return;
            }
            BoneMapSaveDialogue(GetBoneMapList(skinData));
            AddMessageLine("== Finished ==");
        }

        private void SaveBindPoseMenu_Click(object sender, EventArgs e)
        {
            if (modelViewerControl.Model == null)
            {
                // Can only save one if we have a model
                return;
            }
            BindPoseSaveDialogue(GetBindPoseList());
            AddMessageLine("== Finished ==");
        }

        private void SaveClip_Click(object sender, EventArgs e)
        {
            if (modelViewerControl.Model == null || currentClipName == GlobalSettings.listRestPoseName)
            {
                // Can only save one if we have a model and it is not displaying the bind pose
                return;
            }
            SkinningData skinData = (SkinningData)modelViewerControl.Model.Tag;
            if (skinData == null)
            {
                AddMessageLine("Not an animated model!");
                return;
            }
            ClipSaveDialogue(ParseClips.GetAnimationClipData(modelViewerControl.GetCurrentClip(), 
                                skinData.BoneMap, null));
            AddMessageLine("== Finished ==");
        }

        /// <summary>
        /// Event handler for the Exit menu option.
        /// </summary>
        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == View and Help ==
        //
        private void yUp_Click(object sender, EventArgs e)
        {
            yUpMenuItem.Checked = true;
            zUpMenuItem.Checked = false;
            zDownMenuItem.Checked = false;
            modelViewerControl.ViewUp = 1;
            ShowFloor(previousShowFloor);
        }

        private void zUp_Click(object sender, EventArgs e)
        {
            yUpMenuItem.Checked = false;
            zUpMenuItem.Checked = true;
            zDownMenuItem.Checked = false;
            modelViewerControl.ViewUp = 2;
            ShowFloor(false);
        }

        private void zDown_Click(object sender, EventArgs e)
        {
            yUpMenuItem.Checked = false;
            zUpMenuItem.Checked = false;
            zDownMenuItem.Checked = true;
            modelViewerControl.ViewUp = 3;
            ShowFloor(false);
        }

        // Remember what was set between changing views
        private bool previousShowFloor = true;

        private void showFloor_Click(object sender, EventArgs e)
        {
            ShowFloor(!showFloorMenuItem.Checked);
            // Remember the current setting so we can change back after changing views
            previousShowFloor = showFloorMenuItem.Checked;
        }

        private void ShowFloor(bool show)
        {
            if (show && modelViewerControl.Floor == null)
            {
                Loader contentLoad = new Loader(modelViewerControl.Services);
                modelViewerControl.SetFloor(contentLoad.GetModel("grid100x100"));
            }
            showFloorMenuItem.Checked = show;
            showFloorMenuItem.Checked = modelViewerControl.ShowFloor(show);
        }


        private void showAxesMenuItem_Click(object sender, EventArgs e)
        {
            ShowAxes(!showAxesMenuItem.Checked);
        }

        private void ShowAxes(bool show)
        {
            if (show && !modelViewerControl.IsAxisFontLoaded())
            {
                Loader contentLoad = new Loader(modelViewerControl.Services);
                modelViewerControl.SetAxisFont(contentLoad.GetFont("Axis"));
            }
            showAxesMenuItem.Checked = show;
            modelViewerControl.ShowAxes = show;
        }


        private void wireframeItem_Click(object sender, EventArgs e)
        {
            wireframeItem.Checked = !wireframeItem.Checked;
            modelViewerControl.WireFrameEnable(wireframeItem.Checked);
        }

        private void invertYControlsItem_Click(object sender, EventArgs e)
        {
            invertYControlsItem.Checked = !invertYControlsItem.Checked;
            modelViewerControl.InvertY = invertYControlsItem.Checked;
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PauseGameInput(true);
            HelpForm aForm = new HelpForm();
            aForm.ShowDialog();
            PauseGameInput(false);
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Menu Visibility ==
        //
        public void UpdateMenuItemVisibility()
        {
            HasModelLoaded();
            WhatModelType();
            ShowBoundSelections();
        }
        /// <summary>
        /// Call this to enable the various menu items that require an already loaded animated model
        /// </summary>
        private void HasModelLoaded()
        {
            if (modelViewerControl.Model == null || !modelViewerControl.IsAnimated)
            {
                PoseHeading.Visible = false;
                ClipNamesComboBox.Visible = false;
                ClipNamesComboBox.Enabled = false;
                SaveBoneMapMenu.Enabled = false;
                SaveBindPoseMenuItem.Enabled = false;
                LoadIndividualClipMenu.Enabled = false;
                LoadFBXAnimationMenu.Enabled = false;
                return;
            }
            PoseHeading.Visible = true;
            ClipNamesComboBox.Visible = true;
            ClipNamesComboBox.Text = currentClipName;
            ClipNamesComboBox.Enabled = true;
            SaveBoneMapMenu.Enabled = true;
            SaveBindPoseMenuItem.Enabled = true;
            LoadIndividualClipMenu.Enabled = true;
            LoadFBXAnimationMenu.Enabled = true;
        }

        private void HaveClipsLoaded()
        {
            ClipNamesComboBox.Items.Clear();
            ClipNamesComboBox.Items.Add(GlobalSettings.listRestPoseName);
            if (loadedClips != null && loadedClips.Count < 1)
            {
                return;
            }
            ClipNamesComboBox.Items.AddRange(clipNames.ToArray());
            ClipNamesComboBox.Text = currentClipName;
        }

        private void WhatModelType()
        {
            // Diabolical model properties
            savemodelItem.Enabled = false;
            modelPropertiesItem.Enabled = false;
            changeModelTypeItem.Enabled = false;
            createStructureBoundsItem.Enabled = false;
            optimiseBoundsItem.Enabled = false;
            // Bounds
            noBoundsItem.Enabled = false;
            allLargeBoundsItem.Enabled = false;
            allSmallBoundsItem.Enabled = false;
            smallBoundsInTheSelectedBoundItem.Enabled = false;
            boundsWhileStandingItem.Enabled = false;
            boundsWhileCrouchedItem.Enabled = false;
            boundsAttachedToBonesItem.Enabled = false;

            allLargeBoundsItem.Visible = false;
            allSmallBoundsItem.Visible = false;
            smallBoundsInTheSelectedBoundItem.Visible = false;
            boundsWhileStandingItem.Visible = false;
            boundsWhileCrouchedItem.Visible = false;
            boundsAttachedToBonesItem.Visible = false;

            if (diabolical != null && modelViewerControl.Model != null)
            {
                changeModelTypeItem.Enabled = true;
                if (diabolical.CanSave())
                {
                    savemodelItem.Enabled = true;
                }
                if (diabolical.CanEdit())
                {
                    modelPropertiesItem.Enabled = true;
                }

                if (diabolical.IsStructure)
                {
                    createStructureBoundsItem.Enabled = true;
                }

                if (diabolical.HasStructureBounds())
                {
                    noBoundsItem.Enabled = true;

                    allLargeBoundsItem.Visible = true;
                    allSmallBoundsItem.Visible = true;
                    smallBoundsInTheSelectedBoundItem.Visible = true;

                    allLargeBoundsItem.Enabled = true;
                    allSmallBoundsItem.Enabled = true;
                    smallBoundsInTheSelectedBoundItem.Enabled = true;

                    optimiseBoundsItem.Enabled = true;
                }
                else if (diabolical.HasCharacterBounds())
                {
                    noBoundsItem.Enabled = true;

                    boundsWhileStandingItem.Visible = true;
                    boundsWhileCrouchedItem.Visible = true;
                    boundsAttachedToBonesItem.Visible = true;

                    boundsWhileStandingItem.Enabled = true;
                    boundsWhileCrouchedItem.Enabled = true;
                    boundsAttachedToBonesItem.Enabled = true;
                }

            }
        }

        private void ShowBoundSelections()
        {
            numericLarge.ReadOnly = true;
            numericSmall.ReadOnly = true;
            numericLarge.Minimum = -1;
            numericSmall.Minimum = -1;
            if (diabolical != null)
            {
                if (diabolical.HasStructureBounds())
                {
                    numericLarge.Maximum = diabolical.HighestLargerBound;
                    numericLarge.Value = diabolical.CurrentLargerBound;
                    numericSmall.Maximum = diabolical.HighestSmallerBound;
                    numericSmall.Value = diabolical.CurrentSmallerBound;
                    numericLarge.ReadOnly = false;
                    numericSmall.ReadOnly = false;
                }
            }
            else
            {
                numericLarge.Value = -1;
                numericSmall.Value = -1;
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Status Messages ==
        //
        public void ClearMessages()
        {
            textStatus.Clear();
        }

        public void AddMessageLine(string text)
        {
            textStatus.AppendText(text + "\n");
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Load and Save ==
        //
        public Model CurrentModel
        {
            get { return modelViewerControl.Model; }
        }

        /// <summary>
        /// Loads a new 3D model file into the ModelViewerControl.
        /// </summary>
        public void LoadModel(string fileName)
        {
            LoadModel(false, fileName, rotateX, rotateY, rotateZ);
        }

        public void LoadModel(bool isAnimated, string fileName, float rotateXdeg, float rotateYdeg, float rotateZdeg)
        {
            rotateX = ParseData.FloatToString(rotateXdeg);
            rotateY = ParseData.FloatToString(rotateYdeg);
            rotateZ = ParseData.FloatToString(rotateZdeg);
            LoadModel(isAnimated, fileName, rotateX, rotateY, rotateZ);
        }

        /// <summary>
        /// Loads a new 3D model file into the ModelViewerControl.
        /// </summary>
        public void LoadModel(bool isAnimated, string fileName, string rotateXdeg, string rotateYdeg, string rotateZdeg)
        {
            Cursor = Cursors.WaitCursor;
            // Looks better when displaying results
            fileName = ParseData.StandardiseFolderCharacters(fileName);
            // Clear away the previous stuff
            HideAllOutlines();
            modelViewerControl.UnloadModel();

            // Clear the content manager so that a new model is loaded otherwise the same name cannot be loaded again!
            contentManager.Unload();

            // Tell the ContentBuilder what to build.
            contentBuilder.Clear();
            ClearClips();
            if (isAnimated)
            {
                AddMessageLine("Loading animated model: " + fileName);
                // Test
                //List<string> mergeFiles = new List<string>();
                //mergeFiles.Add(@"C:\Users\John\Documents\SavedGames\ExtractTakes\TestDudeAnimations-Patrol2.fbx");
                //contentBuilder.AddWithMergedAnimations(fileName, "Model", rotateXdeg, rotateYdeg, rotateZdeg, mergeFiles);

                contentBuilder.AddAnimated(fileName, "Model", rotateXdeg, rotateYdeg, rotateZdeg);
            }
            else
            {
                AddMessageLine("Loading model: " + fileName);
                contentBuilder.AddModel(fileName, "Model", rotateXdeg, rotateYdeg, rotateZdeg);
            }
            AddMessageLine("Rotating model: X " + rotateXdeg + ", Y " + rotateYdeg + ", Z " + rotateZdeg);

            // Build this new model data.
            string buildError = contentBuilder.Build();
            string buildWarnings = contentBuilder.Warnings();
            if (!string.IsNullOrEmpty(buildWarnings))
            {
                AddMessageLine(buildWarnings);
            }

            if (string.IsNullOrEmpty(buildError))
            {
                // If the build succeeded, use the ContentManager to
                // load the temporary .xnb file that we just created.
                string result = modelViewerControl.SetModel(isAnimated, contentManager.Load<Model>("Model"));
                if (!string.IsNullOrEmpty(result))
                {
                    AddMessageLine(result);
                }
                if (modelViewerControl.Model != null)
                {
                    // Store the loaded model filename and the model for use elsewhere
                    if (diabolical != null)
                    {
                        diabolical.LastLoaded3DModelFile = fileName;
                        diabolical.Model = modelViewerControl.Model;
                        diabolical.SetModelRotation(rotateXdeg, rotateYdeg, rotateZdeg);
                    }
                    // Scale
                    AddMessageLine("The width of each grid square is: " + modelViewerControl.GridSquareWidth + " unit(s)");
                    // Add any animation
                    SkinningData skinData = (SkinningData)modelViewerControl.Model.Tag;
                    if (skinData != null)
                    {
                        foreach (string key in skinData.AnimationClips.Keys)
                        {
                            AnimationClip clip = skinData.AnimationClips[key];
                            if (clip != null)
                            {
                                AddToClipList(clip, key);
                            }
                        }
                    }
                }
                currentClipName = GlobalSettings.listRestPoseName;
            }
            else
            {
                // If the build failed, display an error message and log it
                AddMessageLine(buildError);
                MessageBox.Show(buildError, "Error");
            }

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Loads an animation and add to the clips
        /// </summary>
        public void LoadAnimationTakes(string fileName, string rotateXdeg, string rotateYdeg, string rotateZdeg)
        {
            Cursor = Cursors.WaitCursor;

            // Clear the content builder as each item must have a unique content name
            //contentBuilder.Clear();
            // Tell the ContentBuilder what to build.
            string uniqueName = DateTime.Now.ToString(GlobalSettings.timeFormat);
            AddMessageLine("Loading animation: " + fileName);
            contentBuilder.AddAnimated(fileName, uniqueName, rotateXdeg, rotateYdeg, rotateZdeg);
            AddMessageLine("Rotating animation: X " + rotateXdeg + ", Y " + rotateYdeg + ", Z " + rotateZdeg);

            // Build this new model data.
            string buildError = contentBuilder.Build();
            string buildWarnings = contentBuilder.Warnings();
            if (!string.IsNullOrEmpty(buildWarnings))
            {
                AddMessageLine(buildWarnings);
            }

            if (string.IsNullOrEmpty(buildError))
            {
                // If the build succeeded, use the ContentManager to
                // load the temporary .xnb file that we just created.
                Model animated = contentManager.Load<Model>(uniqueName);
                if (animated == null)
                {
                    AddMessageLine("The animation file did not load!");
                }
                else
                {
                    SkinningData skinData = (SkinningData)animated.Tag;
                    if (skinData != null)
                    {
                        foreach (string key in skinData.AnimationClips.Keys)
                        {
                            AnimationClip clip = skinData.AnimationClips[key];
                            if (clip != null)
                            {
                                AddToClipList(clip, key);
                            }
                        }
                    }
                    else
                    {
                        AddMessageLine("No animations were found in the file!");
                    }
                }
            }
            else
            {
                // If the build failed, display an error message and log it
                AddMessageLine(buildError);
                MessageBox.Show(buildError, "Error");
            }

            Cursor = Cursors.Arrow;
        }

        public SkinningData GetModelSkinData()
        {
            if (modelViewerControl.Model == null)
            {
                return null;
            }
            return (SkinningData)modelViewerControl.Model.Tag;
        }

        public IDictionary<string, int> GetBoneMap()
        {
            if (modelViewerControl.Model == null)
            {
                return null;
            }

            SkinningData skinData = (SkinningData)modelViewerControl.Model.Tag;
            if (skinData == null)
            {
                return null;
            }
            return skinData.BoneMap;
        }

        private void SplitFBX(string fileName)
        {
            Cursor = Cursors.WaitCursor;

            if (!File.Exists(fileName))
            {
                AddMessageLine("File not found: " + fileName);
                Cursor = Cursors.Arrow;
                return;
            }

            ParseFBX fbx = new ParseFBX(this);
            fbx.LoadAsText(fileName);

            LoadModel(true, fileName, rotateX, rotateY, rotateZ);

            fbx.SaveIndividualFBXtakes();

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Loads a text file into an array
        /// </summary>
        private void LoadTakes(string fileName)
        {
            Cursor = Cursors.WaitCursor;

            ClearMessages();
            ParseTakes takes = new ParseTakes(this);
            takes.Load(fileName);

            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Loads a text file and converts to an Animation Clip
        /// </summary>
        private void LoadClip(string fileName)
        {
            Cursor = Cursors.WaitCursor;

            ClearMessages();
            ParseClips clips = new ParseClips(this);
            AnimationClip clip = null;
            // Wrap in a try catch just in case the file format is wrong
            try
            {
                clip = clips.Load(fileName);
            }
            catch (Exception e)
            {
                AddMessageLine(e.ToString());
            }

            string name = Path.GetFileNameWithoutExtension(fileName);
            AddToClipList(clip, name);

            Cursor = Cursors.Arrow;
        }

        // Add a clip to the list and diplays it
        private void AddToClipList(AnimationClip clip, string name)
        {
            if (clip != null)
            {
                if (loadedClips.ContainsKey(name))
                {
                    // rename to avoid duplicates
                    name += DateTime.Now.ToString(GlobalSettings.timeFormat);
                }
                clipNames.Add(name);
                loadedClips.Add(name, clip);
                currentClipName = name;
                string error = modelViewerControl.SetExternalClip(clip);
                SaveClipMenu.Enabled = true;
                if (!string.IsNullOrEmpty(error))
                {
                    AddMessageLine(error);
                    DisplayTheBindPose();
                }
            }
            else
            {
                AddMessageLine("No clip data!");
            }
            HaveClipsLoaded();
        }

        /*
        /// <summary>
        /// Loads a text file and converts to an Animation Clip
        /// </summary>
        private void LoadActions(string fileName)
        {
            Cursor = Cursors.WaitCursor;

            ClearMessages();
            ParseBlenderAction clips = new ParseBlenderAction(this);
            clipNames.Clear();
            loadedClips.Clear();
            // Wrap in a try catch just in case the file format is wrong
            try
            {
                loadedClips = clips.Load(fileName, modelViewerControl.Model,
                                                    rotateX, rotateY, rotateZ);
            }
            catch (Exception e)
            {
                AddMessageLine(e.ToString());
            }

            if (loadedClips != null && loadedClips.Count > 0)
            {
                clipNames.AddRange(loadedClips.Keys);
                AddMessageLine(string.Format("{0} actions loaded.", loadedClips.Count));
            }
            else
            {
                AddMessageLine("No actions loaded!");
            }
            HaveClipsLoaded();

            Cursor = Cursors.Arrow;
        }
         * */

        // Ready for a new model to load
        private void ClearClips()
        {
            clipNames.Clear();
            currentClipName = "";
            loadedClips.Clear();
            HaveClipsLoaded();
        }

        private void BoneMapSaveDialogue(List<string> data)
        {
            if (data.Count < 1)
            {
                AddMessageLine("No bone names!");
                return;
            }
            // Path to default location
            string pathToSaveFolder = defaultFileFolder;
            string assetName = "";
            string fileName = GlobalSettings.fileBoneMap;
            // If we have loaded a file use that for the path and the name
            if (lastLoadedFile != "")
            {
                pathToSaveFolder = Path.GetDirectoryName(lastLoadedFile);
                assetName = Path.GetFileNameWithoutExtension(lastLoadedFile) + "-";
            }
            // Append the bonemap name to the end of the filename
            fileName = assetName + fileName;

            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.InitialDirectory = pathToSaveFolder;

            fileDialog.Title = "Save a list of bone names with their numeric index";

            fileDialog.FileName = fileName;

            fileDialog.Filter = "Text Files (*.txt)|*.txt|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTextFile(fileDialog.FileName, data);
            }

        }

        private void BindPoseSaveDialogue(List<string> data)
        {
            if (data == null || data.Count < 1)
            {
                AddMessageLine("No bind pose!");
                return;
            }
            // Path to default location
            string pathToSaveFolder = defaultFileFolder;
            string assetName = "";
            string fileName = GlobalSettings.fileBindPose;
            // If we have loaded a file use that for the path and the name
            if (lastLoadedFile != "")
            {
                pathToSaveFolder = Path.GetDirectoryName(lastLoadedFile);
                assetName = Path.GetFileNameWithoutExtension(lastLoadedFile) + "-";
            }
            // Append the name to the end of the filename
            fileName = assetName + fileName;

            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.InitialDirectory = pathToSaveFolder;

            fileDialog.Title = "Save the bind pose matrices of the model";

            fileDialog.FileName = fileName;

            fileDialog.Filter = "Text Files (*.txt)|*.txt|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTextFile(fileDialog.FileName, data);
            }

        }

        private void ClipSaveDialogue(List<string> data)
        {
            if (data == null || data.Count < 1)
            {
                AddMessageLine("No clip data!");
                return;
            }
            // Path to default location
            string pathToSaveFolder = defaultFileFolder;
            string assetName = "";
            string fileName = currentClipName;
            // If we have loaded a file use that for the path and the name
            if (lastLoadedFile != "")
            {
                pathToSaveFolder = Path.GetDirectoryName(lastLoadedFile);
                assetName = Path.GetFileNameWithoutExtension(lastLoadedFile) + "-";
            }
            // Append the name to the end of the filename
            fileName = assetName + fileName;

            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.InitialDirectory = pathToSaveFolder;

            fileDialog.Title = "Save the animation clip";

            fileDialog.FileName = fileName;

            fileDialog.Filter = "Clip Files (*.clip)|*.clip|" +
                                "Head and Arms Files (*.head;*.arms)|*.head;*.arms|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTextFile(fileDialog.FileName, data);
            }

        }

        /// <summary>
        /// Used from various classes to save files
        /// </summary>
        public void SaveTextFile(string fileName, List<string> data)
        {
            if (data.Count < 1 || string.IsNullOrEmpty(fileName))
            {
                return;
            }

            Cursor = Cursors.WaitCursor;

            AddMessageLine("Saving: " + fileName);
            File.WriteAllLines(fileName, data);

            Cursor = Cursors.Arrow;

        }

        public List<string> GetBoneMapList(SkinningData skinData)
        {
            IDictionary<string, int> boneMap = skinData.BoneMap;

            // Convert to an array so we can loop through
            string[] keys = new string[boneMap.Keys.Count];
            boneMap.Keys.CopyTo(keys, 0);
            int[] values = new int[boneMap.Values.Count];
            boneMap.Values.CopyTo(values, 0);

            // Create the list to store the results
            List<string> results = new List<string>();
            // Add the headings
            results.Add("Bone = #  [ Parent = # ]");
            results.Add("========================");
            // Add the value pairs to the list
            for (int i = 0; i < boneMap.Count; i++)
            {
                int parent = skinData.SkeletonHierarchy[values[i]];
                if (parent >= 0 && parent < keys.Length)
                {
                    results.Add(String.Format("{0} = {1}  [ {2} = {3} ]", keys[i], values[i], keys[parent], parent));
                }
                else
                {
                    results.Add(String.Format("{0} = {1}  [ Root ]", keys[i], values[i]));
                }
            }
            return results;
        }

        public List<string> GetBindPoseList()
        {
            SkinningData skinData = (SkinningData)modelViewerControl.Model.Tag;
            if (skinData == null)
            {
                AddMessageLine("Not an animated model!");
                SaveBoneMapMenu.Enabled = false;
                SaveBindPoseMenuItem.Enabled = false;
                return null;
            }

            Matrix[] bonePose = new Matrix[skinData.BindPose.Count];
            skinData.BindPose.CopyTo(bonePose, 0);

            // Get the bone map so we can see the bone names
            IDictionary<string, int> boneMap = skinData.BoneMap;
            // Reverse the lookup
            Dictionary<int, string> reverseBoneMap = new Dictionary<int, string>();

            // Convert to an array so we can loop through
            string[] keys = new string[boneMap.Keys.Count];
            boneMap.Keys.CopyTo(keys, 0);
            int[] values = new int[boneMap.Values.Count];
            boneMap.Values.CopyTo(values, 0);

            // Fill reverse bonemap
            for (int b = 0; b < keys.Length; b++)
            {
                reverseBoneMap.Add(values[b], keys[b]);
            }

            // Create the list to store the results
            List<string> results = new List<string>();
            // Add the headings
            results.Add("A= Pose Bone     | Bind Pose Transform Matrix");
            results.Add("B= Armature Bone | Transform Matrix");
            results.Add("================================================");
            // Add the value to the list
            for (int i = 0; i < bonePose.Length; i++)
            {
                // Bind pose matrices
                results.Add(String.Format("A= {0} | {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}", 
                    reverseBoneMap[i], 
                    bonePose[i].M11, bonePose[i].M12, bonePose[i].M13, bonePose[i].M14, 
                    bonePose[i].M21, bonePose[i].M22, bonePose[i].M23, bonePose[i].M24, 
                    bonePose[i].M31, bonePose[i].M32, bonePose[i].M33, bonePose[i].M34, 
                    bonePose[i].M41, bonePose[i].M42, bonePose[i].M43, bonePose[i].M44));
                // Skeleton matrices
                Matrix armature = modelViewerControl.Model.Bones[i].Transform;
                results.Add(String.Format("B= {0} | {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}",
                    modelViewerControl.Model.Bones[i].Name,
                    armature.M11, armature.M12, armature.M13, armature.M14,
                    armature.M21, armature.M22, armature.M23, armature.M24,
                    armature.M31, armature.M32, armature.M33, armature.M34,
                    armature.M41, armature.M42, armature.M43, armature.M44));
            }
            return results;
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Rotations ==
        //
        private void PresetNoRotation_Click(object sender, EventArgs e)
        {
            XComboBox.Text = "X 0";
            rotateX = "0";
            YComboBox.Text = "Y 0";
            rotateY = "0";
            ZComboBox.Text = "Z 0";
            rotateZ = "0";

            AddMessageLine("Reset to no rotation");
            AddMessageLine("Models loaded will be rotated using the follow settings: X=" +
                rotateX + " Y=" + rotateY + " Z=" + rotateZ);
        }

        // Blender to XNA
        private void PresetZUpToYUp_Click(object sender, EventArgs e)
        {
            XComboBox.Text = "X 90";
            rotateX = "90";
            YComboBox.Text = "Y 0";
            rotateY = "0";
            ZComboBox.Text = "Z 180";
            rotateZ = "180";

            AddMessageLine("Preset rotation selected to rotate models from being +Z upwards to being +Y upwards (Blender to XNA)");
            AddMessageLine("Models loaded will be rotated using the follow settings: X=" +
                rotateX + " Y=" + rotateY + " Z=" + rotateZ);
        }

        private void PresetMinusZUpToYUpMenu_Click(object sender, EventArgs e)
        {
            XComboBox.Text = "X -90";
            rotateX = "-90";
            YComboBox.Text = "Y 0";
            rotateY = "0";
            ZComboBox.Text = "Z 180";
            rotateZ = "180";

            AddMessageLine("Preset rotation selected to rotate models from being +Z upwards to being +Y upwards (Blender to XNA)");
            AddMessageLine("Models loaded will be rotated using the follow settings: X=" +
                rotateX + " Y=" + rotateY + " Z=" + rotateZ);
        }

        private void XComboBox_Changed(object sender, EventArgs e)
        {
            rotateX = XComboBox.Text;
            rotateX = rotateX.Substring(2);
        }

        private void YComboBox_Changed(object sender, EventArgs e)
        {
            rotateY = YComboBox.Text;
            rotateY = rotateY.Substring(2);
        }

        private void ZComboBox_Changed(object sender, EventArgs e)
        {
            rotateZ = ZComboBox.Text;
            rotateZ = rotateZ.Substring(2);
        }

        private void resetViewingPoint_Click(object sender, EventArgs e)
        {
            modelViewerControl.InitialiseCameraPosition();
        }
        //
        //////////////////////////////////////////////////////////////////////


        private void ClipNamesComboBox_Changed(object sender, EventArgs e)
        {
            string nextClipName = ClipNamesComboBox.Text;
            // Always re-apply the bind pose when selected
            // otherwise only change if a different pose has been selected
            if (nextClipName != currentClipName || nextClipName == GlobalSettings.listRestPoseName)
            {
                if (loadedClips.ContainsKey(nextClipName))
                {
                    currentClipName = nextClipName;
                    string error = modelViewerControl.SetExternalClip(loadedClips[currentClipName]);
                    // Display the save clip menu option
                    SaveClipMenu.Enabled = true;
                    if (!string.IsNullOrEmpty(error))
                    {
                        AddMessageLine(error);
                        // Display Bind Pose if there are any errors
                        DisplayTheBindPose();
                    }
                }
                else
                {
                    // Anything else displays the Bind pose
                    DisplayTheBindPose();
                }
            }
        }

        public AnimationClip GetCurrentClip()
        {
            if (!string.IsNullOrEmpty(currentClipName))
            {
                return loadedClips[currentClipName];
            }
            return null;
        }

        public string GetCurrentClipName()
        {
            return currentClipName;
        }

        private void DisplayTheBindPose()
        {
            if (modelViewerControl.Model != null)
            {
                // Set the clip to null to show the bind pose
                string error = modelViewerControl.SetExternalClip(null);
                currentClipName = GlobalSettings.listRestPoseName;
                // Disable saving clips
                SaveClipMenu.Enabled = false;
                // To avoid an endless loop do not set the text unless it has changed
                if (ClipNamesComboBox.Text != currentClipName)
                {
                    ClipNamesComboBox.Text = currentClipName;
                }
                if (!string.IsNullOrEmpty(error))
                {
                    AddMessageLine(error);
                }
            }

        }

        /*
        private string GetContentFolder()
        {
            return Path.Combine(
                    Environment.CurrentDirectory,
                    GlobalSettings.pathContentFolder);
        }
         * */

        //////////////////////////////////////////////////////////////////////
        // == Diabolical Menu Actions ==
        //
        private void loadmodelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diabolical.LoadDialogue();
        }

        private void savemodelSettingsItem_Click(object sender, EventArgs e)
        {
            diabolical.SaveDialogue();
        }

        private void modelPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGameInput(true);
            if (diabolical != null)
            {
                diabolical.DisplayPropertyForms();
            }
            PauseGameInput(false);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseGameInput(true);
            float previousEmissive = modelViewerControl.EmissiveLightLevel;
            float previousAmbient = modelViewerControl.AmbientLightLevel;
            float previousDiffuse = modelViewerControl.DiffuseLightLevel;
            OptionsForm aForm = new OptionsForm();
            aForm.MovementSpeed = modelViewerControl.CurrentMoveSpeed;
            aForm.TurnSpeed = modelViewerControl.CurrentTurnSpeed;
            aForm.GridSquareWidth = modelViewerControl.GridSquareWidth.ToString();
            aForm.EmissiveLevel = previousEmissive;
            aForm.AmbientLevel = previousAmbient;
            aForm.DiffuseLevel = previousDiffuse;
            aForm.Emissive.ValueChanged += new EventHandler(Emissive_ValueChanged);
            aForm.Ambient.ValueChanged += new EventHandler(Ambient_ValueChanged);
            aForm.Diffuse.ValueChanged += new EventHandler(Diffuse_ValueChanged);
            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                modelViewerControl.CurrentMoveSpeed = aForm.MovementSpeed;
                modelViewerControl.CurrentTurnSpeed = aForm.TurnSpeed;
                modelViewerControl.EmissiveLightLevel = aForm.EmissiveLevel;
                modelViewerControl.AmbientLightLevel = aForm.AmbientLevel;
                modelViewerControl.DiffuseLightLevel = aForm.DiffuseLevel;
            }
            else
            {
                // Revert back to the previous levels
                modelViewerControl.EmissiveLightLevel = previousEmissive;
                modelViewerControl.AmbientLightLevel = previousAmbient;
                modelViewerControl.DiffuseLightLevel = previousDiffuse;
            }
            PauseGameInput(false);
        }

        private void Diffuse_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown sent = (NumericUpDown)sender;
            OptionsForm aForm = (OptionsForm)sent.Parent;
            modelViewerControl.DiffuseLightLevel = aForm.DiffuseLevel;
        }

        private void Ambient_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown sent = (NumericUpDown)sender;
            OptionsForm aForm = (OptionsForm)sent.Parent;
            modelViewerControl.AmbientLightLevel = aForm.AmbientLevel;
        }

        // Update the lighting level on the fly
        private void Emissive_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown sent = (NumericUpDown)sender;
            OptionsForm aForm = (OptionsForm)sent.Parent;
            modelViewerControl.EmissiveLightLevel = aForm.EmissiveLevel;
        }

        private void changeModelTypeItem_Click(object sender, EventArgs e)
        {
            if (diabolical == null)
            {
                return;
            }
            PauseGameInput(true);
            ModelTypeForm aForm = new ModelTypeForm();
            aForm.ModelType = diabolical.ModelType;
            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                diabolical.ModelType = aForm.ModelType;
            }
            PauseGameInput(false);
            UpdateMenuItemVisibility();
        }

        private void createStructureBoundsItem_Click(object sender, EventArgs e)
        {
            if (diabolical == null)
            {
                return;
            }
            PauseGameInput(true);
            CreateBoundsForm aForm = new CreateBoundsForm();
            aForm.SmallerWidth = GlobalSettings.boundSmallerWidth;
            aForm.LargerMultiple = GlobalSettings.boundLargerMultiple;
            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.Yes)
            {
                // To avoid confusion when the new bounds are created
                HideAllOutlines();
                diabolical.CreateStructureBounds(aForm.SmallerWidth, aForm.LargerMultiple);
            }
            PauseGameInput(false);
            UpdateMenuItemVisibility();
        }

        private void optimiseBoundsItem_Click(object sender, EventArgs e)
        {
            if (diabolical != null)
            {
                HideAllOutlines();
                diabolical.OptimiseModelBounds();
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Bounds ==
        //
        private void noBoundsItem_Click(object sender, EventArgs e)
        {
            HideAllOutlines();
        }

        public void HideAllOutlines()
        {
            ClearAllBoundTicks();
            noBoundsItem.Checked = true;
            diabolical.ClearOutlines();
        }

        private void allLargeBoundsItem_Click(object sender, EventArgs e)
        {
            ClearAllBoundTicks();
            allLargeBoundsItem.Checked = true;
            diabolical.ChangeLargerShowLarger(0);
        }

        private void allSmallBoundsItem_Click(object sender, EventArgs e)
        {
            ClearAllBoundTicks();
            allSmallBoundsItem.Checked = true;
            diabolical.ChangeSmallerShowSmaller(0);
        }

        private void smallBoundsInTheSelectedBoundItem_Click(object sender, EventArgs e)
        {
            ClearAllBoundTicks();
            smallBoundsInTheSelectedBoundItem.Checked = true;
            diabolical.ChangeSmallerInLargerShowInLarger(0);
        }

        private void ClearAllBoundTicks()
        {
            noBoundsItem.Checked = false;
            allLargeBoundsItem.Checked = false;
            allSmallBoundsItem.Checked = false;
            smallBoundsInTheSelectedBoundItem.Checked = false;
        }
        //
        //////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////
        // == File Utilities ==
        //
        /// <summary>
        /// Creates a relative path from one file
        /// or folder to another.
        /// http://weblogs.asp.net/pwelter34/archive/2006/02/08/create-a-relative-path-code-snippet.aspx
        /// </summary>
        /// <param name="fromDirectory">
        /// Contains the directory that defines the 
        /// start of the relative path.
        /// </param>
        /// <param name="toPath">
        /// Contains the path that defines the
        /// endpoint of the relative path.
        /// </param>
        /// <returns>
        /// The relative path from the start
        /// directory to the end path.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RelativePathTo(
            string fromDirectory, string toPath)
        {
            if (fromDirectory == null)
            {
                throw new ArgumentNullException("fromDirectory");
            }

            if (toPath == null)
            {
                throw new ArgumentNullException("toPath");
            }

            bool isRooted = Path.IsPathRooted(fromDirectory) && Path.IsPathRooted(toPath);

            if (isRooted)
            {
                bool isDifferentRoot = string.Compare(
                    Path.GetPathRoot(fromDirectory),
                    Path.GetPathRoot(toPath), true) != 0;

                if (isDifferentRoot)
                {
                    return toPath;
                }
            }

            StringCollection relativePath = new StringCollection();

            string[] fromDirectories = fromDirectory.Split(
                Path.DirectorySeparatorChar);

            string[] toDirectories = toPath.Split(
                Path.DirectorySeparatorChar);

            int length = Math.Min(
                fromDirectories.Length,
                toDirectories.Length);

            int lastCommonRoot = -1;

            // find common root
            for (int x = 0; x < length; x++)
            {
                if (string.Compare(fromDirectories[x],
                    toDirectories[x], true) != 0)
                {
                    break;
                }

                lastCommonRoot = x;
            }

            if (lastCommonRoot == -1)
            {
                return toPath;
            }

            // add relative folders in from path
            for (int x = lastCommonRoot + 1; x < fromDirectories.Length; x++)
            {
                if (fromDirectories[x].Length > 0)
                {
                    relativePath.Add("..");
                }
            }

            // add to folders to path
            for (int x = lastCommonRoot + 1; x < toDirectories.Length; x++)
            {
                relativePath.Add(toDirectories[x]);
            }

            // create relative path
            string[] relativeParts = new string[relativePath.Count];
            relativePath.CopyTo(relativeParts, 0);

            string newPath = string.Join(
                Path.DirectorySeparatorChar.ToString(),
                relativeParts);

            return newPath;
        }
        //
        //////////////////////////////////////////////////////////////////////
    
    }
}
