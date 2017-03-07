using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class GameOverGameState : GameObjectList
    {
        private TextGameObject textObj;

        public GameOverGameState()
        {
            textObj = new TextGameObject("GameFont");
            textObj.Text = "Game over! Press any key to restart...";
            textObj.Position = new Vector2((PainterFramework.Screen.X / 6), (PainterFramework.Screen.Y / 2) - 10);
            this.Add(textObj);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.AnyKeyPressed) PainterFramework.GameStateManager.SwitchTo("playingState");
        }
    }
}