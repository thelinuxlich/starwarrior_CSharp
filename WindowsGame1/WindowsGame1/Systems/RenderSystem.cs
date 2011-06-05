using System;
using Artemis;
using StarWarrior.Components;
using StarWarrior.Spatials;
using Microsoft.Xna.Framework.Graphics;
using StarWarrior.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace StarWarrior.Systems	
{
	public class RenderSystem : EntityProcessingSystem {
		private ComponentMapper spatialFormMapper;
		private ComponentMapper transformMapper;
        private SpriteBatch spriteBatch;
        private Transform transform;
        private string spatialName;
        private ContentManager contentManager;
        GraphicsDevice device;
	
		public RenderSystem(GraphicsDevice device,SpriteBatch spriteBatch,ContentManager contentManager) : base(typeof(Transform), typeof(SpatialForm)) {
            this.spriteBatch = spriteBatch;
            this.device = device;
            this.contentManager = contentManager;
		}
	
		public override void Initialize() {
			spatialFormMapper = new ComponentMapper(typeof(SpatialForm), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
        }
	
		public override void Process(Entity e) {
			transform = transformMapper.Get<Transform>(e);
            SpatialForm spatialForm = spatialFormMapper.Get<SpatialForm>(e);
            spatialName = spatialForm.GetSpatialFormFile();
	
			if (transform.GetX() >= 0 && transform.GetY() >= 0 && transform.GetX() < spriteBatch.GraphicsDevice.Viewport.Width && transform.GetY() < spriteBatch.GraphicsDevice.Viewport.Height && spatialForm != null) {
                CreateSpatial(e); 
			}
		}

		private void CreateSpatial(Entity e) {
			if (String.Compare("PlayerShip",spatialName,true) == 0) {
                PlayerShip.Render(spriteBatch, contentManager,transform);
			} else if (String.Compare("Missile",spatialName,true) == 0) {
                Missile.Render(spriteBatch, contentManager, transform);
			} else if (String.Compare("EnemyShip",spatialName,true) == 0) {
                EnemyShip.Render(spriteBatch, contentManager, transform);
			} else if (String.Compare("BulletExplosion",spatialName,true) == 0) {
                Explosion.Render(spriteBatch, contentManager, transform,Color.Red,10);
			} else if (String.Compare("ShipExplosion",spatialName,true) == 0) {
                ShipExplosion.Render(spriteBatch, contentManager, transform, Color.Yellow, 30);
			}
		}
    }
}