using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Templates
{
    public class EnemyShipTemplate : Artemis.IEntityTemplate
    {
        public Entity BuildEntity(Entity e)
        {
            e.Group = "SHIPS";
            e.AddComponent(new Transform());
            e.AddComponent(new SpatialForm());
            e.AddComponent(new Health());
            e.AddComponent(new Weapon());
            e.AddComponent(new Enemy());
            e.AddComponent(new Velocity());
            e.GetComponent<SpatialForm>().SpatialFormFile = "EnemyShip";
            e.GetComponent<Health>().HP = 10;
            return e;
        }
    }
}
