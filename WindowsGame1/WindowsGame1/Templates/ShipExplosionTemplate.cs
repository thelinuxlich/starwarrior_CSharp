using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;

namespace StarWarrior.Templates
{
    [Artemis.Attributes.ArtemisEntityTemplate(ShipExplosionTemplate.Name)]
    public class ShipExplosionTemplate : Artemis.IEntityTemplate
    {
        public const String Name = "ShipExplosionTemplate";

        public Entity BuildEntity(Entity e, EntityWorld world, params object[] args)
        {
            e.Group = "EFFECTS";
            e.AddComponent(new Transform());
            e.AddComponent(new SpatialForm());
            e.AddComponent(new Expires());
            e.GetComponent<SpatialForm>().SpatialFormFile = "ShipExplosion";
            e.GetComponent<Expires>().LifeTime = 1000;
            return e;
        }
    }
}
