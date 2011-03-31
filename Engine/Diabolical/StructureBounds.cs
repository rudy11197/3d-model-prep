#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Calculate a set of bounding spheres to fit a model
//      Method:
//      Create a cube or other bound round the model
//      Split in to cubes or near cubes
//      Convert to bounding Spheres
//      See which triangles fit in which
//      Remove any empty spheres

//      Old Method:
//      Splits the model triangles in to tiny bits
//      Fits them in to ever decreasing size cubes
//      Remove empty cubes
//      Converts to bounding sphere from cubes
//-----------------------------------------------------------------------------
// Based on articles and samples including:
//  http://www.enchantedage.com/node/30
//  http://www.ziggyware.com/readarticle.php?article_id=248
//  http://rhysyngsun.spaces.live.com/Blog/cns!FBBD62480D87119D!129.entry
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AssetData;
#endregion

namespace Engine
{
    /// <summary>
    /// Calculate the bounding spheres of a given size which encompass a model
    /// WINDOWS ONLY
    /// </summary>
    public class StructureBounds
    {
        // == Create the smaller spheres first then add the larger spheres round them

        // The larger spheres are created from a number of smaller boundingBoxes
        // The larger spheres are centred on the middle of the grid of the smaller boxes.

        // Create all the smaller boxes to be an exact division of roughly the size of
        // the smaller box we want.

        // Fill those smaller boxes with triangles
        // Remove any that are empty
        // Calculate the positions of the larger spheres
        // Convert the smaller boxes to sphere

        // Work out which smaller spheres fit in to which larger spheres
        // Remove any empty larger spheres.

        // The result is likely to have overlapping smaller spheres that stick out
        // of the larger spheres.
        // This overlap sometimes causes undesirable bouncing when colliding.
        // There is a separate function that should be run after the smaller spheres 
        // have been edited that better fits the larger spheres with no overlap.

        public static void CreateModelFittedBounds(DiabolicalModel aModel, float smallerBoundWidth, float largerBoundMultiple)
        {
            // The model and spheres need to be in object space not world space
            aModel.ExposeVertices();
            BoundingBox outsideBox = aModel.CalculateBoundBox(0.01f, false);
            // Get a lot of small boxes to fill the model bounds
            float boxWidth = BestFitSmallWidth(LongestEdgeXorZ(outsideBox), smallerBoundWidth, largerBoundMultiple);
            List<BoundingBox> boxes = FillWithBoxes(outsideBox, boxWidth);
            aModel.SmallerBounds = CreateSpheresFilledWithTriangles(boxes, aModel);
            // Work out the larger cubes based on the multiple of smaller ones we want to fit
            boxWidth *= largerBoundMultiple;
            boxes = FillWithBoxes(outsideBox, boxWidth);
            aModel.LargerBounds = FillWithSmallerBounds(boxes, aModel);
        }

        // Call this after the smaller bounds have been edited just before saving the model.
        // Optimisation Includes:
        // - Make sure the larger bounds fully contain all the smaller spheres
        //      Any smaller bound overlapping can cause undesirable bouncing collisions.
        // - Removes any empty larger bounds
        public static void OptimiseModelBounds(DiabolicalModel aModel)
        {
            if (aModel.LargerBounds.Count < 1)
            {
                return;
            }
            // Work backwards just in case any bounds are removed
            for (int b = aModel.LargerBounds.Count - 1; b >= 0; b--)
            {
                if (aModel.LargerBounds[b].IDs.Count < 1)
                {
                    // If empty remove
                    aModel.LargerBounds.RemoveAt(b);
                }
                else
                {
                    // Fit round the smaller spheres as efficiently as possible without overlap
                    aModel.LargerBounds[b].Sphere = SphereToEncompassSmaller(b, aModel);
                    aModel.LargerBounds[b].CentreInObjectSpace = aModel.LargerBounds[b].Sphere.Center;
                }
            }
        }

        private static BoundingSphere SphereToEncompassSmaller(int larger, DiabolicalModel aModel)
        {
            BoundingSphere result = new BoundingSphere();
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            // Get the min and max corners of the spheres as if a cube
            for (int s = 0; s < aModel.LargerBounds[larger].IDs.Count; s++)
            {
                Vector3 lowCorner = aModel.SmallerBounds[aModel.LargerBounds[larger].IDs[s]].CentreInObjectSpace;
                Vector3 highCorner = aModel.SmallerBounds[aModel.LargerBounds[larger].IDs[s]].CentreInObjectSpace;
                float radius = aModel.SmallerBounds[aModel.LargerBounds[larger].IDs[s]].Sphere.Radius;
                lowCorner.X -= radius;
                lowCorner.Y -= radius;
                lowCorner.Z -= radius;
                highCorner.X += radius;
                highCorner.Y += radius;
                highCorner.Z += radius;
                min = Vector3.Min(min, lowCorner);
                max = Vector3.Max(max, highCorner);
            }
            // Centre
            result.Center = (min + max) / 2f;
            // Radius = half the diagonal
            result.Radius = Vector3.Distance(min, max) * 0.5f;
            return result;
        }

        /// <summary>
        /// Return the smallest bounding sphere that all the points fit in to
        /// </summary>
        public static BoundingSphere SmallestToFit(List<Vector3> points)
        {
            // This uses the built in method but I don't trust it.
            // Should the built in method produce results that are 
            // not the most efficient I can add my own code here.
            return BoundingSphere.CreateFromPoints(points);
        }

