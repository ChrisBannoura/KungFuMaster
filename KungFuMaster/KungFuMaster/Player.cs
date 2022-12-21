using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KungFuMaster
{
	class Player : Entity
	{
		private Rectangle[][] aniList;
		public static Rectangle rect;
		private int frame, index, cooldown;
		public bool walking, idle, flip;
		public Player(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
			Player.rect = rect;
			frame = index = 0;
			cooldown = 15;
			aniList = new Rectangle[3][];
			aniList[0] =  new Rectangle[]{new Rectangle(0, 0, 30, 45), new Rectangle(32, 0, 23, 45), new Rectangle(57, 0, 23, 45)};
		}

		public override void Update()
		{
			Player.rect = this.Rect;





			if (walking)
			{
				idle = false;
				frame = 0;
			}
				
			if (cooldown > 0)
				cooldown--;
			else
			{
				if (index == aniList[frame].Length - 1)
					index = 0;
				else 
					index++;
				cooldown = 15;
			}
			if (idle)
            {
				frame = 0;
				index = 0;
				cooldown = 15;
            }
		}

		public override void Draw(SpriteBatch batch)
		{
			//batch.Draw(this.Texture, this.Rect, Color.White);
			if (flip)
				batch.Draw(this.Texture, this.Rect, aniList[frame][index], Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
			else
				batch.Draw(this.Texture, this.Rect, aniList[frame][index], Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0f);
		}
	}
}
