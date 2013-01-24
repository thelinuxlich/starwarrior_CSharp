using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;

namespace StarWarrior.Templates
{
    public class ShipExplosionTemplate : Artemis.IEntityTemplate
    {
        public Entity BuildEntity(Entity e, params object[] args)
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
