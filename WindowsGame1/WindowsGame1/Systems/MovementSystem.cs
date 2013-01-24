using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarrior.Systems
{
	public class MovementSystem : EntityProcessingSystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper<Velocity> velocityMapper;
		private ComponentMapper<Transform> transformMapper;
	
		public MovementSystem(SpriteBatch spriteBatch) : base(typeof(Transform), typeof(Velocity)) {
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
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

