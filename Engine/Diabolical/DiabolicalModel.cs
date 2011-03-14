﻿#region File Description
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
    public class DiabolicalModel
    {
        //////////////////////////////////////////////////////////////////////
        // == ActiveModelAsset ==

        // == All models
        // Type, e.g. Character, Structure, Weapon, HeadGear etc.
        public string modelType = GlobalSettings.modelTypeStructure;
        // Model and components
        public Model model;    //that's what we are working on
        // Used to store the bounding sphere in object space
        public BoundingSphere oversizeBounds;
        // Rotate the model when loaded round X, Y, Z
        public Vector3 rotation;

        // == Gear
        // Used for weapons to align them to the characters hands.
        // It can be made up by applying a rotation and translation.
        public Matrix boneAlignment;

        // == Structure
        // The bounding spheres making up the model for use for collision 
        // and containing the indices of the triangles for use by projectile impacts.
        public List<StructureSphere> largerBounds;
        public List<StructureSphere> smallerBounds;
        public List<StructureSphere> LargerBounds
        {
            get { return largerBounds; }
            set { largerBounds = value; }
        }
        public List<StructureSphere> SmallerBounds
        {
            get { return smallerBounds; }
            set { smallerBounds = value; }
        }

        // == Character
        // Armature Rig type (Skeleton) used to calculate which animations to use  e.g. 'human'
        public string rigTypeName = "";
        // There are always the same number of standing and crouched spheres
        public List<BoundingSphere> standingSpheres;
        public List<BoundingSphere> crouchedSpheres;
        // The list of bounding spheres attached to bones used for more detailed collision with projectiles
        public List<AttachedSphere> attachedSpheres;
        // The list of equipment attachment points
        public List<AttachmentPoint> attachEquip;
        // The list of adornment attachment points starting with the head
        public List<AttachmentPoint> attachAdorn;
        // The hand to hold the weapon
        public AttachmentPoint attachHold;

        // == Weapon
        // The source Human or Alien
        public int manufacturer = 0;
        // The position of the muzzle in relation to the origin of the model
        public Vector3 muzzleOffset;
        // Half the width of the weapon used to position the model lying on the ground
        public float halfWidth = 0;
        // Ammo
        public string ammoType = "";
        public int ammoClipCapacity = 0;
        public int ammoMaxCarried = 0;
        public float ammoSecondsToReload = 0;
        // Calculated from the ammo fire rate
        public float ammoSecondsToChamber = 0;
        public bool isAutoFire = false;
        // Sounds
        public string fxReload = "";
        public string fxEmpty = "";
        // Optimum ranges used by the AI for the bots
        public float optimumClosest = 0;
        public float optimumFarthest = 0;
        // Recoil - How many degrees the weapon lifts each shot
        public float recoilDegrees;
        // Zoom using a scope
        public List<float> zoomMultipliers;
        // Sight cross hairs to use at each zoom level
        public List<int> crossHairs;

        // == Only used by the editor
        // The fbx or x file of the model including the relative path
        public string modelFilename;
        public string effectType;
        public float specularIntensity = 0.3f;
        public float specularPower = 4.0f;
        // Used for both normal and grey scale bump maps
        public string depthMapFile;
        public string specularMapFile;
        // For per triangle impact from projectiles
        // These remain null until calculated using ExposeVertices()
        public List<Vector3> vertices;
        public List<VertexHelper.TriangleVertexIndices> indices;
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Editor ==
        //
        // Shape class used to draw guide lines for testing collision
        // This is a shared class in the ModelViewerControl which draws these shapes
        public Shapes debugShapes;
        //
        //////////////////////////////////////////////////////////////////////

        public DiabolicalModel(Shapes sharedShapes)
        {
            debugShapes = sharedShapes;
            PreProcessSetup();
        }

        //////////////////////////////////////////////////////////////////////
        // == ActiveModelAssetContent ==
        //
        public void BuildModelAsset(string type, string filename, string effect, float intensity, float power, string depthmap, string specular, Model baseModel, BoundingSphere bounds, float rotXdegrees, float rotYdegrees, float rotZdegrees, string[] options)
        {
            modelType = type;
            modelFilename = filename;
            effectType = effect;
            specularIntensity = intensity;
            specularPower = power;
            depthMapFile = depthmap;
            specularMapFile = specular;
            model = baseModel;
            oversizeBounds = bounds;
            rotation = new Vector3(rotXdegrees, rotYdegrees, rotZdegrees);
            PreProcessSetup();
            ProcessOptions(options);
        }

        private void PreProcessSetup()
        {
            largerBounds = new List<StructureSphere>();
            smallerBounds = new List<StructureSphere>();
            boneAlignment = Matrix.Identity;
            standingSpheres = new List<BoundingSphere>();
            crouchedSpheres = new List<BoundingSphere>();
            attachedSpheres = new List<AttachedSphere>();
            attachAdorn = new List<AttachmentPoint>();
            attachEquip = new List<AttachmentPoint>();
            muzzleOffset = Vector3.Zero;
            zoomMultipliers = new List<float>();
            crossHairs = new List<int>();
        }

        private void ProcessOptions(string[] options)
        {
            if (options != null && model != null && modelType != "")
            {
                // Parse the rest of the loaded data if there is any
                if (options.Length > 0)
                {
                    // Loop through the data and add each item to the level
                    for (int i = 0; i < options.Length; i++)
                    {
                        // Get each element of the item
                        string[] item = ParseData.SplitItemByDivision(options[i]);
                        // if not empty and has at least one element of data to go with the type
                        if (item.Length > 1)
                        {
                            ExtractModelOption(item);
                        }
                    }
                }
            }
        }

        private void ExtractModelOption(string[] item)
        {
            // What have we got
            switch (item[0])
            {
                case GlobalSettings.typeLargerBounds:
                    if (item.Length > 2)
                    {
                        AddLargerBounds(item);
                    }
                    break;
                case GlobalSettings.typeSmallerBounds:
                    if (item.Length > 2)
                    {
                        AddSmallerBounds(item);
                    }
                    break;
                case GlobalSettings.typeRig:
                    if (item.Length > 1)
                    {
                        rigTypeName = item[1];
                    }
                    break;
                case GlobalSettings.typeLargerSpheres:
                    if (item.Length > 4)
                    {
                        AddBodySpheres(item[1], item[2], item[3], item[4]);
                    }
                    break;
                case GlobalSettings.typeSmallerSpheres:
                    if (item.Length > 3)
                    {
                        AddAttachedSphere(item[1], item[2], item[3]);
                    }
                    break;
                case GlobalSettings.typeAttachEquipment:
                    if (item.Length > 7)
                    {
                        AddAttachEquipment(item[1], item[2], item[3], item[4], item[5], item[6], item[7]);
                    }
                    break;
                case GlobalSettings.typeAttachAdornment:
                    if (item.Length > 7)
                    {
                        AddAttachAdornment(item[1], item[2], item[3], item[4], item[5], item[6], item[7]);
                    }
                    break;
                case GlobalSettings.typeWeaponHoldBone:
                    if (item.Length > 7)
                    {
                        AddWeaponHold(item[1], item[2], item[3], item[4], item[5], item[6], item[7]);
                    }
                    break;
                case GlobalSettings.typeAimAdjustment:
                    if (item.Length > 6)
                    {
                        AddBoneAdjustment(item[1], item[2], item[3], item[4], item[5], item[6]);
                    }
                    break;
                case GlobalSettings.typeHeadOffset:
                    if (item.Length > 3)
                    {
                        AddBoneTranslate(item[1], item[2], item[3]);
                    }
                    break;
                case GlobalSettings.typeManufacturer:
                    if (item.Length > 1)
                    {
                        SetManufacturer(item[1]);
                    }
                    break;
                case GlobalSettings.typeWeaponMuzzle:
                    if (item.Length > 3)
                    {
                        SetMuzzleOffset(item[1], item[2], item[3]);
                    }
                    break;
                case GlobalSettings.typeWeaponHalfWidth:
                    if (item.Length > 1)
                    {
                        SetHalfWidth(item[1]);
                    }
                    break;
                case GlobalSettings.typeWeaponAmmo:
                    if (item.Length > 7)
                    {
                        SetAmmo(item[1], item[2], item[3], item[4], item[5], item[6], item[7]);
                    }
                    break;
                case GlobalSettings.typeWeaponRanges:
                    if (item.Length > 2)
                    {
                        SetRanges(item[1], item[2]);
                    }
                    break;
                case GlobalSettings.typeWeaponRecoil:
                    if (item.Length > 1)
                    {
                        recoilDegrees = ParseData.FloatFromString(item[1]);
                    }
                    break;
                case GlobalSettings.typeWeaponZoom:
                    if (item.Length > 1)
                    {
                        SetZoomMultipliers(item);
                    }
                    break;
                case GlobalSettings.typeWeaponSights:
                    if (item.Length > 1)
                    {
                        SetSightTypes(item);
                    }
                    break;
                default:
                    // Type unknown so ignored
                    System.Diagnostics.Debug.WriteLine(String.Format("Model data ignored - unidentified item type '{0}'", item[0]));
                    break;
            }

        }

        // == Structures

        private void AddLargerBounds(string[] items)
        {
            // The first item (index 0) is the type so is ignored
            Vector3 centre = ParseData.StringToVector(items[1]);
            float radius = ParseData.FloatFromString(items[2]);
            if (largerBounds == null)
            {
                largerBounds = new List<StructureSphere>();
            }
            List<int> Indices = new List<int>();
            if (items.Length > 3)
            {
                Indices = ParseData.StringToIntList(items[3]);
            }
            largerBounds.Add(new StructureSphere(centre, radius, Indices));
        }

        private void AddSmallerBounds(string[] items)
        {
            // The first item (index 0) is the type so is ignored
            Vector3 centre = ParseData.StringToVector(items[1]);
            float radius = ParseData.FloatFromString(items[2]);
            if (smallerBounds == null)
            {
                smallerBounds = new List<StructureSphere>();
            }
            List<int> Indices = new List<int>();
            if (items.Length > 3)
            {
                Indices = ParseData.StringToIntList(items[3]);
            }
            smallerBounds.Add(new StructureSphere(centre, radius, Indices));
        }

        // == Characters

        private void AddBodySpheres(string centreStanding, string radiusStanding,
                string centreCrouched, string radiusCrouched)
        {
            Vector3 vCentre = ParseData.StringToVector(centreStanding);
            float fRadius = ParseData.FloatFromString(radiusStanding);
            standingSpheres.Add(new BoundingSphere(vCentre, fRadius));
            vCentre = ParseData.StringToVector(centreCrouched);
            fRadius = ParseData.FloatFromString(radiusCrouched);
            crouchedSpheres.Add(new BoundingSphere(vCentre, fRadius));
        }

        private void AddAttachedSphere(string boneName, string radius, string offset)
        {
            float fRadius = ParseData.FloatFromString(radius);
            float fOffset = ParseData.FloatFromString(offset);

            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            if (boneID >= 0)
            {
                attachedSpheres.Add(new AttachedSphere(boneID, new Vector3(0, fOffset, 0),
                    fRadius, fOffset));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(String.Format("The bone name does not exist in the model '{0}'", boneName));
            }
        }

        private void AddAttachEquipment(string boneName, string sX, string sY, string sZ, string sRotX, string sRotY, string sRotZ)
        {
            // Offset from the bone position to the attachment point
            float X = ParseData.FloatFromString(sX);
            float Y = ParseData.FloatFromString(sY);
            float Z = ParseData.FloatFromString(sZ);
            float rotateX = ParseData.FloatFromString(sRotX);
            float rotateY = ParseData.FloatFromString(sRotY);
            float rotateZ = ParseData.FloatFromString(sRotZ);
            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            // Add the attachment point even if the bone is not valid
            // This is so that dummies can be added and ignored when attempted to be used
            attachEquip.Add(new AttachmentPoint(boneID, X, Y, Z, rotateX, rotateY, rotateZ));
        }

        private void AddAttachAdornment(string boneName, string sX, string sY, string sZ, string sRotX, string sRotY, string sRotZ)
        {
            // Offset from the bone position to the attachment point
            float X = ParseData.FloatFromString(sX);
            float Y = ParseData.FloatFromString(sY);
            float Z = ParseData.FloatFromString(sZ);
            float rotateX = ParseData.FloatFromString(sRotX);
            float rotateY = ParseData.FloatFromString(sRotY);
            float rotateZ = ParseData.FloatFromString(sRotZ);
            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            // Add the attachment point even if the bone is not valid
            // This is so that dummies can be added and ignored when attempted to be used
            attachAdorn.Add(new AttachmentPoint(boneID, X, Y, Z, rotateX, rotateY, rotateZ));
        }

        private void AddWeaponHold(string boneName, string sX, string sY, string sZ, string sRotX, string sRotY, string sRotZ)
        {
            // Offset from the bone position to the attachment point
            float X = ParseData.FloatFromString(sX);
            float Y = ParseData.FloatFromString(sY);
            float Z = ParseData.FloatFromString(sZ);
            float rotateX = ParseData.FloatFromString(sRotX);
            float rotateY = ParseData.FloatFromString(sRotY);
            float rotateZ = ParseData.FloatFromString(sRotZ);
            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            // Add the attachment point even if the bone is not valid
            // This is so that dummies can be added and ignored when attempted to be used
            attachHold = new AttachmentPoint(boneID, X, Y, Z, rotateX, rotateY, rotateZ);
        }

        // Return the bone number from the bone name
        private int GetBoneID(string boneName)
        {
            // Look up our custom skinning information.
            SkinningData skinningData = model.Tag as SkinningData;
            if (skinningData == null)
            {
                //This model does not contain a SkinningData tag.
                throw new Exception("This character cannot be animated because the skinning data is missing!");
            }
            else
            {
                return skinningData.BoneMap[boneName];
            }
        }

        // == Weapons

        private void SetManufacturer(string id)
        {
            manufacturer = ParseData.IntFromString(id);
        }

        private void SetZoomMultipliers(string[] sZooms)
        {
            // The first item will be the type so skip it
            for (int i = 1; i < sZooms.Length; i++)
            {
                zoomMultipliers.Add(ParseData.FloatFromString(sZooms[i]));
            }
        }

        private void SetSightTypes(string[] sTypes)
        {
            // The first item will be the type so skip it
            for (int i = 1; i < sTypes.Length; i++)
            {
                crossHairs.Add(ParseData.IntFromString(sTypes[i]));
            }
        }

        private void SetMuzzleOffset(string sX, string sY, string sZ)
        {
            muzzleOffset.X = ParseData.FloatFromString(sX);
            muzzleOffset.Y = ParseData.FloatFromString(sY);
            muzzleOffset.Z = ParseData.FloatFromString(sZ);
        }

        private void SetHalfWidth(string sWidth)
        {
            halfWidth = ParseData.FloatFromString(sWidth);
        }

        private void SetAmmo(string sType, string sClip, string sCarried, string sFireRate, string sReloadTime, string sReloadSound, string sEmptySound)
        {
            ammoType = sType;
            ammoClipCapacity = ParseData.IntFromString(sClip);
            ammoMaxCarried = ParseData.IntFromString(sCarried);
            float rate = ParseData.FloatFromString(sFireRate);
            if (rate < 0)
            {
                // Single shot
                isAutoFire = false;
                rate = -1.0f * rate;
            }
            else
            {
                isAutoFire = true;
            }
            // Calculate the time to chamber from the rate of fire
            if (MoreMaths.NearZero(rate))
            {
                // Very quick
                ammoSecondsToChamber = 0.01f;
            }
            else
            {
                ammoSecondsToChamber = 1.0f / rate;
            }
            ammoSecondsToReload = ParseData.FloatFromString(sReloadTime);
            fxReload = sReloadSound;
            fxEmpty = sEmptySound;
        }

        private void SetRanges(string sClose, string sFar)
        {
            optimumClosest = ParseData.FloatFromString(sClose);
            optimumFarthest = ParseData.FloatFromString(sFar);
        }

        // == Gear

        // Adjustments to alignments are applied in the order they are in the XML file.
        // As a matrix rotation changes the axes a rotation followed by a translation will be 
        // difficult to understand.  A translation followed by a rotation is easier to visualise.

        private void AddBoneAdjustment(string sX, string sY, string sZ, string sDegX, string sDegY, string sDegZ)
        {
            AddBoneRotation(sDegX, sDegY, sDegZ);
            AddBoneTranslate(sX, sY, sZ);
        }

        // Position the model in relation to something else.  This is used for the weapons in
        // hands and hair on heads.
        private void AddBoneTranslate(string sX, string sY, string sZ)
        {
            // Position the grip exactly in the hand e.g. (0.5f, 0.45f, -0.1f)
            // The axis are relative to the model and are changed by any other adjustment
            // It is easier to understand if the translation is done before any rotation.
            // If that is the case then the translation is relative to the axes of the model.
            // Typically the model should be drawn or rotated to +Y up with the barrel 
            // along the X axis.
            // Therefore +Y = up, +X = away from the grip, +Z = Right if looking from the stock end
            boneAlignment *= Matrix.CreateTranslation(ParseData.FloatFromString(sX),
                ParseData.FloatFromString(sY), ParseData.FloatFromString(sZ));
        }

        private void AddBoneRotation(string sDegX, string sDegY, string sDegZ)
        {
            // Rotate to face forwards (-Up +Down, -Left +Right, +Up -Down) (100, 59, 56)
            float radX = MathHelper.ToRadians(ParseData.FloatFromString(sDegX));
            float radY = MathHelper.ToRadians(ParseData.FloatFromString(sDegY));
            float radZ = MathHelper.ToRadians(ParseData.FloatFromString(sDegZ));
            boneAlignment *= Matrix.CreateRotationX(radX) *
                Matrix.CreateRotationY(radY) *
                Matrix.CreateRotationZ(radZ);
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Bounding Shapes ==
        //
        // Used to view the result of creating bounding spheres
        public void OutlineLargerBounds(int lastLargerBound)
        {
            debugShapes.ClearStoredShapes();
            MoveBounds();
            for (int i = 0; i < LargerBounds.Count; i++)
            {
                // highlight the last selected bound
                if (i == lastLargerBound)
                {
                    debugShapes.StoreNewSphere(
                        LargerBounds[i].Sphere.Center,
                        LargerBounds[i].Sphere.Radius,
                        Color.Yellow);
                }
                else
                {
                    debugShapes.StoreNewSphere(
                        LargerBounds[i].Sphere.Center,
                        LargerBounds[i].Sphere.Radius,
                        Color.Red);
                }
            }
        }

        // Used to view and edit the result of creating bounding spheres
        public void OutlineSmallerBoundsInLarger(int lastLargerBound, int lastSmallerBound)
        {
            debugShapes.ClearStoredShapes();
            MoveBounds();
            if (lastLargerBound < 0 || lastLargerBound >= LargerBounds.Count)
            {
                return;
            }
            // Loop through all the indices contained in the larger bound
            for (int i = 0; i < LargerBounds[lastLargerBound].IDs.Count; i++)
            {
                if (lastSmallerBound == LargerBounds[lastLargerBound].IDs[i])
                {
                    debugShapes.StoreNewSphere(
                        SmallerBounds[LargerBounds[lastLargerBound].IDs[i]].Sphere.Center,
                        SmallerBounds[LargerBounds[lastLargerBound].IDs[i]].Sphere.Radius,
                        Color.Yellow);
                }
                else
                {
                    debugShapes.StoreNewSphere(
                        SmallerBounds[LargerBounds[lastLargerBound].IDs[i]].Sphere.Center,
                        SmallerBounds[LargerBounds[lastLargerBound].IDs[i]].Sphere.Radius,
                        Color.Red);
                }
            }
        }

        // Used to view the smaller bounds
        public void OutlineAllSmallerBounds(int lastSmallerBound)
        {
            debugShapes.ClearStoredShapes();
            MoveBounds();
            // Loop through all the smaller bounds
            for (int i = 0; i < SmallerBounds.Count; i++)
            {
                if (i == lastSmallerBound)
                {
                    debugShapes.StoreNewSphere(
                        SmallerBounds[i].Sphere.Center,
                        SmallerBounds[i].Sphere.Radius,
                        Color.Yellow);
                }
                else
                {
                    debugShapes.StoreNewSphere(
                        SmallerBounds[i].Sphere.Center,
                        SmallerBounds[i].Sphere.Radius,
                        Color.Red);
                }
            }
        }

        public void MoveBounds()
        {
            // All models drawn at zero
            Matrix WorldPosition = Matrix.Identity;
            // Move the Static bounds making up the model
            if (LargerBounds != null)
            {
                for (int i = 0; i < LargerBounds.Count; i++)
                {
                    LargerBounds[i].MoveBounds(WorldPosition);
                }
            }
            if (SmallerBounds != null)
            {
                for (int i = 0; i < SmallerBounds.Count; i++)
                {
                    SmallerBounds[i].MoveBounds(WorldPosition);
                }
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Bounds ==
        //
        // Fill a list with the points and indices which can be used to make up the triangles 
        // of the model.  Always calculated with the model on object space.
        public void ExposeVertices()
        {
            List<Vector3> original = new List<Vector3>();
            // Check if we've done this before
            if (vertices == null)
            {
                vertices = new List<Vector3>();
            }
            else
            {
                vertices.Clear();
            }
            if (indices == null)
            {
                indices = new List<VertexHelper.TriangleVertexIndices>();
            }
            else
            {
                indices.Clear();
            }
            // In object space
            VertexHelper.ExtractTrianglesFrom(model, original, indices, Matrix.Identity);

            foreach (Vector3 vec in original)
            {
                // Create a duplicate for each model
                // NOTE: I don't think this is necessary but it is to rule this out as a 
                // possible cause of errors.
                vertices.Add(new Vector3(vec.X, vec.Y, vec.Z));
            }
        }

        /// <summary>
        /// Calculate a tight fitting bounding box for this model.
        /// Oversize adjusts the max and min by the amount specified e.g. 0.1 (10cm) or 0.01 (1cm)
        /// Some methods work best if the result is a cube.
        /// </summary>
        public BoundingBox CalculateBoundBox(float oversize, bool cube)
        {
            // Then calculate the overall bounding shape
            Vector3 min = Vector3.One * float.MaxValue;
            Vector3 max = Vector3.One * float.MinValue;
            // Loop through every triangle to find the min and max points
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector3 current = vertices[i];
                // Get minimum of each of the Triangles minimum bound
                Vector3.Min(ref min, ref current, out min);
                // Get maximum of each of the Trigons maximum bound
                Vector3.Max(ref max, ref current, out max);
            }

            // Expand each corner by the oversize fraction
            min.X = min.X - oversize;
            min.Y = min.Y - oversize;
            min.Z = min.Z - oversize;
            max.X = max.X + oversize;
            max.Y = max.Y + oversize;
            max.Z = max.Z + oversize;

            if (cube)
            {
                // Find the longest edge
                float longest = MathHelper.Max(max.X - min.X,
                                MathHelper.Max(max.Y - min.Y, max.Z - min.Z));
                // Find the middle
                Vector3 middle = (max - min) * 0.5f;
                Vector3 centre = min + middle;
                // half the longest
                float half = longest * 0.5f;
                // Adjust corners to create a cube with sides equal to the longest side
                min.X = centre.X - half;
                min.Y = centre.Y - half;
                min.Z = centre.Z - half;
                max.X = centre.X + half;
                max.Y = centre.Y + half;
                max.Z = centre.Z + half;
            }

            return new BoundingBox(min, max);
        }

        public int CountTriangles()
        {
            return indices.Count;
        }

                // Set the size and position of the triangle provided to be that of the triangle index
        // specified.
        // This is called frequently so error checking has deliberately
        // not been included.
        public void GetTriangle(ref int index, ref Triangle triangle)
        {
            triangle.Resize(vertices[indices[index].A], vertices[indices[index].B],
                vertices[indices[index].C]);
        }

        // This creates a copy of the triangle in world space
        // This adds to the heap so is bad for Garbage collection
        // Only use during level loading or saving never mid game
        public Triangle GetTriangle(int index)
        {
            if (vertices != null && indices != null && index > -1 && index < indices.Count)
            {
                return new Triangle(vertices[indices[index].A], vertices[indices[index].B],
                    vertices[indices[index].C]);
            }
            else
            {
                return new Triangle(Vector3.Zero, Vector3.Zero, Vector3.Zero);
            }
        }

        // Return a new list of the the triangles in the model
        // This adds loads to the heap so is bad for Garbage collection
        // Only use during level loading or saving never mid game
        public List<Triangle> GetTriangles()
        {
            List<Triangle> tris = new List<Triangle>();
            if (vertices != null && indices != null && indices.Count > 0)
            {
                for (int i = 0; i < indices.Count; i++)
                {
                    tris.Add(GetTriangle(i));
                }
            }
            return tris;
        }
        //
        //////////////////////////////////////////////////////////////////////


    }
}