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
    class CheckBox:Element
    {
        public bool isChecked;

        public CheckBox(string label,int x,int y) : base(label, x, y, 36, 36) { }
        public override void ReceiveLeftClick(int x, int y)
        {
            isChecked = !isChecked;
            Game1.playSound("drumkit6");
        }
        public override void Draw(SpriteBatch b)
        {
            b.Draw(Game1.mouseCursors, new Vector2(this.bounds.X,this.bounds.Y), new Rectangle?(this.isChecked ? OptionsCheckbox.sourceRectChecked : OptionsCheckbox.sourceRectUnchecked), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0.4f);
        }
    }
}
