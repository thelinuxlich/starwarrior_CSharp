using System;
namespace StarWarrior	
{
	public class RenderSystem : EntityProcessingSystem {
		private Graphics graphics;
		private Bag<Spatial> spatials;
		private ComponentMapper spatialFormMapper;
		private ComponentMapper transformMapper;
		private GameContainer container;
	
		public RenderSystem(GameContainer container) : base(typeof(Transform), typeof(SpatialForm)) {
			this.container = container;
			this.graphics = container.getGraphics();
	
			spatials = new Bag<Spatial>();
		}
	
		public override void Initialize() {
			spatialFormMapper = new ComponentMapper(typeof(SpatialForm), world.GetEntityManager());
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		}
	
		public override void Process(Entity e) {
			Spatial spatial = spatials.Get(e.GetId());
			Transform transform = transformMapper.Get(e);
	
			if (transform.GetX() >= 0 && transform.GetY() >= 0 && transform.GetX() < container.GetWidth() && transform.GetY() < container.GetHeight() && spatial != null) {
				spatial.Render(graphics);
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
			SpatialForm spatialForm = spatialFormMapper.Get(e);
			String spatialFormFile = spatialForm.GetSpatialFormFile();
	
			if (String.Compare("PlayerShip",spatialFormFile,true)) {
				return new PlayerShip(world, e);
			} else if (String.Compare("Missile",spatialFormFile,true)) {
				return new Missile(world, e);
			} else if (String.Compare("EnemyShip",spatialFormFile,true)) {
				return new EnemyShip(world, e);
			} else if (String.Compare("BulletExplosion",spatialFormFile,true)) {
				return new Explosion(world, e, 10);
			} else if (String.Compare("ShipExplosion",spatialFormFile,true)) {
				return new Explosion(world, e, 30);
			}
	
			return null;
		}
	
	}
}