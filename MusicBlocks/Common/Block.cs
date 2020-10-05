using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using PyTK.CustomElementHandler;
using StardewValley;
using StardewValley.Objects;
using StardewValley.Tools;
using MusicBlocks.Instruments;
using Object = StardewValley.Object;

namespace MusicBlocks.Common
{
    internal class Block : Object, ISaveElement
    {
        public Texture2D Texture { get; set; }
        private Dictionary<string, string> musicIndex = new Dictionary<string, string>
        {
            {"A1", "1"},
            {"#A1","2"},
            {"B1", "3"},
            {"C2", "4"},
            {"#C2","5"},
            {"D2", "6"},
            {"#D2","7"},
            {"E2", "8"},
            {"F2", "9"},
            {"#F2","10" },
            {"G2", "11"},
            {"#G2","12" },
            {"A2", "13"},
            {"#A2","14" },
            {"B2", "15"},
            {"C3", "16"},
            {"#C3","17"},
            {"D3", "18"},
            {"#D3","19" },
            {"E3", "20"},
            {"F3", "21"},
            {"#F3","22" },
            {"G3", "23"},
            {"#G3","24" },
            {"A3", "25"},
            {"#A3","26" },
            {"B3", "27"},
            {"C4", "28"},
            {"#C4","29" },
            {"D4", "30"},
            {"#D4","31" },
            {"E4", "32"},
            {"F4", "33"},
            {"#F4","34" },
            {"G4", "35"},
            {"#G4","36" },
            {"A4", "37"},
            {"#A4","38" },
            {"B4", "39"},
            {"C5", "40"},
            {"#C5","41" },
            {"D5", "42"},
            {"#D5","43" },
            {"E5", "44"},
            {"F5", "45"},
            {"#F5","46" },
            {"G5", "47"},
            {"#G5","48" },
            {"A5", "49"},
            {"#A5","50" },
            {"B5", "51"},
            {"C6", "52"},
            {"#C6","53" },
            {"D6", "54"},
            {"#D6","55" },
            {"E6", "56"},
            {"F6", "57"},
            {"#F6","58" },
            {"G6", "59"},
            {"#G6","60" },
            {"A6", "61"},
            {"#A6","62" },
            {"B6", "63"},
            {"C7", "64"},
            {"#C7","65" },
            {"D7", "66"},
            {"#D7","67" },
            {"E7", "68"},
            {"F7", "69"},
            {"#F7","70" },
            {"G7", "71"},
            {"#G7","72" },
            {"A7", "73"},
            {"#A7","74" },
            {"B7", "75"},
            {"C8", "76"},
            {"#C8","77" },
            {"D8", "78"},
            {"#D8","79" },
            {"E8", "80"},
            {"F8", "81"},
            {"#F8","82" },
            {"G8", "83"},
            {"#G8","84" },
            {"A8", "85"},
            {"#A8","86"},
            {"B8", "87" },
            {"Keyboard Block","a" },
            {"Wind Block","b" },
            {"Piano","a" },
            {"0.25","a" },
            {"2.00","b" }
            //{"2.00","c" }
        };
        public Menu menu;
        public string pit;
        public string dur;
        public string sou;
        private Cue cue;
        private static Cue cueInternal;

