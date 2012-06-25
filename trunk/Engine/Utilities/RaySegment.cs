#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using AssetData;
#endregion

namespace Engine
{
    /// <summary>
    /// Create a line with a start and end point.
    /// The direction is always from the first to the last point.
    /// </summary>
    public struct RaySegment : IEquatable<RaySegment>
    {
        private Vector3 from;
        private Vector3 to;
        private float length;
        private float lengthSquared;
        private Vector3 direction;

        public RaySegment(Vector3 fromFirstPoint, Vector3 toLastPoint)
        {
            from = fromFirstPoint;
            to = toLastPoint;
            direction = Vector3.Zero;
            length = 0;
            lengthSquared = 0;
            CalculateProperties();
        }

        /// <summary>
        /// Create a line of the length specified.
        /// The end point of the line will be calculated from the length.
        /// The direction will be calculated using the point on the line.
        /// </summary>
        public RaySegment(Vector3 fromPoint, Vector3 anyPointOnTheLine, float lengthToMakeTheLine)
        {
            from = fromPoint;
            direction = Vector3.Subtract(anyPointOnTheLine, from);
            length = direction.Length();
            if (Math.Abs(length) < float.Epsilon)
            {
                direction = Vector3.Zero;
            }
            else
            {
                direction = Vector3.Divide(direction, length);
            }
            length = lengthToMakeTheLine;
            lengthSquared = length * length;
            to = Vector3.Add(from, Vector3.Multiply(direction, length));
        }

        /// <summary>
        /// Create a line that overlaps the end point by the extra length specified.
        /// The direction will be calculated using the points on the line.
        /// The end point of the line will be calculated by adding the overlap amount
        /// to the point that we want to overlap near the end of the line.
        /// </summary>
        public RaySegment(float overlap, Vector3 fromPoint, Vector3 nearEndPoint)
        {
            from = fromPoint;
            direction = Vector3.Subtract(nearEndPoint, from);
            length = direction.Length();
            if (Math.Abs(length) < float.Epsilon)
            {
                direction = Vector3.Zero;
            }
            else
            {
                direction = Vector3.Divide(direction, length);
            }
            length += overlap;
            lengthSquared = length * length;
            to = Vector3.Add(from, Vector3.Multiply(direction, length));
        }
        /// <summary>
        /// Direction, length and length squared.
        /// </summary>
        private void CalculateProperties()
        {
            direction = Vector3.Subtract(to, from);
            length = direction.Length();
            lengthSquared = length * length;
            if (Math.Abs(length) < float.Epsilon)
            {
                direction = Vector3.Zero;
            }
            else
            {
                direction = Vector3.Divide(direction, length);
            }
        }

        /////////////////////////////////////////////////////////////////////
        //
        #region IEquatable implementation

        public bool Equals(RaySegment other)
        {
            return (from == other.from && to == other.to);
        }

