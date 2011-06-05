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
    class ShipExplosion
    {
        static Texture2D circle = null;

        public static void Render(SpriteBatch spriteBatch, GraphicsDevice device, Transform transform, Color color, int radius)
        {
            if (circle == null)
            {
                circle = Explosion.CreateCircle(radius, spriteBatch.GraphicsDevice,color);
            }
		    spriteBatch.Draw(circle, new Vector2((float)transform.GetX() - radius, (float)transform.GetY() - radius),Color.White);
	    }
    }
}
