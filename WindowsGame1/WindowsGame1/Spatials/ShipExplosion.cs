using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StarWarrior.Spatials
{
    static class ShipExplosion
    {
        static Texture2D circle = null;

        public static void Render(SpriteBatch spriteBatch, ContentManager contentManager, Transform transform, Color color, int radius)
        {
            if (circle == null)
            {
                circle = contentManager.Load<Texture2D>("explosion");
            }
            Rectangle rect = new Rectangle((int)transform.X, (int)transform.Y, circle.Width, circle.Height);
            spriteBatch.Draw(circle, new Vector2(transform.X - circle.Width / 2, transform.Y - circle.Height / 2), circle.Bounds, Color.White);
        }
    }
}
