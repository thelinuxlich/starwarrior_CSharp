using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Systems
{
    class CollisionSystem : EntitySystem
    {
        private ComponentMapper<Transform> transformMapper;
	    private ComponentMapper<Velocity> velocityMapper;
	    private ComponentMapper<Health> healthMapper;

	    public CollisionSystem() : base(typeof(Transform)){
	    }

	    public override void Initialize() {
		    transformMapper = new ComponentMapper<Transform>(world);
		    velocityMapper = new ComponentMapper<Velocity>(world);
		    healthMapper = new ComponentMapper<Health>(world);
	    }

        protected override void ProcessEntities(Dictionary<int, Entity> entities)
        {
            Bag<Entity> bullets = world.GroupManager.GetEntities("BULLETS");
		    Bag<Entity> ships = world.GroupManager.GetEntities("SHIPS");            
            if(bullets != null && ships != null) {                
			    for(int a = 0; ships.Size() > a; a++) {                    
				    Entity ship = ships.Get(a);
				    for(int b = 0; bullets.Size() > b; b++) {
					    Entity bullet = bullets.Get(b);
					
					    if(CollisionExists(bullet, ship)) {
						    Transform tb = transformMapper.Get(bullet);
						    EntityFactory.CreateBulletExplosion(world, tb.X, tb.Y).Refresh();
						    bullet.Delete();
						
						    Health health = healthMapper.Get(ship);
						    health.AddDamage(4);
	
						    if(!health.IsAlive) {
							    Transform ts = transformMapper.Get(ship);	
							    EntityFactory.CreateShipExplosion(world, ts.X, ts.Y).Refresh();
							    ship.Delete();
                                break;
						    }
					    }
				    }                    
			    }
		    }
	    }

	    private bool CollisionExists(Entity e1, Entity e2) {
		    Transform t1 = transformMapper.Get(e1);
		    Transform t2 = transformMapper.Get(e2);
            return t1.DistanceTo(t2) < 15; 
	    }
    }
}