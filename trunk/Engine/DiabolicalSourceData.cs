#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
// Based on: http://msdn.microsoft.com/en-us/library/bb447754.aspx
//-----------------------------------------------------------------------------
// Used to hold the data imported to create an ActiveModel
//-----------------------------------------------------------------------------
// File format:
// Line 1: The Type of model.  The name is used in the game to pre-load types
//      Structure
//      WeaponLight
//      WeaponSupport
//      Character
// Line 2: The filename of the model to load plus other information
//      What effect file to use, e.g. normalmap
//      The name of the Normal map file to use instead of the one contained in the model
//      The name of the Specular map file to use instead of the one contained in the model
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using AssetData;
#endregion

namespace Engine
{
    // Used to hold the source data when read in
    // This is very similar to the ActiveModelSourceData class.
    public class DiabolicalSourceData
    {
        // The original filename of the source data
        private string identity = "";
        public string Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        // Character, Structure, Weapon etc.
        private string modelType = "";
        public string ModelType
        {
            get { return modelType; }
        }

        // Relative path and filename
        private string modelFilename = "";
        public string ModelFilename
        {
            get { return modelFilename; }
        }

        // Effect type, Bump map or flat
        // Used to decide which processor to use
        private string effectType = "";
        public string EffectType
        {
            get { return effectType; }
        }

        // Shininess
        private float specularIntensity = 0.3f;
        public float SpecularIntensity
        {
            get { return specularIntensity; }
        }

        // Highlight tightness
        private float specularPower = 4.0f;
        public float SpecularPower
        {
            get { return specularPower; }
        }

        // Relative path and filename
        // Used for normal maps and grey scale bump maps
        private string depthMapFilename = "";
        public string DepthMapFilename
        {
            get { return depthMapFilename; }
        }

        // This is currently not used by any shader
        // Relative path and filename
        private string specularMapFilename = "";
        public string SpecularMapFilename
        {
            get { return specularMapFilename; }
        }

        // == Parameters
        private float rotateX;
        public float RotateX
        {
            get { return rotateX; }
        }

        private float rotateY;
        public float RotateY
        {
            get { return rotateY; }
        }

        private float rotateZ;
        public float RotateZ
        {
            get { return rotateZ; }
        }

        // == Options
        private string[] options;
        public string[] Options
        {
            get { return options; }
        }

        public DiabolicalSourceData(string filename, string[] source)
        {
            Identity = filename;
            modelType = source[0];
            // The second line can contain just the file name or more information
            string[] items = ParseData.SplitItemByDivision(source[1]);
            if (items.Length > 5)
            {
                specularMapFilename = items[5];
            }
            if (items.Length > 4)
            {
                depthMapFilename = items[4];
            }
            if (items.Length > 3)
            {
                specularPower = ParseData.FloatFromString(items[3]);
            }
            if (items.Length > 2)
            {
                specularIntensity = ParseData.FloatFromString(items[2]);
            }
            if (items.Length > 1)
            {
                effectType = items[1].ToLowerInvariant();
            }
            modelFilename = items[0];
            // The third line must contain any parameters
            // Starting with the rotation X|Y|Z, set to 0|0|0 for no rotation
            if (source.Length > 2)
            {
                items = ParseData.SplitItemByDivision(source[2]);
                if (items.Length > 2)
                {
                    rotateX = ParseData.FloatFromString(items[0]);
                    rotateY = ParseData.FloatFromString(items[1]);
                    rotateZ = ParseData.FloatFromString(items[2]);
                }
            }
            // Add everything else as an option
            if (source.Length > 3)
            {
                options = new string[source.Length - 2];
                for (int i = 2; i < source.Length; i++)
                {
                    options[i - 2] = source[i];
                }
            }
        }

    }
}
