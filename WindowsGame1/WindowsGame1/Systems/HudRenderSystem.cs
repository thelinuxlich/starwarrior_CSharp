using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
namespace StarWarrior.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.DrawSynchronous)]
	public class HudRenderSystem : TagSystem {
		private SpriteBatch spriteBatch;
		private ComponentMapper<Health> healthMapper;
        private SpriteFont font;
       
		public HudRenderSystem() : base("PLAYER") {			
		}
	
		public override void Initialize() {
            this.spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");
            this.font = EntitySystem.BlackBoard.GetEntry<SpriteFont>("SpriteFont");		    
            healthMapper = new ComponentMapper<Health>(world);
		}
	
        public override void Process(Entity e) {
            Health health = healthMapper.Get(e);
            Vector2 textPosition = new Vector2(20, spriteBatch.GraphicsDevice.Viewport.Height);
            spriteBatch.DrawString(font, "Health: " + health.HealthPercentage + "%", textPosition, Color.White);
		}
    }
}

