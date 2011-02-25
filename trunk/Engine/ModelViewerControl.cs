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
        private float originalFloorRadius = 30;
        // Calculated from the scale
        private float floorRadius = 30;
        private float floorScale = 1.0f;

        /// <summary>
        /// Which way up the camera is
        /// 1 = Y Up (XNA)
        /// 2 = Z Up (Blender)
        /// 3 = Z Down
        /// </summary>
        public int ViewUp
        {
            get { return viewUp; }
            set 
            { 
                viewUp = value;
                InitialiseCameraPosition();
            }
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
        KeyboardState currentKeyboardState;
        Vector3 cameraPosition = Vector3.Zero;
        // Camera Axes calculated before use
        Vector3 cameraUp = Vector3.Zero;
        Vector3 cameraForward = Vector3.Zero;
        // Movement
        private const float defaultMoveSpeed = 1.0f;
        private const float defaultTurnSpeed = 1.0f;
        public float CurrentMoveSpeed
        {
            get { return movePerSec; }
            set { movePerSec = value; }
        }
        private float movePerSec = defaultMoveSpeed;
        public float CurrentTurnSpeed
        {
            get { return turnPerSec; }
            set { turnPerSec = value; }
        }
        private float turnPerSec = defaultTurnSpeed;

        // Timer controls the movement speed.
        Stopwatch timer;
        // Keep track of elapsed time
        TimeSpan previousTime;
        TimeSpan currentTime;
        TimeSpan elapsedGameTime;

        // For clearing the screen in the game
        // This is changed to match the control colour
        Color gameBackColor = Color.CornflowerBlue;

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
                InitialiseCameraPosition();
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
                InitialiseCameraPosition();
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

        private void CalculateAxes()
        {
            // Change which way up the model is viewed
            if (viewUp == 3)
            {
                // Z Down
                cameraUp = Vector3.Forward;
                cameraForward = Vector3.Down;
            }
            else if (viewUp == 2)
            {
                // Z Up (Blender default)
                cameraUp = Vector3.Backward;
                cameraForward = Vector3.Up;
            }
            else
            {
                // XNA Default
                cameraUp = Vector3.Up;
                cameraForward = Vector3.Forward;
            }
        }

        public void InitialiseCameraPosition()
        {
            CalculateAxes();
            // Initial viewing location
            cameraPosition = Vector3.Zero;
            float away = 200;
            float up = 100;
            if (model != null)
            {
                cameraPosition = modelCentre;
                away = modelRadius * 2;
                up = modelRadius;
            }
            else if (floor != null)
            {
                // Still show the floor even if no model has been loaded
                cameraPosition = floorCentre;
                away = floorRadius * 2;
                up = floorRadius;
            }
            // Change which way up the model is viewed
            if (viewUp == 3)
            {
                // Z Down
                cameraPosition.Y += away;
                cameraPosition.Z += up;
            }
            else if (viewUp == 2)
            {
                // Z Up (Blender default)
                cameraPosition.Y += away;
                cameraPosition.Z += up;
            }
            else
            {
                // XNA Default
                cameraPosition.Z += away;
                cameraPosition.Y += up;
            }
            CalculateProjection();
            InitialiseLookAt();
        }

        // Start looking at the model if present
        private void InitialiseLookAt()
        {
            if (model != null)
            {
                cameraForward = modelCentre - cameraPosition;
            }
            else if (floor != null)
            {
                cameraForward = floorCentre - cameraPosition;
            }
        }

        private void CalculateProjection()
        {
            float aspectRatio = GraphicsDevice.Viewport.AspectRatio;
            float nearClip = 1;
            float farClip = 100;

            if (model != null)
            {
                nearClip = modelRadius / 100;
                farClip = modelRadius * 100;
            }
            else if (showFloor && floor != null)
            {
                nearClip = floorRadius / 100;
                farClip = floorRadius * 100;
            }
            projection = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio, nearClip, farClip);
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

        // Support English, German and French keyboards
        private void HandleInput()
        {
            currentKeyboardState = Keyboard.GetState();

            float time = (float)elapsedGameTime.TotalMilliseconds;

            // == Rotate ==

            float pitch = 0;
            float turn = 0;
            float speed = 0.001f * turnPerSec;

            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                pitch += time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                pitch -= time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                turn += time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                turn -= time * speed;
            }

            Vector3 cameraRight = Vector3.Cross(cameraUp, cameraForward);
            Vector3 flatFront = Vector3.Cross(cameraRight, cameraUp);

            Matrix pitchMatrix = Matrix.CreateFromAxisAngle(cameraRight, pitch);
            Matrix turnMatrix = Matrix.CreateFromAxisAngle(cameraUp, turn);

            Vector3 tiltedFront = Vector3.TransformNormal(cameraForward, pitchMatrix * turnMatrix);

            // Check angle so we cant flip over
            if (Vector3.Dot(tiltedFront, flatFront) > 0.001f)
            {
                cameraForward = Vector3.Normalize(tiltedFront);
            }

            // == Move ==

            speed = 0.1f * movePerSec;

            if (currentKeyboardState.IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                cameraPosition += cameraForward * time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                cameraPosition -= cameraForward * time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                cameraPosition += cameraRight * time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                cameraPosition -= cameraRight * time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.R))
            {
                // Reset view
                InitialiseCameraPosition();
            }

            cameraForward.Normalize();

            // Create the new view matrix
            view = Matrix.CreateLookAt(cameraPosition, cameraPosition + cameraForward, cameraUp);
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
            GraphicsDevice.Clear(gameBackColor);

            // Set states ready for 3D
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            if (model != null)
            {
                world = Matrix.Identity;

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
                    world = Matrix.CreateScale(floorScale);
                    DrawRigid(world, view, projection, floor);
                }
            }
            else if (showFloor && floor != null)
            {
                world = Matrix.CreateTranslation(floorCentre);
                DrawRigid(world, view, projection, floor);
            }

        }

        private void DrawAnimated(Matrix aWorld, Matrix aView, Matrix aProjection)
        {
            Matrix[] bones = animationPlayer.GetSkinTransforms();

            // Render the skinned mesh.
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (SkinnedEffect effect in mesh.Effects)
                {
                    effect.SetBoneTransforms(bones);

                    // Added to move model
                    effect.World = boneTransforms[mesh.ParentBone.Index] * aWorld;

                    effect.View = aView;
                    effect.Projection = aProjection;

                    effect.EnableDefaultLighting();

                    effect.SpecularColor = new Vector3(0.25f);
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
        }

        private void DrawRigid(Matrix aWorld, Matrix aView, Matrix aProjection, Model aModel)
        {
            // Draw the model.
            foreach (ModelMesh mesh in aModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    if (boneTransforms != null)
                    {
                        effect.World = boneTransforms[mesh.ParentBone.Index] * aWorld;
                    }
                    else
                    {
                        effect.World = aWorld;
                    }
                    effect.View = aView;
                    effect.Projection = aProjection;

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

            // Get the same background used by the control in a format usable by the game
            gameBackColor = new Color(BackColor.R, BackColor.G, BackColor.B);
        }

        /// <summary>
        /// Whenever a new model is selected, we examine it to see how big
        /// it is and where it is centered. This lets us automatically zoom
        /// the display, so we can correctly handle models of any scale.
        /// </summary>
        private void MeasureModel()
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
            AdjustFloorSizes();
        }

        // Adjust the floor to match the model
        private void AdjustFloorSizes()
        {
            // Change the size of the floor based on the model size
            floorScale = modelRadius / originalFloorRadius;
            floorRadius = originalFloorRadius * floorScale;
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