        public override bool Equals(Object obj)
        {
            if (obj != null && obj is RaySegment)
            {
                RaySegment other = (RaySegment)obj;
                return (from == other.from && to == other.to);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return from.GetHashCode() ^ to.GetHashCode();
        }

        public static bool operator ==(RaySegment a, RaySegment b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(RaySegment a, RaySegment b)
        {
            return !Equals(a, b);
        }

        public override string ToString()
        {
            return "{From:" + from.ToString() +
                   " To:" + to.ToString() +
                   " Length:" + length.ToString() + "}";
        }

        #endregion
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //
        #region Properties
        //
        /// <summary>
        /// First point.
        /// </summary>
        public Vector3 From
        {
            get { return from; }
            set
            {
                from = value;
                CalculateProperties();
            }
        }
        /// <summary>
        /// Last point.
        /// </summary>
        public Vector3 To
        {
            get { return to; }
            set
            {
                to = value;
                CalculateProperties();
            }
        }
        /// <summary>
        /// Reposition the line.
        /// Quicker than setting the individual properties because it only recalculates
        /// the other properties once.
        /// </summary>
        public void Change(Vector3 fromPoint, Vector3 toPoint)
        {
            from = fromPoint;
            to = toPoint;
            CalculateProperties();
        }
        /// <summary>
        /// Distance between the ends of the line.
        /// Setting the length recalculates the end point of the line.
        /// </summary>
        public float Length
        {
            get { return length; }
            set
            {
                length = value;
                lengthSquared = length * length;
                to = Vector3.Add(from, Vector3.Multiply(direction, length));
            }
        }
        /// <summary>
        /// The square of the distance between the ends of the line.
        /// </summary>
        public float LengthSquared
        {
            get { return lengthSquared; }
        }
        /// <summary>
        /// The normalised vector pointing away from the first point along 
        /// the line towards the last point.
        /// </summary>
        public Vector3 Direction
        {
            get { return direction; }
        }
        /// <summary>
        /// Returns a ray with no end positioned at the first point of the line.
        /// </summary>
        public Ray Ray
        {
            get { return new Ray(from, direction); }
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////
        //
        #region Intersects
        //
        /// <summary>
        /// Returns the distance from the start of the line to the intersection with 
        /// the triangle, null if no intersect.
        /// Failuse case: Lines that start or end touching the triangle face
        /// will not intersect.
        /// </summary>
        public static void Intersects(ref RaySegment line, ref TriangleFace tri, out float? distance)
        {
            Intersects(ref line, ref tri.V0, ref tri.V1, ref tri.V2, out distance);
        }
        /// <summary>
        /// Returns the distance from the start of the line to the intersection with 
        /// the triangle face formed by v0,v1 and v2.
        /// Returns null if there is no intersection.
        /// Failuse case: Lines that start or end touching the triangle face
        /// will not intersect.
        /// </summary>
        public static void Intersects(ref RaySegment line, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2, out float? distance)
        {
            Vector3 direction = line.Direction;
            Vector3 from = line.From;
            // Set the Distance to indicate no intersect
            distance = null;
            // Compute vectors along two edges of the triangle.
            Vector3 edge1, edge2;

            Vector3.Subtract(ref v2, ref v1, out edge1);
            Vector3.Subtract(ref v0, ref v1, out edge2);

            // Compute the determinant.
            Vector3 directionCrossEdge2;
            Vector3.Cross(ref direction, ref edge2, out directionCrossEdge2);

            float determinant;
            Vector3.Dot(ref edge1, ref directionCrossEdge2, out determinant);

            // If the ray is parallel to the triangle plane, there is no collision.
            if (determinant > -float.Epsilon && determinant < float.Epsilon)
            {
                return;
            }

            float inverseDeterminant = 1.0f / determinant;

            // Calculate the U parameter of the intersection point.
            Vector3 distanceVector;
            Vector3.Subtract(ref from, ref v1, out distanceVector);

            float triangleU;
            Vector3.Dot(ref distanceVector, ref directionCrossEdge2, out triangleU);
            triangleU *= inverseDeterminant;

            // Make sure it is inside the triangle.
            if (triangleU < 0 || triangleU > 1)
            {
                return;
            }

            // Calculate the V parameter of the intersection point.
            Vector3 distanceCrossEdge1;
            Vector3.Cross(ref distanceVector, ref edge1, out distanceCrossEdge1);

            float triangleV;
            Vector3.Dot(ref direction, ref distanceCrossEdge1, out triangleV);
            triangleV *= inverseDeterminant;

            // Make sure it is inside the triangle.
            if (triangleV < 0 || triangleU + triangleV > 1)
            {
                return;
            }

            // == By here the ray must be inside the triangle

            // Compute the distance along the ray to the triangle.
            float length = 0;
            Vector3.Dot(ref edge2, ref distanceCrossEdge1, out length);
            distance = length * inverseDeterminant;

            // The distance test is the only difference between the ray and line intesects.
            if (distance > line.Length || distance < -float.Epsilon)
            {
                distance = null;
            }
        }
        /// <summary>
        /// Returns the true if the line intersects with 
        /// the triangle formed by v0,v1 and v2.
        /// </summary>
        public static bool Intersects(ref RaySegment line, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2)
        {
            float? distance = null;
            Intersects(ref line, ref v0, ref v1, ref v2, out distance);
            return (distance != null);
        }
        /// <summary>
        /// Returns the distance from the start of the line to the intersection with 
        /// the Axis Aligned Bounding Box (AABB), null if no intersect.
        /// </summary>
        public static void Intersects(ref RaySegment line, ref BoundingBox box, out float? distance)
        {
            distance = box.Intersects(line.Ray);
            if (distance == null || distance < 0 || distance > line.Length)
            {
                distance = null;
                return;
            }
            return;
        }
        /// <summary>
        /// Returns the true if the line intersects with 
        /// the Axis Aligned Bounding Box (AABB).
        /// </summary>
        public static bool Intersects(ref RaySegment line, ref BoundingBox box)
        {
            float? distance = null;
            Intersects(ref line, ref box, out distance);
            return (distance != null);
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////

    }
}
