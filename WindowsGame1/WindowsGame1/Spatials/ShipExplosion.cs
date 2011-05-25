using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarrior.Spatials
{
    class ShipExplosion : Spatial
    {
        private Transform transform;
	    private Expires expires;
	    private int initialLifeTime;
	    private Color color;
	    private int radius;
        static Texture2D circle = null;

        public ShipExplosion(World world, Entity owner, int radius, Color Color)
            : base(world, owner)
        {
		    this.radius = radius;
            this.color = Color;
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);
		
		    ComponentMapper expiresMapper = new ComponentMapper(typeof(Expires), world.GetEntityManager());
		    expires = expiresMapper.Get<Expires>(owner);
		    initialLifeTime = expires.GetLifeTime();
	    }

        private Texture2D CreateCircle(int radius,GraphicsDevice graphics)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(graphics, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];

            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = color;
            }

            texture.SetData(data);
            return texture;
        }

	    public override void Render(SpriteBatch spriteBatch) {
		    color.A = (byte)(expires.GetLifeTime()/initialLifeTime);
            if (circle == null)
            {
                circle = CreateCircle(radius, spriteBatch.GraphicsDevice);
            }
		    spriteBatch.Draw(circle, new Vector2((float)transform.GetX() - radius, (float)transform.GetY() - radius),Color.White);
	    }
    }
}
