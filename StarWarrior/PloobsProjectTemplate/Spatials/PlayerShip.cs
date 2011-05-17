using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;

namespace StarWarrior.Spatials
{
    class PlayerShip : Spatial
    {
        private Transform transform;
	    private Polygon ship;

	    public PlayerShip(World world, Entity owner) : base(world, owner) {
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);

		    ship = new Polygon();
		    ship.AddPoint(0, -10);
		    ship.AddPoint(10, 10);
		    ship.AddPoint(-10, 10);
		    ship.SetClosed(true);
	    }

	    public override void Render(Graphics g) {
		    g.SetColor(Color.White);
		    g.SetAntiAlias(true);
		    ship.SetLocation(transform.GetX(), transform.GetY());
		    g.Fill(ship);
	    }
    }
}
