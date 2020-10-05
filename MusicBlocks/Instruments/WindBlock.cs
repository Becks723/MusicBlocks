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
    internal class WindBlock : Block, ISaveElement, ICustomObject
    {
        public WindBlock()
        {
            this.Build();
        }

        public override void Build()
        {
            base.Build();
            this.Texture = ModEntry._helper.Content.Load<Texture2D>(@"assets\windInstrument.png", ContentSource.ModFolder);
            this.name = "Wind Block";
            this.boundingBox.Value = new Rectangle((int)this.tileLocation.X * 64, (int)this.tileLocation.Y * 64, 64, 64);
            menu = new Menu(new string[] { "Flute", "Violin" });
        }

        public override string getDescription()
        {
            return "Woodwind & Brass.";
        }

        public override Item getOne()
        {
            return new WindBlock();
        }

        public override object getReplacement()
        {
            return base.getReplacement();
        }

        public override Dictionary<string, string> getAdditionalSaveData()
        {
            return new Dictionary<string, string>();
        }

        public override void rebuild(Dictionary<string, string> additionalSaveData, object replacement)
        {
            base.rebuild(additionalSaveData, replacement);
        }

        public ICustomObject recreate(Dictionary<string, string> additionalSaveData, object replacement)
        {
            WindBlock wind = new WindBlock();
            wind.menu.sca = additionalSaveData["sca"];
            wind.menu.gro = additionalSaveData["gro"];
            wind.menu.dur = additionalSaveData["dur"];
            wind.menu.labels[menu.labelIndex] = additionalSaveData["sou"];
            wind.menu.value = Convert.ToSingle(additionalSaveData["vol"]);
            wind.tileLocation.Value = StringToVector2(additionalSaveData["tile"]);
            return wind;
        }
    }
}