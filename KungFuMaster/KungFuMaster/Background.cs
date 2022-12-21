using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KungFuMaster
{
	class Background : Entity
	{
		public Background(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
		}

		public override void Draw(SpriteBatch batch)
		{
			batch.Draw(this.Texture, this.Rect, Color.White);
		}

		public override void Update()
		{

		}
	}
}
