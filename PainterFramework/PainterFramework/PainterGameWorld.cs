﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class PainterGameWorld : GameObjectList
    {
        private RotatableSpriteGameObject cannonBarrel = null;
        private ThreeColorGameObject cannonColor = null;
        private ThreeColorGameObject can1 = null, can2 = null, can3 = null;
        private Ball ball = null;

        public PainterGameWorld()
        {
            cannonBarrel = new RotatableSpriteGameObject("spr_cannon_barrel");
            cannonBarrel.Position = new Vector2(74, 404);
            cannonBarrel.Origin = new Vector2(34, 34);

            cannonColor = new ThreeColorGameObject("spr_cannon_red", "spr_cannon_green", "spr_cannon_blue");
            cannonColor.Position = new Vector2(58, 388);

            can1 = new PaintCan(Color.Red, 450f);
            can2 = new PaintCan(Color.Green, 575f);
            can3 = new PaintCan(Color.Blue, 700f);

            ball = new Ball();

            this.Add(new SpriteGameObject("spr_background"));
            this.Add(cannonBarrel);
            this.Add(cannonColor);
            this.Add(can1);
            this.Add(can2);
            this.Add(can3);
            this.Add(ball);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyPressed(Keys.R))
                cannonColor.Color = Color.Red;
            else if (inputHelper.KeyPressed(Keys.G))
                cannonColor.Color = Color.Green;
            else if (inputHelper.KeyPressed(Keys.B))
                cannonColor.Color = Color.Blue;

            double opposite = inputHelper.MousePosition.Y - cannonBarrel.GlobalPosition.Y;
            double adjacent = inputHelper.MousePosition.X - cannonBarrel.GlobalPosition.X;
            cannonBarrel.Angle = (float)Math.Atan2(opposite, adjacent);

            if (inputHelper.MouseLeftButtonPressed() && !ball.Shooting)
            {
                ball.Shoot(inputHelper, cannonColor, cannonBarrel);
            }
        }

        public bool IsOutsideWorld(Vector2 aPosition)
        {
            return aPosition.X < 0 || aPosition.X > PainterFramework.Screen.X || aPosition.Y > PainterFramework.Screen.Y;
        }

        public override void Update(GameTime gameTime)
        {
            if (ball.CollidesWith(can1))
            {
                can1.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(can2))
            {
                can1.Color = ball.Color;
                ball.Reset();
            }
            if (ball.CollidesWith(can3))
            {
                can1.Color = ball.Color;
                ball.Reset();
            }

            base.Update(gameTime);
        }

        /*public int Score
        {
            get
            {
                return score;
            }
            set
            {
                lives = value;
            }
        }

        public int Lives
        {
            get
            {
                return lives;
            }
            set
            {
                lives = value;
            }
        }*/
    }
}
