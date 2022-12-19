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

		public WalkingEnemy(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
			this.rect = rect;
			this.texture = texture;
		}

		public override void Update()
		{

		}

		public override void Draw(SpriteBatch batch)
		{

		}
	}
}
