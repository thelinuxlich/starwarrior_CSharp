using System;
using StarWarrior.Components;
using Artemis;
using Microsoft.Xna.Framework;
namespace StarWarrior
{
	public class EntityFactory {

        private static GamePool pool;

		public static Entity CreateMissile(World world) {
			Entity missile = world.AddEntity(pool.TakeEntity());
			missile.SetGroup("BULLETS");
			
			missile.AddComponent(pool.TakeComponent<Transform>());
			missile.AddComponent(pool.TakeComponent<SpatialForm>());
			missile.AddComponent(pool.TakeComponent<Velocity>());
			missile.AddComponent(pool.TakeComponent<Expires>());
            missile.GetComponent<SpatialForm>().SetSpatialFormFile("Missile");
            missile.GetComponent<Expires>().SetLifeTime(2000);
	   		return missile;
		}

        public static void SetPool(GamePool gamePool)
        {
            pool = gamePool;
        }

		public static Entity CreateEnemyShip(World world) {
			Entity e = world.AddEntity(pool.TakeEntity());
			e.SetGroup("SHIPS");
			
			e.AddComponent(pool.TakeComponent<Transform>());
			e.AddComponent(pool.TakeComponent<SpatialForm>());
			e.AddComponent(pool.TakeComponent<Health>());
			e.AddComponent(pool.TakeComponent<Weapon>());
            e.AddComponent(pool.TakeComponent<Enemy>());
			e.AddComponent(pool.TakeComponent<Velocity>());
            e.GetComponent<SpatialForm>().SetSpatialFormFile("EnemyShip");
            e.GetComponent<Health>().SetHealth(10);
			return e;
		}
		
		public static Entity CreateBulletExplosion(World world, float x, float y) {
			Entity e = world.AddEntity(pool.TakeEntity());
			
			e.SetGroup("EFFECTS");
			
			e.AddComponent(pool.TakeComponent<Transform>());
			e.AddComponent(pool.TakeComponent<SpatialForm>());
			e.AddComponent(pool.TakeComponent<Expires>());
            e.GetComponent<SpatialForm>().SetSpatialFormFile("BulletExplosion");
            e.GetComponent<Expires>().SetLifeTime(1000);
            e.GetComponent<Transform>().SetCoords(new Vector3(x, y, 0));
			return e;
		}
		
		public static Entity CreateShipExplosion(World world, float x, float y) {
			Entity e = world.AddEntity(pool.TakeEntity());
			
			e.SetGroup("EFFECTS");
			
			e.AddComponent(pool.TakeComponent<Transform>());
			e.AddComponent(pool.TakeComponent<SpatialForm>());
			e.AddComponent(pool.TakeComponent<Expires>());
            e.GetComponent<SpatialForm>().SetSpatialFormFile("ShipExplosion");
            e.GetComponent<Transform>().SetCoords(new Vector3(x, y, 0));
            e.GetComponent<Expires>().SetLifeTime(1000);
			return e;
		}
	
	}
}

