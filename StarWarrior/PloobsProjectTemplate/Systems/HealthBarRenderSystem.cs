using System;
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
			Health health = healthMapper.Get(e);
			Transform transform = transformMapper.Get(e);
			
			g.SetColor(Color.white);
			g.DrawString(health.GetHealthPercentage() + "%", transform.GetX()-10, transform.GetY()-30);
		}
	
	}
}

