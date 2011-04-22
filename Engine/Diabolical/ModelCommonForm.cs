using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Engine
{
    public partial class ModelCommonForm : Form
    {
        public ModelCommonForm()
        {
            InitializeComponent();
            BuildList();
            SetInitialValues();
            SetInitialEvents();
            UpdateEnableDisable();
        }
        //////////////////////////////////////////////////////////////////////
        // == Results and Properties ==
        //
        /// <summary>
        /// Set the path to the current model for use with the browse image dialogues.
        /// </summary>
        private string modelFullPath = "";
        public string ModelFullPath
        {
            set { modelFullPath = value; }
        }

        public string ModelRelativePath
        {
            set { textModelFile.Text = value; }
        }

        public Vector3 ModelRotation
        {
            get { return positionRotation.Value; }
            set { positionRotation.Value = value; }
        }

        public string EffectType
        {
            get 
            {
                return (string)comboEffect.SelectedItem;
            }
            set
            {
                string input = value;
                if (string.IsNullOrEmpty(input))
                {
                    input = GlobalSettings.effectTypeRigid;
                }
                else if (!comboEffect.Items.Contains(input))
                {
                    // Add anything that does not already exist
                    comboEffect.Items.Add(input);
                }
                comboEffect.SelectedItem = input;
            }
        }

        public bool IsEffectRigid
        {
            get 
            {
                if ((string)comboEffect.SelectedItem == GlobalSettings.effectTypeRigid)
                {
                    return true;
                }
                return false;
            }
        }

        public string DepthMapFileName
        {
            get { return textNormalMapFile.Text; }
            set { textNormalMapFile.Text = value; }
        }

        public float SpecularPower
        {
            get { return (float)numericSpecularPower.Value; }
            set { numericSpecularPower.Value = (decimal)value; }
        }

        private System.Drawing.Color specularColour = System.Drawing.Color.White;
        public Vector3 SpecularColour
        {
            get { return ColorToVector(specularColour); }
            set 
            { 
                specularColour = VectorToColor(value);
                UpdateColours();
            }
        }

        private System.Drawing.Color diffuseColour = System.Drawing.Color.White;
        public Vector3 DiffuseColour
        {
            get { return ColorToVector(diffuseColour); }
            set 
            { 
                diffuseColour = VectorToColor(value);
                UpdateColours();
            }
        }

        private System.Drawing.Color emissiveColour = System.Drawing.Color.Black;
        public Vector3 EmissiveColour
        {
            get { return ColorToVector(emissiveColour); }
            set 
            { 
                emissiveColour = VectorToColor(value);
                UpdateColours();
            }
        }

        private System.Drawing.Color VectorToColor(Vector3 colour)
        {
            return System.Drawing.Color.FromArgb(255, (int)colour.X * 255, (int)colour.Y * 255, (int)colour.Z * 255);
        }

        private Vector3 ColorToVector(System.Drawing.Color colour)
        {
            return new Vector3((float)colour.R / 255f, (float)colour.G / 255f, (float)colour.B / 255f);
        }

        // Convert to the int32 colour values for use with the colorDialog custom colours
        // CustomColor = ((FirstColor.B << 16) || (FirstColor.G << 8) || (FirstColor.R));
        // or
        // CustomColor = (FirstColor.R) + (FirstColor.G * 256) + (FirstColor.B * 256 * 256);
        private int ColorToBGR(System.Drawing.Color colour)
        {
            return (colour.B << 16) + (colour.G << 8) + colour.R;
        }

        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Setup ==
        //
        private void BuildList()
        {
            comboEffect.Items.Clear();
            comboEffect.Items.Add(GlobalSettings.effectTypeRigid);
            comboEffect.Items.Add(GlobalSettings.effectTypeAnimated);
            //comboEffect.Items.Add(GlobalSettings.effectTypeNormalMap);
        }

        private void SetInitialValues()
        {
            comboEffect.SelectedItem = GlobalSettings.effectTypeRigid;
            UpdateColours();
        }



        private void SetInitialEvents()
        {
            comboEffect.SelectedValueChanged += new EventHandler(comboEffect_SelectedValueChanged);
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Changes ==
        //
        private void comboEffect_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateEnableDisable();
        }

        private void UpdateEnableDisable()
        {
            // Effect
            DisableNormalMap();
            UpdateColours();
        }

        // Disable the normal map options as they are not supported for the time being
        private void DisableNormalMap()
        {
            labelNormalMapHeading.Enabled = false;
            textNormalMapFile.Enabled = false;
            buttonNormalMapFileBrowse.Enabled = false;
            labelNormalMapNote.Enabled = false;

            labelNormalMapHeading.Visible = false;
            textNormalMapFile.Visible = false;
            buttonNormalMapFileBrowse.Visible = false;
            labelNormalMapNote.Visible = false;
        }

        private void UpdateColours()
        {
            buttonSpecularColour.BackColor = specularColour;
        }

        /// <summary>
        /// Rotation suitable to change models produced using Z as the up axis to XNA which uses the Y as the up axis.
        /// For some reason rigid model exported from Blender are a different way up to animated models.
        /// Animated Blender to XNA.
        /// </summary>
        private void buttonBlenderAnimated_Click(object sender, EventArgs e)
        {
            // 90 0 180
            positionRotation.Value = new Vector3(90, 0, 180);
        }

        /// Rotation suitable to change models produced using Z as the up axis to XNA which uses the Y as the up axis.
        /// For some reason rigid model exported from Blender are a different way up to animated models.
        /// Rigid Blender to XNA.
        private void buttonBlenderRigid_Click(object sender, EventArgs e)
        {
            // -90 0 180
            positionRotation.Value = new Vector3(-90, 0, 180);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            positionRotation.Value = Vector3.Zero;
        }

        private string BrowseImages(string previousName)
        {
            string currentPath = Path.GetDirectoryName(modelFullPath);
            if (string.IsNullOrEmpty(currentPath))
            {
                currentPath = MainForm.GetSavePath();
            }

            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = currentPath;

            fileDialog.Title = "Image Files";

            fileDialog.Filter = "Image Files (*.jpg;*.png etc.)|*.jpg;*.jpeg;*.png;*.bmp;*.tga|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string result = fileDialog.FileName;
                if (string.IsNullOrEmpty(result))
                {
                    return previousName;
                }
                result = Path.GetFileName(result);
                return result;
            }
            return previousName;
        }

        private void buttonNormalMap_Click(object sender, EventArgs e)
        {
            textNormalMapFile.Text = BrowseImages(textNormalMapFile.Text);
        }

        //
        //////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////
        // == Colours ==
        //
        private void SpecularColourDialogue()
        {
            ColorDialog colourDialog = new ColorDialog();
            colourDialog.Color = specularColour;
            colourDialog.FullOpen = true;
            colourDialog.CustomColors = new int[3] { ColorToBGR(specularColour), ColorToBGR(diffuseColour), ColorToBGR(emissiveColour) };
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                // Results
                specularColour = colourDialog.Color;
                UpdateColours();
            }
        }

        private void DiffuseColourDialogue()
        {
            ColorDialog colourDialog = new ColorDialog();
            colourDialog.Color = diffuseColour;
            colourDialog.FullOpen = true;
            colourDialog.CustomColors = new int[3] { ColorToBGR(specularColour), ColorToBGR(diffuseColour), ColorToBGR(emissiveColour) };
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                // Results
                diffuseColour = colourDialog.Color;
                UpdateColours();
            }
        }

        private void EmissiveColourDialogue()
        {
            ColorDialog colourDialog = new ColorDialog();
            colourDialog.Color = emissiveColour;
            colourDialog.FullOpen = true;
            colourDialog.CustomColors = new int[3] { ColorToBGR(specularColour), ColorToBGR(diffuseColour), ColorToBGR(emissiveColour) };
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                // Results
                emissiveColour = colourDialog.Color;
                UpdateColours();
            }
        }


        private void buttonSpecularColour_Click(object sender, EventArgs e)
        {
            SpecularColourDialogue();
        }

        private void buttonDiffuseColour_Click(object sender, EventArgs e)
        {
            DiffuseColourDialogue();

        }

        private void buttonEmissiveColour_Click(object sender, EventArgs e)
        {
            EmissiveColourDialogue();
        }

        private void buttonSpecularDefault_Click(object sender, EventArgs e)
        {
            SpecularColour = Vector3.One;
        }

        private void buttonDiffuseDefault_Click(object sender, EventArgs e)
        {
            DiffuseColour = Vector3.One;
        }

        private void buttonEmissiveDefault_Click(object sender, EventArgs e)
        {
            EmissiveColour = Vector3.Zero;
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
