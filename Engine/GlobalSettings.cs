#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
#endregion

namespace Engine
{
    public static class GlobalSettings
    {
        // Parse FBX files (lowercase)
        public const string fbxStartTakes = "takes:";
        public const string fbxCurrentTake = "current:";
        public const string fbxStartTake = "take:";
        public const string fbxNotStartTake = "multitake:";
        public const string fbxStartSection = "{";
        public const string fbxEndSection = "}";

        // Paths and files
        //public const string pathContentFolder = "../../../Content/"; // The relative path to the content folder
        //public const string fileFloor = "grid.fbx"; // The local path to the content
        public const string timeFormat = "yyyymmddhhmmss";  // Names that need to be unique
        public const string pathSaveGameFolder = "SavedGames";   // Same as the XNA default
        public const string pathSaveDataFolder = "PrepModels";  // used to load and save the results
        public const string fileBoneMap = "BoneMap.txt";    // appended to the model name to save a bonemap
        public const string fileBindPose = "BindPose.txt";    // appended to the model name to save a bind pose
        public const string settingsFileExcludingExtension = "Model";   // Use this is no other name available
        public const string settingsFileExtension = ".model";   // The extension for model settings files

        // Save keyframes
        // All lowercase
        public const string itemRigType = "rigtype";
        public const string itemHeadBones = "headbones";
        public const string itemArmsBones = "armbones";
        public const string itemClipTake = "clip";
        public const string itemHeadTake = "head";
        public const string itemArmsTake = "arms";

        // Names
        public const string listRestPoseName = "* Rest or bind pose";

        // Models
        public const string modelTypeCharacter = "Character";
        public const string modelTypeStructure = "Structure";
        public const string modelTypeEquipLight = "WeaponLight";
        public const string modelTypeEquipSupport = "WeaponSupport";
        public const string modelTypeEquipSmallArms = "WeaponSmall";
        public const string modelTypeEquipGrenade = "WeaponGrenade";
        public const string modelTypeGearHead = "HeadGear";
        public const string modelTypeGearAccessory = "Accessory";
        public const string modelTypeGearOther = "OtherGear";
        // Default effect type
        public const string effectTypeNone = "None";
        // Normal map is a texture containing the normal directions
        public const string effectTypeNormalMap = "NormalMap";
        // Bump map is a grey scale containing depth levels as grey scales
        public const string effectTypeBumpMap = "BumpMap";
        // == Types of object that can be loaded from the model file
        // These are used to parse the data from the file because not all models have 
        // all the types of data.
        // Armature Rig type used to prefix animation filenames (Skeleton) e.g. human, insect, robot etc.
        public const string typeRig = "RigType";
        // Idle animation for characters when they are loaded or not doing anything else
        public const string typeAnimation = "Idle";
        // Bounding shapes used for structures
        public const string typeLargerBounds = "Lb";
        public const string typeSmallerBounds = "Sb";
        // Bounding spheres to make up the collision shape of the character
        // Must be listed in the same order.  Usually head first working down.
        public const string typeLargerSpheres = "Ls";
        public const string typeSmallerSpheres = "Ss";
        // Adjusts the weapon to align the grips with the hand bones so that the grips remain
        // in the right place while aiming.
        // These are offsets from the model origin in object space
        public const string typeAimAdjustment = "AimAdjust";
        // Other attachement positions
        public const string typeHeadOffset = "HeadOffset";
        // Attachment points load in order
        public const string typeAttachEquipment = "AttachEquip";
        // Matches the position of the gear types
        public const string typeAttachAdornment = "AttachAdorn";
        public const string typeWeaponHoldBone = "AttachHold";
        // Bone that the gear is usually attached to
        public const string typeBone = "Bone";
        // The equipment manufacturer Human or Alien stored as an integer, 0 or 1
        public const string typeManufacturer = "Manufacturer";
        // Muzzle location relative to the position of the model
        public const string typeWeaponMuzzle = "Muzzle";
        // The thickness of the weapon used for laying on the ground or attached to the character
        public const string typeWeaponHalfWidth = "HalfWidth";
        // Ammunition 
        // particle effect, clip capacity, maximum carried, 
        // shots per second +=autofire -=single shot, time to reload
        // reload sound, empty sound
        // Ammo|Bullet|4|8|-2|1.6|GunReload1|GunEmpty1
        public const string typeWeaponAmmo = "Ammo";
        // Weapon ranges, closest optimum and farthest optimum ranges.
        public const string typeWeaponRanges = "Ranges";
        // Recoil degrees
        public const string typeWeaponRecoil = "Recoil";
        // Zoom multipliers
        public const string typeWeaponZoom = "Zoom";
        // CrossHairs
        public const string typeWeaponSights = "CrossHairs";

        // Movement
        public const float defaultMoveSpeed = 0.6f;
        public const float defaultTurnSpeed = 1.0f;
        // Where the mouse cursor sits during mouse movement
        public const int mouseZeroX = 15;
        public const int mouseZeroY = 15;
        // Lighting
        public const float defaultEmissive = 0.25f;
        public const float defaultAmbient = 0.75f;
        public const float defaultDiffuse = 0.45f;

        // Structure bounding spheres
        // These sizes are applicable to the scale used in Diabolical
        // If the models are too large the bounds will throw an exception!
        // The width of the smallest bounding box
        // The final result is converted to a sphere which will have a diameter equal 
        // to the corner to corner size of this box.
        public const float miniBoxWidth = 0.7f;
        // The number of miniBoxWidths which make up the next larger sphere diameter.
        // If their width multiple is too large there will be too many ray intersections
        // for the xbox to test quickly.
        public const float widthMultiple = 3.0f;


    }
}
