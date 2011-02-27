#region File Description
//-----------------------------------------------------------------------------
// MoreMaths.cs
//
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Helper adding functions not already available in XNA
// Some of the code came from:
// http://www.ziggyware.com/readarticle.php?article_id=54
// http://www.xnainfo.com/content.php?content=18
//-----------------------------------------------------------------------------
#endregion

//-----------------------------------------------------------------------------
// MATHS
//-----------------------------------------------------------------------------
// Dot Product of Two Vectors:
// - http://chortle.ccsu.edu/VectorLessons/vch07/vch07_7.html
//   http://forums.xna.com/forums/p/40687/238194.aspx#238194
//      U.V = |U||V|cos(smallest angle between two vectors)
//      U.V < 0 angle between is > 90 deg (negative dot product = opposite direction)
//      U.V = 0 angle between is = 90 deg (zero dot product = exactly right angle)
//      U.V > 0 angle between is < 90 deg (positive dot product = same direction)
//      This is a useful way to determin if the vectors face roughly
//      in the same direction
//-----------------------------------------------------------------------------

#region Using Statements
using System;
using Microsoft.Xna.Framework;
#endregion

namespace AssetData
{

    /// <summary>
    /// Helper adding functions not already available in XNA
    /// </summary>
    public class MoreMaths
    {
        // Useful for avoiding floating point errors
        public const float TinyNearZero = 0.000001f;
        // The square root of 2 used to get the diagonal length of a square corner to corner 1.4142135623...
        public const float SqrtTwo = 1.414f;

        /// <summary>
        /// Return true if the number supplied is very near zero.
        /// This is to avoid floating point errors.
        /// </summary>
        public static bool NearZero(float num)
        {
            if (num > -TinyNearZero && num < TinyNearZero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return the velocity vector calculated from the direction and speed
        /// </summary>
        public static Vector3 CalculateVelocity(Vector3 direction, float unitsPerSecond)
        {
            return SafeNormalize(direction) * unitsPerSecond;
        }

        /// <summary>
        /// Normalizing a zero length vector throws a 'Not a Number' (NaN) error.
        /// This tests for zero length therefore avoiding the error.
        /// </summary>
        public static Vector3 SafeNormalize(Vector3 vector)
        {
            if (!NearZero(vector.X + vector.Y + vector.Z))
            {
                return Vector3.Normalize(vector);
            }
            else
            {
                return Vector3.Zero;
            }
        }

        /// <summary>
        /// Normalizing a zero length vector throws a 'Not a Number' (NaN) error.
        /// This tests for zero length therefore avoiding the error.
        /// </summary>
        public static Vector2 SafeNormalize(Vector2 vector)
        {
            if (!NearZero(vector.X + vector.Y))
            {
                return Vector2.Normalize(vector);
            }
            else
            {
                return Vector2.Zero;
            }
        }

        /// <summary>
        /// Return a location on the line closest to the point specified.
        /// The point specified can be anywhere.
        /// </summary>
        public static Vector3 ClosestPointAlongLine(
             ref Vector3 lineStart,
             ref Vector3 lineEnd,
             ref Vector3 point)
        {
            Vector3 direction = lineEnd - lineStart;
            direction = SafeNormalize(direction);
            float along = Vector3.Dot(direction, point - lineStart);
            if (along < 0)
            {
                // The position is before the start of the line
                return lineStart;
            }
            float length = (lineEnd - lineStart).Length();
            if (along > length)
            {
                // The position is past the end of the line
                return lineEnd;
            }
            return lineStart + (direction * along);
        }

        /// <summary>
        /// Returns the distance from the point to the closest position on the line.
        /// </summary>
        public static float ShortestDistanceToLine(
             ref Vector3 lineStart,
             ref Vector3 lineEnd,
             ref Vector3 point)
        {
            // I am not sure if this is the most efficient maths
            return (point - ClosestPointAlongLine(ref lineStart, ref lineEnd, ref point)).Length();
        }

        /// <summary>
        /// Return the angle in radians between the two vectors but not the direction!
        /// </summary>
        public static double AngleBetweenVectors(Vector3 first, Vector3 second)
        {
            float dot = Vector3.Dot(first, second);
            float magnitude = first.Length() * second.Length();
            return Math.Acos(dot / magnitude);
        }

        /// <summary>
        /// Returns degrees round the Y axis (+Z axis = 0 deg. e.g. facing up on a graph)
        /// Results in the range +180 to -180
        /// </summary>
        public static float DegreesRoundYAxisZeroNorth(Vector3 direction)
        {
            return WrapAngleDegrees(
                MathHelper.ToDegrees(
                (float)Math.Atan2(direction.Z, direction.X)) + 90f);
        }

        /// <summary>
        /// Returns the quaternion rotation between two vectors
        /// From: http://www.xnainfo.com/content.php?content=18
        /// </summary>
        public static Quaternion RotationBetween(Vector3 src, Vector3 dest)
        {
            src.Normalize();
            dest.Normalize();

            float d = Vector3.Dot(src, dest);

            if (d >= 1f)
            {
                return Quaternion.Identity;
            }
            else if (d < (1e-6f - 1.0f))
            {
                Vector3 axis = Vector3.Cross(Vector3.UnitX, src);

                if (axis.LengthSquared() == 0)
                {
                    axis = Vector3.Cross(Vector3.UnitY, src);
                }

                axis.Normalize();
                return Quaternion.CreateFromAxisAngle(axis, MathHelper.Pi);
            }
            else
            {
                float s = (float)Math.Sqrt((1 + d) * 2);
                float invS = 1 / s;

                Vector3 c = Vector3.Cross(src, dest);
                Quaternion q = new Quaternion(invS * c, 0.5f * s);
                q.Normalize();

                return q;
            }
        }

        /// <summary>
        /// Returns the angle expressed in radians between -Pi and Pi.
        /// <param name="radians">the angle to wrap, in radians.</param>
        /// <returns>the input value expressed in radians from -Pi to Pi.</returns>
        /// </summary>
        public static float WrapAngle(float radians)
        {
            while (radians < -MathHelper.Pi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.Pi)
            {
                radians -= MathHelper.TwoPi;
            }
            return radians;
        }

        /// <summary>
        /// Returns the angle expressed in degrees between -180 and 180.
        /// </summary>
        public static float WrapAngleDegrees(float degrees)
        {
            while (degrees < -180)
            {
                degrees += 360;
            }
            while (degrees > 180)
            {
                degrees -= 360;
            }
            return degrees;
        }
    }
}
