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
    static class Missile
    {
        static Texture2D bullet = null;
	   
	    public static void Render(SpriteBatch spriteBatch,ContentManager contentManager,Transform transform) {
            if (bullet == null)
            {
                bullet = contentManager.Load<Texture2D>("bullet");
            }
            Rectangle rect = new Rectangle((int)transform.X, (int)transform.Y, bullet.Width, bullet.Height);
            spriteBatch.Draw(bullet, new Vector2(transform.X - bullet.Width / 2, transform.Y - bullet.Height / 2), bullet.Bounds, Color.White);
	    }
    }
}
