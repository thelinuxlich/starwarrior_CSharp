using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Spatials
{
    class Missile : Spatial
    {
        private Transform transform;

	    public Missile(World world, Entity owner) : base(world, owner) {
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform),world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);
	    }

	    public override void Render(Graphics g) {
		    g.SetColor(Color.white);
		    g.SetAntiAlias(true);
		    g.FillRect(transform.GetX() - 1, transform.GetY() - 3, 2, 6);
	    }
    }
}
