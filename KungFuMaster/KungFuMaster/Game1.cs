using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KungFuMaster
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private const float speed = 5.0f;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D debugPixel;

        private Background background;
        private List<Entity> entities = new List<Entity>();
        private Player player;

        private float velocityX;
        private bool shouldJump;
        private bool isGrounded;
        private bool shouldCrouch;

        private bool playerHasControl = true;
        private bool backroundReachedEdgeLastFrame;
        private bool playerReachedCenterLastFrame;

        private KeyboardState previousState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.graphics.PreferredBackBufferWidth = 640;
            this.graphics.PreferredBackBufferHeight = 480;
            this.graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.background = new Background(new Rectangle(0, 0, 5000, 640),
                this.Content.Load<Texture2D>("levelBackground"));

            this.debugPixel = Content.Load<Texture2D>("whiteSquare");

            this.player = new Player(new Rectangle(250, 270, 75, 150), this.debugPixel);
        }

        protected override void Update(GameTime gameTime)
        {
            this.HandleInput();

            foreach (var entity in this.entities)
            {
                entity.Update();
            }

            if (this.playerReachedCenterLastFrame)
            {
                this.playerHasControl = false;
            }
            else if (this.backroundReachedEdgeLastFrame)
            {
                this.playerHasControl = true;
            }

            if (!this.playerHasControl)
            {
                this.background.Rect.X += (int)this.velocityX;
            }
            else
            {
                this.player.Rect.X -= (int)this.velocityX;
            }

            this.backroundReachedEdgeLastFrame = this.background.Rect.X <= 0;
            this.playerReachedCenterLastFrame = this.player.Rect.X < 250;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();

            this.background.Draw(this.spriteBatch);
            this.player.Draw(this.spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void HandleInput()
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

            if (keyboardState.IsKeyDown(Keys.A))
                this.velocityX = speed;
            else if (keyboardState.IsKeyDown(Keys.D))
                this.velocityX = -speed;
            else
                this.velocityX = 0.0f;

            if (this.isGrounded)
            {
                if (keyboardState.IsKeyDown(Keys.Space) && this.previousState.IsKeyUp(Keys.Space) && this.isGrounded)
                    this.shouldJump = true;

                this.shouldCrouch = keyboardState.IsKeyDown(Keys.LeftControl);
            }

            this.previousState = keyboardState;
        }
    }
}