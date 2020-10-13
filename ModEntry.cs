using System;
using System.Linq;
using MusicBlocks.Instruments;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MusicBlocks
{
    internal class ModEntry : Mod
    {
        internal static ModEntry _instance;
        internal static IModHelper _helper => ModEntry._instance.Helper;
        public AudioEngine audioEngine;
        public static SoundBank soundBank;
        public WaveBank waveBank;
        public static AudioCategory pianoCategory;
        private Cue cue;

        public override void Entry(IModHelper helper)
        {
            _instance = this;
            this.LoadContents(helper);
            pianoCategory = audioEngine.GetCategory("Default");

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.Display.MenuChanged += this.OnMenuChanged;
        }
        private void LoadContents(IModHelper helper)
        {
            Block.TextureKey = helper.Content.Load<Texture2D>(@"assets\Keyboard.png");
            Block.TextureWind = helper.Content.Load<Texture2D>(@"assets\windInstrument.png");
            Block.TextureNotes = helper.Content.Load<Texture2D>(@"assets\notes.png");
            Block.TextureSaveButton = helper.Content.Load<Texture2D>(@"assets\save.png");
            this.audioEngine = new AudioEngine(@"Mods\MusicBlocks\audio\Audio.xgs");
            waveBank = new WaveBank(audioEngine, @"Mods\MusicBlocks\audio\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Mods\MusicBlocks\audio\Sound Bank.xsb");
        }

        private void OnMenuChanged(object sender, MenuChangedEventArgs e)
        {
            if (e.NewMenu is ShopMenu shop && shop.portraitPerson == null && shop.forSale.All(salable => salable is Furniture))
            {
                var itemsForSale = new ISalable[] { new KeyboardBlock(), new WindBlock() };
                foreach (var item in itemsForSale)
                {
                    shop.itemPriceAndStock.Add(item, new int[2] { 0, int.MaxValue });
                    shop.forSale.Add(item);
                }
            }
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            //if (!Context.IsPlayerFree || Game1.currentMinigame != null)
            //    return;
            //if (e.Button == SButton.Space)
            //{
            //    Game1.activeClickableMenu = new Menu(new string[] { "Piano" });
                //cue = soundBank.GetCue("aab40");
                //cue.SetVariable("Volume", 100f);
                //cue.Play();
            //}
            //if (e.Button == SButton.L)
            //{
            //    if (cue != null && cue.IsPlaying)
            //        cue.Stop(AudioStopOptions.Immediate);
            //}
            //if (e.Button == SButton.K)
            //{
            //    if (cue != null && cue.IsPlaying)
            //        cue.Stop(AudioStopOptions.AsAuthored);
            //}

        }
    }
}
