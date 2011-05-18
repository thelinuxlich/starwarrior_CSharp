using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
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
			Health health = healthMapper.Get<Health>(e);
			g.SetColor(Color.White);
			g.DrawString("Health: " + health.GetHealthPercentage() + "%", 20, container.GetHeight() - 40);
		}
	
	}
}

