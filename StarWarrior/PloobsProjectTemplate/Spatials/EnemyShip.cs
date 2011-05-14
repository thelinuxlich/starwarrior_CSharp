using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;

namespace StarWarrior.Spatials
{
    class EnemyShip : Spatial
    {
        private Transform transform;
	    private Polygon ship;

	    public EnemyShip(World world, Entity owner) : base(world, owner) {
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);

		    ship = new Polygon();
		    ship.AddPoint(-10, -10);
		    ship.AddPoint(10, -10);
		    ship.AddPoint(0, 10);
		    ship.SetClosed(true);
	    }

	    public override void Render(Graphics g) {
		    g.SetColor(Color.red);
		    g.SetAntiAlias(true);
		    ship.SetLocation(transform.GetX(), transform.GetY());
		    g.Fill(ship);
	    }
    }
}
