using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarrior.Spatials
{
    class Explosion
    {
        static Texture2D circle = null;

        public static Texture2D CreateCircle(int radius,GraphicsDevice graphics,Color color)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(graphics, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];

            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = color;
            }

            texture.SetData(data);
            return texture;
        }

        public static void Render(SpriteBatch spriteBatch, GraphicsDevice device, Transform transform,Color color,int radius)
        {
            if (circle == null)
            {
                circle = CreateCircle(radius, spriteBatch.GraphicsDevice,color);
            }
		    spriteBatch.Draw(circle, new Vector2((float)transform.GetX() - radius, (float)transform.GetY() - radius),Color.White);
	    }
    }
}
