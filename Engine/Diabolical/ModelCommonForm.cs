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
            get { return textBumpFile.Text; }
            set { textBumpFile.Text = value; }
        }

        public float SpecularIntensity
        {
            get { return (float)numericSpecularIntensity.Value; }
            set { numericSpecularIntensity.Value = (decimal)value; }
        }

        public float SpecularPower
        {
            get { return (float)numericSpecularPower.Value; }
            set { numericSpecularPower.Value = (decimal)value; }
        }

        public string SpecularMapFileName
        {
            get { return textSpecularFile.Text; }
            set { textSpecularFile.Text = value; }
        }

        public int LargeBoundCount
        {
            set { textLargeCount.Text = value.ToString(); }
        }

        public int SmallBoundCount
        {
            set { textSmallCount.Text = value.ToString(); }
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
            comboEffect.Items.Add(GlobalSettings.effectTypeNormalMap);
        }

        private void SetInitialValues()
        {
            comboEffect.SelectedItem = GlobalSettings.effectTypeRigid;
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
            textBumpFile.Enabled = true;
            buttonBump.Enabled = true;
            numericSpecularIntensity.Enabled = true;
            numericSpecularPower.Enabled = true;
            textSpecularFile.Enabled = true;
            buttonSpecular.Enabled = true;
            if (IsEffectRigid)
            {
                textBumpFile.Enabled = false;
                buttonBump.Enabled = false;
                numericSpecularIntensity.Enabled = false;
                numericSpecularPower.Enabled = false;
                textSpecularFile.Enabled = false;
                buttonSpecular.Enabled = false;
            }
        }

        /// <summary>
        /// Rotation suitable to change models produced using Z as the up axis to XNA which uses the Y as the up axis.
        /// Blender to XNA.
        /// </summary>
        private void buttonBlender_Click(object sender, EventArgs e)
        {
            // 90 0 180
            positionRotation.Value = new Vector3(90, 0, 180);
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

        private void buttonBump_Click(object sender, EventArgs e)
        {
            textBumpFile.Text = BrowseImages(textBumpFile.Text);
        }

        private void buttonSpecular_Click(object sender, EventArgs e)
        {
            textSpecularFile.Text = BrowseImages(textSpecularFile.Text);
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
