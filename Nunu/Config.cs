using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;


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
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _manaW;
                private static readonly Slider _minR;

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

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int MinR
                {
                    get { return _minR.CurrentValue; }
                }

                static Combo()
                {
                    Menu.AddGroupLabel("Combo");
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", false));
                    _manaW = Menu.Add("WMana", new Slider("Use W Until % Mana", 35));
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
                    _minMana = Menu.Add("harassMana", new Slider("Use E Until % Mana", 20));
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

                static JungleClear()
                {
                    Menu.AddGroupLabel("JungleClear");
                    _useQ = Menu.Add("jungleUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("jungleUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("jungleUseE", new CheckBox("Use E"));
                    _minMana = Menu.Add("jungleMana", new Slider("Use W/E Until % Mana", 30));
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
                    _minMana = Menu.Add("laneMana", new Slider("Use Q/W/E Until % Mana", 30));
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
                    _manalasthit = Menu.Add("lasthitmana", new Slider("Use E to Last Hit until % Mana", 20));
                }

                public static void Initialize()
                {
                }
            }

            

            public static class MiscMenu
            {
                private static readonly CheckBox _useautoQ;
                private static readonly CheckBox _enablePotion;
                private static readonly Slider _autoQhealth;
                private static readonly Slider _minHPPotion;
                private static readonly Slider _minMPPotion;

                public static bool UseAutoQ
                {
                    get { return _useautoQ.CurrentValue; }
                }

                public static bool EnablePotion
                {
                    get { return _enablePotion.CurrentValue; }
                }

                public static int AutoQHealth
                {
                    get { return _autoQhealth.CurrentValue; }
                }

                public static int MinHPPotion
                {
                    get { return _minHPPotion.CurrentValue; }
                }

                public static int MinMPPotion
                {
                    get { return _minMPPotion.CurrentValue; }
                }


                static MiscMenu()
                {
                    Menu.AddGroupLabel("Misc");
                    _useautoQ = Menu.Add("autouseQ", new CheckBox("Use Auto Q"));
                    _autoQhealth = Menu.Add("autoQhealth", new Slider("Auto Q at health percentage", 35));
                    Menu.AddSeparator();
                    Menu.AddGroupLabel("Potion Manager");
                    _enablePotion = Menu.Add("Potion", new CheckBox("Use Potions"));
                    _minHPPotion = Menu.Add("minHPPotion", new Slider("Use at % Health", 70));
                    _minMPPotion = Menu.Add("minMPPotion", new Slider("Use at % Mana", 20));
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
                public static readonly KeyBind _smiteEnemies;
                public static readonly KeyBind _smiteCombo;
                private static readonly KeyBind _smiteToggle;
                private static readonly Slider _redSmitePercent;

                public static Menu MainMenu
                {
                    get { return SMenu; }
                }


                public static bool SmiteToggle
                {
                    get { return _smiteToggle.CurrentValue; }
                }

                public static bool SmiteEnemies
                {
                    get { return _smiteEnemies.CurrentValue; }
                }

                public static bool SmiteCombo
                {
                    get { return _smiteCombo.CurrentValue; }
                }

                public static int RedSmitePercent
                {
                    get { return _redSmitePercent.CurrentValue; }
                }

                static SmiteMenu()
                {
                    SMenu.AddGroupLabel("Smite Options");
                    SMenu.AddSeparator();
                    _smiteToggle = SMenu.Add("EnableSmite", new KeyBind("Enable Smite Monsters (Toggle)", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _smiteEnemies = SMenu.Add("EnableSmiteEnemies", new KeyBind("Blue Smite KS (Toggle)", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _smiteCombo = SMenu.Add("EnableSmiteCombo", new KeyBind("Red Smite Combo (Toggle)", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _redSmitePercent = SMenu.Add("SmiteRedPercent", new Slider("Red Smite Enemy % HP", 60));
                    SMenu.AddSeparator();
                    SMenu.AddGroupLabel("Smite-able Monsters");
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

