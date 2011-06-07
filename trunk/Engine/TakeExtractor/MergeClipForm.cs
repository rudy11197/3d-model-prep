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
            // Remove any bones that don't exist in the bone map and de-duplicate
            for (int i = upperBodyBones.Count - 1; i >= 0; i--)
            {
                if (!boneMap.ContainsKey(upperBodyBones[i]))
                {
                    upperBodyBones.RemoveAt(i);
                }
                else
                {
                    // De-duplicate
                    for (int j = 0; j < i; j++)
                    {
                        if (upperBodyBones[j] == upperBodyBones[i])
                        {
                            upperBodyBones.RemoveAt(i);
                            break;
                        }
                    }
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

        /////////////////////////////////////////////////////////////////////
        // == Changes ==
        //
        private void buttonEmpty_Click(object sender, EventArgs e)
        {
            upperBodyBones.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddBoneWithName(comboBones.Text);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveBonesWithName(comboBones.Text);
        }

        private void buttonTypical_Click(object sender, EventArgs e)
        {
            upperBodyBones.AddRange(GetUpperBoneNamesFromBoneMap());
            PopulateUpperBodyBoneList();
        }

        private void RemoveBonesWithName(string name)
        {
            for (int i = upperBodyBones.Count - 1; i >= 0; i--)
            {
                if (name == upperBodyBones[i])
                {
                    upperBodyBones.RemoveAt(i);
                }
            }
            PopulateUpperBodyBoneList();
        }

        private void AddBoneWithName(string name)
        {
            upperBodyBones.Add(name);
            PopulateUpperBodyBoneList();
        }

        private List<string> GetUpperBoneNamesFromBoneMap()
        {
            List<string> result = new List<string>();
            if (boneMap == null)
            {
                return result;
            }
            string[] typical = TypicalUpperBodyBoneNames();
            List<string> boneNames = new List<string>();
            boneNames.AddRange(boneMap.Keys.ToArray());

            for (int b = 0; b < boneNames.Count; b++)
            {
                if (IsBoneWeWant(boneNames[b], typical))
                {
                    result.Add(boneNames[b]);
                }
            }
            return result;
        }

        private string[] TypicalUpperBodyBoneNames()
        {
            string[] result = new string[] 
            { 
                "Head",
                "Skull",
                "Neck",
                "Shoulder",
                "Collar",
                "Arm",
                "Finger",
                "Thumb",
                "Hand",
                "Wrist",
                "Ulna",
                "Radius",
                "Humerus",
                "Digit"
            };
            // Convert to lower
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].ToLower();
            }
            return result;
        }

        /// <summary>
        /// typical bone names must only contain lower case values
        /// </summary>
        private bool IsBoneWeWant(string name, string[] typical)
        {
            name = name.ToLower();
            for (int i = 0; i < typical.Length; i++)
            {
                if (name.Contains(typical[i]))
                {
                    return true;
                }
            }
            return false;
        }
        //
        /////////////////////////////////////////////////////////////////////

    }
}
