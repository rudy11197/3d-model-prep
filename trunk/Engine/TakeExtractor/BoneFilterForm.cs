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

            listBoneFilter.DoubleClick += new EventHandler(listBoneFilter_DoubleClick);
            listBoneMap.DoubleClick += new EventHandler(listBoneMap_DoubleClick);
        }

        /////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        public List<string> BoneFilter
        {
            get { return GetBoneFilter(); }
            set{ SetBoneFilter(value); }
        }

        public float CentreFrame
        {
            get { return (float)numericCentreFrame.Value; }
            set { numericCentreFrame.Value = (decimal)value; }
        }

        private void SetBoneFilter(List<string> bones)
        {
            listBoneFilter.Items.Clear();
            if (bones != null)
            {
                listBoneFilter.Items.AddRange(bones.ToArray());
                ValidateBoneFilterList();
            }
        }

        private List<string> GetBoneFilter()
        {
            List<string> bones = new List<string>();
            for (int i = 0; i < listBoneFilter.Items.Count; i++)
            {
                bones.Add((string)listBoneFilter.Items[i]);
            }
            return bones;
        }

        private IDictionary<string, int> boneMap;
        public IDictionary<string, int> BoneMap
        {
            set
            {
                boneMap = value;
                PopulateBoneMapList();
                ValidateBoneFilterList();
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
            for (int i = listBoneFilter.Items.Count - 1; i >= 0; i--)
            {
                if (!boneMap.ContainsKey((string)listBoneFilter.Items[i]))
                {
                    listBoneFilter.Items.RemoveAt(i);
                }
                else
                {
                    // De-duplicate
                    for (int j = 0; j < i; j++)
                    {
                        if (listBoneFilter.Items[j] == listBoneFilter.Items[i])
                        {
                            listBoneFilter.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
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
            SetBoneFilter(null);
        }

        private void buttonHeadBones_Click(object sender, EventArgs e)
        {
            SetBoneFilter(GetTypicalBoneNamesFromBoneMap(TypicalHeadBoneNames()));
            CentreFrame = 2.5f;
        }

        private void buttonArmBones_Click(object sender, EventArgs e)
        {
            SetBoneFilter(GetTypicalBoneNamesFromBoneMap(TypicalArmBoneNames()));
            CentreFrame = 4.0f;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void listBoneMap_DoubleClick(object sender, EventArgs e)
        {
            AddItem();
        }

        private void listBoneFilter_DoubleClick(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void RemoveItem()
        {
            if (listBoneFilter.SelectedIndex >= 0)
            {
                listBoneFilter.Items.RemoveAt(listBoneFilter.SelectedIndex);
            }
        }

        private void AddItem()
        {
            if (listBoneMap.SelectedIndex >= 0)
            {
                listBoneFilter.Items.Add(listBoneMap.Items[listBoneMap.SelectedIndex]);
                ValidateBoneFilterList();
            }
        }
        //
        /////////////////////////////////////////////////////////////////////


    }
}
