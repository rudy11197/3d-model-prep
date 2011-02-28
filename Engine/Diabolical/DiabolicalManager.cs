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
        string lastLoadedPropertiesFile = "";
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

        // Which types we have save methods for
        public bool CanSave()
        {
            if (modelAsset != null &&
                modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                return true;
            }
            return false;
        }

        // Which types we have property forms for
        public bool CanEdit()
        {
            if (modelAsset != null &&
                modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                return true;
            }
            return false;
        }

        // If the model has any bounds that can be viewed
        public bool HasStructureBounds()
        {
            if (modelAsset != null &&
                modelAsset.modelType == GlobalSettings.modelTypeStructure  &&
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
                if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
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
                if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
                {
                    return modelAsset.smallerBounds.Count;
                }
                return 0;
            }
        }

        public bool HasCharacterBounds()
        {
            if (modelAsset != null &&
                modelAsset.modelType == GlobalSettings.modelTypeCharacter &&
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

        public Vector3 ModelRotation
        {
            get { return modelAsset.rotation; }
            set { modelAsset.rotation = value; }
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
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Bounding Shapes ==
        //
        public void ClearOutlines()
        {
            debugShapes.ClearStoredShapes();
        }

        public void OutlineLargerBounds()
        {
            if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineLargerBounds(0);
            }
        }

        public void OutlineSmallerBounds()
        {
            if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineSmallerBounds(0, 0);
            }
        }

        public void OutlineAllSmallerBounds()
        {
            if (modelAsset != null && modelAsset.modelType == GlobalSettings.modelTypeStructure)
            {
                modelAsset.OutlineAllSmallerBounds(0);
            }
        }
        //
        //////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////
        // == Load and Save ==
        //
        public void LoadDialogue()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = form.DefaultFileFolder;
            fileDialog.Title = "Load Diabolical Model";
            fileDialog.Filter = "Model Files (*.model)|*.model|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                form.ClearMessages();
                lastLoadedPropertiesFile = fileDialog.FileName;
                LoadModelFile(fileDialog.FileName);
            }
            form.AddMessageLine("== Finished ==");
        }

        public void SaveDialogue()
        {
            // Path to default location
            string pathToSaveFolder = form.DefaultFileFolder;
            string fileName = "Model.model";
            // If we have loaded a file use that for the path and the name
            if (lastLoadedPropertiesFile != "")
            {
                fileName = Path.GetFileName(lastLoadedPropertiesFile);
                pathToSaveFolder = Path.GetDirectoryName(lastLoadedPropertiesFile);
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = pathToSaveFolder;
            fileDialog.Title = "Save Diabolical Model";
            fileDialog.FileName = fileName;
            fileDialog.Filter = "Model Files (*.model)|*.model|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveModelFile(fileDialog.FileName);
            }
            form.AddMessageLine("== Finished ==");
        }

        private void SaveModelFile(string fileName)
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
            // == Filename and effect parameters
            string effect = modelAsset.modelFilename;
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

        private void LoadModelFile(string fileName)
        {
            string[] result = new string[0];

            if (File.Exists(fileName))
            {
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
                form.LoadAnimatedModel(true, filepath, input.RotateX, input.RotateY, input.RotateZ);
            }
            else
            {
                form.LoadAnimatedModel(false, filepath, input.RotateX, input.RotateY, input.RotateZ);
            }

            // Create the class
            modelAsset = new DiabolicalModel(debugShapes);
            modelAsset.BuildModelAsset(
                input.ModelType,
                input.ModelFilename,
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

    }
}
