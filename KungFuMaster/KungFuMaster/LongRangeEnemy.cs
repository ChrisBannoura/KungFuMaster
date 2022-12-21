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
    class LongRangeEnemy : Entity
    {
        public int Cooldown;
        public Rectangle Fireball;
        public Texture2D FireballTex;
        public bool Shot;
        public LongRangeEnemy(Rectangle rect, Texture2D texture) : base(rect, texture)
        {
            this.Rect = rect;
            this.Texture = texture;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(this.Texture, this.Rect, Color.White);
            if (Cooldown > 0)
                batch.Draw(FireballTex, Fireball, Color.White);
        }

        public override void Update()
        {
            int distTo = (int)Vector2.Distance(new Vector2(this.Rect.X, 0), new Vector2(Player.rect.X, 0));
            if (distTo > 100)
                this.Rect.X += distTo / (int)Game1.playerSpeed;
            else if (Cooldown == 0)
                this.Shoot();
            if (Cooldown > 0)
            {
                Fireball.X++;
                Cooldown--;
            }

        }

        public void Shoot()
        {
             Fireball = new Rectangle(this.Rect.Right, this.Rect.Center.Y, 20, 20);
             Shot = true;
                Cooldown = 60;
        }
    }
}
