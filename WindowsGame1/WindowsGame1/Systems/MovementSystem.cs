using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarrior.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.UpdateSyncronous, Layer = 1)]
	public class MovementSystem : EntityProcessingSystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper<Velocity> velocityMapper;
		private ComponentMapper<Transform> transformMapper;
	
		public MovementSystem() : base(typeof(Transform), typeof(Velocity)) {			
		}
	
		public override void Initialize() {
            this.spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");
			velocityMapper = new ComponentMapper<Velocity>(world);
			transformMapper = new ComponentMapper<Transform>(world);
		}
	
		public override void Process(Entity e) {
			Velocity velocity = velocityMapper.Get(e);
			float v = velocity.Speed;
	
			Transform transform = transformMapper.Get(e);
	
			float r = velocity.AngleAsRadians;
	
			float xn = transform.X + ((float)Math.Cos(r) * v * world.Delta);
            float yn = transform.Y + ((float)Math.Sin(r) * v * world.Delta);
	
			transform.SetLocation(xn, yn);
		}
    }
}

