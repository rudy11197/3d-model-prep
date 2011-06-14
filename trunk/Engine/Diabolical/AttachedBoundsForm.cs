using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AssetData;

namespace Engine
{
    public partial class AttachedBoundsForm : Form
    {
        public AttachedBoundsForm()
        {
            InitializeComponent();
            comboBones.SelectedIndexChanged += new EventHandler(comboBones_SelectedIndexChanged);
            comboIDs.SelectedIndexChanged += new EventHandler(comboIDs_SelectedIndexChanged);
        }

        /////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        private DiabolicalManager diabolicalForm;
        public DiabolicalManager DiabolicalForm
        {
            set 
            { 
                diabolicalForm = value;
                UpdateEnabled();
            }
        }

        private IDictionary<string, int> boneMap;
        public IDictionary<string, int> BoneMap
        {
            set
            {
                boneMap = value;
                PopulateBoneList();
            }
        }

        private List<AttachedSphere> attachedCurrent = new List<AttachedSphere>();
        public List<AttachedSphere> AttachedBounds
        {
            get { return attachedCurrent; }
            set 
            { 
                attachedCurrent.Clear();
                attachedPrevious.Clear();
                if (value.Count > 0)
                {
                    attachedCurrent.AddRange(value);
                    attachedPrevious.AddRange(value);
                }
                PopulateIDs();
            }
        }
        // Used to reset the originals if the form is cancelled
        private List<AttachedSphere> attachedPrevious = new List<AttachedSphere>();
        public List<AttachedSphere> PreviousBounds
        {
            get { return attachedPrevious; }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Initialise ==
        //
        private const string unknownBoneName = "!! Unknown !!";
        private void PopulateBoneList()
        {
            comboBones.Items.Clear();
            comboBones.Items.AddRange(boneMap.Keys.ToArray());
            comboBones.Items.Add(unknownBoneName);
            if (comboBones.Items.Count > 0)
            {
                comboBones.SelectedIndex = 0;
            }
            PopulateIDs();
        }

        private void PopulateIDs()
        {
            if (comboBones.Items.Count < 1 ||
                attachedCurrent.Count < 1)
            {
                return;
            }
            int currentID = comboIDs.SelectedIndex;
            comboIDs.Items.Clear();
            for (int a = 0; a < attachedCurrent.Count; a++)
            {
                AttachedSphere item = attachedCurrent[a];
                string output = a.ToString() + " " + GetBoneName(item.BoneIndex);
                comboIDs.Items.Add(output);
            }
            if (currentID >= 0 && currentID < comboIDs.Items.Count)
            {
                comboIDs.SelectedIndex = currentID;
            }
            else if (comboIDs.Items.Count > 0)
            {
                comboIDs.SelectedIndex = 0;
            }
            GetCurrentData();
        }

        private void UpdateEnabled()
        {
            buttonAdd.Enabled = false;
            buttonOK.Enabled = false;
            buttonUpdate.Enabled = false;
            if (comboBones.SelectedIndex != comboBones.Items.Count - 1 &&
                diabolicalForm != null)
            {
                buttonAdd.Enabled = true;
                buttonOK.Enabled = true;
                buttonUpdate.Enabled = true;
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Changes ==
        //
        private void comboIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCurrentData();
        }

        private void comboBones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoneName();
        }

        private void CheckBoneName()
        {
            if (comboBones.Items.Count > 1 && 
                comboBones.SelectedIndex >= comboBones.Items.Count - 1)
            {
                // Avoid selecting unknown if possible
                ShowBoneNameFromAttached();
            }
        }

        private void ShowBoneNameFromAttached()
        {
            if (comboIDs.SelectedIndex < 0 || 
                comboIDs.SelectedIndex >= attachedCurrent.Count ||
                comboBones.Items.Count < 1)
            {
                return;
            }
            if (attachedCurrent[comboIDs.SelectedIndex].BoneIndex >= 0 &&
                attachedCurrent[comboIDs.SelectedIndex].BoneIndex < comboBones.Items.Count)
            {
                comboBones.SelectedIndex = attachedCurrent[comboIDs.SelectedIndex].BoneIndex;
            }
            else
            {
                // Unknown
                comboBones.SelectedIndex = comboBones.Items.Count - 1;
            }
            UpdateEnabled();
        }

        private string GetBoneName(int boneID)
        {
            if (boneID >= 0 && boneID < comboBones.Items.Count)
            {
                return (string)comboBones.Items[boneID];
            }
            return unknownBoneName;
        }

        private void GetCurrentData()
        {
            if (comboIDs.SelectedIndex < 0 || 
                comboIDs.SelectedIndex >= attachedCurrent.Count)
            {
                return;
            }
            ShowBoneNameFromAttached();
            AttachedSphere item = attachedCurrent[comboIDs.SelectedIndex];
            positionOffset.Value = item.Offset;
            numericRadius.Value = (decimal)item.Sphere.Radius;
            if (diabolicalForm != null)
            {
                diabolicalForm.SetSelectedBound(comboIDs.SelectedIndex);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateChanges();
        }

        private void UpdateChanges()
        {
            if (diabolicalForm == null ||
                comboIDs.SelectedIndex < 0 || 
                comboIDs.SelectedIndex >= attachedCurrent.Count ||
                comboBones.Items.Count < 2 ||
                comboBones.SelectedIndex >= comboBones.Items.Count - 1)
            {
                return;
            }
            AttachedSphere item = attachedCurrent[comboIDs.SelectedIndex];
            item.BoneIndex = comboBones.SelectedIndex;
            item.Offset = positionOffset.Value;
            item.Sphere.Radius = (float)numericRadius.Value;
            attachedCurrent[comboIDs.SelectedIndex] = item;
            // Update the model
            diabolicalForm.AttachedBounds = attachedCurrent;
            // Reload all the data
            PopulateIDs();
        }
        //
        /////////////////////////////////////////////////////////////////////

    }
}
