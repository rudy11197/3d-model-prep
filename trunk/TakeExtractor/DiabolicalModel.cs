#region File Description
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
// URL: http://www.MistyManor.co.uk
//-----------------------------------------------------------------------------
#endregion

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AssetData;

namespace Engine
{
    /// <summary>
    /// The model properties
    /// </summary>
    class DiabolicalModel
    {

        // Structure
        // The larger contains the indices of the smaller
        public List<StructureSphere> LargerBounds = new List<StructureSphere>();
        // The smaller contains the indices of the triangles
        public List<StructureSphere> SmallerBounds = new List<StructureSphere>();

        // Base
        // The filename of the original model .fbx or .x relative to the folder which contains the .model file
        public string ModelFilename = "";
        // Used for both Normal and grey scale Bump map files
        public string DepthMapFile = "";
        // Specular map file
        public string SpecularMapFile = "";
        // Shape class used to draw guide lines for testing collision
        //public Shapes debugShapes;
        // Rotate the model when loaded round X, Y, Z
        public Vector3 Rotation;
        // These are only needed for the initial setup of the effect once loaded
        // Effect type
        public string EffectType = "";
        // Shininess
        public float SpecularIntensity = 0.3f;
        // Highlight tightness
        public float SpecularPower = 4.0f;

        // Model and components
        public Model model;    //that's what we are working on

        public DiabolicalModel()
        {
        }

        //////////////////////////////////////////////////////////////////////
        //

        //
        //////////////////////////////////////////////////////////////////////

    }
}
