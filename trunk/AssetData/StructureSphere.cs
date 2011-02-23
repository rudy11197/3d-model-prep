#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Used for collision and intersect with projectiles
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
#endregion

namespace AssetData
{
    // Detailed bounding spheres for collision with projectiles
    // and moving characters.
    public class StructureSphere
    {
        // Bounding sphere usually in world space
        [ContentSerializer]
        public BoundingSphere Sphere;
        // The position of the sphere in object space
        [ContentSerializer]
        public Vector3 CentreInObjectSpace = Vector3.Zero;
        // The height of the highest triangle point in world space
        // This can only be calculated after the model has been loaded
        // put in its final position and all the triangles exposed
        // in to world space.
        [ContentSerializer]
        public float Highest = 0.0f;
        // List of the indices to triangles, other StructureSpheres or any object list
        [ContentSerializer]
        public List<int> IDs; 

        public StructureSphere()
        {
        }

        // Create in object space and update to world space afterwards
        public StructureSphere(Vector3 centre, float radius)
        {
            CentreInObjectSpace = centre;
            Sphere = new BoundingSphere(centre, radius);
            if (IDs == null)
            {
                IDs = new List<int>();
            }
        }

        public StructureSphere(Vector3 centre, float radius, List<int> indices)
            : this(centre, radius)
        {
            IDs = indices;
        }

        public StructureSphere(Vector3 centre, float radius, List<int> indices, float height)
            : this(centre, radius, indices)
        {
            Highest = height;
        }

        // Use this whenever the model moves
        public void MoveBounds(Matrix modelWorldPosition)
        {
            // Move to world space
            Sphere.Center = Vector3.Transform(CentreInObjectSpace, modelWorldPosition);
        }

        public void MoveToObjectSpace()
        {
            Sphere.Center = CentreInObjectSpace;
        }

        // Used to see if this sphere is at floor level
        public bool IsAtFloorLevel(float floorLevel)
        {
            return (floorLevel < Sphere.Center.Y + Sphere.Radius &&
                    floorLevel > Sphere.Center.Y - Sphere.Radius);
        }

        // Used to find the lowest point of the sphere
        public float LowestHeight()
        {
            return Sphere.Center.Y - Sphere.Radius;
        }

    }
}
