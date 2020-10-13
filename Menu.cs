using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MusicBlocks.Instruments;
using MusicBlocks.UI;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace MusicBlocks
{
    public class Menu : IClickableMenu
    {
        private List<ClickableTextureComponent> musicElements = new List<ClickableTextureComponent>();
        private List<ClickableTextureComponent> arrows = new List<ClickableTextureComponent>();
        public string[] Labels;
        private List<Element> components = new List<Element>();
        private Rectangle leftArrow = new Rectangle(8, 268, 44, 40);
        private Rectangle rightArrow = new Rectangle(12, 204, 44, 40);
        private ClickableTextureComponent save;
        internal bool IsSaved = true;
        public int Volume = 70;
        public int Bpm = 100;
        public int Duration = 4;
        public int labelIndex;
        public string Scale;
        public string Group;

        public Menu(string[] labels, string scale = "C", string group = "5", int duration = 4, int timbre = 0, int volume = 70, int bpm = 100) : base()
        {
            this.Scale = scale;
            this.Group = group;
            this.Duration = duration;
            this.labelIndex = timbre;
            this.Volume = volume;
            this.Bpm = bpm;
            this.Labels = labels;
            this.SetUpPositions();
        }
        public override void gameWindowSizeChanged(Rectangle oldBounds, Rectangle newBounds)
        {
            base.gameWindowSizeChanged(oldBounds, newBounds);
            this.SetUpPositions();
        }
        private void SetUpPositions()
        {
            xPositionOnScreen = Game1.viewport.Width / 2 - 425;
            yPositionOnScreen = Game1.viewport.Height / 2 - 250;
            this.width = 850;
            this.height = 500;
            IClickableMenu.borderWidth = 35;
            this.musicElements.Clear();
            this.arrows.Clear();
            this.components.Clear();
            this.musicElements.Add(new ClickableTextureComponent("1", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 8, this.yPositionOnScreen + IClickableMenu.borderWidth * 2, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("2", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 6, this.yPositionOnScreen + IClickableMenu.borderWidth * 2, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("3", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 4, this.yPositionOnScreen + IClickableMenu.borderWidth * 2, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("4", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 2, this.yPositionOnScreen + IClickableMenu.borderWidth * 2, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(32, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("5", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 8, this.yPositionOnScreen + IClickableMenu.borderWidth * 4, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(40, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("6", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 6, this.yPositionOnScreen + IClickableMenu.borderWidth * 4, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(48, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("7", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 4, this.yPositionOnScreen + IClickableMenu.borderWidth * 4, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(56, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("8", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 2, this.yPositionOnScreen + IClickableMenu.borderWidth * 4, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(64, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("C", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 14, this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#C", new Rectangle((int)(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 11.7), this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 64, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 1, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#C", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 11, this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("D", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 9, this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(32, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#D", new Rectangle((int)(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 6.7), this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 64, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 1, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#D", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 6, this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(32, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("E", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 4, this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(40, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("F", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 2, this.yPositionOnScreen + IClickableMenu.borderWidth * 8, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(48, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#F", new Rectangle((int)(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 14.7), this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 64, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 1, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#F", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 14, this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(48, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("G", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 12, this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(56, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#G", new Rectangle((int)(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 9.7), this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 64, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 1, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#G", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 9, this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(56, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("A", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 7, this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#A", new Rectangle((int)(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 4.7), this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 64, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 1, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("#A", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 4, this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 34, 8, 14), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("B", new Rectangle(Game1.viewport.Width - this.xPositionOnScreen - IClickableMenu.borderWidth * 2, this.yPositionOnScreen + IClickableMenu.borderWidth * 11, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 34, 8, 14), 4f, false));
            this.arrows.Add(new ClickableTextureComponent("left arrow", new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth, this.yPositionOnScreen + IClickableMenu.borderWidth, 64, 64), "", "", Game1.mouseCursors, this.leftArrow, 1f, false));
            this.arrows.Add(new ClickableTextureComponent("right arrow", new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth * 8, this.yPositionOnScreen + IClickableMenu.borderWidth, 64, 64), "", "", Game1.mouseCursors, this.rightArrow, 1f, false));
            this.components.Add(new SmallScroll("BPM", this.xPositionOnScreen + IClickableMenu.borderWidth, Game1.viewport.Height - this.yPositionOnScreen - IClickableMenu.borderWidth * 3, 10, 310, Bpm, val => { Bpm = val; }, null));
            this.components.Add(new Slider("Volume", this.xPositionOnScreen + IClickableMenu.borderWidth, Game1.viewport.Height - this.yPositionOnScreen - IClickableMenu.borderWidth * 5, 0, 100, Volume, val => { Volume = val; }, true, null));
            this.components.Add(new Slider("Note", this.xPositionOnScreen + IClickableMenu.borderWidth, Game1.viewport.Height - this.yPositionOnScreen - IClickableMenu.borderWidth * 7, 0, 7, Duration, val => { Duration = val; }, true, val =>
                    {
                        string[] index = { "1/64", "1/32", "1/16", "1/8", "1/4", "1/2", "1", "2" };
                        return index[val];
                    }));
            //this.components.Add(new CheckBox("", this.xPositionOnScreen + IClickableMenu.borderWidth, this.yPositionOnScreen + IClickableMenu.borderWidth * 6));
        }
        public void HandleButtonClick(string name)
        {
            if (name == null)
                return;
            if (name == "left arrow")
            {
                labelIndex--;
                if (labelIndex < 0)
                    labelIndex = Labels.Length - 1;
                goto IL_101;
            }
            if (name == "right arrow")
            {
                labelIndex++;
                if (labelIndex >= Labels.Length)
                    labelIndex = 0;
                goto IL_101;
            }
            if (name == "C" || name == "#C" || name == "D" || name == "#D" || name == "E" || name == "F" || name == "#F" || name == "G" || name == "#G" || name == "A" || name == "#A" || name == "B")
            {
                this.Scale = name;
                goto IL_101;
            }
            if (name == "1" || name == "2" || name == "3" || name == "4" || name == "5" || name == "6" || name == "7" || name == "8")
            {
                this.Group = name;
                goto IL_101;
            }
        //if (name == "save")
        //{
        //    IsSaved = true;
        //}
        IL_101:
            Game1.playSound("bigDeSelect");
        }
        public override void leftClickHeld(int x, int y)
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].LeftClickHeld(x, y);
            }
        }
        public override void receiveLeftClick(int x, int y, bool playsound = true)
        {
            foreach (var button in this.musicElements)
            {
                if (button.containsPoint(x, y))
                {
                    HandleButtonClick(button.name);
                    button.scale -= 0.5f;
                    button.scale = Math.Max(3.5f, button.scale);
                }
            }
            foreach (var arrow in this.arrows)
            {
                if (arrow.containsPoint(x, y))
                {
                    HandleButtonClick(arrow.name);
                    arrow.scale -= 0.2f;
                    arrow.scale = Math.Max(1.2f, arrow.scale);
                }
            }
            //if (this.save.containsPoint(x, y) && !IsSaved)
            //{
            //    HandleButtonClick(save.name);
            //    save.scale -= 0.05f;
            //    save.scale = Math.Max(0.8f, save.scale);
            //}
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].bounds.Contains(x, y))
                    components[i].ReceiveLeftClick(x, y);
            }
        }
        public override void releaseLeftClick(int x, int y)
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].LeftClickReleased(x, y);
            }
        }
        public override void performHoverAction(int x, int y)
        {
            foreach (var button in this.musicElements)
            {
                button.scale = button.containsPoint(x, y) ? Math.Min(button.scale + 0.5f, button.baseScale + 0.3f) : Math.Max(button.scale - 0.02f, button.baseScale);
            }
            foreach (var arrow in this.arrows)
            {
                arrow.scale = arrow.containsPoint(x, y) ? Math.Min(arrow.scale + 0.2f, arrow.baseScale + 0.1f) : Math.Max(arrow.scale - 0.02f, arrow.baseScale);
            }
            //save.scale = save.containsPoint(x, y) && !IsSaved ? Math.Min(save.scale + 0.05f, save.baseScale + 0.05f) : Math.Max(save.scale - 0.02f, save.baseScale);
            for (int i = 0; i < components.Count; i++)
            {
                components[i].PerformHoverAction(x, y);
            }
        }
        public override void draw(SpriteBatch b)
        {
            b.Draw(Game1.fadeToBlackRect, Game1.graphics.GraphicsDevice.Viewport.Bounds, Color.Black * 0.4f);
            IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60), this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, Color.White, 1f, true);
            foreach (ClickableTextureComponent button in this.musicElements)
            {
                button.draw(b);
            }
            foreach (var arrow in this.arrows)
            {
                arrow.draw(b);
            }
            //if (!IsSaved)
            //    save.draw(b);
            //else
            //{
            //    save.draw(b);
            //    save.draw(b, Color.Black * 0.5f, 0.9f);
            //}
            Utility.drawTextWithShadow(b, Labels[labelIndex], Game1.smallFont, new Vector2(this.xPositionOnScreen + IClickableMenu.borderWidth * 3, this.yPositionOnScreen + IClickableMenu.borderWidth), Game1.textColor, 1.5f, -1f, -1, -1, 1f, 3);
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Draw(b);
            }
            base.drawMouse(b);
        }
        //public override void receiveKeyPress(Keys key)
        //{
        //    base.receiveKeyPress(key);
        //    int a = -1;
        //    int b = -1;
        //    int c = -1;
        //    if (key.Equals(Keys.A))
        //    {
        //        a = bpm;
        //        b = duration;
        //        c = volume;
        //    }
        //}
    }
}