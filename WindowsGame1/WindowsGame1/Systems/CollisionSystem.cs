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
        private ComponentMapper transformMapper;
	    private ComponentMapper velocityMapper;
	    private ComponentMapper healthMapper;

	    public CollisionSystem() : base(typeof(Transform)){
	    }

	    public override void Initialize() {
		    transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    velocityMapper = new ComponentMapper(typeof(Velocity), world.GetEntityManager());
		    healthMapper = new ComponentMapper(typeof(Health), world.GetEntityManager());
	    }
	
	    public void processEntities(Bag<Entity> entities) {
		    Bag<Entity> bullets = world.GetGroupManager().getEntities("BULLETS");
		    Bag<Entity> ships = world.GetGroupManager().getEntities("SHIPS");
		
		    if(bullets != null && ships != null) {
                bool shipLoop = false;
			    for(int a = 0; ships.Size() > a; a++) {
                    shipLoop = false;
				    Entity ship = ships.Get(a);
				    for(int b = 0; bullets.Size() > b; b++) {
					    Entity bullet = bullets.Get(b);
					
					    if(CollisionExists(bullet, ship)) {
						    Transform tb = transformMapper.Get<Transform>(bullet);
						    EntityFactory.CreateBulletExplosion(world, tb.GetX(), tb.GetY()).Refresh();
						    world.DeleteEntity(bullet);
						
						    Health health = healthMapper.Get<Health>(ship);
						    health.AddDamage(4);
	
						
						    if(!health.IsAlive()) {
							    Transform ts = transformMapper.Get<Transform>(ship);
	
							    EntityFactory.CreateShipExplosion(world, ts.GetX(), ts.GetY()).Refresh();
	
							    world.DeleteEntity(ship);
							    break;
						    }
					    }
				    }
                    if(shipLoop == true) {
                        continue;
                    }
			    }
		    }
	    }

	    private bool CollisionExists(Entity e1, Entity e2) {
		    Transform t1 = transformMapper.Get<Transform>(e1);
		    Transform t2 = transformMapper.Get<Transform>(e2);
		    return t1.GetDistanceTo(t2) < 15;
	    }
    }
}