        // Create the larger bounding spheres
        private static List<StructureSphere> FillWithSmallerBounds(List<BoundingBox> boxes, DiabolicalModel aModel)
        {
            List<StructureSphere> spheres = new List<StructureSphere>(boxes.Count);
            // Convert to spheres
            for (int b = 0; b < boxes.Count; b++)
            {
                BoundingSphere ball = BoundingSphere.CreateFromBoundingBox(boxes[b]);
                spheres.Add(new StructureSphere(ball.Center, ball.Radius));
            }
            // Loop through the smaller spheres and fit them in to the larger ones
            // The result of this will have overlapping smaller spheres
            for (int m = 0; m < aModel.SmallerBounds.Count; m++)
            {
                for (int s = 0; s < spheres.Count; s++)
                {
                    // Is the smaller one in or touching the larger one
                    if (spheres[s].Sphere.Contains(aModel.SmallerBounds[m].Sphere) != ContainmentType.Disjoint)
                    {
                        // Store the index to the smaller sphere
                        spheres[s].IDs.Add(m);
                    }
                }
            }
            // Remove empty spheres
            // Easier to add those that have something in them rather than remove from a list
            List<StructureSphere> results = new List<StructureSphere>();
            for (int r = 0; r < spheres.Count; r++)
            {
                // Add any that have triangles in them
                if (spheres[r].IDs.Count > 0)
                {
                    results.Add(spheres[r]);
                }
            }
            return results;
        }

        // Create the smallest bounding spheres
        private static List<StructureSphere> CreateSpheresFilledWithTriangles(List<BoundingBox> boxes, DiabolicalModel aModel)
        {
            List<StructureSphere> spheres = new List<StructureSphere>(boxes.Count);
            // Convert to spheres
            for (int b = 0; b < boxes.Count; b++)
            {
                BoundingSphere ball = BoundingSphere.CreateFromBoundingBox(boxes[b]);
                spheres.Add(new StructureSphere(ball.Center, ball.Radius));
            }
            FillWithTriangles(spheres, aModel);
            // Remove empty spheres
            // Easier to add those that have something in them rather than remove from a list
            List<StructureSphere> results = new List<StructureSphere>();
            for (int r = 0; r < spheres.Count; r++)
            {
                // Add any that have triangles in them
                if (spheres[r].IDs.Count > 0)
                {
                    results.Add(spheres[r]);
                }
            }
            OptimiseFittedSphere(results, aModel);
            return results;
        }

        // Optimise the size of the spheres
        private static void OptimiseFittedSphere(List<StructureSphere> spheres, DiabolicalModel aModel)
        {
            Triangle tri = new Triangle();
            List<Vector3> points = new List<Vector3>();
            for (int s = 0; s < spheres.Count; s++)
            {
                points.Clear();
                for (int t = 0; t < spheres[s].IDs.Count; t++)
                {
                    aModel.GetTriangle(ref t, ref tri);
                    points.AddRange(tri.PointsInsideSphere(spheres[s].Sphere));
                }
                spheres[s].RePosition(SmallestToFit(points));
            }
        }

        // Used for filling and refilling spheres
        private static void FillWithTriangles(List<StructureSphere> spheres, DiabolicalModel aModel)
        {
            // Loop through the triangles
            Triangle tri = new Triangle();
            bool result = false;
            BoundingSphere bound;
            int count = aModel.CountTriangles();
            for (int t = 0; t < count; t++)
            {
                aModel.GetTriangle(ref t, ref tri);
                // Loop through the spheres and then mini spheres
                for (int s = 0; s < spheres.Count; s++)
                {
                    // Test which mini spheres each triangle fits in
                    bound = spheres[s].Sphere;
                    tri.Intersects(ref bound, out result);
                    if (result)
                    {
                        // Store the reference to the triangle with the sphere
                        spheres[s].IDs.Add(t);
                    }
                }
            }
        }

        // Bounding boxes to fill the model bounds
        private static List<BoundingBox> FillWithBoxes(BoundingBox box, float side)
        {
            List<BoundingBox> cubes = new List<BoundingBox>();
            Vector3 min = Vector3.Zero;
            Vector3 max = Vector3.Zero;
            float width = box.Max.X - box.Min.X;
            float height = box.Max.Y - box.Min.Y;
            float depth = box.Max.Z - box.Min.Z;
            // Calculate the cubes to fit the larger bounding box
            for (float w = box.Min.X; w < box.Max.X; w += side)
            {
                for (float h = box.Min.Y; h < box.Max.Y; h += side)
                {
                    for (float d = box.Min.Z; d < box.Max.Z; d += side)
                    {
                        min.X = w;
                        min.Y = h;
                        min.Z = d;
                        max.X = w + side;
                        max.Y = h + side;
                        max.Z = d + side;
                        cubes.Add(new BoundingBox(min, max));
                    }
                }
            }
            return cubes;
        }

        // Calculate a size that in the desired multiples fit neatly across the model at roughly
        // the desired size.  
        // The larger bounding sphere will have a diameter of that multiple x the mini width.
        // This is to try to fit the boxes as efficiently as possible at least along the 
        // longest edge.
        private static float BestFitSmallWidth(float edgeLength, float smallerBoundWidth, float largerBoundMultiple)
        {
            float desiredLarger = smallerBoundWidth * largerBoundMultiple;
            // For small objects use the default
            if (edgeLength < desiredLarger)
            {
                return smallerBoundWidth;
            }
            // Round to nearest hole number up or down
            float fits = (float)Math.Floor((edgeLength / desiredLarger)+0.5f);
            // The size of the smallest box to a multiple of times across the object
            return edgeLength / fits / largerBoundMultiple;
        }

        // Calculate the longest edge across the ground
        // We are not worried about the height
        private static float LongestEdgeXorZ(BoundingBox box)
        {
            float lengthX = Math.Abs(box.Max.X - box.Min.X);
            float lengthZ = Math.Abs(box.Max.Z - box.Min.Z);
            if (lengthX > lengthZ)
            {
                return lengthX;
            }
            return lengthZ;
        }

    }
}
