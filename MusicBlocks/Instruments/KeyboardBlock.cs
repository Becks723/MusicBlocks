using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PyTK.CustomElementHandler;
using StardewValley;
using StardewModdingAPI;
using StardewValley.Objects;
using MusicBlocks.Common;
using System;

namespace MusicBlocks.Instruments
{
    internal class KeyboardBlock : Block, ISaveElement, ICustomObject
    {

        public KeyboardBlock()
        {
            this.Build();
        }

        public override void Build()
        {
            base.Build();
            this.Texture = ModEntry._helper.Content.Load<Texture2D>(@"assets\Keyboard.png", ContentSource.ModFolder);
            this.name = "Keyboard Block";
            this.boundingBox.Value = new Rectangle((int)this.tileLocation.X * 64, (int)this.tileLocation.Y * 64, 64, 64);
            menu = new Menu(new string[] { "Piano" });
        }

        public override string getDescription()
        {
            return "Keyboard.";
        }

        public override Item getOne()
        {
            return new KeyboardBlock();
        }

        public override object getReplacement()
        {
            return base.getReplacement();
        }

        public override Dictionary<string, string> getAdditionalSaveData()
        {
            return base.getAdditionalSaveData();
        }

        public override void rebuild(Dictionary<string, string> additionalSaveData, object replacement)
        {
            base.rebuild(additionalSaveData, replacement);
        }

        public ICustomObject recreate(Dictionary<string, string> additionalSaveData, object replacement)
        {
            KeyboardBlock keyboard = new KeyboardBlock();
            keyboard.menu.sca = additionalSaveData["sca"];
            keyboard.menu.gro = additionalSaveData["gro"];
            keyboard.menu.dur = additionalSaveData["dur"];
            keyboard.menu.labels[menu.labelIndex] = additionalSaveData["sou"];
            keyboard.menu.value = Convert.ToSingle(additionalSaveData["vol"]);
            keyboard.tileLocation.Value = StringToVector2(additionalSaveData["tile"]);
            return keyboard;
        }
    }
}
