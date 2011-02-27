#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
#endregion

namespace AssetData
{
    // List of points on the model to attach other models to
    public class AttachmentPoint
    {
        // Index of the bone that the attached model connects to
        [ContentSerializer]
        public int idBone;  
        // Any local transform needed on the attached model
        // The adjustment is relative to the bone and is affected by which way the model
        // is drawn, If the model is rotated when it was imported so that it is now +Y up then:
        // +X=To the bone left, -X=To the bone right
        // +Y=To the bone back, -Y=To the bone front
        // +Z=To the bone up, -Z=To the bone down
        // Rotations
        // X rotates round the barrel
        // Y rotates round the trigger as if a finger was there
        // Z rotates to the sides
        [ContentSerializer]
        public Matrix mtxTransform;  

        public AttachmentPoint()
        {
        }

        public AttachmentPoint(int boneIndex, float X, float Y, float Z)
        {
            idBone = boneIndex;
            mtxTransform = Matrix.Identity;
            mtxTransform.Translation = new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Rotation in degrees
        /// </summary>
        public AttachmentPoint(int boneIndex, float X, float Y, float Z, 
            float degreesAboutX, float degreesAboutY, float degreesAboutZ)
        {
            float thing = MathHelper.ToRadians(1);
            idBone = boneIndex;
            mtxTransform = Matrix.Identity * Matrix.CreateRotationX(MathHelper.ToRadians(degreesAboutX)) *
                Matrix.CreateRotationY(MathHelper.ToRadians(degreesAboutY)) * 
                Matrix.CreateRotationZ(MathHelper.ToRadians(degreesAboutZ));
            mtxTransform.Translation = new Vector3(X, Y, Z);
        }
    }
}
