using System;
using Artemis;
using StarWarrior.Components;
namespace StarWarrior.Systems
{
	public class EnemyShooterSystem : EntityProcessingSystem {

		private ComponentMapper weaponMapper;		
		private ComponentMapper transformMapper;
        Random rd = new Random();
	
		public EnemyShooterSystem() : base(typeof(Transform), typeof(Weapon)) {
		}
	
		public override void Initialize() {
			weaponMapper = new ComponentMapper(typeof(Weapon), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Begin() {			
		}
	
		public override void Process(Entity e) {
			Weapon weapon = weaponMapper.Get<Weapon>(e);
	
            long t = weapon.GetShotAt() + TimeSpan.FromSeconds(2).Ticks;
            if (t < DateTime.Now.Ticks)
            {
				Transform transform = transformMapper.Get<Transform>(e);
	
				Entity missile = EntityFactory.CreateMissile(world);
				missile.GetComponent<Transform>().SetLocation(transform.GetX() + 20, transform.GetY() + 20);
				missile.GetComponent<Velocity>().SetVelocity(-0.5f);
				missile.GetComponent<Velocity>().SetAngle(270);
				missile.Refresh();

                weapon.SetShotAt(DateTime.Now.Ticks);
			}
	
		}
    }
}