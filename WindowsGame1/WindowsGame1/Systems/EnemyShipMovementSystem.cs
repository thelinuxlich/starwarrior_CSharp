using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarrior.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType=ExecutionType.UpdateSynchronous)]
    class EnemyShipMovementSystem : EntityProcessingSystem
    {
        private SpriteBatch spriteBatch;
	    private ComponentMapper<Transform> transformMapper;
	    private ComponentMapper<Velocity> velocityMapper;
        
	    public EnemyShipMovementSystem() : base(typeof(Transform), typeof(Velocity),typeof(Enemy)) {            
	    }

	    public override void Initialize() {
            this.spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");		    
		    transformMapper = new ComponentMapper<Transform>(world);
		    velocityMapper = new ComponentMapper<Velocity>(world);
	    }

	    public override void Process(Entity e) {
            Transform transform = transformMapper.Get(e);
            Velocity velocity = velocityMapper.Get(e);

            if (transform.X > spriteBatch.GraphicsDevice.Viewport.Width || transform.X < 0)
            {
                velocity.AddAngle(180);
            }
	    }
    }
}
