#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AssetData;
#endregion

namespace Engine
{
    public class ParseClips
    {
        // Main form used to display results
        private MainForm form;

        public ParseClips(MainForm parentForm)
        {
            form = parentForm;
        }

        /// <summary>
        /// Loads a text file and converts to an animation clip
        /// </summary>
        public AnimationClip Load(string fileName)
        {
            string[] result = new string[0];

            if (File.Exists(fileName))
            {
                result = File.ReadAllLines(fileName);
            }
            else
            {
                form.AddMessageLine("File not found: " + fileName);
                return null;
            }

            if (result == null || result.Length < 1)
            {
                form.AddMessageLine("Empty file: " + fileName);
                return null;
            }

            return ProcessData(result, fileName);
        }

        public AnimationClip ProcessData(string[] input, string fullFile)
        {
            // If there is nothing do not process anything
            if (input.Length < 1)
            {
                return null;
            }

            form.AddMessageLine("Processing file: " + fullFile);

            // First line of the file
            string[] data = ParseData.SplitNumbersAtSpaces(input[0]);
            int count = ParseData.IntFromString(data[0]);
            TimeSpan duration = ParseData.TimeFromString(data[1]);
            List<TimeSpan> steps = new List<TimeSpan>();
            if (data.Length > 2)
            {
                // The rest of the first line are the frame times for the sounds of foot steps
                for (int d = 2; d < data.Length; d++)
                {
                    steps.Add(ParseData.TimeFromString(data[d]));
                }
            }
            IList<Keyframe> keyFrames = new List<Keyframe>();
            if (input.Length < 2)
            {
                form.AddMessageLine("There are no key frames in this file!");
                return null;
            }
            // Now add all the frames
            for (int i = 1; i < input.Length; i++)
            {
                string[] item = ParseData.SplitItemByDivision(input[i]);
                data = ParseData.SplitNumbersAtSpaces(item[0]);
                keyFrames.Add(new Keyframe(ParseData.IntFromString(data[0]),
                                                        ParseData.TimeFromString(data[1]),
                                                        ParseData.StringToMatrix(item[1])));
            }
            return new AnimationClip(count, duration, keyFrames, steps);
        }

        /// <summary>
        /// Get the animation clip in the format used to save and load clips.
        /// boneFilter is a list of bones to match that will be saved all other discarded
        /// leave null or empty to select all bones
        /// </summary>
        public static List<string> GetAnimationClipData(AnimationClip clip, IDictionary<string, int> BoneMap, List<string> bonesFilter)
        {
            bool IsClip = false;
            if (bonesFilter == null || bonesFilter.Count < 1 || BoneMap == null)
            {
                IsClip = true;
            }

            // This is where we store the lines to export to the file
            List<string> data = new List<string>();

            if (IsClip)
            {
                // CLIP
                // Add the details from the AnimationClip
                string output = ParseData.IntToString(clip.BoneCount) + " " + ParseData.TimeToString(clip.Duration);
                // Add the sound times
                for (int s = 0; s < clip.SoundFrameTimes.Count; s++)
                {
                    output += " " + ParseData.TimeToString(clip.SoundFrameTimes[s]);
                }
                data.Add(output);
            }
            else
            {
                // PART, head or arms
                // Use the details from the AnimationClip to create the AnimationPart file
                // Add the extra header information for, max, min and defaultFrame
                data.Add(String.Format("{0} {1} {2} {3}",
                    ParseData.IntToString(clip.BoneCount),
                    ParseData.FloatToString(GlobalSettings.armAnimateAngleUp),
                    ParseData.FloatToString(GlobalSettings.armAnimateAngleDown),
                    ParseData.FloatToString(((
                                (float)clip.Keyframes.Count /
                                (float)clip.BoneCount) + 1)
                                * 0.5f)));  // The middle frame if the first frame is zero

                
            }

            IList<Keyframe> frames = clip.Keyframes;
            if (frames == null)
            {
                data.Clear();
                // Animation does not have any frames
                return null;
            }

            // Add each keyframe
            WantedBones BoneTest = new WantedBones(BoneMap, bonesFilter);
            for (int i = 0; i < frames.Count; i++)
            {
                // FRAME
                // Include some or all of the bones to create 
                // either an AnimationClip or AnimationPart file
                if (IsClip || BoneTest.IsBoneWeWant(frames[i].Bone))
                {
                    data.Add(String.Format("{0} {1}{2}{3}",
                        ParseData.IntToString(frames[i].Bone),
                        ParseData.TimeToString(frames[i].Time),
                        ParseData.div,
                        ParseData.MatrixToString(frames[i].Transform)));
                }
            }
            return data;
        }

        public static AnimationClip MergeClips(AnimationClip upper, AnimationClip lower, IDictionary<string, int> BoneMap, List<string> upperBonesFilter)
        {
            // Only valid if both clips are for the same skeleton
            int boneCount = upper.BoneCount;
            if (lower.BoneCount != boneCount)
            {
                return null;
            }

            TimeSpan duration = lower.Duration;
            if (upper.Duration > lower.Duration)
            {
                duration = upper.Duration;
            }
            // The foot sounds only come from the lower bones.
            List<TimeSpan> steps = lower.SoundFrameTimes;

            IList<Keyframe> keyframes = new List<Keyframe>();
            IList<Keyframe> upperframes = upper.Keyframes;
            IList<Keyframe> lowerframes = lower.Keyframes;

            WantedBones UpperBoneTest = new WantedBones(BoneMap, upperBonesFilter);

            int nextUpper = 0;
            int nextLower = 0;

            while (nextLower < lowerframes.Count)
            {
                while (nextUpper < upperframes.Count &&
                    upperframes[nextUpper].Time <= lowerframes[nextLower].Time)
                {
                    if (UpperBoneTest.IsBoneWeWant(upperframes[nextUpper].Bone))
                    {
                        keyframes.Add(upperframes[nextUpper]);
                    }
                    nextUpper++;
                }
                if (!UpperBoneTest.IsBoneWeWant(lowerframes[nextLower].Bone))
                {
                    keyframes.Add(lowerframes[nextLower]);
                }
                nextLower++;
            }
            // Add the remainder
            if (nextUpper < upperframes.Count)
            {
                for (int i = nextUpper; i < upperframes.Count; i++)
                {
                    if (UpperBoneTest.IsBoneWeWant(upperframes[nextUpper].Bone))
                    {
                        keyframes.Add(upperframes[i]);
                    }
                }
            }

            return new AnimationClip(boneCount, duration, keyframes, steps);
        }

    }
}
