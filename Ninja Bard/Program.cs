using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Bard
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Bard";

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                // therefore we return
                return;
            }

            // Initialize the classes that we need
            Config.Initialize();
            Events.Initialize();
            Misc.Initialize();
            ModeManager.Initialize();
            SpellManager.Initialize();
            
            
            

            // Listen to events we need
            
        }
    }
}
