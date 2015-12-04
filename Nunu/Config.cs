using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace Nunu
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Ninja Nunu";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to this AddonTemplate!");
            Menu.AddLabel("To change the menu, please have a look at the");
            Menu.AddLabel("Config.cs class inside the project, now have fun!");

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();
                Harass.Initialize();
                Menu.AddSeparator();
                JungleClear.Initialize();
                Menu.AddSeparator();
                LaneClear.Initialize();
                Menu.AddSeparator();
                MiscMenu.Initialize();




            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _minR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static int MinR
                {
                    get { return _minR.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", false)); // Default false
                    _minR = Menu.Add("minnumberR", new Slider("Min. Enemies for R", 2, 0, 5));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useE;
                private static readonly Slider _minMana;
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static int MinMana
                {
                    get { return _minMana.CurrentValue; }
                }

                static Harass()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Harass");
                    _useE = Menu.Add("harassUseE", new CheckBox("Use E"));
                    _minMana = Menu.Add("harassMana", new Slider("Minimum Mana", 40, 0, 100));
                }

                public static void Initialize()
                {
                }
            }
            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _minManaE;
                private static readonly Slider _minManaW;



                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static int MinManaE
                {
                    get { return _minManaE.CurrentValue; }
                }
                public static int MinManaW
                {
                    get { return _minManaW.CurrentValue; }
                }

                static JungleClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("JungleClear");
                    _useQ = Menu.Add("jungleUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("jungleUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("jungleUseE", new CheckBox("Use E"));
                    _minManaE = Menu.Add("jungleManaW", new Slider("Minimum Mana W", 40, 0, 100));
                    _minManaW = Menu.Add("jungleManaE", new Slider("Minimum Mana E", 40, 0, 100));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _minManaE;
                private static readonly Slider _minManaW;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static int MinManaE
                {
                    get { return _minManaE.CurrentValue; }
                }
                public static int MinManaW
                {
                    get { return _minManaW.CurrentValue; }
                }
                static LaneClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("LaneClear");
                    _useQ = Menu.Add("laneUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("laneUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("laneUseE", new CheckBox("Use E"));
                    _minManaE = Menu.Add("laneManaW", new Slider("Minimum Mana W", 40, 0, 100));
                    _minManaW = Menu.Add("laneManaE", new Slider("Minimum Mana E", 40, 0, 100));
                }
                public static void Initialize()
                {
                }
            }


            public static class MiscMenu
            {
                private static readonly CheckBox _useautoQ;
                private static readonly Slider _autoQhealth;

                public static bool UseAutoQ
                {
                    get { return _useautoQ.CurrentValue; }
                }
                public static int AutoQHealth
                {
                    get { return _autoQhealth.CurrentValue; }
                }


                static MiscMenu()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Misc");
                    _useautoQ = Menu.Add("autouseQ", new CheckBox("Use Auto Q"));
                    _autoQhealth = Menu.Add("autoQhealth", new Slider("Auto Q at health percentage", 20, 0, 100));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}

