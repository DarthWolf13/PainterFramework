using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PainterFramework
{
    public class PainterFramework : GameEnvironment
    {
        public PainterFramework()
        {
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            gameStateManager.AddGameState("playingState", new PainterGameWorld());
            gameStateManager.SwitchTo("playingState");
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            AssetManager.PlayMusic("snd_music");
        }

    }
}
