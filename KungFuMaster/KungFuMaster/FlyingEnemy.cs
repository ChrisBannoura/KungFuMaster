using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KungFuMaster
{
	class FlyingEnemy : Entity
	{
		public FlyingEnemy(Rectangle rect, Texture2D texture) : base(rect, texture)
		{
			this.AttackRect = rect;
		}

		public override void Update()
		{

		}

		public override void Draw(SpriteBatch batch)
		{

		}
	}
}
