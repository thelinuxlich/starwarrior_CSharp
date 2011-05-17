using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
namespace StarWarrior
{
	public class HealthBarRenderSystem : EntityProcessingSystem {
		private GameContainer container;
		private Graphics g;
		private ComponentMapper healthMapper;
		private ComponentMapper transformMapper;
	
		public HealthBarRenderSystem(GameContainer container) : base(typeof(Health), typeof(Transform)) {
			this.container = container;
			this.g = container.getGraphics();
		}
	
		public override void Initialize() {
			healthMapper = new ComponentMapper(typeof(Health), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Health health = healthMapper.Get<Health>(e);
			Transform transform = transformMapper.Get<Transform>(e);
			
			g.SetColor(Color.White);
			g.DrawString(health.GetHealthPercentage() + "%", transform.GetX()-10, transform.GetY()-30);
		}
	
	}
}

