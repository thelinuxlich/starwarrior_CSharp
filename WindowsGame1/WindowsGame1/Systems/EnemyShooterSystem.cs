using System;
using Artemis;
using StarWarrior.Components;
namespace StarWarrior.Systems
{
	public class EnemyShooterSystem : EntityProcessingSystem {

		private ComponentMapper weaponMapper;
		private long now;
		private ComponentMapper transformMapper;
	
		public EnemyShooterSystem() : base(typeof(Transform), typeof(Weapon), typeof(Enemy)) {
		}
	
		public override void Initialize() {
			weaponMapper = new ComponentMapper(typeof(Weapon), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Begin() {
			now = DateTime.Now.Ticks;
		}
	
		public override void Process(Entity e) {
			Weapon weapon = weaponMapper.Get<Weapon>(e);
	
			if (weapon.GetShotAt() + 2000 < now) {
				Transform transform = transformMapper.Get<Transform>(e);
	
				Entity missile = EntityFactory.CreateMissile(world);
				missile.GetComponent<Transform>().SetLocation(transform.GetX(), transform.GetY() + 20);
				missile.GetComponent<Velocity>().SetVelocity(-0.5f);
				missile.GetComponent<Velocity>().SetAngle(270);
				missile.Refresh();
	
				weapon.SetShotAt(now);
			}
	
		}
    }
}