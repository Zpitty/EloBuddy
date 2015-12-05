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
namespace NinjaNunu
{
    public static class Config
    {
        private const string MenuName = "Ninja Nunu";

        public static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Nunu By Zpitty");

            Modes.Initialize();
            Smite.Initialize();
            Draw.Initialize();
            
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            public static readonly Menu Menu;
            public static Spell.Targeted Smite;
            static Modes()
            {

                Menu = Config.Menu.AddSubMenu("Modes");

                Combo.Initialize();
                Menu.AddSeparator();
                Flee.Initialize();
                Menu.AddSeparator();
                Harass.Initialize();
                Menu.AddSeparator();
                JungleClear.Initialize();
                Menu.AddSeparator();
                LaneClear.Initialize();
                Menu.AddSeparator();
                LastHit.Initialize();
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
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", false));
                    _minR = Menu.Add("minnumberR", new Slider("Min. Enemies for R", 2, 0, 5));
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                static Flee()
                {
                    Menu.AddGroupLabel("Flee");
                    _useW = Menu.Add("fleeUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("fleeUseE", new CheckBox("Use E"));
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
                private static readonly Slider _minMana;
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
                public static int MinMana
                {
                    get { return _minMana.CurrentValue; }
                }
                static LaneClear()
                {
                    Menu.AddGroupLabel("LaneClear");
                    _useQ = Menu.Add("laneUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("laneUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("laneUseE", new CheckBox("Use E"));
                    _minMana = Menu.Add("laneMana", new Slider("Use Skills Until % Mana", 40, 0, 100));
                }
                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                private static readonly CheckBox _useE;
                private static readonly Slider _manalasthit;

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int ManaLastHit
                {
                    get { return _manalasthit.CurrentValue; }
                }

                static LastHit()
                {
                    Menu.AddGroupLabel("Last Hit");
                    _useE = Menu.Add("lasthitUseE", new CheckBox("Use E to Last Hit"));
                    _manalasthit = Menu.Add("lasthitmana", new Slider("Use E to Last Hit until % Mana", 20, 0, 100));
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
                    Menu.AddGroupLabel("Misc");
                    _useautoQ = Menu.Add("autouseQ", new CheckBox("Use Auto Q"));
                    _autoQhealth = Menu.Add("autoQhealth", new Slider("Auto Q at health percentage", 20, 0, 100));
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Smite
        {
            public static readonly Menu SMenu;
            static Smite()
            {

                SMenu = Config.Menu.AddSubMenu("Smite Menu");

                SmiteMenu.Initialize();
            }
            public static void Initialize()
            {
            }

            public static class SmiteMenu
            {
                public static readonly CheckBox _smiteEnabled;
                public static readonly CheckBox _smiteEnemies;

                public static Menu MainMenu
                {
                    get { return SMenu; }
                }
                

                public static bool SmiteEnabled
                {
                    get { return _smiteEnabled.CurrentValue; }
                }

                public static bool SmiteEnemies
                {
                    get { return _smiteEnemies.CurrentValue; }
                }

                static SmiteMenu()
                {
                    SMenu.AddGroupLabel("Smite Options");
                    SMenu.AddSeparator();
                    _smiteEnabled = SMenu.Add("EnableSmite", new CheckBox("Always Smite"));
                    _smiteEnemies = SMenu.Add("EnableSmiteEnemies", new CheckBox("Use Blue Smite to KS"));
                    SMenu.AddSeparator();
                    SMenu.AddGroupLabel("Monsters to smite");
                    SMenu.AddLabel("Select monsters you want to smite");
                    SMenu.AddSeparator();
                    SMenu.Add("SRU_Baron", new CheckBox("Baron"));
                    SMenu.Add("SRU_Dragon", new CheckBox("Dragon"));
                    SMenu.Add("SRU_Red", new CheckBox("Red"));
                    SMenu.Add("SRU_Blue", new CheckBox("Blue"));
                    SMenu.Add("SRU_Gromp", new CheckBox("Gromp"));
                    SMenu.Add("SRU_Murkwolf", new CheckBox("Murkwolf"));
                    SMenu.Add("SRU_Krug", new CheckBox("Krug"));
                    SMenu.Add("SRU_Razorbeak", new CheckBox("Razorbeak"));
                    SMenu.Add("Sru_Crab", new CheckBox("Crab"));
                    SMenu.Add("SRU_RiftHerald", new CheckBox("Rift Herald", false));
                }

                public static void Initialize()
                {
                }

            }
        }

        public static class Draw
        {
            public static readonly Menu DMenu;
            static Draw()
            {

                DMenu = Config.Menu.AddSubMenu("Draw Menu");

                DrawMenu.Initialize();
            }
            public static void Initialize()
            {
            }

            public static class DrawMenu
            {
                public static readonly CheckBox _drawQ;
                public static readonly CheckBox _drawW;
                public static readonly CheckBox _drawE;
                public static readonly CheckBox _drawR;
                public static readonly CheckBox _drawSmite;

                public static Menu MainMenu
                {
                    get { return DMenu; }
                }


                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }

                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }

                public static bool DrawSmite
                {
                    get { return _drawSmite.CurrentValue; }
                }
                static DrawMenu()
                {
                    DMenu.AddGroupLabel("Draw Options");
                    DMenu.AddSeparator();
                    _drawQ = DMenu.Add("QDraw", new CheckBox("Draw Q"));
                    _drawW = DMenu.Add("WDraw", new CheckBox("Draw W"));
                    _drawE = DMenu.Add("EDraw", new CheckBox("Draw E"));
                    _drawR = DMenu.Add("RDraw", new CheckBox("Draw R"));
                    _drawSmite = DMenu.Add("SmiteDraw", new CheckBox("Draw Smite"));
                }

                public static void Initialize()
                {
                }

            }
        }
    }
}

