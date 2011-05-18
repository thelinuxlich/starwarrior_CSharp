using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace StarWarrior.Systems
{
	public class HealthBarRenderSystem : EntityProcessingSystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper healthMapper;
		private ComponentMapper transformMapper;
	
		public HealthBarRenderSystem(SpriteBatch spriteBatch) : base(typeof(Health), typeof(Transform)) {
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
			healthMapper = new ComponentMapper(typeof(Health), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Health health = healthMapper.Get<Health>(e);
			Transform transform = transformMapper.Get<Transform>(e);
			SpriteFont font = new SpriteFont();
            Vector2 textPosition = new Vector2((float)transform.GetX()-10, (float)transform.GetY()-30);
			spriteBatch.DrawString(font,health.GetHealthPercentage() + "%",textPosition,Color.White);
		}
	
	}
}

