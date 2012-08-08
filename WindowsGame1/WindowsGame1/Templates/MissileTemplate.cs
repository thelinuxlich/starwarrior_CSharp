using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Templates
{
    public class MissileTemplate : Artemis.IEntityTemplate
    {
        public Entity BuildEntity(Entity e)
        {
            e.Group = "BULLETS";

            e.AddComponent(new Transform());
            e.AddComponent(new SpatialForm());
            e.AddComponent(new Velocity());
            e.AddComponent(new Expires());
            e.GetComponent<SpatialForm>().SpatialFormFile = "Missile";
            e.GetComponent<Expires>().LifeTime = 2000;
            return e;
        }
    }
}
