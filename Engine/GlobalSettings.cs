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
        // Arm movement limits
        public const float armAnimateAngleUp = 60.0f;
        public const float armAnimateAngleDown = -60.0f;
        // All lowercase
        public const string itemRigType = "rigtype";
        public const string itemHeadBones = "headbones";
        public const string itemArmsBones = "armbones";
        public const string itemClipTake = "clip";
        public const string itemHeadTake = "head";
        public const string itemArmsTake = "arms";
        public const string itemMergeClips = "merge";

        // Names
        public const string listRestPoseName = "* Rest or bind pose";

        // Model Files
        public const string modelSaveFormatType = "2";
        // Effects
        public const string effectTypeNormalMap = "NormalMap";
        public const string effectTypeAnimated = "Animated";
        public const string effectTypeRigid = "Rigid";
        public const float colourSpecularGreyDefault = 0.25f;
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
        // == Types of object that can be loaded from the model file
        // These are used to parse the data from the file because not all models have 
        // all the types of data.
        // A short description of the item mainly for use by gear and weapons
        public const string typeDisplayName = "DisplayName";
        public const string typeDescription = "Description";
        // Can be used as a player character, True or False
        public const string typePlayerUse = "UseAsPlayer";
        // Armature Rig type used to prefix animation filenames (Skeleton) e.g. human, insect, robot etc.
        public const string typeRig = "RigType";
        // The various material colours for lighting
        public const string typeColour = "Colour";
        // Idle animation for characters when they are loaded or not doing anything else
        public const string typeAnimation = "Idle";
        // Bounding shapes used for structures
        public const string typeLargerBounds = "Lb";
        public const string typeSmallerBounds = "Sb";
        // Dimensions used to create the bounding shapes for the character
        public const string typeBodySizes = "BodySizes";
        // Bounding spheres to make up the collision shape of the character
        // Must be listed in the same order.  Usually head first working down.
        public const string typeLargerSpheres = "Ls";
        public const string typeAttachedSpheres = "Ss";
        // Adjusts the weapon to align the grips with the hand bones so that the grips remain
        // in the right place while aiming.
        // These are offsets from the model origin in object space
        // Can be individual rotations and transformations or a single matrix
        public const string typeAimAdjustment = "AimAdjust";
        // Other attachement positions
        public const string typeHeadOffset = "HeadOffset";
        // Attachment points load in order 
        // Can be individual rotations and transformations or a single matrix
        public const string typeAttachEquipment = "AttachEquip";
        // Matches the position of the gear types
        // Can be individual rotations and transformations or a single matrix
        public const string typeAttachAdornment = "AttachAdorn";
        // Can be individual rotations and transformations or a single matrix
        public const string typeWeaponHoldBone = "AttachHold";
        // The angles to adjust the animations to look in the right direction
        public const string typeBotAnimationAngles = "BotLookAngles";
        public const string typeCameraAnimationAngles = "CameraLookAngles";
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

        // Structure bounding spheres
        // These sizes are applicable to the scale used in Diabolical
        // If the models are too large the bounds will throw an exception!
        // The width of the smallest bounding box
        // The final result is converted to a sphere which will have a diameter equal 
        // to the corner to corner size of this box.
        public const float boundSmallerWidth = 0.7f;
        // The number of MiniBoxWidths which make up the next larger sphere diameter.
        // If their width multiple is too large there will be too many ray intersections
        // for the xbox to test quickly.
        public const float boundLargerMultiple = 3.0f;
        // Character bounds
        public const float boundAttachedRadius = 0.5f;

    }
}
