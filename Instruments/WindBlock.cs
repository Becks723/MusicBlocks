using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;

namespace MusicBlocks.Instruments
{
    internal class WindBlock : Block
    {
        public WindBlock()
        {
            this.Build();
        }

        public override void Build()
        {
            base.Build();
            this.Name = "Wind Block";
            this.Texture = Block.TextureWind;
            Menu = new Menu(WindLabels);
        }

        public override string getDescription()
        {
            return "Woodwind & Brass.";
        }

        public override Item getOne()
        {
            return new WindBlock();
        }
    }
}