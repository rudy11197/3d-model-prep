#region File Description
//-----------------------------------------------------------------------------
// ModelViewerControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using AssetData;
using Keys = Microsoft.Xna.Framework.Input.Keys;
#endregion

namespace Engine
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, and displays
    /// a spinning 3D model. The main form class is responsible for loading
    /// the model: this control just displays it.
    /// </summary>
    class ModelViewerControl : GraphicsDeviceControl
    {
        /// <summary>
        /// Gets or sets the current model.
        /// </summary>
        public Model Model
        {
            get { return model; }
        }
        private Model model;
        private AnimationPlayer animationPlayer;

        // Animations
        public List<string> ClipNames
        {
            get { return clipNames; }
        }
        private List<string> clipNames = new List<string>();

        public bool IsAnimated
        {
            get { return isAnimated; }
            set { isAnimated = value; }
        }
        private bool isAnimated = false;

        public Model Floor
        {
            get { return floor; }
        }
        private Model floor;

        private bool showFloor = false;
        private Vector3 floorCentre = Vector3.Zero;
        private float floorRadius = 30;

        /// <summary>
        /// Which way up the camera is
        /// 1 = Y Up (XNA)
        /// 2 = Z Up (Blender)
        /// 3 = Z Down
        /// </summary>
        public int ViewUp
        {
            get { return viewUp; }
            set { viewUp = value; }
        }
        private int viewUp = 1;

        // Used every frame
        Matrix world = Matrix.Identity;
        Matrix view = Matrix.Identity;
        Matrix projection = Matrix.Identity;

        // Cache information about the model size and position.
        Matrix[] boneTransforms;
        Vector3 modelCentre;
        float modelRadius;
        // Camera movement
        Vector3 eyePosition = Vector3.Zero;
        Vector3 xAxisSide = Vector3.Zero;
        Vector3 yAxisUp = Vector3.Zero;
        Vector3 zAxisForward = Vector3.Zero;
        // Movement each update X = sideways, Y = up down, Z = forward back
        Vector3 moveDelta = Vector3.Zero;
        // Movement is based on the size of the model
        private const float defaultMoveFraction = 0.6f;
        private float currentMoveFraction = defaultMoveFraction;
        public float CurrentMoveFraction
        {
            get { return currentMoveFraction; }
            set 
            { 
                currentMoveFraction = value;
                CalculateMoveSpeed();
            }
        }
        // The default movemet is multiplied by the radius of the model bounds
        private float movePerSec = defaultMoveFraction;

        // Timer controls the movement speed.
        Stopwatch timer;
        // Keep track of elapsed time
        TimeSpan previousTime;
        TimeSpan currentTime;
        TimeSpan elapsedGameTime;

        //////////////////////////////////////////////////////////////////////
        // == Change ==
        //
        /// <summary>
        /// Set the model and return any error messages
        /// </summary>
        public string SetModel(bool animated, Model aModel)
        {
            string result = "";
            isAnimated = animated;
            if (aModel != null)
            {
                model = aModel;
                MeasureModel();
            }

            if (isAnimated)
            {
                // Look up our custom skinning information.
                SkinningData skinningData = model.Tag as SkinningData;

                if (skinningData == null)
                {
                    result += "\nThis model does not contain a SkinningData tag.";
                    isAnimated = false;
                }
                // Check again to make sure it is still treated as animated
                if (isAnimated)
                {
                    // Create an animation player, and start decoding an animation clip.
                    animationPlayer = new AnimationPlayer(skinningData);
                    clipNames.AddRange(skinningData.AnimationClips.Keys);

                    if (clipNames.Count > 0)
                    {
                        //AnimationClip clip = skinningData.AnimationClips["Take 001"];
                        AnimationClip clip = skinningData.AnimationClips[clipNames[0]];
                        result += "\nClip: " + clipNames[0];
                        string error = animationPlayer.StartClip(clip);
                        if (!string.IsNullOrEmpty(error))
                        {
                            result += "\n" + error;
                        }
                    }
                    else
                    {
                        result += "\nThis model does not have any takes!";
                    }
                }

            }
            ResetViewingPoint();
            return result;
        }

        public AnimationClip GetCurrentClip()
        {
            if (isAnimated && animationPlayer != null)
            {
                return animationPlayer.CurrentClip;
            }
            return null;
        }

        public void SetClipName(string name)
        {
            if (isAnimated && model != null && animationPlayer != null)
            {
                // Look up our custom skinning information.
                SkinningData skinningData = model.Tag as SkinningData;
                // Make sure the animation exists in the model
                if (skinningData == null ||
                    !skinningData.AnimationClips.ContainsKey(name))
                {
                    return;
                }
                // Change the animation
                AnimationClip clip = skinningData.AnimationClips[name];
                animationPlayer.StartClip(clip);
            }
        }

        // returns any error message
        public string SetExternalClip(AnimationClip clip)
        {
            if (isAnimated && model != null && animationPlayer != null)
            {
                // Change the animation
                return animationPlayer.StartClip(clip);
            }
            return "The model is not animated!";
        }

        public void UnloadModel()
        {
            isAnimated = false;
            clipNames.Clear();
            animationPlayer = null;
            model = null;
        }

        public void SetFloor(Model aModel)
        {
            if (aModel != null)
            {
                floor = aModel;
            }
        }

        public bool ShowFloor(bool enable)
        {
            if (floor != null)
            {
                showFloor = enable;
            }
            else
            {
                showFloor = false;
            }
            return showFloor;
        }

        private void CalculateMoveSpeed()
        {
            // The movement speed is based on the size of the model
            movePerSec = modelRadius * defaultMoveFraction;
        }

        public void ResetViewingPoint()
        {
            CalculateMoveSpeed();
            //distanceFraction = 1.0f;
            moveDelta = Vector3.Zero;
            // Initial viewing location
            eyePosition = modelCentre;
            float away = modelRadius * 2;
            float up = modelRadius;
            // Change which way up the model is viewed
            if (viewUp == 3)
            {
                // Z Down
                eyePosition.Y += away;
                eyePosition.Z += up;
            }
            else if (viewUp == 2)
            {
                // Z Up (Blender default)
                eyePosition.Y += away;
                eyePosition.Z += up;
            }
            else
            {
                // XNA Default
                eyePosition.Z += away;
                eyePosition.Y += up;
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Game ==
        //
        /// <summary>
        /// Simulated update called prior to the draw method
        /// </summary>
        protected override void UpdateGameLoop()
        {
            currentTime = timer.Elapsed;
            elapsedGameTime = currentTime - previousTime;
            previousTime = currentTime;

            HandleInput();

            if (isAnimated && model != null && animationPlayer != null)
            {
                animationPlayer.Update(elapsedGameTime, true, Matrix.Identity);
            }
        }

        // Try to work on English, German and French keyboards
        private void HandleInput()
        {
            moveDelta = Vector3.Zero;
            // Sideways
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                moveDelta.X = ((float)elapsedGameTime.TotalSeconds * movePerSec) * -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                moveDelta.X = ((float)elapsedGameTime.TotalSeconds * movePerSec);
            }

            // Up Down
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                moveDelta.Y = ((float)elapsedGameTime.TotalSeconds * movePerSec) * -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                moveDelta.Y = ((float)elapsedGameTime.TotalSeconds * movePerSec);
            }
            
            // Forward Back
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                moveDelta.Z = ((float)elapsedGameTime.TotalSeconds * movePerSec) * -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                moveDelta.Z = ((float)elapsedGameTime.TotalSeconds * movePerSec);
            }
            CalculateAxes();
            CalculateCameraPosition();
        }

        private void CalculateCameraPosition()
        {
            eyePosition += xAxisSide * moveDelta.X;
            eyePosition += yAxisUp * moveDelta.Y;
            eyePosition += zAxisForward * moveDelta.Z;
        }

        private void CalculateAxes()
        {
            // Relative to the current look direction
            zAxisForward = Vector3.Normalize(modelCentre - eyePosition);
            // Change which way up the model is viewed
            if (viewUp == 3)
            {
                // Z Down
                yAxisUp = Vector3.Forward;
            }
            else if (viewUp == 2)
            {
                // Z Up (Blender default)
                yAxisUp = Vector3.Backward;
            }
            else
            {
                // XNA Default
                yAxisUp = Vector3.Up;
            }
            xAxisSide = Vector3.Normalize(Vector3.Cross(yAxisUp, zAxisForward));
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
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Display ==
        //
        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            // Clear to the default control background color.
            Color backColor = new Color(BackColor.R, BackColor.G, BackColor.B);

            GraphicsDevice.Clear(backColor);
            float aspectRatio = GraphicsDevice.Viewport.AspectRatio;

            if (model != null)
            {

                float nearClip = modelRadius / 100;
                float farClip = modelRadius * 100;

                // Compute camera matrices.
                world = Matrix.Identity;
                view = Matrix.CreateLookAt(eyePosition, modelCentre, yAxisUp);
                projection = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio, nearClip, farClip);

                // Set states ready for 3D
                GraphicsDevice.BlendState = BlendState.Opaque;
                GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                if (isAnimated)
                {
                    DrawAnimated(world, view, projection);
                }
                else
                {
                    DrawRigid(world, view, projection, model);
                }

                if (showFloor && floor != null)
                {
                    // Change the size of the floor based on the model size
                    float scale = modelRadius / floorRadius;
                    world = Matrix.CreateScale(scale);
                    DrawRigid(world, view, projection, floor);
                }
            }
            else if (showFloor && floor != null)
            {
                // Still show the floor even if no model has been loaded
                float nearClip = floorRadius / 100;
                float farClip = floorRadius * 100;

                projection = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio, nearClip, farClip);

                Vector3 eyePosition = floorCentre;
                eyePosition.Z += floorRadius * 2;
                eyePosition.Y += floorRadius;
                world = Matrix.CreateTranslation(floorCentre);
                view = Matrix.CreateLookAt(eyePosition, floorCentre, Vector3.Up);

                DrawRigid(world, view, projection, floor);
            }

        }

        private void DrawAnimated(Matrix world, Matrix view, Matrix projection)
        {
            Matrix[] bones = animationPlayer.GetSkinTransforms();

            // Render the skinned mesh.
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (SkinnedEffect effect in mesh.Effects)
                {
                    effect.SetBoneTransforms(bones);

                    // Added to move model
                    effect.World = boneTransforms[mesh.ParentBone.Index] * world;

                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();

                    effect.SpecularColor = new Vector3(0.25f);
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
        }

        private void DrawRigid(Matrix world, Matrix view, Matrix projection, Model aModel)
        {
            // Draw the model.
            foreach (ModelMesh mesh in aModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    if (boneTransforms != null)
                    {
                        effect.World = boneTransforms[mesh.ParentBone.Index] * world;
                    }
                    else
                    {
                        effect.World = world;
                    }
                    effect.View = view;
                    effect.Projection = projection;

                    // Add a bit more light to our animated models
                    //effect.EmissiveColor = new Vector3(0.8f, 0.8f, 0.8f);
                    //effect.LightingEnabled = true;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Setup ==
        //
        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            // Start the animation timer.
            timer = Stopwatch.StartNew();
            currentTime = timer.Elapsed;
            previousTime = currentTime;

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }

        /// <summary>
        /// Whenever a new model is selected, we examine it to see how big
        /// it is and where it is centered. This lets us automatically zoom
        /// the display, so we can correctly handle models of any scale.
        /// </summary>
        void MeasureModel()
        {
            // Look up the absolute bone transforms for this model.
            boneTransforms = new Matrix[model.Bones.Count];
            
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            // Compute an (approximate) model center position by
            // averaging the center of each mesh bounding sphere.
            modelCentre = Vector3.Zero;

            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[mesh.ParentBone.Index];
                Vector3 meshCenter = Vector3.Transform(meshBounds.Center, transform);

                modelCentre += meshCenter;
            }

            modelCentre /= model.Meshes.Count;

            // Now we know the center point, we can compute the model radius
            // by examining the radius of each mesh bounding sphere.
            modelRadius = 0;

            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[mesh.ParentBone.Index];
                Vector3 meshCenter = Vector3.Transform(meshBounds.Center, transform);

                float transformScale = transform.Forward.Length();
                
                float meshRadius = (meshCenter - modelCentre).Length() +
                                   (meshBounds.Radius * transformScale);

                modelRadius = Math.Max(modelRadius,  meshRadius);
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
