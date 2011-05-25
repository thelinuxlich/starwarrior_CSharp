using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace StarWarrior.Systems
{
	public class EnemySpawnSystem : IntervalEntitySystem {

		private ComponentMapper weaponMapper;
		private long now;
		private ComponentMapper transformMapper;
		private SpriteBatch spriteBatch;
		private Random r;
	
		public EnemySpawnSystem(int interval, SpriteBatch spriteBatch) : base(interval, typeof(Transform), typeof(Weapon), typeof(Enemy)){
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
			weaponMapper = new ComponentMapper(typeof(Weapon), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
			
			r = new Random();
		}

        public override void ProcessEntities(Dictionary<int, Entity> entities)
        {
			Entity e = EntityFactory.CreateEnemyShip(world);
			
			e.GetComponent<Transform>().SetLocation(r.Next(spriteBatch.GraphicsDevice.Viewport.Width), r.Next(400)+50);
			e.GetComponent<Velocity>().SetVelocity(0.05f);
			e.GetComponent<Velocity>().SetAngle(r.Next() % 2  == 0 ? 0 : 180);
			
			e.Refresh();
		}
    }
}

