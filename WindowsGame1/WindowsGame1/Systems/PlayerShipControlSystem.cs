using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace StarWarrior.Systems
{
	public class PlayerShipControlSystem : EntityProcessingSystem {
		private SpriteBatch spriteBatch;
		private bool moveRight;
		private bool moveLeft;
		private bool shoot;
		private ComponentMapper transformMapper;
        private KeyboardState oldState;
	
		public PlayerShipControlSystem(SpriteBatch spriteBatch) : base(typeof(Transform), typeof(Player)) {
			this.spriteBatch = spriteBatch;
		}
	
		public override void Initialize() {
			transformMapper = new ComponentMapper(typeof(Transform), world.GetEntityManager());
            oldState = Keyboard.GetState();
		}
	
		public override void Process(Entity e) {
			Transform transform = transformMapper.Get<Transform>(e);
            UpdateInput();
			if (moveLeft) {
				transform.AddX(world.GetDelta() * -0.3f);
			}
			if (moveRight) {
				transform.AddX(world.GetDelta() * 0.3f);
			}
			
			if (shoot) {
				Entity missile = EntityFactory.CreateMissile(world);
				missile.GetComponent<Transform>(typeof(Transform)).SetLocation(transform.GetX(), transform.GetY() - 20);
				missile.GetComponent<Velocity>(typeof(Velocity)).SetVelocity(-0.5f);
				missile.GetComponent<Velocity>(typeof(Velocity)).SetAngle(90);
				missile.Refresh();
	
				shoot = false;
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
            if (ks.IsKeyDown(Keys.Space))
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