using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KungFuMaster
{
	class WalkingEnemy : Entity
	{
		private int attackTime = 60;
		private Rectangle attackRect;
		private bool attack;

		public WalkingEnemy(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
		}

		public override void Update()
		{
			if (this.Rect.X > (Player.rect.X + 100))
			{
				this.Rect.X -= (int)Game1.aiSpeed;
			}
			else if (Rect.X < (Player.rect.X - 100))
			{
				Rect.X += (int)Game1.aiSpeed;
			}
			else if (attackTime == 0)
			{
				attack = true;
				attackTime = 60;
			}
			else
			{
				attackTime--;
				attack = false;
			}

		}

		public override void Draw(SpriteBatch batch)
		{
			batch.Draw(this.Texture, this.Rect, Color.White);
		}
	}
}
