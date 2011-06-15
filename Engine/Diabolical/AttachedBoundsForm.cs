using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
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
            // Orbit buttons
            buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            buttonPlay.Click += new EventHandler(buttonPlay_Click);
            buttonRewind.Click += new EventHandler(buttonRewind_Click);
            buttonForward.LostFocus += new EventHandler(buttonForward_LostFocus);
            buttonReverse.LostFocus += new EventHandler(buttonReverse_LostFocus);
            buttonForward.MouseDown += new MouseEventHandler(buttonForward_MouseDown);
            buttonReverse.MouseDown += new MouseEventHandler(buttonReverse_MouseDown);
            buttonForward.MouseUp += new MouseEventHandler(buttonForward_MouseUp);
            buttonReverse.MouseUp += new MouseEventHandler(buttonReverse_MouseUp);
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
                PopulateIDs(false);
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
            PopulateIDs(false);
        }

        private void PopulateIDs(bool selectHighest)
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
            if (!selectHighest && currentID >= 0 && currentID < comboIDs.Items.Count)
            {
                comboIDs.SelectedIndex = currentID;
            }
            else if (comboIDs.Items.Count > 0)
            {
                comboIDs.SelectedIndex = comboIDs.Items.Count - 1;
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
            UpdateModelAndFormLists(false);
        }

        private void UpdateModelAndFormLists(bool selectHighest)
        {
            // Update the model
            diabolicalForm.AttachedBounds = attachedCurrent;
            // Reload all the data
            PopulateIDs(selectHighest);
        }

        private void WarnBeforeDeleteBound()
        {
            if (MessageBox.Show("Are you sure you want to delete this attached bound?", "Delete Bounds", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteBound(comboIDs.SelectedIndex);
            }
        }

        private void DeleteBound(int boundID)
        {
            if (attachedCurrent != null && boundID >= 0 && boundID < attachedCurrent.Count)
            {
                attachedCurrent.RemoveAt(boundID);
                UpdateModelAndFormLists(false);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            WarnBeforeDeleteBound();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddBound();
        }

        private void AddBound()
        {
            if (attachedCurrent != null && comboBones.Items.Count > 1)
            {
                AttachedSphere sphere = 
                    new AttachedSphere(0, Vector3.Zero, GlobalSettings.boundAttachedRadius, Vector3.Zero);
                attachedCurrent.Add(sphere);
                UpdateModelAndFormLists(true);
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Orbit ==
        //
        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopOrbit();
        }

        private void buttonReverse_MouseUp(object sender, MouseEventArgs e)
        {
            StopOrbit();
        }

        private void buttonForward_MouseUp(object sender, MouseEventArgs e)
        {
            StopOrbit();
        }

        private void buttonReverse_MouseDown(object sender, MouseEventArgs e)
        {
            PlayOrbit(-1);
        }

        private void buttonForward_MouseDown(object sender, MouseEventArgs e)
        {
            PlayOrbit(1);
        }

        private void buttonReverse_LostFocus(object sender, EventArgs e)
        {
            StopOrbit();
        }

        private void buttonForward_LostFocus(object sender, EventArgs e)
        {
            StopOrbit();
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            PlayOrbit(-1);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            PlayOrbit(1);
        }

        private void PlayOrbit(float amount)
        {
            if (diabolicalForm != null)
            {
                diabolicalForm.SetOrbit(true, amount);
            }
        }

        private void StopOrbit()
        {
            if (diabolicalForm != null)
            {
                diabolicalForm.SetOrbit(false, 0);
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

    }
}
