using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarrior.Primitives
{
    public class Triangle
    {
        PrimitiveBatch batch;
        List<Vector2> point = new List<Vector2>();
        Color color = Color.White;
        bool fill = true;
        RasterizerState state;
        GraphicsDevice device;       


        public Triangle(GraphicsDevice device)
        {
            this.device = device;
            this.batch = new PrimitiveBatch(device);
            state = new RasterizerState();
            state.CullMode = CullMode.CullCounterClockwiseFace;
            state.FillMode = FillMode.WireFrame;
        }

        public void AddTriangle(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            point.Add(new Vector2(x1,y1));
            point.Add(new Vector2(x2, y2));
            point.Add(new Vector2(x3, y3));
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetFillMode(bool fill)
        {
            this.fill = fill;
        }

        public void Draw(Vector2 transform)
        {
            if (fill == false)
            {
                device.RasterizerState = state;
            }

            batch.Begin(PrimitiveType.TriangleList);
            foreach (var item in point)
            {
                batch.AddVertex(item + transform, color);       
            }
            batch.End();

            if (fill == false)
            {
                device.RasterizerState = RasterizerState.CullCounterClockwise;
            }
        }

    }
}
