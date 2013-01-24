using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Templates
{
    public class BulletExplosionTemplate : Artemis.IEntityTemplate
    {
        public Entity BuildEntity(Entity e, params object[] args)
        {
            e.Group = "EFFECTS";
            e.AddComponent(new Transform());
            e.AddComponent(new SpatialForm());
            e.AddComponent(new Expires());
            e.GetComponent<SpatialForm>().SpatialFormFile = "BulletExplosion";
            e.GetComponent<Expires>().LifeTime = 1000;
            return e;
        }
    }
}
