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
    public partial class MergeClipForm : Form
    {
        public MergeClipForm()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        private List<string> upperBodyBones = new List<string>();
        public List<string> UpperBodyBones
        {
            get { return upperBodyBones; }
            set 
            { 
                upperBodyBones = value;
                PopulateUpperBodyBoneList();
            }
        }

        private IDictionary<string, int> boneMap;
        public IDictionary<string, int> BoneMap
        {
            set 
            { 
                boneMap = value;
                PopulateBoneList();
                PopulateUpperBodyBoneList();
            }
        }

        private List<string> clipNames = new List<string>();
        public List<string> ClipNames
        {
            set
            {
                clipNames = value;
                PopulateClipNames();
            }
        }

        public string UpperBodyClip
        {
            get { return comboUpper.Text; }
        }

        public string LowerBodyClip
        {
            get { return comboLower.Text; }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Initialise ==
        //
        private void PopulateBoneList()
        {
            comboBones.Items.Clear();
            comboBones.Items.AddRange(boneMap.Keys.ToArray());
            if (comboBones.Items.Count > 0)
            {
                comboBones.SelectedIndex = 0;
            }
        }

        private void PopulateClipNames()
        {
            comboUpper.Items.Clear();
            comboUpper.Items.AddRange(clipNames.ToArray());
            if (comboUpper.Items.Count > 0)
            {
                comboUpper.SelectedIndex = 0;
            }
            comboLower.Items.Clear();
            comboLower.Items.AddRange(clipNames.ToArray());
            if (comboLower.Items.Count > 0)
            {
                comboLower.SelectedIndex = 0;
            }
        }

        private void ValidateUpperBonesList()
        {
            if (boneMap == null || boneMap.Count < 1)
            {
                return;
            }
            // Remove any bones that done exist in the bone map
            for (int i = upperBodyBones.Count - 1; i >= 0; i--)
            {
                if (!boneMap.ContainsKey(upperBodyBones[i]))
                {
                    upperBodyBones.RemoveAt(i);
                }
            }
        }

        private void PopulateUpperBodyBoneList()
        {
            ValidateUpperBonesList();
            string result = "";
            for (int i = 0; i < upperBodyBones.Count; i++)
            {
                result += upperBodyBones[i] + ParseData.div;
            }
            textBones.Text = result;
        }
        //
        /////////////////////////////////////////////////////////////////////

    }
}
