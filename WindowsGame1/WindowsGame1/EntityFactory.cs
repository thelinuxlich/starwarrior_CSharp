using System;
using StarWarrior.Components;
using Artemis;
using Microsoft.Xna.Framework;
namespace StarWarrior
{
	public class EntityFactory {

        public static Entity CreateMissile(EntityWorld world)
        {
			Entity missile = world.CreateEntity();
            GamePool pool = (GamePool)world.Pool;
			missile.SetGroup("BULLETS");
			
			missile.AddComponent(pool.TakeComponent<Transform>());
			missile.AddComponent(pool.TakeComponent<SpatialForm>());
			missile.AddComponent(pool.TakeComponent<Velocity>());
			missile.AddComponent(pool.TakeComponent<Expires>());
            missile.GetComponent<SpatialForm>().SpatialFormFile = "Missile";
            missile.GetComponent<Expires>().LifeTime = 2000;
	   		return missile;
		}

     	public static Entity CreateEnemyShip(EntityWorld world) {
			Entity e = world.CreateEntity();
			e.SetGroup("SHIPS");
            GamePool pool = (GamePool)world.Pool;
			e.AddComponent(pool.TakeComponent<Transform>());
			e.AddComponent(pool.TakeComponent<SpatialForm>());
			e.AddComponent(pool.TakeComponent<Health>());
			e.AddComponent(pool.TakeComponent<Weapon>());
            e.AddComponent(pool.TakeComponent<Enemy>());
			e.AddComponent(pool.TakeComponent<Velocity>());
            e.GetComponent<SpatialForm>().SpatialFormFile = "EnemyShip";
            e.GetComponent<Health>().HP = 10;
			return e;
		}

        public static Entity CreateBulletExplosion(EntityWorld world, float x, float y)
        {
			Entity e = world.CreateEntity();
            GamePool pool = (GamePool)world.Pool;
			e.SetGroup("EFFECTS");
			
			e.AddComponent(pool.TakeComponent<Transform>());
			e.AddComponent(pool.TakeComponent<SpatialForm>());
			e.AddComponent(pool.TakeComponent<Expires>());
            e.GetComponent<SpatialForm>().SpatialFormFile = "BulletExplosion";
            e.GetComponent<Expires>().LifeTime = 1000;
            e.GetComponent<Transform>().Coords = new Vector3(x, y, 0);
			return e;
		}

        public static Entity CreateShipExplosion(EntityWorld world, float x, float y)
        {
			Entity e = world.CreateEntity();
            GamePool pool = (GamePool)world.Pool;
			e.SetGroup("EFFECTS");
			
			e.AddComponent(pool.TakeComponent<Transform>());
			e.AddComponent(pool.TakeComponent<SpatialForm>());
			e.AddComponent(pool.TakeComponent<Expires>());
            e.GetComponent<SpatialForm>().SpatialFormFile = "ShipExplosion";
            e.GetComponent<Transform>().Coords = new Vector3(x, y, 0);
            e.GetComponent<Expires>().LifeTime = 1000;
			return e;
		}
	
	}
}