        public Block()
        {
        }
        public virtual void Build()
        {
            this.Type = "Crafting";
        }
        public override bool actionWhenPurchased()
        {
            return false;
        }
        public override bool canBeTrashed()
        {
            return true;
        }
        public override bool isActionable(Farmer who)
        {
            return true;
        }
        public override bool checkForAction(Farmer who, bool justCheckingForActivity = false)
        {
            if (this.name.Contains("Block"))
            {
                Game1.activeClickableMenu = menu;
                return true;
            }
            return base.checkForAction(who, justCheckingForActivity);
        }
        public override void draw(SpriteBatch b, int x, int y, float alpha = 1f)
        {
            b.Draw(this.Texture, Game1.GlobalToLocal(Game1.viewport, new Vector2((float)(x * 64 + ((this.shakeTimer > 0) ? Game1.random.Next(-1, 2) : 0)), (float)(y * 64 + ((this.shakeTimer > 0) ? Game1.random.Next(-1, 2) : 0)))), new Rectangle?(new Rectangle(0, 0, 16, 16)), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0.01f);
            b.Draw(Game1.shadowTexture, this.getLocalPosition(Game1.viewport) + new Vector2(32f, 53f), new Microsoft.Xna.Framework.Rectangle?(Game1.shadowTexture.Bounds), Color.White, 0f, new Vector2((float)Game1.shadowTexture.Bounds.Center.X, (float)Game1.shadowTexture.Bounds.Center.Y), 4f, SpriteEffects.None, 0f);
        }
        public override void drawInMenu(SpriteBatch b, Vector2 location, float scaleSize, float transparency, float layerDepth, StackDrawType drawStackNumber, Color color, bool drawShadow)
        {
            b.Draw(this.Texture, location + new Vector2(32f, 32f), new Rectangle?(Game1.getSquareSourceRectForNonStandardTileSheet(this.Texture, 16, 16, 0)), color * transparency, 0f, new Vector2(8f, 8f), 4f * scaleSize, SpriteEffects.None, layerDepth);
            if (this.maximumStackSize() > 1 && this.Stack > 1 && (double)scaleSize > 0.3 && this.Stack != 2147483647)
            {
                Utility.drawTinyDigits(this.stack, b, location + new Vector2((float)(64 - Utility.getWidthOfTinyDigitString(this.stack, 3f * scaleSize)) + 3f * scaleSize, (float)(64.0 - 18.0 * (double)scaleSize + 2.0)), 3f * scaleSize, 1f, color);
            }
        }
        public override void drawWhenHeld(SpriteBatch b, Vector2 objectPosition, Farmer f)
        {
            b.Draw(this.Texture, objectPosition, new Rectangle?(Game1.getSquareSourceRectForNonStandardTileSheet(this.Texture, 16, 16, 0)), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, Math.Max(0f, (float)(f.getStandingY() + 3) / 10000f));
        }
        public override void drawPlacementBounds(SpriteBatch b, GameLocation location)
        {
            int x = (int)Game1.GetPlacementGrabTile().X * 64;
            int y = (int)Game1.GetPlacementGrabTile().Y * 64;
            Game1.isCheckingNonMousePlacement = !Game1.IsPerformingMousePlacement();
            bool isCheckingNonMousePlacement = Game1.isCheckingNonMousePlacement;
            if (isCheckingNonMousePlacement)
            {
                Vector2 placementPosition = Utility.GetNearbyValidPlacementPosition(Game1.player, location, this, x, y);
                x = (int)placementPosition.X;
                y = (int)placementPosition.Y;
            }
            bool flag = Utility.playerCanPlaceItemHere(location, this, x, y, Game1.player) || (Utility.isThereAnObjectHereWhichAcceptsThisItem(location, this, x, y) && Utility.withinRadiusOfPlayer(x, y, 1, Game1.player));
            Game1.isCheckingNonMousePlacement = false;
            b.Draw(Game1.mouseCursors, new Vector2((float)(x / 64 * 64 - Game1.viewport.X), (float)(y / 64 * 64 - Game1.viewport.Y)), new Rectangle?(new Rectangle(flag ? 194 : 210, 388, 16, 16)), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0.01f);
        }
        public override bool isPlaceable()
        {
            return true;
        }
        public override bool performToolAction(Tool t, GameLocation location)
        {
            if (t is Pickaxe && this.name.Contains("Block"))
            {
                location.playSound("hammer", 0);
                t.getLastFarmerToUse().currentLocation.debris.Add(new Debris(new KeyboardBlock(), this.tileLocation.Value * 64f + new Vector2(32f, 32f)));
                location.objects.Remove(this.tileLocation);
                return false;
            }
            return false;
        }
        public override void farmerAdjacentAction(GameLocation location)
        {
            if (this.name == null || this.isTemporarilyInvisible)
                return;
            if (this.name.Contains("Block") && (this.pit != menu.sca + menu.gro || this.dur != menu.dur || this.sou != menu.labels[menu.labelIndex]))
            {
                this.pit = musicIndex.ContainsKey(menu.sca + menu.gro) ? menu.sca + menu.gro : null;
                this.dur = menu.dur;
                this.sou = menu.labels[menu.labelIndex];
            }
            if ((this.cue == null || Game1.currentGameTime.TotalGameTime.TotalMilliseconds - this.lastNoteBlockSoundTime >= 1000) && sou != null && pit != null && dur != null)
            {
                if (cueInternal != null && cueInternal.IsPlaying)
                    cueInternal.Stop(AudioStopOptions.AsAuthored);
                cue = ModEntry.soundBank.GetCue(musicIndex[this.name] + musicIndex[sou] + musicIndex[dur] + musicIndex[pit]);
                cue.SetVariable("Volume", menu.value / 2.1f);
                if (menu.whetherToStopNextTime)
                {
                    cueInternal = cue;
                    cueInternal.Play();
                }
                else
                    cue.Play();
                this.scale.Y = 1.3f;
                this.shakeTimer = 200;
                this.lastNoteBlockSoundTime = (int)Game1.currentGameTime.TotalGameTime.TotalMilliseconds;
                return;
            }
        }

        public virtual object getReplacement()
        {
            return new Chest(true);
        }

        public virtual Dictionary<string, string> getAdditionalSaveData()
        {
            Dictionary<string, string> saveData = new Dictionary<string, string>
            {
                { "sca", menu.sca },
                { "gro", menu.gro },
                { "dur", menu.dur },
                { "sou", menu.labels[menu.labelIndex] },
                { "vol", menu.value.ToString() },
                { "tile", this.tileLocation.Value.ToString() }
            };
            return saveData;
        }

        public virtual void rebuild(Dictionary<string, string> additionalSaveData, object replacement)
        {
            Chest chest = (Chest)replacement;
        }

        public Vector2 StringToVector2(string str)
        {
            float x = Convert.ToSingle(str.Substring(3, str.IndexOf(" ") - 3));
            float y = Convert.ToSingle(str.Substring(str.IndexOf(" ") + 3, str.IndexOf("}") - 3 - str.IndexOf(" ")));
            return new Vector2(x, y);
        }
    }
}
