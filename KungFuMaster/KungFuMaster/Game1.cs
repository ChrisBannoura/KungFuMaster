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
		public const float speed = 5.0f;

		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private Entity background;
		private List<Entity> entities;
		private Player player;

		private Vector2 velocity;
		private bool shouldJump;
		private bool isGrounded;
		private bool shouldCrouch;

		private KeyboardState previousState;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			this.HandleInput();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}

		private void HandleInput()
		{
			var keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Escape))
				this.Exit();

			if (keyboardState.IsKeyDown(Keys.A))
				this.velocity = -Vector2.UnitX * speed;
			else if (keyboardState.IsKeyDown(Keys.D))
				this.velocity = Vector2.UnitX * speed;

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
