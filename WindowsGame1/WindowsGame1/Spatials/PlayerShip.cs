using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarWarrior.Primitives;

namespace StarWarrior.Spatials
{
    class PlayerShip
    {
        private static Triangle ship = null;
        
	    public static void Render(SpriteBatch spriteBatch,GraphicsDevice device,PrimitiveBatch primitiveBatch,Transform transform) {
            if (ship == null)
            {
                ship = new Triangle(device, primitiveBatch);
                ship.AddTriangle(0, -10, 10, 10, -10, 10);
                ship.SetColor(Color.White);
            }
            ship.Draw(new Vector2(transform.GetX(), transform.GetY()));
	    }
    }
}
