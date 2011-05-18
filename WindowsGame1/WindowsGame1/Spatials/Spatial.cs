using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarrior.Spatials
{
    public abstract class Spatial
    {
        protected World world;
        protected Entity owner;

        public Spatial(World world, Entity owner)
        {
            this.world = world;
            this.owner = owner;
        }

        public abstract void Initalize();

        public abstract void Render(SpriteBatch spriteBatch);

    }
}
