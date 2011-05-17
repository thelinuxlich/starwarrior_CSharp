using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;

namespace StarWarrior.Spatials
{
    class Explosion : Spatial
    {
        private Transform transform;
	    private Expires expires;
	    private int initialLifeTime;
	    private Color color;
	    private int radius;

	    public Explosion(World world, Entity owner, int radius) : base(world, owner) {
		    this.radius = radius; 
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);
		
		    ComponentMapper expiresMapper = new ComponentMapper(typeof(Expires), world.GetEntityManager());
		    expires = expiresMapper.Get<Expires>(owner);
		    initialLifeTime = expires.GetLifeTime();
		
		    color = new Color();
	    }

	    public override void Render(Graphics g) {
		    color.A = (byte)(expires.GetLifeTime()/initialLifeTime);
		    g.SetColor(color);
		    g.SetAntiAlias(true);
		    g.FillOval(transform.GetX() - radius, transform.GetY() - radius, radius*2, radius*2);
	    }
    }
}
