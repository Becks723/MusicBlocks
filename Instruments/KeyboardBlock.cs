using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewModdingAPI;
using System;

namespace MusicBlocks.Instruments
{
    internal class KeyboardBlock : Block
    {

        public KeyboardBlock()
        {
            this.Build();
        }

        public override void Build()
        {
            base.Build();
            this.Name = "Keyboard Block";
            this.Texture = Block.TextureKey;
            Menu = new Menu(KeyboardLabels);
        }

        public override string getDescription()
        {
            return "Keyboard.";
        }

        public override Item getOne()
        {
            return new KeyboardBlock();
        }
    }
}
