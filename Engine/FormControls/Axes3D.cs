#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
// Draw a set of 3D axes at a static position within the view
//-----------------------------------------------------------------------------
// TODO:  Add text X, Y, Z
//  http://blogs.msdn.com/b/shawnhar/archive/2011/01/12/spritebatch-billboards-in-a-3d-world.aspx
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
        private BasicEffect basicEffect;

        public Axes3D(GraphicsDevice gDevice)
        {
            graphicsDevice = gDevice;
            basicEffect = new BasicEffect(graphicsDevice);
            basicEffect.VertexColorEnabled = true;
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

        private float offsetRight = -0.75f;
        public float OffsetRight
        {
            get { return offsetRight; }
            set { offsetRight = value; }
        }

        private float offsetUp = -0.50f;
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
        //
        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        // == Draw ==
        //
        public void Draw(Vector3 at, Vector3 forward, Vector3 up, Matrix view, Matrix projection)
        {
            Vector3 right = Vector3.Cross(forward, up);

            Vector3 offset = right * offsetRight;
            at += offset;
            offset = up * offsetUp;
            at += offset;
            offset = forward * offsetForward;
            at += offset;

            Draw(at, ref view, ref projection);
        }

        private void Draw(Vector3 at, ref Matrix view, ref Matrix projection)
        {
            Vector3 to = at;
            to.X += axesLength;
            DrawLine(at, to, Color.Red, ref view, ref projection);
            to = at;
            to.Y += axesLength;
            DrawLine(at, to, Color.Green, ref view, ref projection);
            to = at;
            to.Z += axesLength;
            DrawLine(at, to, Color.Blue, ref view, ref projection);
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
            basicEffect.World = Matrix.Identity;
            basicEffect.View = view;
            basicEffect.Projection = projection;

            DrawLines(ref pointList);
        }

        // Draw the shape from the line list which is an
        // array of points to draw lines between
        private void DrawLines(ref VertexPositionColor[] verticesList)
        {
            if (verticesList.Length > 1)
            {
                basicEffect.CurrentTechnique.Passes[0].Apply();
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
