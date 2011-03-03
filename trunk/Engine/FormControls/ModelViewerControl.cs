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
// To avoid ambiguities
using Keys = Microsoft.Xna.Framework.Input.Keys;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
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

        private bool showFloor = true;
        private Vector3 floorCentre = Vector3.Zero;
        private float originalFloorRadius = 10;
        // Calculated from the scale
        private float floorRadius = 10;
        private float floorScale = 1.0f;
        // Size in units of the grid squares (rounded to the nearest whole number)
        public float GridSquareWidth
        {
            get { return floorScale; }
        }
        // Scale to make one grid square = 1 unit
        // 100x100 unit grid with 20x20 squares on it
        private float floorModelScale = 0.2f;

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
        // Calculated
        float aspectRatio = 1;

        // Cache information about the model size and position.
        Matrix[] boneTransforms;
        Vector3 modelCentre;
        float modelRadius;
        // Camera movement
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        MouseState currentMouseState;
        MouseState previousMouseState;
        // Use to position the cursor each frame while using the mouse
        int mouseX = 0;
        int mouseY = 0;
        Vector3 cameraPosition = Vector3.Zero;
        // Point to look at when in orbit mode
        Vector3 orbitCentre = Vector3.Zero;
        // Camera Axes calculated before use
        Vector3 cameraUp = Vector3.Zero;
        Vector3 cameraForward = Vector3.Zero;
        // Movement
        private bool pauseInput = true;
        public bool PauseInput
        {
            get { return pauseInput; }
            set { pauseInput = value; }
        }
        // This is also adjusted by the size of the model based on the floor scale calculation
        private float movePerSec = GlobalSettings.defaultMoveSpeed;
        public float CurrentMoveSpeed
        {
            get { return movePerSec; }
            set { movePerSec = value; }
        }
        private float turnPerSec = GlobalSettings.defaultTurnSpeed;
        public float CurrentTurnSpeed
        {
            get { return turnPerSec; }
            set { turnPerSec = value; }
        }
        private float invertY = 1.0f;
        public bool InvertY
        {
            set
            {
                invertY = 1.0f;
                if (value)
                {
                    invertY = -1.0f;
                }
            }
        }

        // Timer controls the movement speed.
        Stopwatch timer;
        // Keep track of elapsed time
        TimeSpan previousTime;
        TimeSpan currentTime;
        TimeSpan elapsedGameTime;

        // For clearing the screen in the game
        // This is changed to match the control colour
        private Color gameBackColor = Color.CornflowerBlue;

        // For displaying the models
        private Vector3 emissiveLighting = new Vector3(GlobalSettings.defaultEmissive, GlobalSettings.defaultEmissive, GlobalSettings.defaultEmissive);
        private Vector3 ambientLighting = new Vector3(GlobalSettings.defaultAmbient, GlobalSettings.defaultAmbient, GlobalSettings.defaultAmbient);
        private Vector3 diffuseLighting = new Vector3(GlobalSettings.defaultDiffuse, GlobalSettings.defaultDiffuse, GlobalSettings.defaultDiffuse);
        public float EmissiveLightLevel
        {
            get
            {
                return emissiveLighting.X;
            }
            set
            {
                emissiveLighting.X = value;
                emissiveLighting.Y = value;
                emissiveLighting.Z = value;
            }
        }
        public float AmbientLightLevel
        {
            get
            {
                return ambientLighting.X;
            }
            set
            {
                ambientLighting.X = value;
                ambientLighting.Y = value;
                ambientLighting.Z = value;
            }
        }
        public float DiffuseLightLevel
        {
            get
            {
                return diffuseLighting.X;
            }
            set
            {
                diffuseLighting.X = value;
                diffuseLighting.Y = value;
                diffuseLighting.Z = value;
            }
        }

        /// <summary>
        /// For displaying shapes in 3D
        /// </summary>
        private Shapes debugShapes;
        public Shapes DebugShapes
        {
            get { return debugShapes; }
        }

        private bool wireframeEnabled = false;
        private RasterizerState RasterWireFrame = new RasterizerState();
        private RasterizerState RasterSolid = new RasterizerState();


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
                cameraPosition.Y -= away;
                cameraPosition.Z += up;
            }
            else if (viewUp == 2)
            {
                // Z Up (Blender default)
                cameraPosition.Y -= away;
                cameraPosition.Z += up;
            }
            else
            {
                // XNA Default
                cameraPosition.Z -= away;
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
                farClip = floorRadius * 100 * floorScale;
            }
            projection = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio, nearClip, farClip);
            int x = 0;
            x++;
        }

        public void WireFrameEnable(bool change)
        {
            wireframeEnabled = change;
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
            if (pauseInput)
            {
                return;
            }

            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            float time = (float)elapsedGameTime.TotalMilliseconds;

            // == Rotate ==

            float pitch = 0;
            float turn = 0;
            float speed = 0.0005f * turnPerSec;

            // Mouse look
            // The first time we select the mouse move just position the mouse
            // to a known location otherwise the model will spin dramatically
            if ((currentMouseState.MiddleButton == ButtonState.Pressed &&
                previousMouseState.MiddleButton == ButtonState.Released) ||
                (currentKeyboardState.IsKeyDown(Keys.LeftShift) &&
                previousKeyboardState.IsKeyUp(Keys.LeftShift)) ||
                (currentKeyboardState.IsKeyDown(Keys.RightShift) &&
                previousKeyboardState.IsKeyUp(Keys.RightShift))
                )
            {
                // Position the cursor a few pixel in from the top left
                mouseX = GlobalSettings.mouseZeroX;
                mouseY = GlobalSettings.mouseZeroY;
                Mouse.SetPosition(mouseX, mouseY);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.LeftShift) ||
                currentKeyboardState.IsKeyDown(Keys.RightShift) || 
                currentMouseState.MiddleButton == ButtonState.Pressed)
            {
                // Mouse look
                turn = (mouseX - currentMouseState.X) * time * speed;
                pitch = (mouseY - currentMouseState.Y) * time * speed * invertY * -1.0f;
                // centre mouse so we get the change each time
                Mouse.SetPosition(mouseX, mouseY);
            }

            // Keyboard look
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                pitch -= time * speed * invertY;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                pitch += time * speed * invertY;
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

            cameraForward.Normalize();


            // == Move ==

            if (currentKeyboardState.IsKeyDown(Keys.F) && model != null)
            {
                // Face the model
                cameraForward = modelCentre - cameraPosition;
                // Keep the turn speed unchanged
            }
            if (currentKeyboardState.IsKeyDown(Keys.O) && model != null)
            {
                // Orbit mode
                if (previousKeyboardState.IsKeyUp(Keys.O))
                {
                    // Calculate the point we are looking at
                    float distance = Vector3.Distance(modelCentre, cameraPosition);
                    orbitCentre = cameraPosition + (cameraForward * distance);
                }
                cameraForward = orbitCentre - cameraPosition;
                // Keep the turn speed unchanged
            }
            else
            {
                // Move speed
                speed = 0.005f * movePerSec * floorScale;
            }

            // For the scroll wheel to work the Mouse.WindowHandle must be set to this control
            float scroll = (currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue);
            cameraPosition += cameraForward * time * speed * scroll;

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

            // == Move up and down

            if (currentKeyboardState.IsKeyDown(Keys.PageUp))
            {
                cameraPosition += cameraUp * time * speed;
            }

            if (currentKeyboardState.IsKeyDown(Keys.PageDown))
            {
                cameraPosition -= cameraUp * time * speed;
            }

            // == Other

            if (currentKeyboardState.IsKeyDown(Keys.R))
            {
                // Reset view
                InitialiseCameraPosition();
            }

            // Create the new view matrix
            view = Matrix.CreateLookAt(cameraPosition, cameraPosition + cameraForward, cameraUp);

            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
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
                if (wireframeEnabled)
                {
                    // Draw the model in wireframe
                    GraphicsDevice.RasterizerState = RasterWireFrame;
                }

                world = Matrix.Identity;

                if (isAnimated)
                {
                    DrawAnimated(world, view, projection);
                }
                else
                {
                    DrawRigid(world, view, projection, model);
                }

                if (wireframeEnabled)
                {
                    // Everything else draws normally
                    GraphicsDevice.RasterizerState = RasterSolid;
                }

                if (showFloor && floor != null)
                {
                    // Scale to 1unit per grid square then enlarge to fit the model size
                    world = Matrix.CreateScale(floorModelScale * floorScale);
                    DrawRigid(world, view, projection, floor);
                }
            }
            else if (showFloor && floor != null)
            {
                world = Matrix.CreateTranslation(floorCentre);
                DrawRigid(world, view, projection, floor);
            }
            DrawStoredShapes();
        }

        // Draw shapes regardless of what created them
        private void DrawStoredShapes()
        {
            debugShapes.DrawStoredShapes(view, projection);
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
                    effect.AmbientLightColor = ambientLighting;
                    effect.DiffuseColor = diffuseLighting;
                    effect.EmissiveColor = emissiveLighting;

                    effect.PreferPerPixelLighting = true;
                    //effect.SpecularColor = new Vector3(0.25f);
                    //effect.SpecularPower = 16;
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

                    effect.EnableDefaultLighting();
                    effect.AmbientLightColor = ambientLighting;
                    effect.DiffuseColor = diffuseLighting;
                    effect.EmissiveColor = emissiveLighting;

                    effect.PreferPerPixelLighting = true;
                    //effect.SpecularColor = new Vector3(0.25f);
                    //effect.SpecularPower = 16;
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
            aspectRatio = GraphicsDevice.Viewport.AspectRatio;

            // Setup the shapes
            debugShapes = new Shapes(GraphicsDevice);

            RasterWireFrame.CullMode = CullMode.CullCounterClockwiseFace;
            RasterWireFrame.FillMode = FillMode.WireFrame;
            RasterWireFrame.MultiSampleAntiAlias = true;

            RasterSolid.CullMode = CullMode.CullCounterClockwiseFace;
            RasterSolid.FillMode = FillMode.Solid;
            RasterSolid.MultiSampleAntiAlias = true;

            // Initialise mouse and keyboard
            // For the scroll wheel to work the Mouse.WindowHandle must be set to this control
            Mouse.WindowHandle = Handle;
            currentKeyboardState = Keyboard.GetState();
            previousKeyboardState = currentKeyboardState;
            currentMouseState = Mouse.GetState();
            previousMouseState = currentMouseState;
            // A few pixel in from the top left
            // Once the WindowHandlw was set on the mouse this became relative to itself.
            mouseX = GlobalSettings.mouseZeroX;
            mouseY = GlobalSettings.mouseZeroY;
            Mouse.SetPosition(mouseX, mouseY);
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
            // Round up to the nearest one, 10 or 100
            float tempScale = (modelRadius / originalFloorRadius * 2f);
            if (tempScale < 10)
            {
                floorScale = (int)(tempScale + 1f);
            }
            else if (tempScale < 100)
            {
                floorScale = (((int)(tempScale / 10)) + 1) * 10;
            }
            else
            {
                floorScale = (((int)(tempScale / 100)) + 1) * 100;
            }
            floorRadius = originalFloorRadius * floorScale;
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
