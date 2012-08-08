using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace StarWarrior.Systems
{
	public class EnemySpawnSystem : IntervalEntitySystem {

		private SpriteBatch spriteBatch;
		private Random r;
	
		public EnemySpawnSystem(int interval, SpriteBatch spriteBatch) : base(interval){
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
			r = new Random();
		}
        
       protected override void ProcessEntities(Dictionary<int, Entity> entities)
        {
            Entity e = world.CreateEntity("EnemyShip");
			
			e.GetComponent<Transform>().SetLocation(r.Next(spriteBatch.GraphicsDevice.Viewport.Width), r.Next(400)+50);
			e.GetComponent<Velocity>().Speed = 0.05f;
			e.GetComponent<Velocity>().Angle = r.Next() % 2  == 0 ? 0 : 180;
			
			e.Refresh();
		}
    }
}

