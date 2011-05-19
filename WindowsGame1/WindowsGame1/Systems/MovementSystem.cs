using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarrior.Systems
{
	public class MovementSystem : EntityProcessingSystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper velocityMapper;
		private ComponentMapper transformMapper;
	
		public MovementSystem(SpriteBatch spriteBatch) : base(typeof(Transform), typeof(Velocity)) {
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
			velocityMapper = new ComponentMapper(typeof(Velocity), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Velocity velocity = velocityMapper.Get<Velocity>(e);
			float v = velocity.GetVelocity();
	
			Transform transform = transformMapper.Get<Transform>(e);
	
			float r = velocity.GetAngleAsRadians();
	
			float xn = transform.GetX() + (TrigLUT.Cos(r) * v * world.GetDelta());
			float yn = transform.GetY() + (TrigLUT.Sin(r) * v * world.GetDelta());
	
			transform.SetLocation(xn, yn);
		}
    }
}

