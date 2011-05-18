using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarrior.Systems
{
	public class HudRenderSystem : EntityProcessingSystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper healthMapper;
	
		public HudRenderSystem(SpriteBatch spriteBatch) : base(typeof(Health), typeof(Player)) {
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
			healthMapper = new ComponentMapper(typeof(Health), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Health health = healthMapper.Get<Health>(e);
            SpriteFont font = new SpriteFont();
            Vector2 textPosition = new Vector2(20, spriteBatch.GraphicsDevice.Viewport.Height);
            spriteBatch.DrawString(font, "Health: " + health.GetHealthPercentage() + "%", textPosition, Color.White);
		}
	
	}
}

