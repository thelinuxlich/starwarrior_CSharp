using System;
namespace StarWarrior
{
	public class HudRenderSystem : EntityProcessingSystem {
		private GameContainer container;
		private Graphics g;
		private ComponentMapper healthMapper;
	
		public HudRenderSystem(GameContainer container) : base(typeof(Health), typeof(Player)) {
			this.container = container;
			this.g = container.GetGraphics();
		}
	
		public override void Initialize() {
			healthMapper = new ComponentMapper(typeof(Health), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Health health = healthMapper.Get(e);
			g.SetColor(Color.white);
			g.DrawString("Health: " + health.GetHealthPercentage() + "%", 20, container.GetHeight() - 40);
		}
	
	}
}

