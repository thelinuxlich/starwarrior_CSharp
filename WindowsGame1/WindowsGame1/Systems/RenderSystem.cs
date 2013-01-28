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
    //renderSystem = systemManager.SetSystem(new RenderSystem(GraphicsDevice,spriteBatch,Content),ExecutionType.DrawSyncronous);                        
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.DrawSynchronous)]
	public class RenderSystem : EntityProcessingSystem {
		private ComponentMapper<SpatialForm> spatialFormMapper;
		private ComponentMapper<Transform> transformMapper;
        private SpriteBatch spriteBatch;
        private Transform transform;
        private string spatialName;
        private ContentManager contentManager;
        GraphicsDevice device;
	
		public RenderSystem() : base(typeof(Transform), typeof(SpatialForm)) {            
		}
	
		public override void Initialize() {
            this.device = EntitySystem.BlackBoard.GetEntry<GraphicsDevice>("GraphicsDevice");
            this.spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");
            this.contentManager = EntitySystem.BlackBoard.GetEntry<ContentManager>("ContentManager");		    
			spatialFormMapper = new ComponentMapper<SpatialForm>(world);
			transformMapper = new ComponentMapper<Transform>(world);
        }
	
		public override void Process(Entity e) {
			transform = transformMapper.Get(e);
            SpatialForm spatialForm = spatialFormMapper.Get(e);
            spatialName = spatialForm.SpatialFormFile;
	
			if (transform.X >= 0 && transform.Y >= 0 && transform.X < spriteBatch.GraphicsDevice.Viewport.Width && transform.Y < spriteBatch.GraphicsDevice.Viewport.Height && spatialForm != null) {
                CreateSpatial(e); 
			}
		}

		private void CreateSpatial(Entity e) {
			if (String.Compare("PlayerShip",spatialName,StringComparison.InvariantCultureIgnoreCase) == 0) {
                PlayerShip.Render(spriteBatch, contentManager,transform);
            }
            else if (String.Compare("Missile", spatialName, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                Missile.Render(spriteBatch, contentManager, transform);
            }
            else if (String.Compare("EnemyShip", spatialName, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                EnemyShip.Render(spriteBatch, contentManager, transform);
            }
            else if (String.Compare("BulletExplosion", spatialName, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                Explosion.Render(spriteBatch, contentManager, transform,Color.Red,10);
            }
            else if (String.Compare("ShipExplosion", spatialName, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                ShipExplosion.Render(spriteBatch, contentManager, transform, Color.Yellow, 30);
			}
		}
    }
}