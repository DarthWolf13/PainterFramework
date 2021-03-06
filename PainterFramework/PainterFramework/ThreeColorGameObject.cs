﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class ThreeColorGameObject : RotatableSpriteGameObject
    {
        protected SpriteSheet colorRed, colorGreen, colorBlue;
        protected Color color;

        public ThreeColorGameObject(string redAssetName, string greenAssetName, string blueAssetName):base("")
        {
            colorRed = new SpriteSheet(redAssetName);
            colorGreen = new SpriteSheet(greenAssetName);
            colorBlue = new SpriteSheet(blueAssetName);

            Color = Color.Blue;
        }

        public override void Reset()
        {
            base.Reset();

            Color = Color.Blue;
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != Color.Red && value != Color.Green && value != Color.Blue)
                    return;
                color = value;
                if (color == Color.Red)
                    sprite = colorRed;
                else if (color == Color.Green)
                    sprite = colorGreen;
                else if (color == Color.Blue)
                    sprite = colorBlue;
            }
        }
    }
}
