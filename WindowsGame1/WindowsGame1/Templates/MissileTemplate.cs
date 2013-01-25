using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Templates
{
    [Artemis.Attributes.ArtemisEntityTemplate(MissileTemplate.Name)]
    public class MissileTemplate : Artemis.IEntityTemplate
    {
        public const String Name = "MissileTemplate";

        public Entity BuildEntity(Entity e, EntityWorld world, params object[] args)
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
