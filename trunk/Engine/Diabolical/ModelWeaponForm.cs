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
    public partial class ModelWeaponForm : Form
    {
        public ModelWeaponForm()
        {
            InitializeComponent();

            PopulateAmmo();
            PopulateReloadSound();
            PopulateEmptySound();

            listZoom.SelectedIndexChanged += new EventHandler(listZoom_SelectedIndexChanged);
            listCrosshairs.SelectedIndexChanged += new EventHandler(listCrosshairs_SelectedIndexChanged);
        }

        /////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        public Vector3 MuzzleOffset
        {
            get { return positionMuzzle.Value; }
            set { positionMuzzle.Value = value; }
        }

        public float HalfWidth
        {
            get { return (float)numericHalfWidth.Value; }
            set { numericHalfWidth.Value = (decimal)value; }
        }

        public string AmmoType
        {
            get { return comboAmmoType.Text; }
            set
            {
                if (!comboAmmoType.Items.Contains(value))
                {
                    comboAmmoType.Items.Add(value);
                }
                comboAmmoType.Text = value;
            }
        }

        public int MagazineCapacity
        {
            get { return (int)numericClipCapacity.Value; }
            set { numericClipCapacity.Value = (decimal)value; }
        }

        public int MaximumRoundsCarried
        {
            get { return (int)numericMaximum.Value; }
            set { numericMaximum.Value = (decimal)value; }
        }

        public bool AutoFire
        {
            get { return checkAutoFire.Checked; }
            set { checkAutoFire.Checked = value; }
        }

        public float RateOfFire
        {
            get { return (float)numericRateOfFire.Value; }
            set { numericRateOfFire.Value = (decimal)value; }
        }

        public float ReloadSeconds
        {
            get { return (float)numericReloadTime.Value; }
            set { numericReloadTime.Value = (decimal)value; }
        }

        public string ReloadSound
        {
            get { return comboSoundReload.Text; }
            set
            {
                if (!comboSoundReload.Items.Contains(value))
                {
                    comboSoundReload.Items.Add(value);
                }
                comboSoundReload.Text = value;
            }
        }

        public string EmptySound
        {
            get { return comboSoundEmpty.Text; }
            set
            {
                if (!comboSoundEmpty.Items.Contains(value))
                {
                    comboSoundEmpty.Items.Add(value);
                }
                comboSoundEmpty.Text = value;
            }
        }

        public float RangeClosest
        {
            get { return (float)numericRangeClosest.Value; }
            set { numericRangeClosest.Value = (decimal)value; }
        }

        public float RangeFarthest
        {
            get { return (float)numericRangeFarthest.Value; }
            set { numericRangeFarthest.Value = (decimal)value; }
        }

        public float RecoilDegrees
        {
            get { return (float)numericRecoil.Value; }
            set { numericRecoil.Value = (decimal)value; }
        }

        public List<float> ZoomMultipliers
        {
            get
            {
                List<float> result = new List<float>();
                foreach (string s in listZoom.Items)
                {
                    float r = ParseData.FloatFromString(s);
                    result.Add(r);
                }
                return result;
            }
            set
            {
                listZoom.Items.Clear();
                foreach (float f in value)
                {
                    listZoom.Items.Add(ParseData.FloatToString(f));
                }
                ValidateCrosshairs();
            }
        }

        public List<int> Crosshairs
        {
            get
            {
                ValidateCrosshairs();
                List<int> result = new List<int>();
                foreach (string s in listCrosshairs.Items)
                {
                    int r = ParseData.IntFromString(s);
                    result.Add(r);
                }
                return result;
            }
            set
            {
                listCrosshairs.Items.Clear();
                foreach (int i in value)
                {
                    listCrosshairs.Items.Add(ParseData.IntToString(i));
                }
                ValidateCrosshairs();
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Change ==
        //
        private void ValidateCrosshairs()
        {
            while (listCrosshairs.Items.Count < listZoom.Items.Count)
            {
                if (listCrosshairs.Items.Count > 0)
                {
                    listCrosshairs.Items.Add(listCrosshairs.Items[listCrosshairs.Items.Count - 1]);
                }
                else
                {
                    listCrosshairs.Items.Add("1");
                }
            }
            // Only reduce if the zoom multipliers have been loaded
            if (listZoom.Items.Count > 0 && listCrosshairs.Items.Count > listZoom.Items.Count)
            {
                ReduceCrosshairsToMatchZoom();
            }
        }

        private void ReduceCrosshairsToMatchZoom()
        {
            while (listCrosshairs.Items.Count > listZoom.Items.Count)
            {
                listCrosshairs.Items.RemoveAt(listCrosshairs.Items.Count - 1);
            }
        }

        private void listCrosshairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCrosshairs.SelectedIndex >= 0)
            {
                numericEditCrosshair.Value = (decimal)ParseData.IntFromString((string)listCrosshairs.SelectedItem);
            }
            if (listCrosshairs.SelectedIndex != listZoom.SelectedIndex)
            {
                listZoom.SelectedIndex = listCrosshairs.SelectedIndex;
            }
        }

        private void listZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listZoom.SelectedIndex >= 0)
            {
                numericEditZoom.Value = (decimal)ParseData.IntFromString((string)listZoom.SelectedItem);
            }
            if (listCrosshairs.SelectedIndex != listZoom.SelectedIndex)
            {
                listCrosshairs.SelectedIndex = listZoom.SelectedIndex;
            }
        }

        private void buttonChangeCrosshair_Click(object sender, EventArgs e)
        {
            if (listCrosshairs.SelectedIndex >= 0)
            {
                listCrosshairs.Items[listCrosshairs.SelectedIndex] = ParseData.IntToString((int)numericEditCrosshair.Value);
            }
        }

        private void buttonChangeZoom_Click(object sender, EventArgs e)
        {
            if (listZoom.SelectedIndex >= 0)
            {
                listZoom.Items[listZoom.SelectedIndex] = ParseData.FloatToString((float)numericEditZoom.Value);
            }
        }

        /// <summary>
        /// Always adds to the end of the list
        /// </summary>
        private void buttonAddZoom_Click(object sender, EventArgs e)
        {
            listZoom.Items.Add(ParseData.FloatToString((float)numericEditZoom.Value));
            listCrosshairs.Items.Add(ParseData.IntToString((int)numericEditCrosshair.Value));
            ValidateCrosshairs();
        }

        private void buttonRemoveZoom_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (listZoom.SelectedIndex >= 0)
            {
                index = listZoom.SelectedIndex;
            }
            else if (listCrosshairs.SelectedIndex >= 0)
            {
                index = listCrosshairs.SelectedIndex;
            }
            if (index < 0)
            {
                return;
            }
            if (index < listZoom.Items.Count)
            {
                listZoom.Items.RemoveAt(index);
            }
            if (index < listCrosshairs.Items.Count)
            {
                listCrosshairs.Items.RemoveAt(index);
            }
            ValidateCrosshairs();
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // == Setup ==
        //
        private void PopulateAmmo()
        {
            comboAmmoType.Items.Clear();
            comboAmmoType.Items.Add("Bullet");
            comboAmmoType.Items.Add("Rocket");
            comboAmmoType.Items.Add("Explosive");
        }

        private void PopulateReloadSound()
        {
            comboSoundReload.Items.Clear();
            comboSoundReload.Items.Add("GunReload1");
        }

        private void PopulateEmptySound()
        {
            comboSoundEmpty.Items.Clear();
            comboSoundEmpty.Items.Add("GunEmpty1");
        }
        //
        /////////////////////////////////////////////////////////////////////
    }
}
