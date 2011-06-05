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
    class EnemyShip
    {
        private static Triangle ship;
      
	    public static void Render(SpriteBatch spriteBatch,GraphicsDevice device, PrimitiveBatch primitiveBatch, Transform transform) {
            ship = new Triangle(device, primitiveBatch);
            ship.SetColor(Color.Red);
            ship.AddTriangle(-10, -10, 10, -10, 0, 10);
            ship.Draw(new Vector2(transform.GetX(), transform.GetY()));
	    }
    }
}
