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
    class DiabolicalModel
    {
        MainForm main;
        string lastLoadedFile = "";

        public DiabolicalModel(MainForm parent)
        {
            main = parent;
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
                //SaveModelFile(fileDialog.FileName);
            }

        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
