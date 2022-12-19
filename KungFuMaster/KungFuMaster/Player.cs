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
		public static Rectangle rect;
		public Player(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
			Player.rect = Rect;
		}

		public override void Update()
		{

		}

		public override void Draw(SpriteBatch batch)
		{

		}
	}
}
