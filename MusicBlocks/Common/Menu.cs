using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace MusicBlocks.Common
{
    class Menu : IClickableMenu
    {
        public List<ClickableTextureComponent> musicElements = new List<ClickableTextureComponent>();
        public List<ClickableTextureComponent> arrows = new List<ClickableTextureComponent>();
        public List<string> labels = new List<string>();
        private bool isSliderHeld;
        private Rectangle leftArrow = new Rectangle(8, 268, 44, 40);
        private Rectangle rightArrow = new Rectangle(12, 204, 44, 40);
        private int sliderX;
        private int sliderY;
        private int sliderWidth;
        private int sliderHeight;
        private int tickWidth;
        private ClickableComponent sliderBound;
        private ClickableComponent checkBoxBound;
        public float value = 50 * 2.1f;
        public bool whetherToStopNextTime;
        public int labelIndex;
        public string sca;
        public string gro;
        public string dur;

        public Menu()
        {
        }

        public Menu(params string[] labels)
        {
            this.labels.Clear();
            for (int i = 0; i < labels.Length; i++)
            {
                this.labels.Add(labels[i]);
            }
            this.SetUpPositions(this.labels);
        }

        public override void gameWindowSizeChanged(Rectangle oldBounds, Rectangle newBounds)
        {
            base.gameWindowSizeChanged(oldBounds, newBounds);
            this.SetUpPositions(this.labels);
        }

        private void SetUpPositions(List<string> labels)
        {
            //this.xPositionOnScreen = Game1.viewport.Width / 6;
            //this.yPositionOnScreen = Game1.viewport.Height / 6;
            //this.width = Game1.viewport.Width / 3 * 2;
            //this.height = Game1.viewport.Height / 3 * 2;

            xPositionOnScreen = Game1.viewport.Width / 2 - 425;
            yPositionOnScreen = Game1.viewport.Height / 2 - 250;
            this.width = 850;
            this.height = 500;

            IClickableMenu.borderWidth = 35;
            this.sliderX = this.xPositionOnScreen + IClickableMenu.borderWidth;
            this.sliderY = Game1.viewport.Height - this.yPositionOnScreen - IClickableMenu.borderWidth * 5;
            this.sliderWidth = Game1.viewport.Width / 5;
            this.sliderHeight = Game1.viewport.Height / 25;
            this.tickWidth = (int)((float)this.sliderHeight * 10 / 6);

            this.musicElements.Clear();
            this.arrows.Clear();
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
            this.musicElements.Add(new ClickableTextureComponent("0.25", new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth * 1, Game1.viewport.Height - this.yPositionOnScreen - IClickableMenu.borderWidth * 3, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), 4f, false));
            this.musicElements.Add(new ClickableTextureComponent("2.00", new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth * 3, Game1.viewport.Height - this.yPositionOnScreen - IClickableMenu.borderWidth * 3, 32, 64), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), 4f, false));
            this.arrows.Add(new ClickableTextureComponent("left arrow", new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth, this.yPositionOnScreen + IClickableMenu.borderWidth, 64, 64), "", "", Game1.mouseCursors, this.leftArrow, 1f, false));
            this.arrows.Add(new ClickableTextureComponent("right arrow", new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth * 8, this.yPositionOnScreen + IClickableMenu.borderWidth, 64, 64), "", "", Game1.mouseCursors, this.rightArrow, 1f, false));
            this.sliderBound = new ClickableComponent(new Rectangle(this.sliderX, this.sliderY, this.sliderWidth, this.sliderHeight), "");
            this.checkBoxBound = new ClickableComponent(new Rectangle(this.xPositionOnScreen + IClickableMenu.borderWidth, this.yPositionOnScreen + IClickableMenu.borderWidth * 6, OptionsCheckbox.sourceRectChecked.Width * 4, OptionsCheckbox.sourceRectChecked.Height * 4), "");
        }

        public void HandleButtonClick(string name)
        {
            if (name == null)
                return;
            if (name == "left arrow")
            {
                labelIndex--;
                if (labelIndex < 0)
                    labelIndex = labels.Count - 1;
                goto IL_101;
            }
            if (name == "right arrow")
            {
                labelIndex++;
                if (labelIndex >= labels.Count)
                    labelIndex = 0;
                goto IL_101;
            }
            if (name == "C" || name == "#C" || name == "D" || name == "#D" || name == "E" || name == "F" || name == "#F" || name == "G" || name == "#G" || name == "A" || name == "#A" || name == "B")
            {
                this.sca = name;
                goto IL_101;
            }
            if (name == "1" || name == "2" || name == "3" || name == "4" || name == "5" || name == "6" || name == "7" || name == "8")
            {
                this.gro = name;
                goto IL_101;
            }
            if (name == "0.25" || name == "2.00")
            {
                this.dur = name;
                goto IL_101;
            }
        IL_101:
            Game1.playSound("bigDeSelect");
        }


        public override void leftClickHeld(int x, int y)
        {
            if (this.isSliderHeld)
            {
                if (x < this.sliderX)
                    this.value = 0;
                else if (x > this.sliderX + this.sliderWidth - this.tickWidth)
                    this.value = this.sliderWidth - this.tickWidth;
                else
                    this.value = x - this.sliderX;
            }
        }

        public override void receiveLeftClick(int x, int y, bool playsound = true)
        {
            foreach (ClickableTextureComponent button in this.musicElements)
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
            if (this.sliderBound.containsPoint(x, y))
            {
                this.leftClickHeld(x, y);
                this.isSliderHeld = true;
            }
            if (this.checkBoxBound.containsPoint(x, y))
            {
                this.whetherToStopNextTime = !this.whetherToStopNextTime;
                Game1.playSound("drumkit6");
            }
        }

        public override void releaseLeftClick(int x, int y)
        {
            this.isSliderHeld = false;
        }

        public override void performHoverAction(int x, int y)
        {
            foreach (ClickableTextureComponent button in this.musicElements)
            {
                button.scale = button.containsPoint(x, y) ? Math.Min(button.scale + 0.5f, button.baseScale + 0.3f) : Math.Max(button.scale - 0.02f, button.baseScale);
            }
            foreach (var arrow in this.arrows)
            {
                arrow.scale = arrow.containsPoint(x, y) ? Math.Min(arrow.scale + 0.2f, arrow.baseScale + 0.1f) : Math.Max(arrow.scale - 0.02f, arrow.baseScale);
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
            Utility.drawTextWithShadow(b, labels[labelIndex], Game1.smallFont, new Vector2(this.xPositionOnScreen + IClickableMenu.borderWidth * 3, this.yPositionOnScreen + IClickableMenu.borderWidth), Game1.textColor, 1.5f, -1f, -1, -1, 1f, 3);
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, OptionsSlider.sliderBGSource, this.sliderX, this.sliderY, this.sliderWidth, this.sliderHeight, Color.White, 4f, false);
            b.Draw(Game1.mouseCursors, new Vector2(this.sliderX + this.value, this.sliderY), new Rectangle?(OptionsSlider.sliderButtonRect), Color.White, 0f, Vector2.Zero, (float)this.sliderHeight / 6, SpriteEffects.None, 0.9f);
            b.Draw(Game1.mouseCursors, new Vector2(this.xPositionOnScreen + IClickableMenu.borderWidth, this.yPositionOnScreen + IClickableMenu.borderWidth * 6), new Rectangle?(this.whetherToStopNextTime ? OptionsCheckbox.sourceRectChecked : OptionsCheckbox.sourceRectUnchecked), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0.4f);
            base.drawMouse(b);
        }
    }
}