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
    class DiabolicalData
    {
        MainForm main;
        string lastLoadedFile = "";

        DiabolicalModel model;


        public DiabolicalData(MainForm parent)
        {
            main = parent;
            model = new DiabolicalModel();
        }

        //////////////////////////////////////////////////////////////////////
        // == Load and Save ==
        //
        public void LoadDialogue()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = main.DefaultFileFolder;
            fileDialog.Title = "Load Diabolical Model";
            fileDialog.Filter = "Model Files (*.model)|*.model|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                main.ClearMessages();
                lastLoadedFile = fileDialog.FileName;
                //LoadModelFile(fileDialog.FileName);
            }
            main.AddMessageLine("== Finished ==");
        }

        public void SaveDialogue()
        {
            // Path to default location
            string pathToSaveFolder = main.DefaultFileFolder;
            string fileName = "Model.model";
            // If we have loaded a file use that for the path and the name
            if (lastLoadedFile != "")
            {
                fileName = Path.GetFileName(lastLoadedFile);
                pathToSaveFolder = Path.GetDirectoryName(lastLoadedFile);
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = pathToSaveFolder;
            fileDialog.Title = "Save Diabolical Model";
            fileDialog.FileName = fileName;
            fileDialog.Filter = "Model Files (*.model)|*.model|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //SaveModelFile(fileDialog.FileName, GetStructureSaveData());
            }

        }

        // Save changes to any model to the user storage area
        public List<string> GetStructureSaveData()
        {
            List<string> data = new List<string>();
            // == Model data
            // The type and name
            data.Add("Structure");
            // == Filename and effect parameters
            string effect = model.ModelFilename;
            if (!string.IsNullOrEmpty(model.EffectType))
            {
                effect += ParseData.div + model.EffectType;
                effect += ParseData.div + ParseData.FloatToString(model.SpecularIntensity);
                effect += ParseData.div + ParseData.FloatToString(model.SpecularPower);
                if (!string.IsNullOrEmpty(model.DepthMapFile))
                {
                    effect += ParseData.div + model.DepthMapFile;
                    if (!string.IsNullOrEmpty(model.SpecularMapFile))
                    {
                        effect += ParseData.div + model.SpecularMapFile;
                    }
                }
            }
            data.Add(effect);
            // == Parameters
            string parameters = ParseData.FloatToString(model.Rotation.X) +
                ParseData.div + ParseData.FloatToString(model.Rotation.Y) +
                ParseData.div + ParseData.FloatToString(model.Rotation.Z);
            data.Add(parameters);
            // == Options
            // Bounds
            foreach (StructureSphere ssBound in model.LargerBounds)
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
            foreach (StructureSphere ssBound in model.SmallerBounds)
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
        //
        //////////////////////////////////////////////////////////////////////

    }
}
