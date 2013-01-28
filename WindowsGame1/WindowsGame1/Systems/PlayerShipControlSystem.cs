using System;
using Artemis;
using StarWarrior.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using StarWarrior.Templates;
namespace StarWarrior.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.UpdateSynchronous)]
	public class PlayerShipControlSystem : TagSystem {
		private SpriteBatch spriteBatch;
		private bool moveRight;
		private bool moveLeft;
		private bool shoot;
		private ComponentMapper<Transform> transformMapper;
        private KeyboardState oldState;
        
		public PlayerShipControlSystem() : base("PLAYER") {			
		}
	
		public override void Initialize() {
            this.spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");
            transformMapper = new ComponentMapper<Transform>(world);
            oldState = Keyboard.GetState();
		}

        public override void Process(Entity e)
        {
            Transform transform = transformMapper.Get(e);
            UpdateInput();
            if (moveLeft)
            {
                transform.X += world.ElapsedTime * -0.3f;
            }
            if (moveRight)
            {
                transform.X += world.ElapsedTime * 0.3f;
            }

            if (shoot)
            {
                Entity missile = world.CreateEntityFromTemplate(MissileTemplate.Name);
                missile.GetComponent<Transform>().SetLocation(transform.X + 30, transform.Y - 20);
                missile.GetComponent<Velocity>().Speed = -0.5f;
                missile.GetComponent<Velocity>().Angle = 90;
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