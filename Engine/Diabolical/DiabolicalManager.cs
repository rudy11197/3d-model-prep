#region File Description
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
// URL: http://www.MistyManor.co.uk
//-----------------------------------------------------------------------------
#endregion

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AssetData;

namespace Engine
{
    /// <summary>
    /// For editing the properties and bounds of models used in Diabolical:The Shooter
    /// </summary>
    class DiabolicalManager
    {
        MainForm form;
        Shapes debugShapes;
        string lastLoadedSettingsFile = "";
        string lastLoaded3DModelFile = "";

        DiabolicalModel modelAsset;


        public DiabolicalManager(MainForm parent, Shapes sharedShapes)
        {
            form = parent;
            debugShapes = sharedShapes;
            modelAsset = new DiabolicalModel(debugShapes);
        }

        //////////////////////////////////////////////////////////////////////
        // == Results and Properties ==
        //
        // For use when browsing for other related files
        public string LastLoaded3DModelFile
        {
            get { return lastLoaded3DModelFile; }
            set { lastLoaded3DModelFile = value; }
        }

        public Model Model
        {
            get
            {
                if (modelAsset != null)
                {
                    return modelAsset.model;
                }
                return null;
            }
            set
            {
                if (modelAsset != null)
                {
                    modelAsset.model = value;
                }
            }
        }

        // Which types we have save methods for
        public bool CanSave()
        {
            if (IsStructure)
            {
                return true;
            }
            return false;
        }

        // Which types we have property forms for
        public bool CanEdit()
        {
            if (IsStructure)
            {
                return true;
            }
            return false;
        }

