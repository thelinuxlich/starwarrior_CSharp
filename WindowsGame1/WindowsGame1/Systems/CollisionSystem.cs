using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using StarWarrior.Templates;

namespace StarWarrior.Systems
{    
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType=ExecutionType.UpdateSynchronous,Layer=1)]
    class CollisionSystem : EntitySystem
    {
        private ComponentMapper<Transform> transformMapper;
	    private ComponentMapper<Velocity> velocityMapper;
	    private ComponentMapper<Health> healthMapper;

	    public CollisionSystem() : base(Aspect.All(typeof(Transform))){
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
			    for(int a = 0; ships.Size > a; a++) {                    
				    Entity ship = ships.Get(a);
				    for(int b = 0; bullets.Size > b; b++) {
					    Entity bullet = bullets.Get(b);
					
					    if(CollisionExists(bullet, ship)) {
						    Transform tb = transformMapper.Get(bullet);
                            Entity bulletExplosion = world.CreateEntityFromTemplate(BulletExplosionTemplate.Name);
                            bulletExplosion.GetComponent<Transform>().Coords = new Vector3(tb.X, tb.Y, 0);
                            bulletExplosion.Refresh();
						    bullet.Delete();
						
						    Health health = healthMapper.Get(ship);
						    health.AddDamage(4);
	
						    if(!health.IsAlive) {
							    Transform ts = transformMapper.Get(ship);
                                Entity shipExplosion = world.CreateEntityFromTemplate(ShipExplosionTemplate.Name);
                                shipExplosion.GetComponent<Transform>().Coords = new Vector3(ts.X, ts.Y, 0);
                                shipExplosion.Refresh();
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
            Vector2 x = new Vector2(t1.X, t1.Y);
            Vector2 y = new Vector2(t2.X, t2.Y);
            return Vector2.Distance(x, y) < 20 ;
	    }
    }
}