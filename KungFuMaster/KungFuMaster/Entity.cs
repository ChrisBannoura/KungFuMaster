using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KungFuMaster
{
	public abstract class Entity
	{
		public Rectangle Rect;
		public Texture2D Texture;
		public Rectangle AttackRect;

		public Entity(Rectangle rect, Texture2D texture)
		{
			this.Rect = rect;
			this.Texture = texture;
		}

		public virtual void Move(Vector2 displacement)
		{
			this.Rect.X += (int)displacement.X;
			this.Rect.Y += (int)displacement.Y;
		}

		public abstract void Update();

		public abstract void Draw(SpriteBatch batch);
	}
}
