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
    class PlayerShip : Spatial
    {
        private Transform transform;
        private static Triangle ship = null;
        GraphicsDevice device;
        PrimitiveBatch primitiveBatch;

	    public PlayerShip(World world, Entity owner,GraphicsDevice device,PrimitiveBatch primitiveBatch) : base(world, owner) {
            this.device = device;
            this.primitiveBatch = primitiveBatch;
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);
            if (ship == null)
            {
                ship = new Triangle(device, primitiveBatch);
                ship.AddTriangle(0, -10, 10, 10, -10, 10);
                ship.SetColor(Color.White);
            }
	    }

	    public override void Render(SpriteBatch spriteBatch) {
            ship.Draw(new Vector2(transform.GetX(), transform.GetY()));
	    }
    }
}
