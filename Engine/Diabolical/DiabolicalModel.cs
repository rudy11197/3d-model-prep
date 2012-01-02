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
    public class DiabolicalModel
    {
        //////////////////////////////////////////////////////////////////////
        // == ActiveModelAsset ==

        // The fbx or x file of the model including the relative path
        public string ModelFilename;

        // == All models
        // Type, e.g. Character, Structure, Weapon, HeadGear etc.
        public string ModelType = GlobalSettings.modelTypeStructure;
        // Model and components
        public Model Replica;
        // Used to store the bounding sphere in object space
        public BoundingSphere OversizeBounds;
        // Rotate the model when loaded round X, Y, Z
        public Vector3 Rotation;

        // == Lighting ==
        // These are only needed for the initial setup of the effect once loaded
        // Effect type
        public string EffectType = GlobalSettings.effectTypeRigid;
        // Highlight tightness
        protected float specularPower = 16f;
        public float SpecularPower
        {
            get { return specularPower; }
            set
            {
                specularPower = value;
            }
        }
        protected Vector3 specularColour = new Vector3(GlobalSettings.colourSpecularGreyDefault);
        /// <summary>
        /// The colour of the reflective shiny surfaces of an objects materials (range 0 to 1).
        /// </summary>
        public Vector3 SpecularColour
        {
            get { return specularColour; }
            set
            {
                specularColour = value;
            }
        }

        protected float materialAlpha = 1;
        /// <summary>
        /// The objects material alpha (transparency if that is enabled) (range 0 to 1).
        /// </summary>
        public float MaterialAlpha
        {
            get { return materialAlpha; }
            set
            {
                materialAlpha = value;
            }
        }

        protected Vector3 diffuseColour = Vector3.One;
        /// <summary>
        /// Diffuse colour of the objects material (range 0 to 1).
        /// </summary>
        public Vector3 DiffuseColour
        {
            get { return diffuseColour; }
            set
            {
                diffuseColour = value;
            }
        }

        protected Vector3 emissiveColour = Vector3.Zero;
        /// <summary>
        /// The colour emitted from an objects materials (range 0 to 1).
        /// </summary>
        public Vector3 EmissiveColour
        {
            get { return emissiveColour; }
            set
            {
                emissiveColour = value;
            }
        }
        //

        // == Gear
        // Used for weapons to align them to the characters hands.
        // It can be made up by applying a rotation and translation.
        public Matrix BoneAlignment;

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
        // The character is suitable to be used as a player character
        public bool CanBeUsedAsPlayer = false;
        // Armature Rig type (Skeleton) used to calculate which animations to use  e.g. 'human'
        public string RigTypeName = "";
        // The weight of the character in kilograms (kg) used for physics simulations
        public float Mass = 80f;
        // The standing height of the character in metres (m)
        public float HeightStanding = 1.8f;
        // The crouched height of the character (m)
        public float HeightCrouched = 1.0f;
        // The radius of the collision cylinder that closely fits the character
        public float CylinderRadius = 0.5f;
        // The height over which a character can shoot while crouched but can duck behind
        public float MinimumCoverHeight = 0.75f;
        // The list of bounding spheres attached to bones used for more detailed collision with projectiles
        public List<AttachedSphere> AttachedBounds;
        // The list of equipment attachment points
        public List<AttachmentPoint> AttachEquip;
        // The list of adornment attachment points starting with the head
        public List<AttachmentPoint> AttachAdorn;
        // The hand to hold the weapon
        public AttachmentPoint AttachHold;
        // Angles to adjust the weapon position to face forwards
        public float BotDegreesStand = 0f;
        public float BotDegreesWalk = 0f;
        public float BotDegreesRun = -24.0f;
        public float BotDegreesCrouch = -13.0f;
        public float BotDegreesShuffle = -24.0f;
        // Angles to adjust the weapon position to line up with the cross hairs
        public float CameraDegreesStand = 9.0f;
        public float CameraDegreesWalk = 9.0f;
        public float CameraDegreesRun = -15.0f;
        public float CameraDegreesCrouch = -4.0f;
        public float CameraDegreesShuffle = -15.0f;


        // == Weapon
        // The source Human or Alien
        public int Manufacturer = 0;
        // The position of the muzzle in relation to the origin of the model
        public Vector3 MuzzleOffset;
        // Half the width of the weapon used to position the model lying on the ground
        public float HalfWidth = 0;
        // Ammo
        public string AmmoType = "";
        public int AmmoClipCapacity = 0;
        public int AmmoMaxCarried = 0;
        public float AmmoSecondsToReload = 0;
        // Calculated from the ammo fire rate
        public float AmmoSecondsToChamber = 0;
        public bool IsAutoFire = false;
        // Sounds
        public string FxReload = "";
        public string FxEmpty = "";
        // Optimum ranges used by the AI for the bots
        public float OptimumClosest = 0;
        public float OptimumFarthest = 0;
        // Recoil - How many degrees the weapon lifts each shot
        public float RecoilDegrees;
        // Zoom using a scope
        public List<float> ZoomMultipliers;
        // Sight cross hairs to use at each zoom level
        public List<int> CrossHairs;

        // For per triangle impact from projectiles
        // These remain null until calculated using ExposeVertices()
        public List<Vector3> Vertices;
        public List<VertexHelper.TriangleVertexIndices> Indices;

        // For calculation only not part of the model object in the game
        // Shots per second
        private float ammoRateOfFire = 1;
        public float AmmoRateOfFire
        {
            get { return ammoRateOfFire; }
            set { ammoRateOfFire = value; }
        }
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
        public void BuildModelAsset(string type, string filename, string effect, Model baseModel, BoundingSphere bounds, float rotXdegrees, float rotYdegrees, float rotZdegrees, string[] options)
        {
            ModelType = type;
            ModelFilename = filename;
            EffectType = effect;
            Replica = baseModel;
            OversizeBounds = bounds;
            Rotation = new Vector3(rotXdegrees, rotYdegrees, rotZdegrees);
            PreProcessSetup();
            ProcessOptions(options);
        }

        private void PreProcessSetup()
        {
            largerBounds = new List<StructureSphere>();
            smallerBounds = new List<StructureSphere>();
            BoneAlignment = Matrix.Identity;
            AttachedBounds = new List<AttachedSphere>();
            AttachAdorn = new List<AttachmentPoint>();
            AttachEquip = new List<AttachmentPoint>();
            MuzzleOffset = Vector3.Zero;
            ZoomMultipliers = new List<float>();
            CrossHairs = new List<int>();
        }

        private void ProcessOptions(string[] options)
        {
            if (options != null && Replica != null && ModelType != "")
            {
                SetDefaultValues();
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

        private void SetDefaultValues()
        {
            specularColour = new Vector3(GlobalSettings.colourSpecularGreyDefault);
            specularPower = 16f;
            diffuseColour = Vector3.One;
            emissiveColour = Vector3.Zero;
        }

        private void ExtractModelOption(string[] item)
        {
            // What have we got
            switch (item[0])
            {
                case GlobalSettings.typeColour:
                    if (item.Length > 5)
                    {
                        SetMaterialColours(item[1], item[2], item[3], item[4], item[5]);
                    }
                    break;
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
                        RigTypeName = item[1];
                    }
                    break;
                case GlobalSettings.typeBodySizes:
                    if (item.Length > 5)
                    {
                        SetBodySizes(item[1], item[2], item[3], item[4], item[5]);
                    }
                    else if (item.Length > 4)
                    {
                        SetBodySizes(item[1], item[2], item[3], item[4], "0.5");
                    }
                    break;
                case GlobalSettings.typeAttachedSpheres:
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
                    else if (item.Length > 2)
                    {
                        // Matrix
                        AddAttachEquipment(item[1], item[2]);
                    }
                    break;
                case GlobalSettings.typeAttachAdornment:
                    if (item.Length > 7)
                    {
                        AddAttachAdornment(item[1], item[2], item[3], item[4], item[5], item[6], item[7]);
                    }
                    else if (item.Length > 2)
                    {
                        // Matrix
                        AddAttachAdornment(item[1], item[2]);
                    }
                    break;
                case GlobalSettings.typeWeaponHoldBone:
                    if (item.Length > 7)
                    {
                        AddWeaponHold(item[1], item[2], item[3], item[4], item[5], item[6], item[7]);
                    }
                    else if (item.Length > 2)
                    {
                        // Matrix
                        AddWeaponHold(item[1], item[2]);
                    }
                    break;
                case GlobalSettings.typeBotAnimationAngles:
                    if (item.Length > 5)
                    {
                        SetBotLookAngles(item[1], item[2], item[3], item[4], item[5]);
                    }
                    break;
                case GlobalSettings.typeCameraAnimationAngles:
                    if (item.Length > 5)
                    {
                        SetCameraLookAngles(item[1], item[2], item[3], item[4], item[5]);
                    }
                    break;
                case GlobalSettings.typePlayerUse:
                    if (item.Length > 1)
                    {
                        SetForPlayerUse(item[1]);
                    }
                    break;
                case GlobalSettings.typeAimAdjustment:
                    if (item.Length > 6)
                    {
                        AddBoneAdjustment(item[1], item[2], item[3], item[4], item[5], item[6]);
                    }
                    else if (item.Length > 1)
                    {
                        SetAlignment(item[1]);
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
                    if (item.Length > 1)
                    {
                        SetMuzzleOffset(item[1]);
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
                        SetAmmo(item[1], item[2], item[3], item[4], item[5], item[6], item[7], item[8]);
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
                        RecoilDegrees = ParseData.FloatFromString(item[1]);
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
            Vector3 centre = ParseData.StringToVector3(items[1]);
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
            Vector3 centre = ParseData.StringToVector3(items[1]);
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

        private void SetBodySizes(string mass, string standing, string crouched, string radius, string cover)
        {
            Mass = ParseData.FloatFromString(mass);
            HeightStanding = ParseData.FloatFromString(standing);
            HeightCrouched = ParseData.FloatFromString(crouched);
            CylinderRadius = ParseData.FloatFromString(radius);
            MinimumCoverHeight = ParseData.FloatFromString(cover);
        }

        private void AddAttachedSphere(string boneName, string radius, string offset)
        {
            float fRadius = ParseData.FloatFromString(radius);
            Vector3 fOffset = ParseData.StringToVector3(offset);

            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            if (boneID >= 0)
            {
                AttachedBounds.Add(new AttachedSphere(boneID, fOffset, fRadius, fOffset));
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
            AttachEquip.Add(new AttachmentPoint(boneID, X, Y, Z, rotateX, rotateY, rotateZ));
        }

        private void AddAttachEquipment(string boneName, string mtxS)
        {
            // Offset from the bone position to the attachment point
            Matrix mtx = ParseData.StringToMatrix(mtxS);
            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            AttachEquip.Add(new AttachmentPoint(boneID, mtx));
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
            AttachAdorn.Add(new AttachmentPoint(boneID, X, Y, Z, rotateX, rotateY, rotateZ));
        }

        private void AddAttachAdornment(string boneName, string mtxS)
        {
            // Offset from the bone position to the attachment point
            Matrix mtx = ParseData.StringToMatrix(mtxS);
            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            AttachAdorn.Add(new AttachmentPoint(boneID, mtx));
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
            AttachHold = new AttachmentPoint(boneID, X, Y, Z, rotateX, rotateY, rotateZ);
        }

        private void AddWeaponHold(string boneName, string mtxS)
        {
            // Offset from the bone position to the attachment point
            Matrix mtx = ParseData.StringToMatrix(mtxS);
            // The model must have been loaded first so the bonemap works
            int boneID = GetBoneID(boneName);
            AttachHold = new AttachmentPoint(boneID, mtx);
        }

        private void SetBotLookAngles(string stand, string walk, string run, string crouch, string shuffle)
        {
            float degStand = ParseData.FloatFromString(stand);
            float degWalk = ParseData.FloatFromString(walk);
            float degRun = ParseData.FloatFromString(run);
            float degCrouch = ParseData.FloatFromString(crouch);
            float degShuffle = ParseData.FloatFromString(shuffle);
            BotDegreesStand = degStand;
            BotDegreesWalk = degWalk;
            BotDegreesRun = degRun;
            BotDegreesCrouch = degCrouch;
            BotDegreesShuffle = degShuffle;
        }

        private void SetCameraLookAngles(string stand, string walk, string run, string crouch, string shuffle)
        {
            float degStand = ParseData.FloatFromString(stand);
            float degWalk = ParseData.FloatFromString(walk);
            float degRun = ParseData.FloatFromString(run);
            float degCrouch = ParseData.FloatFromString(crouch);
            float degShuffle = ParseData.FloatFromString(shuffle);
            CameraDegreesStand = degStand;
            CameraDegreesWalk = degWalk;
            CameraDegreesRun = degRun;
            CameraDegreesCrouch = degCrouch;
            CameraDegreesShuffle = degShuffle;
        }

        private void SetForPlayerUse(string enable)
        {
            CanBeUsedAsPlayer = ParseData.ShortStringToBool(enable);
        }

        // Return the bone number from the bone name
        private int GetBoneID(string boneName)
        {
            // Look up our custom skinning information.
            SkinningData skinningData = Replica.Tag as SkinningData;
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

        // This method is not efficient but should be reliable.
        public string GetBoneName(int ID)
        {
            // Look up our custom skinning information.
            SkinningData skinningData = Replica.Tag as SkinningData;
            if (skinningData == null)
            {
                //This model does not contain a SkinningData tag.
                throw new Exception("This character cannot be animated because the skinning data is missing!");
            }
            else
            {
                List<string> list = new List<string>();
                // Get all the bone names
                list.AddRange(skinningData.BoneMap.Keys);
                for ( int i = 0; i < list.Count; i++)
                {
                    // Try each bone in turn
                    if (skinningData.BoneMap[list[i]] == ID)
                    {
                        // When the bone ID matches
                        // return the name of the bone
                        return list[i];
                    }
                }
            }
            return "None";
        }

        // == Weapons

        private void SetManufacturer(string id)
        {
            Manufacturer = ParseData.IntFromString(id);
        }

        private void SetZoomMultipliers(string[] sZooms)
        {
            // The first item will be the type so skip it
            for (int i = 1; i < sZooms.Length; i++)
            {
                ZoomMultipliers.Add(ParseData.FloatFromString(sZooms[i]));
            }
        }

        private void SetSightTypes(string[] sTypes)
        {
            // The first item will be the type so skip it
            for (int i = 1; i < sTypes.Length; i++)
            {
                CrossHairs.Add(ParseData.IntFromString(sTypes[i]));
            }
        }

        private void SetMuzzleOffset(string sOffset)
        {
            MuzzleOffset = ParseData.StringToVector3(sOffset);
        }

        private void SetHalfWidth(string sWidth)
        {
            HalfWidth = ParseData.FloatFromString(sWidth);
        }

        private void SetAmmo(string sType, string sClip, string sCarried, string autoFire, string sFireRate, string sReloadTime, string sReloadSound, string sEmptySound)
        {
            AmmoType = sType;
            AmmoClipCapacity = ParseData.IntFromString(sClip);
            AmmoMaxCarried = ParseData.IntFromString(sCarried);
            IsAutoFire = ParseData.ShortStringToBool(autoFire);
            float rate = ParseData.FloatFromString(sFireRate);
            ammoRateOfFire = rate;
            // Calculate the time to chamber from the rate of fire
            if (MoreMaths.NearZero(rate))
            {
                // Very quick
                AmmoSecondsToChamber = 0.01f;
            }
            else
            {
                AmmoSecondsToChamber = 1.0f / rate;
            }
            AmmoSecondsToReload = ParseData.FloatFromString(sReloadTime);
            FxReload = sReloadSound;
            FxEmpty = sEmptySound;
        }

        private void SetRanges(string sClose, string sFar)
        {
            OptimumClosest = ParseData.FloatFromString(sClose);
            OptimumFarthest = ParseData.FloatFromString(sFar);
        }

        // == Gear

        // Bone alignment is used to adjust the models so they are all in the same position 
        // relative to the rest of the model despite how they are drawn.
        // Typically only necessary to make fine adjustments to how the weapon is held
        // in the animated models hand.

        // Older hand crafted model files use separate translation and rotation settings
        // Newer model files save the resulting matrix to the model file

        // Adjustments to alignments are applied in the order they are in the XML file.
        // As a matrix rotation changes the axes a rotation followed by a translation will be 
        // difficult to understand.  A translation followed by a rotation is easier to visualise.

        private void AddBoneAdjustment(string sX, string sY, string sZ, string sDegX, string sDegY, string sDegZ)
        {
            AddBoneRotation(sDegX, sDegY, sDegZ);
            AddBoneTranslate(sX, sY, sZ);
        }

        private void SetAlignment(string adjust)
        {
            Matrix align = ParseData.StringToMatrix(adjust);
            BoneAlignment = align;
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
            BoneAlignment *= Matrix.CreateTranslation(ParseData.FloatFromString(sX),
                ParseData.FloatFromString(sY), ParseData.FloatFromString(sZ));
        }

        private void AddBoneRotation(string sDegX, string sDegY, string sDegZ)
        {
            // Rotate to face forwards (-Up +Down, -Left +Right, +Up -Down) (100, 59, 56)
            float radX = MathHelper.ToRadians(ParseData.FloatFromString(sDegX));
            float radY = MathHelper.ToRadians(ParseData.FloatFromString(sDegY));
            float radZ = MathHelper.ToRadians(ParseData.FloatFromString(sDegZ));
            BoneAlignment *= Matrix.CreateRotationX(radX) *
                Matrix.CreateRotationY(radY) *
                Matrix.CreateRotationZ(radZ);
        }

        // == All models

        private void SetMaterialColours(string specularPower, string specularColour, string materialAlpha, string diffuseColour, string emissiveColour)
        {
            SpecularPower = ParseData.FloatFromString(specularPower);
            SpecularColour = ParseData.StringToVector3(specularColour);
            MaterialAlpha = ParseData.FloatFromString(materialAlpha);
            DiffuseColour = ParseData.StringToVector3(diffuseColour);
            EmissiveColour = ParseData.StringToVector3(emissiveColour);
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
            if (Vertices == null)
            {
                Vertices = new List<Vector3>();
            }
            else
            {
                Vertices.Clear();
            }
            if (Indices == null)
            {
                Indices = new List<VertexHelper.TriangleVertexIndices>();
            }
            else
            {
                Indices.Clear();
            }
            // In object space
            VertexHelper.ExtractTrianglesFrom(Replica, original, Indices, Matrix.Identity);

            foreach (Vector3 vec in original)
            {
                // Create a duplicate for each model
                // NOTE: I don't think this is necessary but it is to rule this out as a 
                // possible cause of errors.
                Vertices.Add(new Vector3(vec.X, vec.Y, vec.Z));
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
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vector3 current = Vertices[i];
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
            return Indices.Count;
        }

                // Set the size and position of the triangle provided to be that of the triangle index
        // specified.
        // This is called frequently so error checking has deliberately
        // not been included.
        public void GetTriangle(ref int index, ref Triangle triangle)
        {
            triangle.Resize(Vertices[Indices[index].A], Vertices[Indices[index].B],
                Vertices[Indices[index].C]);
        }

        // This creates a copy of the triangle in world space
        // This adds to the heap so is bad for Garbage collection
        // Only use during level loading or saving never mid game
        public Triangle GetTriangle(int index)
        {
            if (Vertices != null && Indices != null && index > -1 && index < Indices.Count)
            {
                return new Triangle(Vertices[Indices[index].A], Vertices[Indices[index].B],
                    Vertices[Indices[index].C]);
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
            if (Vertices != null && Indices != null && Indices.Count > 0)
            {
                for (int i = 0; i < Indices.Count; i++)
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
