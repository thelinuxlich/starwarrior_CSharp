using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Artemis;
using StarWarrior.Components;
using StarWarrior.Systems;
using StarWarrior.Primitives;

namespace StarWarrior
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PrimitiveBatch primitiveBatch;
        private World world;

        private EntitySystem renderSystem;
        private EntitySystem hudRenderSystem;
        private EntitySystem controlSystem;
        private EntitySystem movementSystem;
        private EntitySystem enemyShooterSystem;
        private EntitySystem enemyShipMovementSystem;
        private EntitySystem collisionSystem;
        private EntitySystem healthBarRenderSystem;
        private EntitySystem enemySpawnSystem;
        private EntitySystem expirationSystem;
        private SpriteFont font;

        int frameRate,frameCounter;
        TimeSpan elapsedTime = TimeSpan.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            primitiveBatch = new PrimitiveBatch(GraphicsDevice);

            world = new World();

            font = Content.Load<SpriteFont>("myFont");
            SystemManager systemManager = world.GetSystemManager();
            renderSystem = systemManager.SetSystem(new RenderSystem(GraphicsDevice,spriteBatch,primitiveBatch));
            hudRenderSystem = systemManager.SetSystem(new HudRenderSystem(spriteBatch,font));
            controlSystem = systemManager.SetSystem(new MovementSystem(spriteBatch));
            movementSystem = systemManager.SetSystem(new PlayerShipControlSystem(spriteBatch));
            enemyShooterSystem = systemManager.SetSystem(new EnemyShipMovementSystem(spriteBatch));
            enemyShipMovementSystem = systemManager.SetSystem(new EnemyShooterSystem());
            collisionSystem = systemManager.SetSystem(new CollisionSystem());
            healthBarRenderSystem = systemManager.SetSystem(new HealthBarRenderSystem(spriteBatch,font));
            enemySpawnSystem = systemManager.SetSystem(new EnemySpawnSystem(500, spriteBatch));
            expirationSystem = systemManager.SetSystem(new ExpirationSystem());

            systemManager.InitializeAll();

            InitPlayerShip();
            InitEnemyShips();


            // TODO: use this.Content to load your game content here   
            base.Initialize();
        }

        private void InitEnemyShips() {
		    Random r = new Random();
		    for (int i = 0; 2 > i; i++) {
			    Entity e = EntityFactory.CreateEnemyShip(world);

			    e.GetComponent<Transform>().SetLocation(r.Next(GraphicsDevice.Viewport.Width), r.Next(400)+50);
			    e.GetComponent<Velocity>().SetVelocity(0.05f);
			    e.GetComponent<Velocity>().SetAngle(r.Next() % 2 == 0 ? 0 : 180);
			
			    e.Refresh();
		    }
	    }

	    private void InitPlayerShip() {
		    Entity e = world.CreateEntity();
		    e.SetGroup("SHIPS");

            e.AddComponent(new Transform(new Vector3(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 40,0)));
		    e.AddComponent(new SpatialForm("PlayerShip"));
		    e.AddComponent(new Health(30));
		    
		    e.Refresh();
            world.GetTagManager().Register("PLAYER", e);
	    }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
        }


        DateTime dt = DateTime.Now;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            TimeSpan elapsed = DateTime.Now - dt;
            dt = DateTime.Now;
            world.LoopStart();
            world.SetDelta(elapsed.Milliseconds);

            controlSystem.Process();
            movementSystem.Process();
            enemyShooterSystem.Process();
            enemyShipMovementSystem.Process();
            collisionSystem.Process();
            enemySpawnSystem.Process();
            expirationSystem.Process();

            elapsedTime += elapsed;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            frameCounter++;
            string fps = string.Format("fps: {0}", frameRate);

            GraphicsDevice.Clear(Color.Black);
            primitiveBatch.Begin(PrimitiveType.TriangleList);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, fps, new Vector2(32,32), Color.Yellow);
            renderSystem.Process();
            healthBarRenderSystem.Process();
            hudRenderSystem.Process();            
            primitiveBatch.End();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
