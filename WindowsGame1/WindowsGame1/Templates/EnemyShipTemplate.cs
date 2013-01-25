using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Templates
{
    [Artemis.Attributes.ArtemisEntityTemplate(EnemyShipTemplate.Name)]
    public class EnemyShipTemplate : IEntityTemplate
    {
        public const String Name = "EnemyShipTemplate";

        public Entity BuildEntity(Entity e, EntityWorld world, params object[] args)
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
