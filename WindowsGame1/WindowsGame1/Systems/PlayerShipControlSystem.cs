using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace StarWarrior.Systems
{
	public class PlayerShipControlSystem : EntitySystem {
		private SpriteBatch spriteBatch;
		private bool moveRight;
		private bool moveLeft;
		private bool shoot;
		private ComponentMapper transformMapper;
        private KeyboardState oldState;
        private Entity player;
	
		public PlayerShipControlSystem(SpriteBatch spriteBatch) : base(typeof(Transform)) {
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
            EnsurePlayerEntity();
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
            oldState = Keyboard.GetState();
		}

        private void EnsurePlayerEntity()
        {
            if (player == null)
            {
                player = world.GetTagManager().GetEntity("PLAYER");
            }
            else if (!player.IsActive())
            {
                player = null;
            }
        }

        public override void ProcessEntities(Dictionary<int, Entity> entities)
        {
            EnsurePlayerEntity();
            if (player != null)
            {
                Transform transform = transformMapper.Get<Transform>(player);
                if (transform != null)
                {
                    UpdateInput();
                    if (moveLeft)
                    {
                        transform.AddX(world.GetDelta() * -0.3f);
                    }
                    if (moveRight)
                    {
                        transform.AddX(world.GetDelta() * 0.3f);
                    }

                    if (shoot)
                    {
                        Entity missile = EntityFactory.CreateMissile(world);
                        missile.GetComponent<Transform>().SetLocation(transform.GetX()+30, transform.GetY() - 20);
                        missile.GetComponent<Velocity>().SetVelocity(-0.5f);
                        missile.GetComponent<Velocity>().SetAngle(90);
                        missile.Refresh();

                        shoot = false;
                    }
                }
            }
		}
	
		public void UpdateInput() {
            KeyboardState ks = Keyboard.GetState();
			if (ks.IsKeyDown(Keys.A)) {
				moveLeft = true;
				moveRight = false;
            }
            else if (oldState.IsKeyDown(Keys.A)) {
                moveLeft = false;
            }
            if (ks.IsKeyDown(Keys.D)) {
                moveRight = true;
                moveLeft = false;
            }
            else if (oldState.IsKeyDown(Keys.D))
            {
                moveRight = false;
            }
            if (ks.IsKeyDown(Keys.Space) == true && oldState.IsKeyDown(Keys.Space) == false)
            {
                shoot = true;
            }
            else if (oldState.IsKeyDown(Keys.Space))
            {
                shoot = false;
            }
            oldState = ks;
		}
    }
}