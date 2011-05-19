using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarrior.Systems
{
    class EnemyShipMovementSystem : EntityProcessingSystem
    {
        private SpriteBatch spriteBatch;
	    private ComponentMapper transformMapper;
	    private ComponentMapper velocityMapper;

	    public EnemyShipMovementSystem(SpriteBatch spriteBatch) : base(typeof(Transform), typeof(Enemy), typeof(Velocity)) {
		    this.spriteBatch = spriteBatch;
	    }

	    public override void Initialize() {
		    transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    velocityMapper = new ComponentMapper(typeof(Velocity), world.GetEntityManager());
	    }

	    public override void Process(Entity e) {
		    Transform transform = transformMapper.Get<Transform>(e);
		    Velocity velocity = velocityMapper.Get<Velocity>(e);

		    if (transform.GetX() > spriteBatch.GraphicsDevice.Viewport.Width || transform.GetX() < 0) {
			    velocity.AddAngle(180);
		    }
	    }
    }
}
