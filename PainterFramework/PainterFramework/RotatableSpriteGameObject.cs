using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{

    class RotatableSpriteGameObject : SpriteGameObject
    {
        protected float angle;

        public RotatableSpriteGameObject(string assetname, int layer = 0, string id = "", int sheetIndex = 0)
            : base(assetname, layer, id, sheetIndex)
        {
            angle = -0.5f;
        }

        public float Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || spriteBatch == null)
                return;

            spriteBatch.Draw(sprite.Sprite, new Rectangle((int)this.GlobalPosition.X, (int)this.GlobalPosition.Y, sprite.Width, sprite.Height), null, Color.White, angle, this.Origin, SpriteEffects.None, 0);
        }
    }
}
