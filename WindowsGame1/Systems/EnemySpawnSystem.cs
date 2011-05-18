using System;
using Artemis;
using StarWarrior.Components;
namespace StarWarrior
{
	public class EnemySpawnSystem : IntervalEntitySystem {

		private ComponentMapper weaponMapper;
		private long now;
		private ComponentMapper transformMapper;
		private GameContainer container;
		private Random r;
	
		public EnemySpawnSystem(int interval, GameContainer container) : base(interval, typeof(Transform), typeof(Weapon), typeof(Enemy)){
			this.container = container;
		}
	
		public override void Initialize() {
			weaponMapper = new ComponentMapper(typeof(Weapon), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
			
			r = new Random();
		}
		
		public override void ProcessEntities(Bag<Entity> entities) {
			Entity e = EntityFactory.CreateEnemyShip(world);
			
			e.GetComponent<Transform>(typeof(Transform)).SetLocation(r.Next(container.GetWidth()), r.Next(400)+50);
			e.GetComponent<Velocity>(typeof(Velocity)).SetVelocity(0.05f);
			e.GetComponent<Velocity>(typeof(Velocity)).SetAngle(r.Next() % 2  == 0 ? 0 : 180);
			
			e.Refresh();
		}
		
	}
}

