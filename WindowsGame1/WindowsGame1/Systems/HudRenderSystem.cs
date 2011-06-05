using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
namespace StarWarrior.Systems
{
	public class HudRenderSystem : EntitySystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper healthMapper;
        private SpriteFont font;
        private Entity player;
	
		public HudRenderSystem(SpriteBatch spriteBatch,SpriteFont font) : base(typeof(Health)) {
			this.spriteBatch = spriteBatch;
            this.font = font;
		}
	
		public override void Initialize() {
            EnsurePlayerEntity();
			healthMapper = new ComponentMapper(typeof(Health), world.GetEntityManager());
		}
	
		private void EnsurePlayerEntity()
        {
            if (player == null)
            {
                player = world.GetTagManager().GetEntity("PLAYER");
            }
            else if (!player.IsActive())
            {
                player = null;
            }
        }

        public override void ProcessEntities(Dictionary<int, Entity> entities) {
            EnsurePlayerEntity();
            if(player != null) {
			    Health health = healthMapper.Get<Health>(player);
                if (health != null)
                {
                    Vector2 textPosition = new Vector2(20, spriteBatch.GraphicsDevice.Viewport.Height);
                    spriteBatch.DrawString(font, "Health: " + health.GetHealthPercentage() + "%", textPosition, Color.White);
                }
            }
		}
    }
}

