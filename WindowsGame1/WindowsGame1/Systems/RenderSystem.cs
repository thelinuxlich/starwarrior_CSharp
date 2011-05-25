using System;
using Artemis;
using StarWarrior.Components;
using StarWarrior.Spatials;
using Microsoft.Xna.Framework.Graphics;
using StarWarrior.Primitives;
namespace StarWarrior.Systems	
{
	public class RenderSystem : EntityProcessingSystem {
		private Bag<Spatial> spatials;
		private ComponentMapper spatialFormMapper;
		private ComponentMapper transformMapper;
		private SpriteBatch spriteBatch;
        private PrimitiveBatch primitiveBatch;
        GraphicsDevice device;
	
		public RenderSystem(GraphicsDevice device,SpriteBatch spriteBatch,PrimitiveBatch primitiveBatch) : base(typeof(Transform), typeof(SpatialForm)) {
            this.spriteBatch = spriteBatch;
            this.primitiveBatch = primitiveBatch;
            this.device = device;
			spatials = new Bag<Spatial>();
		}
	
		public override void Initialize() {
			spatialFormMapper = new ComponentMapper(typeof(SpatialForm), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());          

		}
	
		public override void Process(Entity e) {
			Spatial spatial = spatials.Get(e.GetId());
			Transform transform = transformMapper.Get<Transform>(e);
	
			if (transform.GetX() >= 0 && transform.GetY() >= 0 && transform.GetX() < spriteBatch.GraphicsDevice.Viewport.Width && transform.GetY() < spriteBatch.GraphicsDevice.Viewport.Height && spatial != null) {
               spatial.Render(spriteBatch);
			}
		}
	
		public override void Added(Entity e) {
			Spatial spatial = CreateSpatial(e);
			if (spatial != null) {
				spatial.Initalize();
				spatials.Set(e.GetId(), spatial);
			}
		}
	
		public override void Removed(Entity e) {
			spatials.Set(e.GetId(), null);
		}

        

		private Spatial CreateSpatial(Entity e) {

			SpatialForm spatialForm = spatialFormMapper.Get<SpatialForm>(e);
			String spatialFormFile = spatialForm.GetSpatialFormFile();
	        
			if (String.Compare("PlayerShip",spatialFormFile,true) == 0) {
                return new PlayerShip(world, e, device,primitiveBatch);
			} else if (String.Compare("Missile",spatialFormFile,true) == 0) {
				return new Missile(world, e);
			} else if (String.Compare("EnemyShip",spatialFormFile,true) == 0) {
				return new EnemyShip(world, e,device,primitiveBatch);
			} else if (String.Compare("BulletExplosion",spatialFormFile,true) == 0) {
				return new Explosion(world, e, 10);
			} else if (String.Compare("ShipExplosion",spatialFormFile,true) == 0) {
				return new Explosion(world, e, 30);
			}
	
			return null;
		}
    }
}