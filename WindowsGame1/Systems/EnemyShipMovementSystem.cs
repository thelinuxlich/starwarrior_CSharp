using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class EnemyShipMovementSystem : EntityProcessingSystem
    {
        private GameContainer container;
	    private ComponentMapper transformMapper;
	    private ComponentMapper velocityMapper;

	    public EnemyShipMovementSystem(GameContainer container) : base(typeof(Transform), typeof(Enemy), typeof(Velocity)) {
		    this.container = container;
	    }

	    public override void initialize() {
		    transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    velocityMapper = new ComponentMapper(typeof(Velocity), world.GetEntityManager());
	    }

	    protected override void process(Entity e) {
		    Transform transform = transformMapper.Get<Transform>(e);
		    Velocity velocity = velocityMapper.Get<Velocity>(e);

		    if (transform.GetX() > container.getWidth() || transform.GetX() < 0) {
			    velocity.AddAngle(180);
		    }
	    }
    }
}
