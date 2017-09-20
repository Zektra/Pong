using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D speler1tex, speler2tex, balltex;
        GameTime GameTime = new GameTime();
        Bar player1, player2;
        int screenWidth = 1280;
        int screenHeight = 720;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = screenHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            //player1 = new Bar(Vector2.Zero,Vector2.One,bartex);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            player1 = new Bar(Vector2.Zero, Vector2.One, speler1tex);
            player2 = new Bar(new Vector2(screenWidth - Bar.size.X, 0), Vector2.One, speler2tex);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            speler1tex = Content.Load<Texture2D>("blauweSpeler");
            speler2tex = Content.Load<Texture2D>("rodeSpeler");
            balltex = Content.Load<Texture2D>("Bal");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (kstate.IsKeyDown(Keys.S)&&player1.position.Y < screenHeight - Bar.size.Y)
                player1.position += new Vector2(0, gameTime.ElapsedGameTime.Milliseconds);
            if (kstate.IsKeyDown(Keys.W)&&player1.position.Y > 0)
                player1.position += new Vector2(0, -gameTime.ElapsedGameTime.Milliseconds);
            if (kstate.IsKeyDown(Keys.Down) && player2.position.Y < screenHeight - Bar.size.Y)
                player2.position += new Vector2(0, gameTime.ElapsedGameTime.Milliseconds);
            if (kstate.IsKeyDown(Keys.Up) && player2.position.Y > 0)
                player2.position += new Vector2(0, -gameTime.ElapsedGameTime.Milliseconds);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(player1.tex, player1.position);
            spriteBatch.Draw(player2.tex, player2.position);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }

    public class Bar {
        public Vector2 position;
        public static Vector2 size = new Vector2(16,96);
        public Texture2D tex;

        public Bar(Vector2 position_, Vector2 size_, Texture2D tex_) {
            tex = tex_;
            position = position_;
        }
    }

    public class Ball {
        public Vector2 position;
        public Vector2 direction;
        public Texture2D tex;
        public float speed;
        public Ball(Vector2 position_, Vector2 direction_, float speed_, Texture2D tex_)
        {
            position = position_;
            direction = direction_;
            speed = speed_;
            tex = tex_;
        }
    }
}
