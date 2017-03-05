using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterFramework
{
    class PainterGameWorld : GameObjectList
    {
        public PainterGameWorld()
        {
            this.Add(new SpriteGameObject("spr_background"));
        }
    }
}
