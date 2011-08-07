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
    public class DiabolicalManager
    {
        private MainForm form;
        private Shapes debugShapes;
        private string lastLoadedSettingsFile = "";
        private string lastLoaded3DModelFile = "";

        private DiabolicalModel modelAsset;


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
                    return modelAsset.Replica;
                }
                return null;
            }
            set
            {
                if (modelAsset != null)
                {
                    modelAsset.Replica = value;
                }
            }
        }

        // Which types we have save methods for
        public bool CanSave()
        {
            if (IsStructure || IsCharacter || IsWeapon)
            {
                return true;
            }
            return false;
        }

        // Which types we have property forms for
        public bool CanEdit()
        {
            if (IsStructure || IsCharacter || IsWeapon)
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
                    modelAsset.ModelType == GlobalSettings.modelTypeStructure)
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
                    modelAsset.ModelType == GlobalSettings.modelTypeCharacter)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsWeapon
        {
            get
            {
                if (modelAsset != null &&
                    (modelAsset.ModelType == GlobalSettings.modelTypeEquipLight ||
                    modelAsset.ModelType == GlobalSettings.modelTypeEquipSupport ||
                    modelAsset.ModelType == GlobalSettings.modelTypeEquipSmallArms))
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
            if (IsCharacter && modelAsset.AttachedBounds.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<AttachedSphere> AttachedBounds
        {
            get { return modelAsset.AttachedBounds; }
            set { modelAsset.AttachedBounds = value; }
        }

        public float CylinderRadius
        {
            get { return modelAsset.CylinderRadius; }
            set { modelAsset.CylinderRadius = value; }
        }

        public float HeightStanding
        {
            get { return modelAsset.HeightStanding; }
            set { modelAsset.HeightStanding = value; }
        }

        public float HeightCrouched
        {
            get { return modelAsset.HeightCrouched; }
            set { modelAsset.HeightCrouched = value; }
        }

        public float Mass
        {
            get { return modelAsset.Mass; }
            set { modelAsset.Mass = value; }
        }

        public float BotDegreesStand
        {
            get { return modelAsset.BotDegreesStand; }
            set { modelAsset.BotDegreesStand = value; }
        }

        public float BotDegreesWalk
        {
            get { return modelAsset.BotDegreesWalk; }
            set { modelAsset.BotDegreesWalk = value; }
        }

        public float BotDegreesRun
        {
            get { return modelAsset.BotDegreesRun; }
            set { modelAsset.BotDegreesRun = value; }
        }

        public float BotDegreesCrouch
        {
            get { return modelAsset.BotDegreesCrouch; }
            set { modelAsset.BotDegreesCrouch = value; }
        }

        public float BotDegreesShuffle
        {
            get { return modelAsset.BotDegreesShuffle; }
            set { modelAsset.BotDegreesShuffle = value; }
        }

        public float CameraDegreesStand
        {
            get { return modelAsset.CameraDegreesStand; }
            set { modelAsset.CameraDegreesStand = value; }
        }

        public float CameraDegreesWalk
        {
            get { return modelAsset.CameraDegreesWalk; }
            set { modelAsset.CameraDegreesWalk = value; }
        }

        public float CameraDegreesRun
        {
            get { return modelAsset.CameraDegreesRun; }
            set { modelAsset.CameraDegreesRun = value; }
        }

        public float CameraDegreesCrouch
        {
            get { return modelAsset.CameraDegreesCrouch; }
            set { modelAsset.CameraDegreesCrouch = value; }
        }

        public float CameraDegreesShuffle
        {
            get { return modelAsset.CameraDegreesShuffle; }
            set { modelAsset.CameraDegreesShuffle = value; }
        }


        /// <summary>
        /// Call this after any changes to update the model view
        /// </summary>
        public void UpdateModelChanges()
        {
            if (form != null)
            {
                form.UpdateModelChanges();
            }
        }

        /// <summary>
        /// Changing the model type also resets the effect type back to the typical 
        /// for that model type.
        /// </summary>
        public string ModelType
        {
            get
            {
                if (modelAsset != null)
                {
                    return modelAsset.ModelType;
                }
                return "";
            }
            set
            {
                if (modelAsset != null)
                {
                    modelAsset.ModelType = value;
                    SetEffectToDefaultForType();
                }
            }
        }

        public string RelativeFileName
        {
            get { return modelAsset.ModelFilename; }
        }

        public Vector3 ModelRotation
        {
            get { return modelAsset.Rotation; }
            set { modelAsset.Rotation = value; }
        }

        /// <summary>
        /// In most cases the effect type should match the model type but it can differ
        /// if the effect type is set after the model type.
        /// </summary>
        public string EffectType
        {
            get { return modelAsset.EffectType; }
            set { modelAsset.EffectType = value; }
        }

        // Set when the optimise method has been run
        private bool haveOptimised = true;
        public bool HaveOptimised 
        {
            get { return haveOptimised; }
        }

        public bool HasBoundsToOptimise
        {
            get { return IsStructure; }
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

        // Model Material Colours
        public float SpecularPower
        {
            get { return modelAsset.SpecularPower; }
            set { modelAsset.SpecularPower = value; }
        }

        public Vector3 SpecularColour
        {
            get { return modelAsset.SpecularColour; }
            set { modelAsset.SpecularColour = value; }
        }

        public Vector3 DiffuseColour
        {
            get { return modelAsset.DiffuseColour; }
            set { modelAsset.DiffuseColour = value; }
        }

        public Vector3 EmissiveColour
        {
            get { return modelAsset.EmissiveColour; }
            set { modelAsset.EmissiveColour = value; }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Validate ==
        //
        private void SetEffectToDefaultForType()
        {
            switch (ModelType)
            {
                case GlobalSettings.modelTypeCharacter:
                    EffectType = GlobalSettings.effectTypeAnimated;
                    break;
                default:
                    EffectType = GlobalSettings.effectTypeRigid;
                    break;
            }
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
            if (modelAsset != null && modelAsset.ModelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineLargerBounds(lastLargerBound);
            }
        }

        public void OutlineSmallerBoundsInLarger()
        {
            if (modelAsset != null && modelAsset.ModelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineSmallerBoundsInLarger(lastLargerBound, lastSmallerBound);
            }
        }

        public void OutlineAllSmallerBounds()
        {
            if (modelAsset != null && modelAsset.ModelType == GlobalSettings.modelTypeStructure)
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
            if (modelAsset.ModelType != GlobalSettings.modelTypeStructure)
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

        public void SetSelectedBound(int boundIndex)
        {
            if (form != null)
            {
                form.SetSelectedBound(boundIndex);
            }
        }

        public int GetSelectedBound()
        {
            if (form != null)
            {
                return form.GetCurrentSelectedBound();
            }
            return -1;
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

        private void OptimiseAreYouSure()
        {
            if (haveOptimised || !HasBoundsToOptimise)
            {
                // If we have already optimised or don't need to then save time and skip it
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

        // ------------------------------------------------------------------
        // - Save

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
                if (AcceptInvalidPath(modelAsset.ModelFilename))
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
            modelAsset.ModelFilename = MainForm.RelativePathTo(fromFolder, lastLoaded3DModelFile);
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

        // Save file format (.model)
        private void SaveModelSettingsFile(string fileName)
        {
            switch (modelAsset.ModelType)
            {
                case GlobalSettings.modelTypeStructure:
                    form.SaveTextFile(fileName, GetStructureSaveData());
                    haveChanged = false;
                    break;
                case GlobalSettings.modelTypeGearHead:
                    form.SaveTextFile(fileName, GetHeadGearSaveData());
                    haveChanged = false;
                    break;
                case GlobalSettings.modelTypeEquipLight:
                    form.SaveTextFile(fileName, GetWeaponSaveData());
                    haveChanged = false;
                    break;
                case GlobalSettings.modelTypeEquipSmallArms:
                    form.SaveTextFile(fileName, GetWeaponSaveData());
                    haveChanged = false;
                    break;
                case GlobalSettings.modelTypeEquipSupport:
                    form.SaveTextFile(fileName, GetWeaponSaveData());
                    haveChanged = false;
                    break;
                case GlobalSettings.modelTypeCharacter:
                    form.SaveTextFile(fileName, GetCharacterSaveData());
                    haveChanged = false;
                    break;
                default:
                    form.AddMessageLine("The " + modelAsset.ModelType + " model type is not yet supported!");
                    break;
            }
        }

        private List<string> GetCommonSaveData()
        {
            List<string> data = new List<string>();
            // == Common parameters
            string output = "";
            // - File format version
            data.Add(GlobalSettings.modelSaveFormatType);
            // - Effect Type
            data.Add(modelAsset.EffectType);
            // - Model type
            data.Add(modelAsset.ModelType);
            // - Filename including relative path (.X or .FBX)
            // The model pipeline does not load textures correctly if the path uses the standard character
            data.Add(ParseData.UseAlternateFolderCharacters(modelAsset.ModelFilename));
            // - Rotation
            output = ParseData.FloatToString(modelAsset.Rotation.X) +
                ParseData.div + ParseData.FloatToString(modelAsset.Rotation.Y) +
                ParseData.div + ParseData.FloatToString(modelAsset.Rotation.Z);
            data.Add(output);
            // == Common options
            // - Material colours
            output = GlobalSettings.typeColour +
                ParseData.div + ParseData.FloatToString(modelAsset.SpecularPower) +
                ParseData.div + ParseData.ColorToString(modelAsset.SpecularColour) +
                ParseData.div + ParseData.FloatToString(modelAsset.MaterialAlpha) +
                ParseData.div + ParseData.ColorToString(modelAsset.DiffuseColour) +
                ParseData.div + ParseData.ColorToString(modelAsset.EmissiveColour);
            data.Add(output);

            return data;
        }

        private List<string> GetStructureSaveData()
        {
            List<string> data = new List<string>();
            // == Common parameters
            data.AddRange(GetCommonSaveData());
            // == Type specific options
            string output = "";
            // - Larger bounds
            foreach (StructureSphere ssBound in modelAsset.largerBounds)
            {
                output = GlobalSettings.typeLargerBounds + 
                    ParseData.div + ParseData.VectorToString(ssBound.CentreInObjectSpace) +
                    ParseData.div + ParseData.FloatToString(ssBound.Sphere.Radius);
                if (ssBound.IDs.Count > 0)
                {
                    output += ParseData.div + ParseData.IntListToString(ssBound.IDs);
                }
                data.Add(output);
            }
            // - Smaller bounds
            foreach (StructureSphere ssBound in modelAsset.smallerBounds)
            {
                output = GlobalSettings.typeSmallerBounds + 
                    ParseData.div + ParseData.VectorToString(ssBound.CentreInObjectSpace) +
                    ParseData.div + ParseData.FloatToString(ssBound.Sphere.Radius);
                if (ssBound.IDs.Count > 0)
                {
                    output += ParseData.div + ParseData.IntListToString(ssBound.IDs);
                }
                data.Add(output);
            }
            return data;
        }

        private List<string> GetHeadGearSaveData()
        {
            List<string> data = new List<string>();
            // == Common parameters
            data.AddRange(GetCommonSaveData());
            // == Type specific options
            string output = "";
            // - Bone offsets
            output = GlobalSettings.typeHeadOffset +
                ParseData.div + ParseData.VectorToString(modelAsset.BoneAlignment.Translation);
            data.Add(output);

            return data;
        }

        private List<string> GetWeaponSaveData()
        {
            List<string> data = new List<string>();
            // == Common parameters
            data.AddRange(GetCommonSaveData());
            // == Type specific options
            string output = "";
            // - Manufacturer
            output = GlobalSettings.typeManufacturer +
                ParseData.div + ParseData.IntToString(modelAsset.Manufacturer);
            data.Add(output);
            // - Aim adjustment
            // This version saves the matrix instead of individual values
            output = GlobalSettings.typeAimAdjustment +
                ParseData.div + ParseData.MatrixToString(modelAsset.BoneAlignment);
            data.Add(output);
            // - Muzzle position relative to the start of the aim bone
            output = GlobalSettings.typeWeaponMuzzle +
                ParseData.div + ParseData.VectorToString(modelAsset.MuzzleOffset);
            data.Add(output);
            // Half the width so the weapon can be positioned lying on the ground
            output = GlobalSettings.typeWeaponHalfWidth +
                ParseData.div + ParseData.FloatToString(modelAsset.HalfWidth);
            data.Add(output);
            // Ammo
            output = GlobalSettings.typeWeaponAmmo +
                ParseData.div + modelAsset.AmmoType +
                ParseData.div + ParseData.IntToString(modelAsset.AmmoClipCapacity) +
                ParseData.div + ParseData.IntToString(modelAsset.AmmoMaxCarried) +
                ParseData.div + ParseData.BoolToShortString(modelAsset.IsAutoFire) +
                ParseData.div + ParseData.FloatToString(modelAsset.AmmoRateOfFire) +
                ParseData.div + ParseData.FloatToString(modelAsset.AmmoSecondsToReload) +
                ParseData.div + modelAsset.FxReload +
                ParseData.div + modelAsset.FxEmpty;
            data.Add(output);
            // - Ranges, optimum and farthest for use by the AI
            output = GlobalSettings.typeWeaponRanges +
                ParseData.div + ParseData.FloatToString(modelAsset.OptimumClosest) +
                ParseData.div + ParseData.FloatToString(modelAsset.OptimumFarthest);
            data.Add(output);
            // - Recoil amount
            output = GlobalSettings.typeWeaponRecoil +
                ParseData.div + ParseData.FloatToString(modelAsset.RecoilDegrees);
            data.Add(output);
            // - Zoom options
            output = GlobalSettings.typeWeaponZoom;
            for (int i = 0; i < modelAsset.ZoomMultipliers.Count; i++)
            {
                output += ParseData.div + ParseData.FloatToString(modelAsset.ZoomMultipliers[i]);
            }
            data.Add(output);
            // - Croasshair types
            output = GlobalSettings.typeWeaponSights;
            for (int i = 0; i < modelAsset.CrossHairs.Count; i++)
            {
                output += ParseData.div + ParseData.FloatToString(modelAsset.CrossHairs[i]);
            }
            data.Add(output);

            return data;
        }

        private List<string> GetCharacterSaveData()
        {
            List<string> data = new List<string>();
            // == Common parameters
            data.AddRange(GetCommonSaveData());
            // == Type specific options
            string output = "";
            // - Rig type
            output = GlobalSettings.typeRig +
                ParseData.div + modelAsset.RigTypeName;
            data.Add(output);
            // - Body sizes
            output = GlobalSettings.typeBodySizes + 
                ParseData.div + modelAsset.Mass +
                ParseData.div + modelAsset.HeightStanding +
                ParseData.div + modelAsset.HeightCrouched +
                ParseData.div + modelAsset.CylinderRadius;
            data.Add(output);
            // - Attach equipment positions
            for (int a = 0; a < modelAsset.AttachEquip.Count; a++)
            {
                output = GlobalSettings.typeAttachEquipment +
                    ParseData.div + modelAsset.GetBoneName(modelAsset.AttachEquip[a].idBone) +
                    ParseData.div + ParseData.MatrixToString(modelAsset.AttachEquip[a].mtxTransform);
                data.Add(output);
            }
            // - Attach adornments
            for (int b = 0; b < modelAsset.AttachAdorn.Count; b++)
            {
                output = GlobalSettings.typeAttachAdornment +
                    ParseData.div + modelAsset.GetBoneName(modelAsset.AttachAdorn[b].idBone) +
                    ParseData.div + ParseData.MatrixToString(modelAsset.AttachAdorn[b].mtxTransform);
                data.Add(output);
            }
            // - Weapon Hold
            output = GlobalSettings.typeWeaponHoldBone +
                ParseData.div + modelAsset.GetBoneName(modelAsset.AttachHold.idBone) +
                ParseData.div + ParseData.MatrixToString(modelAsset.AttachHold.mtxTransform);
            data.Add(output);
            // - Animation Angle Adjustments
            output = GlobalSettings.typeBotAnimationAngles +
                ParseData.div + ParseData.FloatToString(modelAsset.BotDegreesStand) +
                ParseData.div + ParseData.FloatToString(modelAsset.BotDegreesWalk) +
                ParseData.div + ParseData.FloatToString(modelAsset.BotDegreesRun) +
                ParseData.div + ParseData.FloatToString(modelAsset.BotDegreesCrouch) +
                ParseData.div + ParseData.FloatToString(modelAsset.BotDegreesShuffle);
            data.Add(output);
            output = GlobalSettings.typeCameraAnimationAngles +
                ParseData.div + ParseData.FloatToString(modelAsset.CameraDegreesStand) +
                ParseData.div + ParseData.FloatToString(modelAsset.CameraDegreesWalk) +
                ParseData.div + ParseData.FloatToString(modelAsset.CameraDegreesRun) +
                ParseData.div + ParseData.FloatToString(modelAsset.CameraDegreesCrouch) +
                ParseData.div + ParseData.FloatToString(modelAsset.CameraDegreesShuffle);
            data.Add(output);
            // - Smaller bone attached spheres
            // Bone name, radius and offset
            for (int d = 0; d < modelAsset.AttachedBounds.Count; d++)
            {
                output = GlobalSettings.typeAttachedSpheres +
                    ParseData.div + modelAsset.GetBoneName(modelAsset.AttachedBounds[d].BoneIndex) + 
                    ParseData.div + ParseData.FloatToString(modelAsset.AttachedBounds[d].Sphere.Radius) +
                    ParseData.div + ParseData.VectorToString(modelAsset.AttachedBounds[d].Offset);
                data.Add(output);
            }

            return data;
        }

        // ------------------------------------------------------------------
        // - Load

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
            SetColourValuesFromModel();
            if (IsWeapon)
            {
                // Weapons are drawn with the trigger at the origin so are half in the floor
                form.ShowFloor(false);
            }
        }

        // Call after the model has loaded to make sure everyting is working to the same values
        private void SetColourValuesFromModel()
        {
            SpecularPower = modelAsset.SpecularPower;
            SpecularColour = modelAsset.SpecularColour;
            DiffuseColour = modelAsset.DiffuseColour;
            EmissiveColour = modelAsset.EmissiveColour;
            form.SetMaterialColours(SpecularPower, SpecularColour, DiffuseColour, EmissiveColour);
        }

        private void ProcessData(string[] source, string fileName)
        {
            DiabolicalSourceData input = new DiabolicalSourceData(fileName, source);

            string directory = Path.GetDirectoryName(input.Identity);
            // == The model
            string filepath = Path.Combine(directory, input.ModelFilename);
            lastLoaded3DModelFile = filepath;

            if (input.EffectType == GlobalSettings.effectTypeAnimated)
            {
                form.LoadModel(true, filepath, input.RotateX, input.RotateY, input.RotateZ);
            }
            else
            {
                form.LoadModel(false, filepath, input.RotateX, input.RotateY, input.RotateZ);
            }

            if (form.CurrentModel != null)
            {
                // Create the class
                modelAsset = new DiabolicalModel(debugShapes);
                modelAsset.BuildModelAsset(
                    input.ModelType,
                    ParseData.StandardiseFolderCharacters(input.ModelFilename),
                    input.EffectType,
                    form.CurrentModel,
                    CalculateBoundsFromModel(form.CurrentModel),
                    input.RotateX,
                    input.RotateY,
                    input.RotateZ,
                    input.Options);
            }
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
        public void DisplayCommonPropertyForms()
        {
            DisplayCommonForm();
        }

        public void DisplayTypePropertyForms()
        {
            switch (ModelType)
            {
                case GlobalSettings.modelTypeStructure:
                    DisplayStructureForm();
                    break;
                case GlobalSettings.modelTypeCharacter:
                    DisplayCharacterForm();
                    break;
            }
        }

        private void DisplayCommonForm()
        {
            ModelCommonForm aForm = new ModelCommonForm();

            aForm.ModelFullPath = LastLoaded3DModelFile;
            aForm.ModelRelativePath = RelativeFileName;
            aForm.ModelRotation = ModelRotation;
            aForm.EffectType = EffectType;
            aForm.SpecularPower = SpecularPower;
            aForm.SpecularColour = SpecularColour;
            aForm.DiffuseColour = DiffuseColour;
            aForm.EmissiveColour = EmissiveColour;


            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.OK || diagResult == DialogResult.Yes)
            {
                // Results
                ChangedSomething();
                ModelRotation = aForm.ModelRotation;
                form.SetRotation(ModelRotation);
                EffectType = aForm.EffectType;
                SpecularPower = aForm.SpecularPower;
                SpecularColour = aForm.SpecularColour;
                DiffuseColour = aForm.DiffuseColour;
                EmissiveColour = aForm.EmissiveColour;
                form.SetMaterialColours(SpecularPower, SpecularColour, DiffuseColour, EmissiveColour);
            }
            if (diagResult == DialogResult.Yes && !string.IsNullOrEmpty(lastLoaded3DModelFile))
            {
                // Reload the model
                form.LoadModel(false, lastLoaded3DModelFile, ModelRotation.X, ModelRotation.Y, ModelRotation.Z);
            }
        }

        private void DisplayStructureForm()
        {
            ModelStructureForm aForm = new ModelStructureForm();

            aForm.LargeBoundCount = LargeBoundCount;
            aForm.SmallBoundCount = SmallBoundCount;

            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.OK || diagResult == DialogResult.Yes)
            {
                // Results
                //ChangedSomething();
            }
            if (diagResult == DialogResult.Yes && !string.IsNullOrEmpty(lastLoaded3DModelFile))
            {
                // Reload the model
                form.LoadModel(false, lastLoaded3DModelFile, ModelRotation.X, ModelRotation.Y, ModelRotation.Z);
            }
        }

        public void DisplayAttachedBoundsForm()
        {
            if (modelAsset.ModelType != GlobalSettings.modelTypeCharacter)
            {
                return;
            }

            AttachedBoundsForm aForm = new AttachedBoundsForm();

            aForm.DiabolicalForm = this;
            aForm.BoneMap = form.GetBoneMap();
            aForm.AttachedBounds = AttachedBounds;

            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.Cancel)
            {
                // Reset Results
                AttachedBounds = aForm.PreviousBounds;
                form.UpdateModelChanges();
            }
            
        }

        /// <summary>
        /// turnSpeed range typically -1.0 to +1.0
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="turnSpeed"></param>
        public void SetOrbit(bool enable, float turnSpeed, bool centreAttached)
        {
            if (form != null)
            {
                form.Orbit(enable, turnSpeed, centreAttached);
            }
        }

        private void DisplayCharacterForm()
        {
            ModelCharacterForm aForm = new ModelCharacterForm();

            aForm.CylinderRadius = CylinderRadius;
            aForm.HeightStanding = HeightStanding;
            aForm.HeightCrouched = HeightCrouched;
            aForm.Mass = Mass;
            aForm.BotAngleStand = BotDegreesStand;
            aForm.BotAngleWalk = BotDegreesWalk;
            aForm.BotAngleRun = BotDegreesRun;
            aForm.BotAngleCrouch = BotDegreesCrouch;
            aForm.BotAngleShuffle = BotDegreesShuffle;
            aForm.CameraAngleStand = CameraDegreesStand;
            aForm.CameraAngleWalk = CameraDegreesWalk;
            aForm.CameraAngleRun = CameraDegreesRun;
            aForm.CameraAngleCrouch = CameraDegreesCrouch;
            aForm.CameraAngleShuffle = CameraDegreesShuffle;

            DialogResult diagResult = aForm.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                // Results
                CylinderRadius = aForm.CylinderRadius;
                HeightStanding = aForm.HeightStanding;
                HeightCrouched = aForm.HeightCrouched;
                Mass = aForm.Mass;
                BotDegreesStand = aForm.BotAngleStand;
                BotDegreesWalk = aForm.BotAngleWalk;
                BotDegreesRun = aForm.BotAngleRun;
                BotDegreesCrouch = aForm.BotAngleCrouch;
                BotDegreesShuffle = aForm.BotAngleShuffle;
                CameraDegreesStand = aForm.CameraAngleStand;
                CameraDegreesWalk = aForm.CameraAngleWalk;
                CameraDegreesRun = aForm.CameraAngleRun;
                CameraDegreesCrouch = aForm.CameraAngleCrouch;
                CameraDegreesShuffle = aForm.CameraAngleShuffle;
                UpdateModelChanges();
            }
        }


        //
        //////////////////////////////////////////////////////////////////////
    }
}
