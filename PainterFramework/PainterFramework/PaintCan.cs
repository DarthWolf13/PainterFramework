using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class PaintCan : ThreeColorGameObject
    {
        protected Color targetcolor;
        protected float minVelocity;
        protected float positionOffset;

        public PaintCan(Color targetcolor, float positionOffset, string colorRed = "spr_can_red", string colorBlue = "spr_can_blue", string colorGreen = "spr_can_green") 
            : base(colorRed, colorBlue, colorGreen)
        {
            this.positionOffset = positionOffset;
            this.targetcolor = targetcolor;

            minVelocity = 30;
            this.Reset();
        }

        public override void Reset()
        {
            base.Reset();
            position = new Vector2(this.positionOffset, -BoundingBox.Height);
            velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity.Y == 0.0f && GameEnvironment.Random.NextDouble() < 0.01)
            {
                velocity = CalculateRandomVelocity();
                Color = CalculateRandomColor();
            }

            minVelocity += 0.001f;

            PainterGameWorld pwg = GameWorld as PainterGameWorld;
            if (pwg.IsOutsideWorld(GlobalPosition))
            {
                if (this.targetcolor == this.color)
                {
                    pwg.score += 10;
                    PainterFramework.AssetManager.PlaySound("snd_collect_points");
                }
                else pwg.lives--;

                Reset();
            }
                

            base.Update(gameTime);
        }

        public Vector2 CalculateRandomVelocity()
        {
            return new Vector2(0.0f, (float)GameEnvironment.Random.NextDouble() * 30 + minVelocity);
        }

        public Color CalculateRandomColor()
        {
            int randomval = GameEnvironment.Random.Next(3);
            if (randomval == 0)
                return Color.Red;
            else if (randomval == 1)
                return Color.Green;
            else
                return Color.Blue;
        }
    }
}
