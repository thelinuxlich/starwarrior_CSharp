using System;
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
			
			e.getComponent(typeof(Transform)).SetLocation(r.Next(container.GetWidth()), r.Next(400)+50);
			e.getComponent(typeof(Velocity)).SetVelocity(0.05f);
			e.getComponent(typeof(Velocity)).setAngle(r.nextBoolean() ? 0 : 180);
			
			e.Refresh();
		}
		
	}
}

