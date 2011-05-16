using System;
namespace StarWarrior
{
	public class EnemyShooterSystem : EntityProcessingSystem {

		private ComponentMapper weaponMapper;
		private long now;
		private ComponentMapper transformMapper;
	
		public EnemyShooterSystem() : base(Transform.GetType(), Weapon.GetType(), Enemy.GetType()) {
		}
	
		public override void Initialize() {
			weaponMapper = new ComponentMapper(typeof(Weapon), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		override void Begin() {
			now = DateTime.Now.Ticks;
		}
	
		public override void Process(Entity e) {
			Weapon weapon = weaponMapper.Get(e);
	
			if (weapon.GetShotAt() + 2000 < now) {
				Transform transform = transformMapper.Get(e);
	
				Entity missile = EntityFactory.CreateMissile(world);
				missile.GetComponent(typeof(Transform)).SetLocation(transform.GetX(), transform.GetY() + 20);
				missile.GetComponent(typeof(Velocity)).SetVelocity(-0.5f);
				missile.GetComponent(typeof(Velocity)).SetAngle(270);
				missile.Refresh();
	
				weapon.SetShotAt(now);
			}
	
		}
	}
}