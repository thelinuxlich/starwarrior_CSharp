using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using StarWarrior.Templates;
namespace StarWarrior.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.UpdateSyncronous, Layer = 1)]
	public class EnemySpawnSystem : IntervalEntitySystem {

		private SpriteBatch spriteBatch;
		private Random r;
	
		public EnemySpawnSystem() 
            : base(EntitySystem.BlackBoard.GetEntry<int>("EnemyInterval")){			
		}
	
		public override void Initialize() {
            this.spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");		    
			r = new Random();
		}
        
       protected override void ProcessEntities(Dictionary<int, Entity> entities)
        {
            Entity e = world.CreateEntityFromTemplate(EnemyShipTemplate.Name);
			
			e.GetComponent<Transform>().SetLocation(r.Next(spriteBatch.GraphicsDevice.Viewport.Width), r.Next(400)+50);
			e.GetComponent<Velocity>().Speed = 0.05f;
			e.GetComponent<Velocity>().Angle = r.Next() % 2  == 0 ? 0 : 180;
			
			e.Refresh();
		}
    }
}

