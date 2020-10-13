using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace MusicBlocks.UI
{
    class SmallScroll : Element
    {
        private Rectangle upArrowForSmallScroll = new Rectangle(448, 96, 24, 32);
        private Rectangle downArrowForSmallScroll = new Rectangle(480, 96, 24, 32);

        public SmallScroll(string label, int x, int y, int minValue, int maxValue, int value, Action<int> setValue, Func<int, string> format = null) : base(label, x, y, 80, 40, minValue, maxValue, value, setValue, format)
        {
        }
        public override void LeftClickHeld(int x, int y)
        {
            if (isHeld)
            {
                if (y >= bounds.Bottom + 130)
                    this.value = maxValue;
                else if (y <= bounds.Y - 130)
                    this.value = minValue;
                else
                    this.value = y - 340;
            }
        }
        public override void LeftClickReleased(int x, int y)
        {
            base.LeftClickReleased(x, y);
            setValue(value);
        }
        public override void PerformHoverAction(int x, int y)
        {

        }
        public override void Draw(SpriteBatch b)
        {
            IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60), this.bounds.X, this.bounds.Y, this.bounds.Width, this.bounds.Height, Color.White, 0.6f, false);
            Utility.drawTextWithShadow(b, this.Format(this.value), Game1.smallFont, new Vector2(this.bounds.X + 28, this.bounds.Y + 5), Game1.textColor, 1f, -1f, -1, -1, 1f, 3);
        }
    }
}
