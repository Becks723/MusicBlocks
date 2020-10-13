using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Menus;

namespace MusicBlocks.UI
{
    class Slider : Element
    {
        private readonly string Label;
        private bool withLabel;

        public Slider(string label, int x, int y, int minValue, int maxValue, int value, Action<int> setValue, bool withLabel = true, Func<int, string> format = null) : base(label, x, y, 192, 24, minValue, maxValue, value, setValue, format)
        {
            this.Label = label;
            this.withLabel = withLabel;
        }
        public override void LeftClickHeld(int x, int y)
        {
            if (isHeld)
            {
                if (x < bounds.X)
                    this.value = minValue;
                else if (x > bounds.Right - 40)
                    this.value = maxValue;
                else
                    this.value = (int)((x - this.bounds.X) / (float)(this.bounds.Width - 40) * (maxValue - minValue));
            }
        }
        public override void LeftClickReleased(int x, int y)
        {
            base.LeftClickReleased(x, y);
            this.setValue(this.value);
        }
        public override void PerformHoverAction(int x, int y)
        {
        }
        public override void Draw(SpriteBatch b)
        {
            if (withLabel)
            {
                this.label = $"{this.Label}:{this.Format(this.value)}";
                base.Draw(b);
            }
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, OptionsSlider.sliderBGSource, this.bounds.X, this.bounds.Y, this.bounds.Width, this.bounds.Height, Color.White, 4f, false);
            b.Draw(Game1.mouseCursors, new Vector2(this.bounds.X + (this.bounds.Width - 40) * this.value / (maxValue - minValue), this.bounds.Y), new Rectangle?(OptionsSlider.sliderButtonRect), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0.9f);
        }
    }
}
