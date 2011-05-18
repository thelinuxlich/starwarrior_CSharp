using System;
using Artemis;
using StarWarrior.Components;
namespace StarWarrior
{
	public class MovementSystem : EntityProcessingSystem {
		private GameContainer container;
		private Graphics g;
		private ComponentMapper velocityMapper;
		private ComponentMapper transformMapper;
	
		public MovementSystem(GameContainer container) : base(typeof(Transform), typeof(Velocity)) {
			this.container = container;
		}
	
		public override void Initialize() {
			velocityMapper = new ComponentMapper(typeof(Velocity), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Velocity velocity = velocityMapper.Get<Velocity>(e);
			float v = velocity.GetVelocity();
	
			Transform transform = transformMapper.Get<Transform>(e);
	
			double r = velocity.GetAngleAsRadians();
	
			double xn = transform.GetX() + (TrigLUT.Cos(r) * v * world.GetDelta());
			double yn = transform.GetY() + (TrigLUT.Sin(r) * v * world.GetDelta());
	
			transform.SetLocation(xn, yn);
		}
	
	}
}

