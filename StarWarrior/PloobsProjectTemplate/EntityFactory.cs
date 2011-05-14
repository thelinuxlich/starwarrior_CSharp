using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior
{
    class EntityFactory
    {
        public static Entity CreateMissile(World world)
        {
            Entity missile = world.CreateEntity();
            missile.SetGroup("BULLETS");

            missile.AddComponent(new Transform());
            missile.AddComponent(new SpatialForm("Missile"));
            missile.AddComponent(new Velocity());
            missile.AddComponent(new Expires(2000));

            return missile;
        }

        public static Entity CreateEnemyShip(World world)
        {
            Entity e = world.CreateEntity();
            e.SetGroup("SHIPS");

            e.AddComponent(new Transform());
            e.AddComponent(new SpatialForm("EnemyShip"));
            e.AddComponent(new Health(10));
            e.AddComponent(new Weapon());
            e.AddComponent(new Enemy());
            e.AddComponent(new Velocity());

            return e;
        }

        public static Entity CreateBulletExplosion(World world, float x, float y)
        {
            Entity e = world.CreateEntity();

            e.SetGroup("EFFECTS");

            e.AddComponent(new Transform(x, y));
            e.AddComponent(new SpatialForm("BulletExplosion"));
            e.AddComponent(new Expires(1000));

            return e;
        }

        public static Entity CreateShipExplosion(World world, float x, float y)
        {
            Entity e = world.CreateEntity();

            e.SetGroup("EFFECTS");

            e.AddComponent(new Transform(x, y));
            e.AddComponent(new SpatialForm("ShipExplosion"));
            e.AddComponent(new Expires(1000));

            return e;
        }
    }
}
