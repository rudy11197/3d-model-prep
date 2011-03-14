#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Draw a set of 3D axes at a static position within the view
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AssetData;
#endregion

namespace Engine
{
    /// <summary>
    /// 3D Axes drawn at a static position within the view in 3D space
    /// </summary>
    public class Axes3D
    {
        private GraphicsDevice graphicsDevice;
        private BasicEffect axisEffect;
        private BasicEffect textEffect;
        private SpriteBatch spriteBatch;
        private SpriteFont axisFont;
        private string[] axisText;
        private RasterizerState RasterSolid = new RasterizerState();


        public Axes3D(GraphicsDevice gDevice)
        {
            graphicsDevice = gDevice;
            spriteBatch = new SpriteBatch(graphicsDevice);
            // For use by the 3D lines
            axisEffect = new BasicEffect(graphicsDevice);
            axisEffect.VertexColorEnabled = true;
            // For use by the spritebatch font
            textEffect = new BasicEffect(graphicsDevice);
            textEffect.VertexColorEnabled = true;
            textEffect.TextureEnabled = true;
            axisText = new string[3] { "X", "Y", "Z" };
        }

        public void SetFont(SpriteFont font)
        {
            axisFont = font;
            // Used to reset the raster state after drawing the font
            RasterSolid.CullMode = CullMode.CullCounterClockwiseFace;
            RasterSolid.FillMode = FillMode.Solid;
            RasterSolid.MultiSampleAntiAlias = true;
        }

        //////////////////////////////////////////////////////////////////////
        // == Properties ==
        //
        private float axesLength = 0.05f;
        public float AxesLength
        {
            get { return axesLength; }
            set { axesLength = value; }
        }

        private float offsetRight = -0.50f;
        public float OffsetRight
        {
            get { return offsetRight; }
            set { offsetRight = value; }
        }

        private float offsetUp = -0.30f;
        public float OffsetUp
        {
            get { return offsetUp; }
            set { offsetUp = value; }
        }

        private float offsetForward = 0.7f;
        public float OffsetForward
        {
            get { return offsetForward; }
            set { offsetForward = value; }
        }

        public bool FontLoaded
        {
            get
            {
                if (axisFont == null)
                {
                    return false;
                }
                return true;
            }
        }

        private float textSize = 0.0015f;
        public float TextSize
        {
            get { return textSize; }
            set { textSize = value; }
        }
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Draw ==
        //
        public void Draw(Vector3 viewAt, Vector3 viewForward, Vector3 worldUp, Matrix view, Matrix projection)
        {
            viewForward = Vector3.Normalize(viewForward);
            Vector3 viewRight = Vector3.Cross(viewForward, worldUp);
            Vector3 viewUp = Vector3.Cross(viewRight, viewForward);
            viewRight = Vector3.Normalize(viewRight);
            viewUp = Vector3.Normalize(viewUp);

            viewAt += viewForward * offsetForward;
            viewAt += viewUp * offsetUp;
            viewAt += viewRight * offsetRight;

            Draw(viewAt, ref view, ref projection);
        }

        private void Draw(Vector3 at, ref Matrix view, ref Matrix projection)
        {
            Vector3[] endPoints = new Vector3[3];
            endPoints[0] = at;
            endPoints[0].X += axesLength;
            DrawLine(at, endPoints[0], Color.Red, ref view, ref projection);
            endPoints[1] = at;
            endPoints[1].Y += axesLength;
            DrawLine(at, endPoints[1], Color.Green, ref view, ref projection);
            endPoints[2] = at;
            endPoints[2].Z += axesLength;
            DrawLine(at, endPoints[2], Color.Blue, ref view, ref projection);
            DrawAxesText(endPoints, ref view, ref projection);
        }

        // Draw X, Y, Z
        //  http://blogs.msdn.com/b/shawnhar/archive/2011/01/12/spritebatch-billboards-in-a-3d-world.aspx
        private void DrawAxesText(Vector3[] positions, ref Matrix view, ref Matrix projection)
        {
            if (axisFont == null || spriteBatch == null)
            {
                return;
            }

            Matrix invertY = Matrix.CreateScale(1, -1, 1);

            textEffect.World = invertY;
            textEffect.View = Matrix.Identity;
            textEffect.Projection = projection;

            spriteBatch.Begin(0, null, null, DepthStencilState.DepthRead, RasterizerState.CullNone, textEffect);

            for (int i = 0; i < positions.Length; i++)
            {
                Vector3 viewSpaceTextPosition = Vector3.Transform(positions[i], view * invertY);

                string message = axisText[i];
                Vector2 textOrigin = axisFont.MeasureString(message) / 2;

                spriteBatch.DrawString(axisFont, message, new Vector2(viewSpaceTextPosition.X, viewSpaceTextPosition.Y), Color.Black, 0, textOrigin, textSize, 0, viewSpaceTextPosition.Z);
            }

            spriteBatch.End();

            // Set states ready for 3D
            graphicsDevice.RasterizerState = RasterSolid;
            graphicsDevice.BlendState = BlendState.Opaque;
            graphicsDevice.DepthStencilState = DepthStencilState.Default;
            // Something resets sampler 0 so this has to be set each frame
            graphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }
        /// <summary>
        /// Draw a single thin line.
        /// </summary>
        /// <param name="from">Start point</param>
        /// <param name="to">Finish point</param>
        /// <param name="colour">Colour</param>
        /// <param name="view">View matrix</param>
        /// <param name="projection">Projection matrix</param>
        private void DrawLine(Vector3 from, Vector3 to, Color colour, ref Matrix view, ref Matrix projection)
        {
            VertexPositionColor[] pointList = new VertexPositionColor[2];
            pointList[0] = new VertexPositionColor(from, colour);
            pointList[1] = new VertexPositionColor(to, colour);
            DrawShapeAtOrigin(pointList, ref view, ref projection);
        }

        /// <summary>
        /// Draw a shape based at the origin
        /// </summary>
        /// <param name="pointList">Array of points to draw lines between</param>
        /// <param name="view">View matrix</param>
        /// <param name="projection">Projection matrix</param>
        private void DrawShapeAtOrigin(VertexPositionColor[] pointList, ref Matrix view, ref Matrix projection)
        {
            axisEffect.World = Matrix.Identity;
            axisEffect.View = view;
            axisEffect.Projection = projection;

            DrawLines(ref pointList);
        }

        // Draw the shape from the line list which is an
        // array of points to draw lines between
        private void DrawLines(ref VertexPositionColor[] verticesList)
        {
            if (verticesList.Length > 1)
            {
                axisEffect.CurrentTechnique.Passes[0].Apply();
                graphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                    PrimitiveType.LineStrip,
                    verticesList,
                    0,   // which vertex to start at
                    (verticesList.Length - 1)    // number of primitives to draw
                );
            }
        }
        //
        //////////////////////////////////////////////////////////////////////

    }
}
