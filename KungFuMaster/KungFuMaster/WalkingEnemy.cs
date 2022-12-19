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
		private Rectangle rect;
		private Texture2D texture;
		private int attackTime = 60;
		private Rectangle attackRect;
		private Boolean attack;

		public WalkingEnemy(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
			this.rect = rect;
			this.texture = texture;


		}

		public override void Update()
		{
			if (rect.X > (Player.rect.X + 5) || rect.X < (Player.rect.X - 5))
            {
				if(rect.X > (Player.rect.X + 5))
                {
					rect.X -= (int)Game1.speed;
				}
				else if (rect.X < (Player.rect.X - 5))
                {
					rect.X += (int)Game1.speed;
				}
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

		}
	}
}
