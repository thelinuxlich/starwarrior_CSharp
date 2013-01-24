using System;
using Artemis;
using StarWarrior.Components;
namespace StarWarrior.Systems
{
	public class EnemyShooterSystem : EntityProcessingSystem {

		private ComponentMapper<Weapon> weaponMapper;		
		private ComponentMapper<Transform> transformMapper;
        Random rd = new Random();
     
		public EnemyShooterSystem() : base(typeof(Transform), typeof(Weapon),typeof(Enemy)) {
		}
	
		public override void Initialize() {
			weaponMapper = new ComponentMapper<Weapon>(world);
			transformMapper = new ComponentMapper<Transform>(world);
		}
	
		protected override void Begin() {			
		}
	
		public override void Process(Entity e) {
            Weapon weapon = weaponMapper.Get(e);

            long t = weapon.ShotAt + TimeSpan.FromSeconds(2).Ticks;
            if (t < DateTime.Now.Ticks)
            {
                Transform transform = transformMapper.Get(e);

                Entity missile = world.CreateEntityFromTemplate("Missile");
                missile.GetComponent<Transform>().SetLocation(transform.X, transform.Y + 20);
                missile.GetComponent<Velocity>().Speed = -0.5f;
                missile.GetComponent<Velocity>().Angle = 270;
                missile.Refresh();

                weapon.ShotAt = DateTime.Now.Ticks;
            }
		}
    }
}