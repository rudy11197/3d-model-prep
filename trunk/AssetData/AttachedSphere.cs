#region File Description
//-----------------------------------------------------------------------------
// AttachedSpheres.cs
//
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Used for collision with projectiles
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
#endregion

namespace AssetData
{
    // Detailed bounding spheres for collision with projectiles
    public class AttachedSphere
    {
        // Bone to attach to
        [ContentSerializer]
        public int BoneIndex;
        // Bounding sphere (usually only the +Y value is set as an offset from the end of the bone)
        [ContentSerializer]
        public BoundingSphere Sphere;
        // Offset from the head of the bone
        [ContentSerializer]
        public Vector3 Offset;

        public AttachedSphere()
        {
        }

        public AttachedSphere(int bone, Vector3 centre, float radius, Vector3 offset)
        {
            BoneIndex = bone;
            Sphere = new BoundingSphere(centre, radius);
            Offset = offset;
        }

    }
}
