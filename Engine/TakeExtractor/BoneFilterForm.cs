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
    public partial class BoneFilterForm : Form
    {
        public BoneFilterForm()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        private List<string> boneFilter = new List<string>();
        public List<string> BoneFilter
        {
            get { return boneFilter; }
            set
            {
                boneFilter = value;
                PopulateBoneFilterList();
            }
        }

        private IDictionary<string, int> boneMap;
        public IDictionary<string, int> BoneMap
        {
            set
            {
                boneMap = value;
                PopulateBoneMapList();
                PopulateBoneFilterList();
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Initialise ==
        //
        private void PopulateBoneMapList()
        {
            listBoneMap.Items.Clear();
            listBoneMap.Items.AddRange(boneMap.Keys.ToArray());
        }

        private void ValidateBoneFilterList()
        {
            if (boneMap == null || boneMap.Count < 1)
            {
                return;
            }
            // Remove any bones that don't exist in the bone map and de-duplicate
            for (int i = boneFilter.Count - 1; i >= 0; i--)
            {
                if (!boneMap.ContainsKey(boneFilter[i]))
                {
                    boneFilter.RemoveAt(i);
                }
                else
                {
                    // De-duplicate
                    for (int j = 0; j < i; j++)
                    {
                        if (boneFilter[j] == boneFilter[i])
                        {
                            boneFilter.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateBoneFilterList()
        {
            ValidateBoneFilterList();
            string result = "";
            for (int i = 0; i < boneFilter.Count; i++)
            {
                result += boneFilter[i] + ParseData.div;
            }
            textListBones.Text = result;
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Changes ==
        //
        private List<string> GetTypicalBoneNamesFromBoneMap(string[] typical)
        {
            List<string> result = new List<string>();
            if (boneMap == null)
            {
                return result;
            }
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

        private string[] TypicalArmBoneNames()
        {
            string[] result = new string[] 
            { 
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

        private string[] TypicalHeadBoneNames()
        {
            string[] result = new string[] 
            { 
                "Head",
                "Skull",
                "Neck"
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

        private void buttonAllBones_Click(object sender, EventArgs e)
        {
            boneFilter.Clear();
            PopulateBoneFilterList();
        }

        private void buttonHeadBones_Click(object sender, EventArgs e)
        {
            boneFilter.Clear();
            boneFilter.AddRange(GetTypicalBoneNamesFromBoneMap(TypicalHeadBoneNames()));
            PopulateBoneFilterList();
        }

        private void buttonArmBones_Click(object sender, EventArgs e)
        {
            boneFilter.Clear();
            boneFilter.AddRange(GetTypicalBoneNamesFromBoneMap(TypicalArmBoneNames()));
            PopulateBoneFilterList();
        }
        //
        /////////////////////////////////////////////////////////////////////


    }
}
