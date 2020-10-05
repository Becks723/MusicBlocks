using System;
using System.Linq;
using MusicBlocks.Instruments;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using Microsoft.Xna.Framework.Audio;

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
            string a = "{X:53232 Y:9424}";
            float x = Convert.ToSingle(a.Substring(3, a.IndexOf(" ") - 3));
            float y = Convert.ToSingle(a.Substring(a.IndexOf(" ") + 3, a.IndexOf("}") - 3 - a.IndexOf(" ")));
            ModEntry._instance = this;
            this.audioEngine = new AudioEngine(@"Mods\MusicBlocks\audio\Audio.xgs");
            waveBank = new WaveBank(audioEngine, @"Mods\MusicBlocks\audio\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Mods\MusicBlocks\audio\Sound Bank.xsb");
            pianoCategory = audioEngine.GetCategory("Default");

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.Display.MenuChanged += this.OnMenuChanged;
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
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
            if (!Context.IsPlayerFree || Game1.currentMinigame != null)
                return;
            if (e.Button == SButton.Space)
            {
                //cue = soundBank.GetCue("aab40");
                //cue.SetVariable("Volume", 100f);
                //cue.Play();
                int a = Game1.viewport.Width;
                int b = Game1.viewport.Height;
            }
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