        public bool IsStructure
        {
            get 
            {
                if (modelAsset != null &&
                    modelAsset.modelType == GlobalSettings.modelTypeStructure)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsCharacter
        {
            get
            {
                if (modelAsset != null &&
                    modelAsset.modelType == GlobalSettings.modelTypeCharacter)
                {
                    return true;
                }
                return false;
            }
        }

        // If the model has any bounds that can be viewed
        public bool HasStructureBounds()
        {
            if (IsStructure  &&
                (modelAsset.largerBounds.Count > 0  || modelAsset.smallerBounds.Count > 0))
            {
                return true;
            }
            return false;
        }

        public int LargeBoundCount
        {
            get
            {
                if (IsStructure)
                {
                    return modelAsset.largerBounds.Count;
                }
                return 0;
            }
        }

        public int SmallBoundCount
        {
            get
            {
                if (IsStructure)
                {
                    return modelAsset.smallerBounds.Count;
                }
                return 0;
            }
        }

        public bool HasCharacterBounds()
        {
            if (IsCharacter &&
                (modelAsset.standingSpheres.Count > 0 || 
                modelAsset.crouchedSpheres.Count > 0 ||
                modelAsset.attachedSpheres.Count > 0))
            {
                return true;
            }
            return false;
        }

        public string ModelType
        {
            get
            {
                if (modelAsset != null)
                {
                    return modelAsset.modelType;
                }
                return "";
            }
            set
            {
                if (modelAsset != null)
                {
                    modelAsset.modelType = value;
                }
            }
        }

        public string RelativeFileName
        {
            get { return modelAsset.modelFilename; }
        }

        public Vector3 ModelRotation
        {
            get { return modelAsset.rotation; }
            set { modelAsset.rotation = value; }
        }

        // Used becuase the model processors use strings
        public void SetModelRotation(string sX, string sY, string sZ)
        {
            float fX = ParseData.FloatFromString(sX);
            float fY = ParseData.FloatFromString(sY);
            float fZ = ParseData.FloatFromString(sZ);
            ModelRotation = new Vector3(fX, fY, fZ);
        }

        public string EffectType
        {
            get { return modelAsset.effectType; }
            set { modelAsset.effectType = value; }
        }

        public string DepthMapFileName
        {
            get { return modelAsset.depthMapFile; }
            set { modelAsset.depthMapFile = value; }
        }

        public string SpecularMapFileName
        {
            get { return modelAsset.specularMapFile; }
            set { modelAsset.specularMapFile = value; }
        }

        public float SpecularIntensity
        {
            get { return modelAsset.specularIntensity; }
            set { modelAsset.specularIntensity = value; }
        }

        public float SpecularPower
        {
            get { return modelAsset.specularPower; }
            set { modelAsset.specularPower = value; }
        }

        // Set when the optimise method has been run
        private bool haveOptimised = true;
        public bool HaveOptimised 
        {
            get { return haveOptimised; }
        }

        // Set when any change is made
        private bool haveChanged = false;
        public bool HaveChanged
        {
            get { return haveChanged; }
        }

        // Call this whenever anything is changed
        public void ChangedSomething()
        {
            haveChanged = true;
            haveOptimised = false;
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Show Bounding Shapes ==
        //
        public void ClearOutlines()
        {
            debugShapes.ClearStoredShapes();
        }

        public void OutlineLargerBounds()
        {
            if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineLargerBounds(lastLargerBound);
            }
        }

        public void OutlineSmallerBoundsInLarger()
        {
            if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineSmallerBoundsInLarger(lastLargerBound, lastSmallerBound);
            }
        }

        public void OutlineAllSmallerBounds()
        {
            if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineAllSmallerBounds(lastSmallerBound);
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Create and Edit Bounding Shapes ==
        //
        public void CreateStructureBounds(float smallerBoundWidth, float largerBoundMultiple)
        {
            if (modelAsset == null)
            {
                form.AddMessageLine("No model loaded!");
                return;
            }
            if (modelAsset.modelType != GlobalSettings.modelTypeStructure)
            {
                form.AddMessageLine("Structure bounds can only be created for model types of Structure!");
                return;
            }
            form.AddMessageLine("Calculating model bounds...");
            ChangedSomething();
            StructureBounds.CreateModelFittedBounds(modelAsset, smallerBoundWidth, largerBoundMultiple);
            form.AddMessageLine("== Finished ==");
        }

        private int lastLargerBound = -1;
        private int lastSmallerBound = -1;

        public int CurrentLargerBound
        {
            get { return lastLargerBound; }
            set
            {
                if (modelAsset != null && value >= 0 && value < modelAsset.LargerBounds.Count)
                {
                    lastLargerBound = value;
                }
            }
        }

        public int CurrentSmallerBound
        {
            get { return lastSmallerBound; }
            set
            {
                if (modelAsset != null && value >= 0 && value < modelAsset.SmallerBounds.Count)
                {
                    lastSmallerBound = value;
                }
            }
        }

        public int HighestLargerBound
        {
            get
            {
                if (modelAsset != null && modelAsset.LargerBounds.Count > 0)
                {
                    return modelAsset.LargerBounds.Count - 1;
                }
                return -1;
            }
        }

        public int HighestSmallerBound
        {
            get
            {
                if (modelAsset != null && modelAsset.SmallerBounds.Count > 0)
                {
                    return modelAsset.SmallerBounds.Count - 1;
                }
                return -1;
            }
        }

        private void ChangeLargeBound(int increment)
        {
            if (modelAsset.LargerBounds.Count < 1)
            {
                lastLargerBound = -1;
                return;
            }
            lastLargerBound += increment;
            if (lastLargerBound < 0)
            {
                lastLargerBound = modelAsset.LargerBounds.Count - 1;
            }
            else if (lastLargerBound >= modelAsset.LargerBounds.Count)
            {
                lastLargerBound = 0;
            }
        }

        private void ChangeSmallerBound(int increment)
        {
            if (modelAsset.SmallerBounds.Count < 1)
            {
                lastSmallerBound = -1;
                return;
            }
            lastSmallerBound += increment;
            if (lastSmallerBound < 0)
            {
                lastSmallerBound = modelAsset.SmallerBounds.Count - 1;
            }
            else if (lastSmallerBound >= modelAsset.SmallerBounds.Count)
            {
                lastSmallerBound = 0;
            }
        }

        private void ChangeSmallerInLarger(int increment)
        {
            if (modelAsset.SmallerBounds.Count < 1)
            {
                lastSmallerBound = -1;
                return;
            }
            if (modelAsset.LargerBounds.Count < 1)
            {
                lastLargerBound = -1;
                return;
            }
            if (lastLargerBound < 0)
            {
                ChangeLargeBound(1);
            }
            // This only works if the smaller bounds are in numeric order smallest to highest
            if (increment > 0)
            {
                // Going up
                for (int s = 0; s < modelAsset.LargerBounds[lastLargerBound].IDs.Count; s++)
                {
                    int smallerID = modelAsset.LargerBounds[lastLargerBound].IDs[s];
                    if (smallerID > lastSmallerBound)
                    {
                        lastSmallerBound = smallerID;
                        return;
                    }
                }
                lastSmallerBound = modelAsset.LargerBounds[lastLargerBound].IDs[0];
                return;
            }
            else
            {
                // Going down
                for (int s = modelAsset.LargerBounds[lastLargerBound].IDs.Count - 1; s >= 0; s--)
                {
                    int smallerID = modelAsset.LargerBounds[lastLargerBound].IDs[s];
                    if (smallerID < lastSmallerBound)
                    {
                        lastSmallerBound = smallerID;
                        return;
                    }
                }
                lastSmallerBound = modelAsset.LargerBounds[lastLargerBound].IDs[modelAsset.LargerBounds[lastLargerBound].IDs.Count - 1];
                return;
            }
        }

        public void ChangeLargerShowSmaller(int change)
        {
            ChangeLargeBound(change);
            OutlineSmallerBoundsInLarger();
        }

        public void ChangeLargerShowLarger(int change)
        {
            ChangeLargeBound(change);
            OutlineLargerBounds();
        }

        public void ChangeSmallerShowSmaller(int change)
        {
            ChangeSmallerBound(change);
            OutlineAllSmallerBounds();
        }

        public void ChangeSmallerInLargerShowInLarger(int change)
        {
            ChangeSmallerInLarger(change);
            OutlineSmallerBoundsInLarger();
        }

        public void DeleteSelectedSmallerBound()
        {
            if (modelAsset == null || lastSmallerBound < 0 ||
                modelAsset.LargerBounds.Count < 1 || modelAsset.SmallerBounds.Count < 1)
            {
                return;
            }
            DeleteSmallerBound(lastSmallerBound);
        }

        private void DeleteSmallerBound(int smallerID)
        {
            ChangedSomething();
            // Remove the smaller bound from all larger bounds
            for (int a = 0; a < modelAsset.LargerBounds.Count; a++)
            {
                // Work backwards because we might remove something as we go
                for (int b = modelAsset.LargerBounds[a].IDs.Count - 1; b >= 0; b--)
                {
                    if (smallerID == modelAsset.LargerBounds[a].IDs[b])
                    {
                        modelAsset.LargerBounds[a].IDs.RemoveAt(b);
                    }
                    else if (modelAsset.LargerBounds[a].IDs[b] > smallerID)
                    {
                        // Reduce the ID by one because we are about to remove one of the
                        // smaller bounds so the index will go down.
                        modelAsset.LargerBounds[a].IDs[b] =
                            modelAsset.LargerBounds[a].IDs[b] - 1;
                    }
                }
            }
            // Remove unused smaller bound now that all the indexes stored
            // in the larger bounds have been adjusted.
            modelAsset.SmallerBounds.RemoveAt(smallerID);
        }

        public void DeleteSelectedLargerBound()
        {
            if (modelAsset == null || lastLargerBound < 0 ||
                modelAsset.LargerBounds.Count < 1 || lastLargerBound >= modelAsset.LargerBounds.Count)
            {
                return;
            }
            ChangedSomething();
            modelAsset.LargerBounds.RemoveAt(lastLargerBound);
        }

        // Call this after the smaller bounds have been edited just before saving the model.
        // Optimisation Includes:
        // - Make sure the larger bounds fully contain all the smaller spheres
        //      Any smaller bound overlapping can cause undesirable bouncing collisions.
        // - Removes any empty larger bounds
        // - Remove any smaller bounds which are not included in any of the larger bounds
        public void OptimiseModelBounds()
        {
            if (modelAsset != null && modelAsset.LargerBounds.Count > 0 && modelAsset.SmallerBounds.Count > 0)
            {
                form.AddMessageLine("Optimising bounds...");
                form.HideAllOutlines();
                StructureBounds.OptimiseModelBounds(modelAsset);
                RemoveOrphanedBounds();
                // Set haveOptimised to true after everything because optimisation 
                // resets this during the processes.
                haveOptimised = true;
                form.AddMessageLine("== Finished ==");
            }
        }

        // Delete any smaller bounds that are not included in a larger bound
        private void RemoveOrphanedBounds()
        {
            // Must be in reverse because bounds might be removed
            for (int s = modelAsset.SmallerBounds.Count - 1; s >= 0; s--)
            {
                if (!IsInAnyLarger(s))
                {
                    DeleteSmallerBound(s);
                }
            }
        }

        private bool IsInAnyLarger(int smallerID)
        {
            for (int i = 0; i < modelAsset.LargerBounds.Count; i++)
            {
                for (int s = 0; s < modelAsset.LargerBounds[i].IDs.Count; s++)
                {
                    if (modelAsset.LargerBounds[i].IDs[s] == smallerID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Load and Save ==
        //
        private bool ChangesAreYouSure()
        {
            if (haveChanged)
            {
                if (MessageBox.Show("Are you sure you want to continue without saving changes?", "Unsaved Changes!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public void LoadDialogue()
        {
            if (!ChangesAreYouSure())
            {
                return;
            }
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = form.DefaultFileFolder;
            fileDialog.Title = "Load Diabolical Model Settings";
            fileDialog.Filter = "Model Settings (*.model)|*.model|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                form.ClearMessages();
                LoadModelSettingsFile(fileDialog.FileName);
            }
            form.AddMessageLine("== Finished ==");
        }

        private void OptimiseAreYouSure()
        {
            if (haveOptimised)
            {
                // If we have already optimised save time and skip it
                return;
            }
            if (MessageBox.Show(
                "Any changes to the bounds of the structure must be checked\n" +
                "and optimised where necessary to avoid unwanted behaviour\n" + 
                "during normal game play.\n" + 
                "Do you want to run the optimisation process now?", "Changes Need To Be Optimised!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                OptimiseModelBounds();
            }
        }

        public void SaveDialogue()
        {
            OptimiseAreYouSure();
            // Path to default location
            string pathToSaveFolder = form.DefaultFileFolder;
            string fileName = GlobalSettings.settingsFileExcludingExtension + GlobalSettings.settingsFileExtension;
            // If we have loaded a file use that for the path and the name
            if (lastLoadedSettingsFile != "")
            {
                fileName = Path.GetFileName(lastLoadedSettingsFile);
                pathToSaveFolder = Path.GetDirectoryName(lastLoadedSettingsFile);
            }
            else if (lastLoaded3DModelFile != "")
            {
                fileName = Path.GetFileNameWithoutExtension(lastLoaded3DModelFile) + GlobalSettings.settingsFileExtension;
                pathToSaveFolder = Path.GetDirectoryName(lastLoaded3DModelFile);
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = pathToSaveFolder;
            fileDialog.Title = "Save Diabolical Model Settings";
            fileDialog.FileName = fileName;
            fileDialog.Filter = "Model Settings (*.model)|*.model|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                CalculateRelativePaths(fileDialog.FileName);
                if (AcceptInvalidPath(modelAsset.modelFilename))
                {
                    SaveModelSettingsFile(fileDialog.FileName);
                }
            }
            form.AddMessageLine("== Finished ==");
        }

        private void CalculateRelativePaths(string from)
        {
            if (string.IsNullOrEmpty(lastLoaded3DModelFile))
            {
                // This will leave the model filename unchanged
                form.AddMessageLine("The model settings file was saved without a valid model having been loaded!");
                return;
            }
            string fromFolder = Path.GetDirectoryName(from);
            modelAsset.modelFilename = MainForm.RelativePathTo(fromFolder, lastLoaded3DModelFile);
        }

        private bool AcceptInvalidPath(string relativePath)
        {
            bool result = true;
            if (relativePath.Length < 2)
            {
                if (MessageBox.Show("The 3D model file name is too short!\nThe model is unlikely to load from the settings file!\nDo you want to save anyway?",
                    "Invalid 3D Filename", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    result = false;
                }
            }
            else if (relativePath.Substring(0, 2) == ".." || Path.IsPathRooted(relativePath))
            {
                if (MessageBox.Show("The 3D model file is not in a suitable folder!\nThe 3D model should be in the same folder or a sub folder of where the settings file is saved.\nDo you want to save anyway?",
                    "Invalid 3D File Location", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    result = false;
                }
            }
            return result;
        }

        private void SaveModelSettingsFile(string fileName)
        {
            switch (modelAsset.modelType)
            {
                case GlobalSettings.modelTypeStructure:
                    form.SaveTextFile(fileName, GetStructureSaveData());
                    break;
                default:
                    form.AddMessageLine("The " + modelAsset.modelType + " model type is not yet supported!");
                    break;
            }
        }

        // Save file format (.model)
        private List<string> GetStructureSaveData()
        {
            List<string> data = new List<string>();
            // == Model data
            // The type and name
            data.Add(GlobalSettings.modelTypeStructure);
            // == Filename and effect parameters on one line
            string effect = ParseData.StandardiseFolderCharacters(modelAsset.modelFilename);
            if (!string.IsNullOrEmpty(modelAsset.effectType))
            {
                effect += ParseData.div + modelAsset.effectType;
                effect += ParseData.div + ParseData.FloatToString(modelAsset.specularIntensity);
                effect += ParseData.div + ParseData.FloatToString(modelAsset.specularPower);
                if (!string.IsNullOrEmpty(modelAsset.depthMapFile))
                {
                    effect += ParseData.div + modelAsset.depthMapFile;
                    if (!string.IsNullOrEmpty(modelAsset.specularMapFile))
                    {
                        effect += ParseData.div + modelAsset.specularMapFile;
                    }
                }
            }
            data.Add(effect);
            // == Parameters
            string parameters = ParseData.FloatToString(modelAsset.rotation.X) +
                ParseData.div + ParseData.FloatToString(modelAsset.rotation.Y) +
                ParseData.div + ParseData.FloatToString(modelAsset.rotation.Z);
            data.Add(parameters);
            // == Options
            // Bounds
            foreach (StructureSphere ssBound in modelAsset.largerBounds)
            {
                string output = String.Format("{0}{1}{2}{1}{3}",
                    GlobalSettings.typeLargerBounds,
                    ParseData.div,
                    ParseData.VectorToString(ssBound.CentreInObjectSpace),
                    ParseData.FloatToString(ssBound.Sphere.Radius));
                if (ssBound.IDs.Count > 0)
                {
                    output += ParseData.div + ParseData.IntListToString(ssBound.IDs);
                }
                data.Add(output);
            }
            foreach (StructureSphere ssBound in modelAsset.smallerBounds)
            {
                string output = String.Format("{0}{1}{2}{1}{3}",
                    GlobalSettings.typeSmallerBounds,
                    ParseData.div,
                    ParseData.VectorToString(ssBound.CentreInObjectSpace),
                    ParseData.FloatToString(ssBound.Sphere.Radius));
                if (ssBound.IDs.Count > 0)
                {
                    output += ParseData.div + ParseData.IntListToString(ssBound.IDs);
                }
                data.Add(output);
            }
            return data;
        }

        private void LoadModelSettingsFile(string fileName)
        {
            string[] result = new string[0];

            if (File.Exists(fileName))
            {
                lastLoadedSettingsFile = fileName;
                result = File.ReadAllLines(fileName);
            }
            else
            {
                form.AddMessageLine("File not found: " + fileName);
                return;
            }

            if (result == null || result.Length < 1)
            {
                form.AddMessageLine("Empty file: " + fileName);
                return;
            }

            ProcessData(result, fileName);
        }

        private void ProcessData(string[] source, string fileName)
        {
            DiabolicalSourceData input = new DiabolicalSourceData(fileName, source);

            string directory = Path.GetDirectoryName(input.Identity);
            // == The model
            string filepath = Path.Combine(directory, input.ModelFilename);
            lastLoaded3DModelFile = filepath;

            if (input.ModelType == GlobalSettings.modelTypeCharacter)
            {
                form.LoadModel(true, filepath, input.RotateX, input.RotateY, input.RotateZ);
            }
            else
            {
                form.LoadModel(false, filepath, input.RotateX, input.RotateY, input.RotateZ);
            }

            // Create the class
            modelAsset = new DiabolicalModel(debugShapes);
            modelAsset.BuildModelAsset(
                input.ModelType,
                ParseData.StandardiseFolderCharacters(input.ModelFilename),
                input.EffectType,
                input.SpecularIntensity,
                input.SpecularPower,
                input.DepthMapFilename,
                input.SpecularMapFilename,
                form.CurrentModel,
                CalculateBoundsFromModel(form.CurrentModel),
                input.RotateX,
                input.RotateY,
                input.RotateZ,
                input.Options);

            // Change which menu items are enabled based on the loaded model type
            form.UpdateMenuItemVisibility();
        }

        // Calculate the overall bounding sphere
        public BoundingSphere CalculateBoundsFromModel(Model modelThis)
        {
            BoundingSphere oversizeBounds = new BoundingSphere();
            foreach (ModelMesh mesh in modelThis.Meshes)
            {
                oversizeBounds = BoundingSphere.CreateMerged(oversizeBounds, mesh.BoundingSphere);
            }
            return oversizeBounds;
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Property Forms ==
        //
        public void DisplayPropertyForms()
        {
            switch (ModelType)
            {
                case GlobalSettings.modelTypeStructure:
                    DisplayStructureForm();
                    break;
            }
        }

        private void DisplayStructureForm()
        {
            ModelStructureForm aForm = new ModelStructureForm();

            aForm.ModelFullPath = LastLoaded3DModelFile;
            aForm.ModelRelativePath = RelativeFileName;
            aForm.ModelRotation = ModelRotation;
            aForm.EffectType = EffectType;
            aForm.DepthMapFileName = DepthMapFileName;
            aForm.SpecularMapFileName = SpecularMapFileName;
            aForm.SpecularIntensity = SpecularIntensity;
            aForm.SpecularPower = SpecularPower;
            aForm.LargeBoundCount = LargeBoundCount;
            aForm.SmallBoundCount = SmallBoundCount;

            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.OK || diagResult == DialogResult.Yes)
            {
                // Results
                ChangedSomething();
                ModelRotation = aForm.ModelRotation;
                EffectType = aForm.EffectType;
                DepthMapFileName = aForm.DepthMapFileName;
                SpecularMapFileName = aForm.SpecularMapFileName;
                SpecularIntensity = aForm.SpecularIntensity;
                SpecularPower = aForm.SpecularPower;
            }
            if (diagResult == DialogResult.Yes && !string.IsNullOrEmpty(lastLoaded3DModelFile))
            {
                // Reload the model
                form.LoadModel(false, lastLoaded3DModelFile, ModelRotation.X, ModelRotation.Y, ModelRotation.Z);
            }
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
