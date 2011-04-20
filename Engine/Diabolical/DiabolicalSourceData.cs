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

        /*
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
         * */

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
            // First check the file format version
            switch (source[0])
            {
                case "2":
                    ProcessType2(source);
                    break;
                default:
                    // Original type with no file format number
                    ProcessType1(source);
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////
        // - Colours and specular are added as an option
        // Line 1 = file format version
        //          Allows for future changes to the file format
        // Line 2 = The Effect Type
        //          Animated
        //          Rigid
        //          RigidNormalMap (not currently supported)
        //          etc.
        // Line 3 = Type of model.  Used in the game to group and pre-load the models.
        //          Structure
        //          WeaponLight
        //          WeaponSupport
        //          Character
        // Line 4 = The filename of the model to load
        //          Textures would normally be in the same folder as the .X or .FBX model file.
        // Line 5 = Rotation, X, Y, Z
        //          Used to rotate the model, vertices and animations in the pipeline
        //          while loadinging so that no extra processing is needed at run time.
        private void ProcessType2(string[] source)
        {
            // Start at the first line past the file format type
            int ID = 1;
            // - Effect type -
            effectType = source[ID];
            ID++;
            // - Model type -
            modelType = source[ID];
            ID++;
            // - Filename -
            // Loading model textures does not work if the standard folder character is loaded!
            modelFilename = ParseData.UseAlternateFolderCharacters(source[ID]);
            ID++;
            // - Rotation -
            // Starting with the rotation X|Y|Z, set to 0|0|0 for no rotation
            if (source.Length > ID)
            {
                string[] items = ParseData.SplitItemByDivision(source[ID]);
                ID++;
                if (items.Length > 2)
                {
                    rotateX = ParseData.FloatFromString(items[0]);
                    rotateY = ParseData.FloatFromString(items[1]);
                    rotateZ = ParseData.FloatFromString(items[2]);
                }
            }
            // Add everything else as an option
            if (source.Length > ID)
            {
                options = new string[source.Length - ID];
                for (int i = ID; i < source.Length; i++)
                {
                    options[i - ID] = source[i];
                }
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        // - Old File format (prior to versioning):
        // This is the type before a format type was added to the file
        // Line 1: The Type of model.  The name is used in the game to pre-load types
        //          Structure
        //          WeaponLight
        //          WeaponSupport
        //          Character
        // Line 2: The filename of the model to load plus other information
        //          The other information is no longer used but will be ignored
        // Line 3 = Rotation, X, Y, Z
        //          Used to rotate the model, vertices and animations in the pipeline
        //          while loadinging so that no extra processing is needed at run time.
        private void ProcessType1(string[] source)
        {
            int ID = 0;
            modelType = source[ID];
            ID++;
            // - Filename and other information
            string[] items = ParseData.SplitItemByDivision(source[ID]);
            ID++;
            // Loading model textures does not work if the standard folder character is loaded!
            modelFilename = ParseData.UseAlternateFolderCharacters(items[0]);
            // Other information on this line is ignored
            // Forward compatibility
            effectType = GlobalSettings.effectTypeRigid;
            if (modelType == GlobalSettings.modelTypeCharacter)
            {
                effectType = GlobalSettings.effectTypeAnimated;
            }
            // Starting with the rotation X|Y|Z, set to 0|0|0 for no rotation
            if (source.Length > ID)
            {
                items = ParseData.SplitItemByDivision(source[ID]);
                ID++;
                if (items.Length > 2)
                {
                    rotateX = ParseData.FloatFromString(items[0]);
                    rotateY = ParseData.FloatFromString(items[1]);
                    rotateZ = ParseData.FloatFromString(items[2]);
                }
            }
            // Add everything else as an option
            if (source.Length > ID)
            {
                options = new string[source.Length - ID];
                for (int i = ID; i < source.Length; i++)
                {
                    options[i - ID] = source[i];
                }
            }
        }
        //
        /////////////////////////////////////////////////////////////////////

    }
}
