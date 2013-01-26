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
using StarWarrior.Templates;

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
        private EntityWorld world;
        private SpriteFont font;
       
        int frameRate,frameCounter;
        TimeSpan elapsedTime = TimeSpan.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1000;
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
            font = Content.Load<SpriteFont>("myFont");

            world = new EntityWorld();

            EntitySystem.BlackBoard.SetEntry<ContentManager>("ContentManager", Content);
            EntitySystem.BlackBoard.SetEntry<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            EntitySystem.BlackBoard.SetEntry<SpriteBatch>("SpriteBatch", spriteBatch);
            EntitySystem.BlackBoard.SetEntry<SpriteFont>("SpriteFont", font);            
            EntitySystem.BlackBoard.SetEntry<int>("EnemyInterval", 500);

            world.InitializeAll();

            InitPlayerShip();
            InitEnemyShips();

            base.Initialize();
        }

        private void InitEnemyShips() {
		    Random r = new Random();
		    for (int i = 0; 2 > i; i++) {
                Entity e = world.CreateEntityFromTemplate(EnemyShipTemplate.Name);

			    e.GetComponent<Transform>().SetLocation(r.Next(GraphicsDevice.Viewport.Width), r.Next(400)+50);
			    e.GetComponent<Velocity>().Speed = 0.05f;
			    e.GetComponent<Velocity>().Angle = r.Next() % 2 == 0 ? 0 : 180;
			
			    e.Refresh();
		    }
	    }

	    private void InitPlayerShip() {
		    Entity e = world.CreateEntity();
		    e.Group = "SHIPS";

            e.AddComponent(new Transform());
		    e.AddComponent(new SpatialForm());
		    e.AddComponent(new Health());
            e.GetComponent<SpatialForm>().SpatialFormFile = "PlayerShip";
            e.GetComponent<Health>().HP = 30;
            e.GetComponent<Transform>().Coords = new Vector3(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 50, 0);
		    e.Refresh();
            e.Tag = "PLAYER";
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
            frameCounter++;

            world.Update(elapsed.Milliseconds,ExecutionType.UpdateSyncronous);                        
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
            string fps = string.Format("fps: {0}", frameRate);
            string entityCount = string.Format("active entities: {0}", world.EntityManager.ActiveEntitiesCount);
			string removedEntityCount = string.Format("removed entities: {0}", world.EntityManager.TotalRemoved);
            string totalEntityCount = string.Format("total entities: {0}", world.EntityManager.TotalCreated);

            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            world.Update(gameTime.ElapsedGameTime.Milliseconds,ExecutionType.DrawSyncronous);
            spriteBatch.DrawString(font, fps, new Vector2(32,32), Color.Yellow);
            spriteBatch.DrawString(font, entityCount, new Vector2(32, 62), Color.Yellow);
            spriteBatch.DrawString(font, removedEntityCount, new Vector2(32, 92), Color.Yellow);
            spriteBatch.DrawString(font, totalEntityCount, new Vector2(32, 122), Color.Yellow);            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
