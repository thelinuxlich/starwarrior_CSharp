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
    class EnemyShip : Spatial
    {
        private Transform transform;
	    private VertexPositionColor[] vertices;

	    public EnemyShip(World world, Entity owner) : base(world, owner) {
	    }

	    public override void Initalize() {
		    ComponentMapper transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
		    transform = transformMapper.Get<Transform>(owner);
            vertices = new VertexPositionColor[3];

            vertices[0].Position = new Vector3(-10, -10f, 0f);
            vertices[0].Color = Color.Red;
            vertices[1].Position = new Vector3(10, -10, 0f);
            vertices[1].Color = Color.Red;
            vertices[2].Position = new Vector3(0, 10, 0f);
            vertices[2].Color = Color.Red;
        }

	    public override void Render(SpriteBatch spriteBatch) {
		    ship.SetLocation(transform.GetX(), transform.GetY());
		    spriteBatch.GraphicsDevice.DrawUserPrimitives((PrimitiveType.TriangleList, vertices, 0, 1, VertexPositionColor.VertexDeclaration);
	    }
    }
}
