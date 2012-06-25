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
    /// Store three points to form a triangle with methods for testing collision 
    /// with rays and some bounding shapes. 
    /// </summary>
    public struct TriangleFace : IEquatable<TriangleFace>
    {
        /// <summary>
        /// First corner. 
        /// </summary>
        public Vector3 V0;
        /// <summary>
        /// Second corner. 
        /// </summary>
        public Vector3 V1;
        /// <summary>
        /// Third corner. 
        /// </summary>
        public Vector3 V2;

        /// <summary>
        /// Construct a triangle.
        /// Normals face outwards for a clockwise winding order of corners v0, v1 and v2  
        /// viewed from the outside.
        /// </summary>
        public TriangleFace(Vector3 a, Vector3 b, Vector3 c)
        {
            V0 = a;
            V1 = b;
            V2 = c;
        }


        /////////////////////////////////////////////////////////////////////
        //
        #region IEquatable implementation

        public bool Equals(TriangleFace other)
        {
            return (V0 == other.V0 && V1 == other.V1 && V2 == other.V2);
        }

        public override bool Equals(Object obj)
        {
            if (obj != null && obj is TriangleFace)
            {
                TriangleFace other = (TriangleFace)obj;
                return (V0 == other.V0 && V1 == other.V1 && V2 == other.V2);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return V0.GetHashCode() ^ V1.GetHashCode() ^ V2.GetHashCode();
        }

        public static bool operator ==(TriangleFace a, TriangleFace b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(TriangleFace a, TriangleFace b)
        {
            return !Equals(a, b);
        }

        public override string ToString()
        {
            return "{Corner 0:" + V0.ToString() +
                   " Corner 1:" + V1.ToString() +
                   " Corner 2:" + V2.ToString() + "}";
        }

        #endregion
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //
        #region Properties and Methods
        //
        /// <summary>
        /// Return the line along the edge starting from V0 going to V1.
        /// </summary>
        public RaySegment Edge0
        {
            get
            {
                return new RaySegment(V0, V1);
            }
        }
        /// <summary>
        /// Return the line along the edge starting from V1 going to V2.
        /// </summary>
        public RaySegment Edge1
        {
            get
            {
                return new RaySegment(V1, V2);
            }
        }
        /// <summary>
        /// Return the line along the edge starting from V2 going to V0.
        /// </summary>
        public RaySegment Edge2
        {
            get
            {
                return new RaySegment(V2, V0);
            }
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //
        #region Helper Methods
        //
        /// <summary>
        /// Change all the vertices of this triangle. 
        /// </summary>
        public void Resize(Vector3 a, Vector3 b, Vector3 c)
        {
            V0 = a;
            V1 = b;
            V2 = c;
        }
        /// <summary>
        /// Return the position of the corner nearest to the point specified.  
        /// </summary>
        public Vector3 NearestCorner(Vector3 point)
        {
            float closestSq = Vector3.DistanceSquared(V0, point);
            Vector3 nearest = V0;
            float distSq = Vector3.DistanceSquared(V1, point);
            if (distSq < closestSq)
            {
                closestSq = distSq;
                nearest = V1;
            }
            distSq = Vector3.DistanceSquared(V2, point);
            if (distSq < closestSq)
            {
                closestSq = distSq;
                nearest = V2;
            }
            return nearest;
        }
        /// <summary>
        /// Return the mid point between two other points. 
        /// </summary>
        public Vector3 MidPoint(ref Vector3 startPoint, ref Vector3 endPoint)
        {
            //float midX = startPoint.X + ((endPoint.X - startPoint.X) * 0.5f);
            //float midY = startPoint.Y + ((endPoint.Y - startPoint.Y) * 0.5f);
            //float midZ = startPoint.Z + ((endPoint.Z - startPoint.Z) * 0.5f);
            //return new Vector3(midX, midY, midZ);
            return new Vector3(
                (startPoint.X + endPoint.X) * 0.5f,
                (startPoint.Y + endPoint.Y) * 0.5f,
                (startPoint.Z + endPoint.Z) * 0.5f);
        }
        /// <summary>
        /// Return a point somewhere on the face of the triangle near the middle.
        /// This is faster than the Centroid calculation but is not a recognised
        /// centre.  Suitable if all that is needed is any point on the face.
        /// </summary>
        public Vector3 MidPoint()
        {
            Vector3 midEdge = MidPoint(ref V0, ref V1);
            return MidPoint(ref V2, ref midEdge);
        }
        // http://www.jimloy.com/geometry/centers.htm
        /// <summary>
        /// Return one of the possible centre points of the triangle. 
        /// </summary>
        public Vector3 Centroid()
        {
            return Vector3.Divide(Vector3.Add(V0, Vector3.Add(V1, V2)), 3f);
        }
        /// <summary>
        /// Returns the highest Y value of any of the corner points.  
        /// </summary>
        public float HighestHeight()
        {
            return Math.Max(V2.Y, Math.Max(V0.Y, V1.Y));
        }
        /// <summary>
        /// Returns the lowest Y value of any of the corner points.  
        /// </summary>
        public float LowestHeight()
        {
            return Math.Min(V2.Y, Math.Min(V0.Y, V1.Y));
        }
        /// <summary>
        /// Return the distance from the point to the nearest edge. 
        /// </summary>
        public float LengthToNearestEdge(ref Vector3 point)
        {
            float minDist = MoreMaths.ShortestDistanceToLine(ref V2, ref V0, ref point);
            float curDist = MoreMaths.ShortestDistanceToLine(ref V0, ref V1, ref point);
            if (curDist < minDist)
            {
                minDist = curDist;
            }
            curDist = MoreMaths.ShortestDistanceToLine(ref V1, ref V2, ref point);
            if (curDist < minDist)
            {
                minDist = curDist;
            }
            return minDist;
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //
        #region Array or Index Based
        //
        /// <summary>
        /// Returns a new array containing the positions of the three corners of the triangle. 
        /// </summary>
        public Vector3[] GetCorners()
        {
            Vector3[] vertex = new Vector3[3];
            vertex[0] = V0;
            vertex[1] = V1;
            vertex[2] = V2;
            return vertex;
        }
        /// <summary>
        /// Return the position of a corner based on the index of that corner. 
        /// </summary>
        public Vector3 GetCorner(int index)
        {
            if (index == 0)
                return V0;

            if (index == 1)
                return V1;

            return V2;
        }
        /// <summary>
        /// Return the index of the corner not specified
        /// </summary>
        public int GetOtherIndex(int a, int b)
        {
            if (a + b == 1)
            {
                return 2;
            }
            else if (a + b == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Return the line along the edge starting from the corner specified going 
        /// to the next corner. V0-V1, V1-V2 or V2-V0.
        /// </summary>
        public RaySegment Edge(int from)
        {
            if (from == 0)
            {
                return new RaySegment(V0, V1);
            }
            if (from == 1)
            {
                return new RaySegment(V1, V2);
            }
            return new RaySegment(V2, V0);
        }
        /// <summary>
        /// Return the mid point of an edge given the indices of the start and end corners. 
        /// </summary>
        public Vector3 EdgeMidPoint(int Start, int End)
        {
            Vector3 vStart = GetCorner(Start);
            Vector3 vEnd = GetCorner(End);
            float midX = vStart.X + ((vEnd.X - vStart.X) * 0.5f);
            float midY = vStart.Y + ((vEnd.Y - vStart.Y) * 0.5f);
            float midZ = vStart.Z + ((vEnd.Z - vStart.Z) * 0.5f);
            return new Vector3(midX, midY, midZ);
        }
        /// <summary>
        /// Return a new triangle based on two of the vertices of this triangle
        /// plus some other point.
        /// </summary>
        /// <param name="a">Index of one existing corner</param>
        /// <param name="b">Index of another existing corner</param>
        /// <param name="pointC">The new corner</param>
        public TriangleFace SplitTriangle(int a, int b, Vector3 pointC)
        {
            return new TriangleFace(GetCorner(a), GetCorner(b), pointC);
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////
        
        /////////////////////////////////////////////////////////////////////
        //
        #region Normals and Face Alignment
        //
        /// <summary>
        /// A unit length vector at right angles to the plane of the triangle.
        /// Faces outwards for a clockwise winding order of corners v0, v1 and v2  
        /// viewed from the outside.
        /// </summary>
        public void Normal(out Vector3 normal)
        {
            normal = Normal();
        }
        /// <summary>
        /// A unit length vector at right angles to the plane of the triangle.
        /// Faces outwards for a clockwise winding order of corners A, B and C 
        /// viewed from the outside.
        /// </summary>
        public Vector3 Normal()
        {
            Vector3 side1 = Vector3.Subtract(V1, V0);
            Vector3 side2 = Vector3.Subtract(V2, V0);
            return MoreMaths.SafeNormalize(Vector3.Cross(side2, side1));
        }
        /// <summary>
        /// Get a normal that faces towards the point specified (faces out)
        /// </summary>
        public void NormalFacing(ref Vector3 point, out Vector3 normal)
        {
            Normal(out normal);
            // The direction pointing towards the triangle
            Vector3 direction =  Vector3.Subtract(V0, point);
            // Roughly facing the same way
            if (Vector3.Dot(normal, direction) > 0)
            {
                // Same direction therefore invert the normal to face away from the direction
                // to face the point
                Vector3.Multiply(ref normal, -1.0f, out normal);
                // Is this the same as Vector3.Negate(ref normal, out normal)?
            }
        }
        /// <summary>
        /// Get a normal that faces away from the point specified (faces in)
        /// </summary>
        public void InverseNormal(ref Vector3 point, out Vector3 inverseNormal)
        {
            Normal(out inverseNormal);
            // The direction from any corner of the triangle to the point
            Vector3 inverseDirection = point - V0; ;
            // Roughly facing the same way
            if (Vector3.Dot(inverseNormal, inverseDirection) > 0)
            {
                // Same direction therefore invert the normal to face away from the direction
                // to face the point
                Vector3.Multiply(ref inverseNormal, -1.0f, out inverseNormal);
                // same as? Vector3.Negate(ref inverseNormal, out inverseNormal);
            }
        }
        /// <summary>
        /// Short line from the centre of the triangle pointing in the 
        /// direction of the normal of the face.  Usually used for visualising 
        /// the normal.
        /// </summary>
        public void StubNormal(float length, ref Vector3 resultLineFrom, ref Vector3 resultLineTo)
        {
            Normal(out resultLineTo);
            resultLineFrom = Centroid();
            resultLineTo = Vector3.Add(resultLineFrom, Vector3.Multiply(resultLineTo, length));
        }
        /// <summary>
        /// Creates Garbage.
        /// Returns a new array containing two points.  The first is at the centre 
        /// of the triangle the second pointing in the direction of the 
        /// normal of the face.  Usually used for visualising the normal.
        /// </summary>
        public Vector3[] StubNormal(float length)
        {
            Vector3 from = Vector3.Zero;
            Vector3 to = Vector3.Zero;
            StubNormal(length, ref from, ref to);
            return new Vector3[2] { from, to };
        }
        /// <summary>
        /// Returns true if the normal of the triangle is facing in the 
        /// same direction as the vector supplied.
        /// The triangle should have a clockwise winding order. 
        /// </summary>
        public bool IsFacingSameWayAs(Vector3 direction)
        {
            return (Vector3.Dot(Normal(), direction) > 0);
        }
        /// <summary>
        /// Return a matrix of the alignment and location to attach a decal. 
        /// The matrix can be applied to a decal that has been created with a normal of Vector3.Backward. 
        /// zBias is used to avoid z-fighting and sort the decals in to depth order for transparancy. 
        /// The from position is used to move the decal in the correct direction away from the 
        /// surface towards the viewer while avoiding z-fighting and rotating the decal. 
        /// </summary>
        public Matrix DecalAlignment(float zBias, ref Vector3 from, ref Vector3 atPoint)
        {
            Vector3 normal = Vector3.Zero;
            NormalFacing(ref from, out normal);
            // The Xbox flashes if the distance is too close 0.01f works OK
            Vector3 decalPoint = Vector3.Add(atPoint, Vector3.Multiply(normal, zBias));
            // Calculate the rotation between the normal of the un-rotated decal (which
            // is created facing Vector3.Backward) and where we want the decal to face.
            return Matrix.CreateFromQuaternion(
                MoreMaths.RotationBetween(Vector3.Backward, normal)) *
                Matrix.CreateTranslation(decalPoint);
        }
        /// <summary>
        /// Return a matrix of the alignment and location to attach a decal. 
        /// The matrix can be applied to a decal that has been created with a normal of Vector3.Backward. 
        /// zBias is used to avoid z-fighting and sort the decals in to depth order for transparancy. 
        /// The winding order of the corners must be clockwise. 
        /// </summary>
        public Matrix DecalAlignment(float zBias, ref Vector3 atPoint)
        {
            Vector3 normal = Vector3.Zero;
            Normal(out normal);
            // The Xbox flashes if the distance is too close 0.01f works OK
            Vector3 decalPoint = Vector3.Add(atPoint, Vector3.Multiply(normal, zBias));
            // Calculate the rotation between the normal of the un-rotated decal (which
            // is created facing Vector3.Backward) and where we want the decal to face.
            return Matrix.CreateFromQuaternion(
                MoreMaths.RotationBetween(Vector3.Backward, normal)) *
                Matrix.CreateTranslation(decalPoint);
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        //
        #region Intersects and Bounds
        //
        /// <summary>
        /// Returns an axis aligned bounding box that just fits round the triangle. 
        /// </summary>
        public BoundingBox BoundingBox()
        {
            Vector3 min = V0;
            Vector3 max = V0;
            Vector3.Min(ref min, ref V1, out min);
            Vector3.Max(ref max, ref V1, out max);
            Vector3.Min(ref min, ref V2, out min);
            Vector3.Max(ref max, ref V2, out max);
            return new BoundingBox(min, max);
        }
        /// <summary>
        /// How many of the corners of the triangle are inside the bounding box. 
        /// </summary>
        public int PointsInside(BoundingBox box)
        {
            int count = 0;
            if (box.Contains(V0) != ContainmentType.Disjoint)
            {
                count++;
            }
            if (box.Contains(V1) != ContainmentType.Disjoint)
            {
                count++;
            }
            if (box.Contains(V2) != ContainmentType.Disjoint)
            {
                count++;
            }
            return count;
        }
        /// <summary>
        /// Return true if any edge of the bounding box is larger than the size specified. 
        /// </summary>
        public bool IsLargerThan(float MaxBoundSize)
        {
            BoundingBox bounds = BoundingBox();
            if ((bounds.Max.X - bounds.Min.X) > MaxBoundSize)
            {
                return true;
            }
            if ((bounds.Max.Y - bounds.Min.Y) > MaxBoundSize)
            {
                return true;
            }
            if ((bounds.Max.Z - bounds.Min.Z) > MaxBoundSize)
            {
                return true;
            }
            return false;
        }
        //
        // Method to check whether a ray intersects a triangle. 
        // This uses the algorithm developed by Tomas Moller and Ben Trumbore, which 
        // was published in the Journal of Graphics Tools, volume 2, "Fast, Minimum 
        // Storage Ray-Triangle Intersection".
        // 
        // From the Creators Club TrianglePicking sample RayIntersectsTriangle(...)
        // See: http://creators.xna.com/en-GB/sample/pickingtriangle
        //
        /// <summary>
        /// Returns the distance from the origin of the ray to the intersection with 
        /// the triangle, null if no intersect and negative if behind.
        /// Failure Case: It is possible for a ray to pass between two triangles that 
        /// are touching each other.
        /// </summary>
        public void Intersects(ref Ray ray, out float? distance)
        {
            // Set the Distance to indicate no intersect
            distance = null;
            // Compute vectors along two edges of the triangle.
            Vector3 edge1, edge2;

            Vector3.Subtract(ref V2, ref V1, out edge1);
            Vector3.Subtract(ref V0, ref V1, out edge2);

            // Compute the determinant.
            Vector3 directionCrossEdge2;
            Vector3.Cross(ref ray.Direction, ref edge2, out directionCrossEdge2);

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
            Vector3.Subtract(ref ray.Position, ref V1, out distanceVector);

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
            Vector3.Dot(ref ray.Direction, ref distanceCrossEdge1, out triangleV);
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
        }
        //
        /// <summary>
        /// Returns the distance from the start of the line to the intersection with 
        /// the triangle, null if no intersect.
        /// Failuse case: Lines that start or end touching the triangle face
        /// will not intersect.
        /// </summary>
        public void Intersects(ref RaySegment line, out float? distance)
        {
            Vector3 direction = line.Direction;
            Vector3 from = line.From;
            // Set the Distance to indicate no intersect
            distance = null;
            // Compute vectors along two edges of the triangle.
            Vector3 edge1, edge2;

            Vector3.Subtract(ref V2, ref V1, out edge1);
            Vector3.Subtract(ref V0, ref V1, out edge2);

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
            Vector3.Subtract(ref from, ref V1, out distanceVector);

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

        // Based on existing code available on the Internet
        // See: http://realtimerendering.com/intersections.html
        // Converted to C# for XNA
        /// <summary>
        /// This is an expensive test. 
        /// Returns true if any part of the triangle overlaps or is inside the sphere. 
        /// </summary>
        public void Intersects(ref BoundingSphere sphere, out bool result)
        {
            result = false;
            // First check if any corner point is inside the sphere
            // This is necessary because the other tests can easily miss
            // small triangles that are fully inside the sphere.
            if (sphere.Contains(V0) != ContainmentType.Disjoint ||
                sphere.Contains(V1) != ContainmentType.Disjoint ||
                sphere.Contains(V2) != ContainmentType.Disjoint)
            {
                // A point is inside the sphere
                result = true;
                return;
            }
            // Test the edges of the triangle using a ray
            // If any hit then check the distance to the hit is less than the length of the side
            // The distance from a point of a small triangle inside the sphere coule be longer
            // than the edge of the small triangle, hence the test for points inside above.
            Vector3 side = V1 - V0;
            // Important:  The direction of the ray MUST
            // be normalised otherwise the resulting length 
            // of any intersect is wrong!
            Ray ray = new Ray(V0, Vector3.Normalize(side));
            float distSq = 0;
            float? length = null;
            sphere.Intersects(ref ray, out length);
            if (length != null)
            {
                distSq = (float)length * (float)length;
                if (length > 0 && distSq < side.LengthSquared())
                {
                    // Hit edge
                    result = true;
                    return;
                }
            }
            // Stay at A and change the direction to C
            side = V2 - V0;
            ray.Direction = Vector3.Normalize(side);
            length = null;
            sphere.Intersects(ref ray, out length);
            if (length != null)
            {
                distSq = (float)length * (float)length;
                if (length > 0 && distSq < side.LengthSquared())
                {
                    // Hit edge
                    result = true;
                    return;
                }
            }
            // Change to corner B and edge to C
            side = V2 - V1;
            ray.Position = V1;
            ray.Direction = Vector3.Normalize(side);
            length = null;
            sphere.Intersects(ref ray, out length);
            if (length != null)
            {
                distSq = (float)length * (float)length;
                if (length > 0 && distSq < side.LengthSquared())
                {
                    // Hit edge
                    result = true;
                    return;
                }
            }
            // If we get this far we are not touching the edges of the triangle
            
            // Calculate the InverseNormal of the triangle from the centre of the sphere
            // Do a ray intersection from the centre of the sphere to the triangle.
            // If the triangle is too small the ray could miss a small triangle inside
            // the sphere hence why the points were tested above.
            ray.Position = sphere.Center;
            // This will always create a vector facing towards the triangle from the 
            // ray starting point.
            InverseNormal(ref ray.Position, out side);
            ray.Direction = side;
            Intersects(ref ray, out length);
            if (length != null && length > 0 && length < sphere.Radius)
            {
                // Hit the surface of the triangle
                result = true;
                return;
            }
            // Only if we get this far have we missed the triangle
            result = false;
        }
        // My own version
        /// <summary>
        /// Returns true if the given Axis Aligned Bounding Box (AABB) intersects 
        /// the triangle face formed by v0,v1 and v2.
        /// This method is intended to be robust and capture all cases.
        /// It is unlikely to be as efficient as the other methods available.
        /// </summary>
        public static bool Intersects(ref BoundingBox box, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2)
        {
            return Contains(ref box, ref v0, ref v1, ref v2) != ContainmentType.Disjoint;
        }
        /// <summary>
        /// Returns true if the given Axis Aligned Bounding Box (AABB) intersects 
        /// the triangle.
        /// This method is intended to be robust and capture all cases.
        /// It is unlikely to be as efficient as the other methods available.
        /// </summary>
        public static bool Intersects(ref BoundingBox box, ref TriangleFace tri)
        {
            return Contains(ref box, ref tri.V0, ref tri.V1, ref tri.V2) != ContainmentType.Disjoint;
        }
        /// <summary>
        /// Tests whether the given Axis Aligned Bounding Box (AABB) contains, intersects, or is disjoint from
        /// the triangle face formed by v0,v1 and v2.
        /// This method is intended to be robust and capture all cases.
        /// It is unlikely to be as efficient as the other methods available.
        /// </summary>
        public static ContainmentType Contains(ref BoundingBox box, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2)
        {
            // == Quick test for anything that must be inside
            // Any point inside
            if (box.Contains(v0) != ContainmentType.Disjoint ||
                box.Contains(v1) != ContainmentType.Disjoint ||
                box.Contains(v2) != ContainmentType.Disjoint)
            {
                return ContainmentType.Contains;
            }
            // == Reject anything that cannot possibly intersect
            // All points fully outside in any direction
            if (v0.X > box.Max.X && v1.X > box.Max.X && v2.X > box.Max.X)
            {
                return ContainmentType.Disjoint;
            }
            if (v0.Y > box.Max.Y && v1.Y > box.Max.Y && v2.Y > box.Max.Y)
            {
                return ContainmentType.Disjoint;
            }
            if (v0.Z > box.Max.Z && v1.Z > box.Max.Z && v2.Z > box.Max.Z)
            {
                return ContainmentType.Disjoint;
            }
            if (v0.X < box.Min.X && v1.X < box.Min.X && v2.X < box.Min.X)
            {
                return ContainmentType.Disjoint;
            }
            if (v0.Y < box.Min.Y && v1.Y < box.Min.Y && v2.Y < box.Min.Y)
            {
                return ContainmentType.Disjoint;
            }
            if (v0.Z < box.Min.Z && v1.Z < box.Min.Z && v2.Z < box.Min.Z)
            {
                return ContainmentType.Disjoint;
            }
            // Slower tests
            // == Any triangle edge intersects
            RaySegment line = new RaySegment(v0, v1);
            if (RaySegment.Intersects(ref line, ref box))
            {
                return ContainmentType.Intersects;
            }
            line.Change(v1, v2);
            if (RaySegment.Intersects(ref line, ref box))
            {
                return ContainmentType.Intersects;
            }
            line.Change(v2, v0);
            if (RaySegment.Intersects(ref line, ref box))
            {
                return ContainmentType.Intersects;
            }
            // == Any box edge intersects
            Vector3 lowFrom = box.Min;
            Vector3 lowTo = box.Min;
            Vector3 upFrom = box.Max;
            Vector3 upTo = box.Max;
            // Min X edge and one upright
            lowTo.X = box.Max.X;
            line.Change(lowFrom, lowTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upFrom.X = lowFrom.X;
            upFrom.Z = lowFrom.Z;
            line.Change(lowFrom, upFrom);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upTo.X = lowTo.X;
            upTo.Z = lowTo.Z;
            line.Change(upFrom, upTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            // Max Z edge and one upright
            lowFrom.X = box.Max.X;
            lowFrom.Z = box.Max.Z;
            line.Change(lowFrom, lowTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upFrom.X = lowTo.X;
            upFrom.Z = lowTo.Z;
            line.Change(lowTo, upFrom);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upTo.X = lowFrom.X;
            upTo.Z = lowFrom.Z;
            line.Change(upFrom, upTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            // Max X edge and one upright
            lowTo.X = box.Min.X;
            lowTo.Z = box.Max.Z;
            line.Change(lowFrom, lowTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upFrom.X = lowFrom.X;
            upFrom.Z = lowFrom.Z;
            line.Change(lowFrom, upFrom);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upTo.X = lowTo.X;
            upTo.Z = lowTo.Z;
            line.Change(upFrom, upTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            // Min Z edge and one upright
            lowFrom = box.Min;
            line.Change(lowFrom, lowTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upFrom.X = lowTo.X;
            upFrom.Z = lowTo.Z;
            line.Change(lowTo, upFrom);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            upTo.X = lowFrom.X;
            upTo.Z = lowFrom.Z;
            line.Change(upFrom, upTo);
            if (RaySegment.Intersects(ref line, ref v0, ref v1, ref v2))
            {
                return ContainmentType.Intersects;
            }
            // == Must be disconnected if we get here
            return ContainmentType.Disjoint;
        }
        //
        // From the Microsoft AppHub Education Catalogue collision sample.
        // See: http://create.msdn.com/en-US/education/catalog/sample/collision
        // Not robust!  Can fail incorrectly in some cases.  
        // From what I have read this is whenever the cross product is zero!
        // From testing:
        //      Some exactly aligned vertical and horizontal triangles fail to block and 
        //      all large vertical and horizontal triangles always fail.
        //      Large triangles are any where the corners and edges are all fully outside
        //      the bounding box.
        /// <summary>
        /// Not robust!
        /// Returns true if the given box intersects the triangle (v0,v1,v2).
        /// </summary>
        public static bool IntersectsFast(ref BoundingBox box, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2)
        {
            Vector3 boxCenter = (box.Max + box.Min) * 0.5f;
            Vector3 boxHalfExtent = (box.Max - box.Min) * 0.5f;

            // Transform the triangle into the local space with the box center at the origin
            TriangleFace localTri = new TriangleFace();
            Vector3.Subtract(ref v0, ref boxCenter, out localTri.V0);
            Vector3.Subtract(ref v1, ref boxCenter, out localTri.V1);
            Vector3.Subtract(ref v2, ref boxCenter, out localTri.V2);

            return OriginBoxContainsFast(ref boxHalfExtent, ref localTri) != ContainmentType.Disjoint;
        }
        /// <summary>
        /// Not robust!
        /// Returns true if the given box intersects the triangle (v0,v1,v2).
        /// </summary>
        public static bool IntersectsFast(ref BoundingBox box, ref TriangleFace triangle)
        {
            return IntersectsFast(ref box, ref triangle.V0, ref triangle.V1, ref triangle.V2);
        }
        /// <summary>
        /// Not robust!
        /// Tests whether the given box contains, intersects, or is disjoint from the triangle (v0,v1,v2).
        /// </summary>
        public static ContainmentType ContainsFast(ref BoundingBox box, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2)
        {
            Vector3 boxCenter = (box.Max + box.Min) * 0.5f;
            Vector3 boxHalfExtent = (box.Max - box.Min) * 0.5f;

            // Transform the triangle into the local space with the box center at the origin
            TriangleFace localTri;
            Vector3.Subtract(ref v0, ref boxCenter, out localTri.V0);
            Vector3.Subtract(ref v1, ref boxCenter, out localTri.V1);
            Vector3.Subtract(ref v2, ref boxCenter, out localTri.V2);

            return OriginBoxContainsFast(ref boxHalfExtent, ref localTri);
        }
        /// <summary>
        /// Not robust!
        /// Tests whether the given box contains, intersects, or is disjoint from the given triangle.
        /// </summary>
        public static ContainmentType ContainsFast(ref BoundingBox box, ref TriangleFace triangle)
        {
            return ContainsFast(ref box, ref triangle.V0, ref triangle.V1, ref triangle.V2);
        }
        //
        // From the Microsoft AppHub Education Catalogue collision sample.
        // See: http://create.msdn.com/en-US/education/catalog/sample/collision
        //
        /// <summary>
        /// Not robust!
        /// Check if an origin-centered, axis-aligned box with the given half extents contains,
        /// intersects, or is disjoint from the given triangle. This is used for the box and
        /// frustum vs. triangle tests.
        /// </summary>
        public static ContainmentType OriginBoxContainsFast(ref Vector3 halfExtent, ref TriangleFace tri)
        {
            BoundingBox triBounds = new BoundingBox(); // 'new' to work around NetCF bug
            triBounds.Min.X = Math.Min(tri.V0.X, Math.Min(tri.V1.X, tri.V2.X));
            triBounds.Min.Y = Math.Min(tri.V0.Y, Math.Min(tri.V1.Y, tri.V2.Y));
            triBounds.Min.Z = Math.Min(tri.V0.Z, Math.Min(tri.V1.Z, tri.V2.Z));

            triBounds.Max.X = Math.Max(tri.V0.X, Math.Max(tri.V1.X, tri.V2.X));
            triBounds.Max.Y = Math.Max(tri.V0.Y, Math.Max(tri.V1.Y, tri.V2.Y));
            triBounds.Max.Z = Math.Max(tri.V0.Z, Math.Max(tri.V1.Z, tri.V2.Z));

            Vector3 triBoundhalfExtent;
            triBoundhalfExtent.X = (triBounds.Max.X - triBounds.Min.X) * 0.5f;
            triBoundhalfExtent.Y = (triBounds.Max.Y - triBounds.Min.Y) * 0.5f;
            triBoundhalfExtent.Z = (triBounds.Max.Z - triBounds.Min.Z) * 0.5f;

            Vector3 triBoundCenter;
            triBoundCenter.X = (triBounds.Max.X + triBounds.Min.X) * 0.5f;
            triBoundCenter.Y = (triBounds.Max.Y + triBounds.Min.Y) * 0.5f;
            triBoundCenter.Z = (triBounds.Max.Z + triBounds.Min.Z) * 0.5f;

            if (triBoundhalfExtent.X + halfExtent.X <= Math.Abs(triBoundCenter.X) ||
                triBoundhalfExtent.Y + halfExtent.Y <= Math.Abs(triBoundCenter.Y) ||
                triBoundhalfExtent.Z + halfExtent.Z <= Math.Abs(triBoundCenter.Z))
            {
                return ContainmentType.Disjoint;
            }

            if (triBoundhalfExtent.X + Math.Abs(triBoundCenter.X) <= halfExtent.X &&
                triBoundhalfExtent.Y + Math.Abs(triBoundCenter.Y) <= halfExtent.Y &&
                triBoundhalfExtent.Z + Math.Abs(triBoundCenter.Z) <= halfExtent.Z)
            {
                return ContainmentType.Contains;
            }

            Vector3 edge1, edge2, edge3;
            Vector3.Subtract(ref tri.V1, ref tri.V0, out edge1);
            Vector3.Subtract(ref tri.V2, ref tri.V0, out edge2);

            Vector3 normal;
            Vector3.Cross(ref edge1, ref edge2, out normal);
            float triangleDist = Vector3.Dot(tri.V0, normal);
            if (Math.Abs(normal.X * halfExtent.X) + Math.Abs(normal.Y * halfExtent.Y) + Math.Abs(normal.Z * halfExtent.Z) <= Math.Abs(triangleDist))
            {
                return ContainmentType.Disjoint;
            }

            // Worst case: we need to check all 9 possible separating planes
            // defined by Cross(box edge,triangle edge)
            // Check for separation in plane containing an axis of box A and and axis of box B
            //
            // We need to compute all 9 cross products to find them, but a lot of terms drop out
            // since we're working in A's local space. Also, since each such plane is parallel
            // to the defining axis in each box, we know those dot products will be 0 and can
            // omit them.
            Vector3.Subtract(ref tri.V1, ref tri.V2, out edge3);
            float dv0, dv1, dv2, dhalf;

            // a.X ^ b.X = (1,0,0) ^ edge1
            // axis = Vector3(0, -edge1.Z, edge1.Y);
            dv0 = tri.V0.Z * edge1.Y - tri.V0.Y * edge1.Z;
            dv1 = tri.V1.Z * edge1.Y - tri.V1.Y * edge1.Z;
            dv2 = tri.V2.Z * edge1.Y - tri.V2.Y * edge1.Z;
            dhalf = Math.Abs(halfExtent.Y * edge1.Z) + Math.Abs(halfExtent.Z * edge1.Y);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.X ^ b.Y = (1,0,0) ^ edge2
            // axis = Vector3(0, -edge2.Z, edge2.Y);
            dv0 = tri.V0.Z * edge2.Y - tri.V0.Y * edge2.Z;
            dv1 = tri.V1.Z * edge2.Y - tri.V1.Y * edge2.Z;
            dv2 = tri.V2.Z * edge2.Y - tri.V2.Y * edge2.Z;
            dhalf = Math.Abs(halfExtent.Y * edge2.Z) + Math.Abs(halfExtent.Z * edge2.Y);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.X ^ b.Y = (1,0,0) ^ edge3
            // axis = Vector3(0, -edge3.Z, edge3.Y);
            dv0 = tri.V0.Z * edge3.Y - tri.V0.Y * edge3.Z;
            dv1 = tri.V1.Z * edge3.Y - tri.V1.Y * edge3.Z;
            dv2 = tri.V2.Z * edge3.Y - tri.V2.Y * edge3.Z;
            dhalf = Math.Abs(halfExtent.Y * edge3.Z) + Math.Abs(halfExtent.Z * edge3.Y);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.Y ^ b.X = (0,1,0) ^ edge1
            // axis = Vector3(edge1.Z, 0, -edge1.X);
            dv0 = tri.V0.X * edge1.Z - tri.V0.Z * edge1.X;
            dv1 = tri.V1.X * edge1.Z - tri.V1.Z * edge1.X;
            dv2 = tri.V2.X * edge1.Z - tri.V2.Z * edge1.X;
            dhalf = Math.Abs(halfExtent.X * edge1.Z) + Math.Abs(halfExtent.Z * edge1.X);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.Y ^ b.X = (0,1,0) ^ edge2
            // axis = Vector3(edge2.Z, 0, -edge2.X);
            dv0 = tri.V0.X * edge2.Z - tri.V0.Z * edge2.X;
            dv1 = tri.V1.X * edge2.Z - tri.V1.Z * edge2.X;
            dv2 = tri.V2.X * edge2.Z - tri.V2.Z * edge2.X;
            dhalf = Math.Abs(halfExtent.X * edge2.Z) + Math.Abs(halfExtent.Z * edge2.X);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.Y ^ b.X = (0,1,0) ^ bX
            // axis = Vector3(edge3.Z, 0, -edge3.X);
            dv0 = tri.V0.X * edge3.Z - tri.V0.Z * edge3.X;
            dv1 = tri.V1.X * edge3.Z - tri.V1.Z * edge3.X;
            dv2 = tri.V2.X * edge3.Z - tri.V2.Z * edge3.X;
            dhalf = Math.Abs(halfExtent.X * edge3.Z) + Math.Abs(halfExtent.Z * edge3.X);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.Y ^ b.X = (0,0,1) ^ edge1
            // axis = Vector3(-edge1.Y, edge1.X, 0);
            dv0 = tri.V0.Y * edge1.X - tri.V0.X * edge1.Y;
            dv1 = tri.V1.Y * edge1.X - tri.V1.X * edge1.Y;
            dv2 = tri.V2.Y * edge1.X - tri.V2.X * edge1.Y;
            dhalf = Math.Abs(halfExtent.Y * edge1.X) + Math.Abs(halfExtent.X * edge1.Y);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.Y ^ b.X = (0,0,1) ^ edge2
            // axis = Vector3(-edge2.Y, edge2.X, 0);
            dv0 = tri.V0.Y * edge2.X - tri.V0.X * edge2.Y;
            dv1 = tri.V1.Y * edge2.X - tri.V1.X * edge2.Y;
            dv2 = tri.V2.Y * edge2.X - tri.V2.X * edge2.Y;
            dhalf = Math.Abs(halfExtent.Y * edge2.X) + Math.Abs(halfExtent.X * edge2.Y);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            // a.Y ^ b.X = (0,0,1) ^ edge3
            // axis = Vector3(-edge3.Y, edge3.X, 0);
            dv0 = tri.V0.Y * edge3.X - tri.V0.X * edge3.Y;
            dv1 = tri.V1.Y * edge3.X - tri.V1.X * edge3.Y;
            dv2 = tri.V2.Y * edge3.X - tri.V2.X * edge3.Y;
            dhalf = Math.Abs(halfExtent.Y * edge3.X) + Math.Abs(halfExtent.X * edge3.Y);
            if (Math.Min(dv0, Math.Min(dv1, dv2)) >= dhalf || Math.Max(dv0, Math.Max(dv1, dv2)) <= -dhalf)
                return ContainmentType.Disjoint;

            return ContainmentType.Intersects;
        }
        //
        #endregion
        //
        /////////////////////////////////////////////////////////////////////

    }
}
