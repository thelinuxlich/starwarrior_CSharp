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
    class EnemyShip : Spatial
    {
        private Transform transform;
        private Triangle ship;
        GraphicsDevice device;
        PrimitiveBatch primitiveBatch;

	    public EnemyShip(World world, Entity owner,GraphicsDevice device,PrimitiveBatch primitiveBatch) : base(world, owner) {
            this.device = device;
            this.primitiveBatch = primitiveBatch;
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);
            ship = new Triangle(device,primitiveBatch);
            ship.SetColor(Color.Red);
            ship.AddTriangle(-10, -10, 10, -10, 0, 10);
        }

	    public override void Render(SpriteBatch spriteBatch) {
            ship.Draw(new Vector2(transform.GetX(), transform.GetY()));
 
	    }
    }
}
