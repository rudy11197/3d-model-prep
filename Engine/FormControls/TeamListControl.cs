//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Engine
{
    public partial class TeamListContol : UserControl
    {
        private bool useManufracturers = false;
        private bool includeWaypoints = true;
        private int lowestTeam = -1;
        private bool mustSetRace = false;

        public TeamListContol()
        {
            InitializeComponent();
            comboTeam.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTeam.Items.AddRange(TeamNumbersList(includeWaypoints));
            TeamNumber = lowestTeam;
        }

        private string[] TeamNumbersList(bool withWaypoints)
        {
            includeWaypoints = withWaypoints;
            useManufracturers = false;
            int maxNumber = 32;
            if (includeWaypoints)
            {
                lowestTeam = -1;
            }
            else
            {
                lowestTeam = 0;
            }
            string[] result = new string[maxNumber];
            int index = 0;
            if (includeWaypoints)
            {
                result[index] = " -1 Waypoint";
                index++;
            }
            result[index] = "  0 Any";
            index++;
            result[index] = "  1 Human";
            index++;
            result[index] = "  2 Alien";
            index++;
            string space = "  ";
            int num = 3;
            for (int t = index; t < maxNumber; t++)
            {
                if (num > 9)
                {
                    space = "";
                }
                result[t] = space + num;
                num++;
            }
            return result;
        }

        private string[] ManufacturersList()
        {
            useManufracturers = true;
            lowestTeam = 0;
            return GetManufacturerNames();
        }

        // The manufacturer source.  Cast to an int for use.
        public enum Source
        {
            Any,        // 0
            Human,      // 1
            Alien       // 2
        }

        public static string[] GetManufacturerNames()
        {
            //int numberTypes = (int)Source.Alien + 1;
            // The following does not work on the Xbox (the above could)
            int numberTypes = Enum.GetValues(typeof(Source)).Length;

            string[] aNames = new string[numberTypes];
            aNames[(int)Source.Any] = "Any";
            aNames[(int)Source.Human] = "Human";
            aNames[(int)Source.Alien] = "Alien";
            return aNames;
        }

        private void ValidateTeam()
        {
            if (mustSetRace && TeamNumber < 1)
            {
                TeamNumber = 1;
            }
        }

        //////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        public int TeamNumber
        {
            get { return Math.Max(comboTeam.SelectedIndex + lowestTeam, lowestTeam); }
            set 
            {
                int index = value - lowestTeam;
                index = Math.Max(index, 0);
                index = Math.Min(index, comboTeam.Items.Count - 1);
                comboTeam.SelectedIndex = index;
                ValidateTeam();
            }
        }

        public void ListTeamsWithWaypoints()
        {
            WithWaypoints = true;
        }

        public void ListTeamsWithoutWaypoints()
        {
            WithWaypoints = false;
        }

        public bool WithWaypoints
        {
            get { return includeWaypoints; }
            set
            {
                comboTeam.Items.Clear();
                comboTeam.Items.AddRange(TeamNumbersList(value));
                comboTeam.SelectedIndex = 0;
            }
        }

        public void ListManufacturers()
        {
            WithManufacturers = true;
        }

        public bool WithManufacturers
        {
            get { return useManufracturers; }
            set
            {
                comboTeam.Items.Clear();
                comboTeam.Items.AddRange(ManufacturersList());
                comboTeam.SelectedIndex = 0;
            }
        }

        public bool MustSetRace
        {
            get { return mustSetRace; }
            set 
            { 
                mustSetRace = value;
                ValidateTeam();
            }
        }
        //
        //////////////////////////////////////////////////////////////////////


    }
}
