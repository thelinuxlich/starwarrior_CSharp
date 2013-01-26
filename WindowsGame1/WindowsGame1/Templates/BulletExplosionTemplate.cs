using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Templates
{
    [Artemis.Attributes.ArtemisEntityTemplate(BulletExplosionTemplate.Name)]
    public class BulletExplosionTemplate : Artemis.IEntityTemplate
    {
        public const  String Name = "BulletExplosionTemplate";

        public Entity BuildEntity(Entity e, EntityWorld world, params object[] args)
        {
            e.Group = "EFFECTS";
            e.AddComponentFromPool<Transform>();
            e.AddComponent(new SpatialForm());
            e.AddComponent(new Expires());
            e.GetComponent<SpatialForm>().SpatialFormFile = "BulletExplosion";
            e.GetComponent<Expires>().LifeTime = 1000;
            return e;
        }
    }
}
