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
    class Missile
    {
        static Texture2D pixel = null;
	   
	    public static void Render(SpriteBatch spriteBatch,Transform transform) {
            if (pixel == null)
            {
                pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                Color[] cor = new Color[1];
                cor[0] = Color.White;
                pixel.SetData<Color>(cor);                  
            }
		    Rectangle rect = new Rectangle((int)transform.GetX() - 1, (int)transform.GetY() - 3, 2,6);
            spriteBatch.Draw(pixel, rect, Color.White);
	    }
    }
}
