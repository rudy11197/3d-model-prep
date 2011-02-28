using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Engine
{
    public partial class ModelTypeForm : Form
    {
        public ModelTypeForm()
        {
            InitializeComponent();
            BuildList();
            SetInitialText();
        }

        //////////////////////////////////////////////////////////////////////
        // == Results ==
        //
        public string ModelType
        {
            get { return (string)comboType.SelectedItem; }
            set
            {
                // Add anything that does noes not already exist
                if (!comboType.Items.Contains(value))
                {
                    comboType.Items.Add(value);
                }
                comboType.SelectedItem = value;
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Setup ==
        //
        private void BuildList()
        {
            comboType.Items.Clear();
            comboType.Items.Add(GlobalSettings.modelTypeCharacter);
            comboType.Items.Add(GlobalSettings.modelTypeStructure);
            comboType.Items.Add(GlobalSettings.modelTypeEquipLight);
            comboType.Items.Add(GlobalSettings.modelTypeEquipSupport);
            comboType.Items.Add(GlobalSettings.modelTypeEquipSmallArms);
            comboType.Items.Add(GlobalSettings.modelTypeEquipGrenade);
            comboType.Items.Add(GlobalSettings.modelTypeGearHead);
            comboType.Items.Add(GlobalSettings.modelTypeGearAccessory);
            comboType.Items.Add(GlobalSettings.modelTypeGearOther);
        }

        private void SetInitialText()
        {
            comboType.SelectedText = GlobalSettings.modelTypeStructure;
        }
        //
        //////////////////////////////////////////////////////////////////////
    }
}
