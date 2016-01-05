using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace Zac
{
    public static class Config
    {
        private const string MenuName = "Ninja Zac";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Zac By Zpitty");
            Menu.AddLabel("Report any suggestions/problems to the forum post!");


            Combo.Initialize();
            Jump.Initialize();
            Harass.Initialize();
            JungleClear.Initialize();
            LaneClear.Initialize();
            LastHit.Initialize();
            Misc.Initialize();
            Smite.Initialize();
            Draw.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Combo
        {
            private static readonly Menu CMenu;

            static Combo()
            {
                CMenu = Menu.AddSubMenu("Combo");


                ComboMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class ComboMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly Slider _rMin;
                private static readonly Slider _eDistanceOut;
                private static readonly Slider _eDistanceIn;
                private static readonly Slider _curDistance;


                static ComboMenu()
                {
                    CMenu.AddGroupLabel("Combo Options");
                    _useQ = CMenu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = CMenu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = CMenu.Add("comboUseE", new CheckBox("Use E (enemy inside of Cursor drawing)"));
                    _eDistanceIn = CMenu.Add("comboEDistanceIn",
                        new Slider("Use E when enemy is x distance inside E Range", 100, 0, 1000));
                    _eDistanceOut = CMenu.Add("comboEDistanceOut",
                        new Slider("Use E when enemy is x distance away", 250, 0, 1000));
                    _curDistance = CMenu.Add("comboCurDistance",
                        new Slider("Start charging E when cursor is x distance from enemy", 250, 100, 1000));
                    CMenu.AddSeparator();
                    _useR = CMenu.Add("comboUseR", new CheckBox("Use R", false));
                    _rMin = CMenu.Add("comboMinR", new Slider("Min. enemies for R", 2, 0, 5));
                }

                public static Menu MainMenu
                {
                    get { return CMenu; }
                }

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

                public static int RMin
                {
                    get { return _rMin.CurrentValue; }
                }

                public static int EDistanceOut
                {
                    get { return _eDistanceOut.CurrentValue; }
                }

                public static int EDistanceIn
                {
                    get { return _eDistanceIn.CurrentValue; }
                }

                public static int CurDistance
                {
                    get { return _curDistance.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Jump
        {
            private static readonly Menu FMenu;


            static Jump()
            {
                FMenu = Menu.AddSubMenu("Jump");

                JumpMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class JumpMenu
            {
                private static readonly CheckBox _useE;
                private static readonly Slider _eDistanceIn;
                private static readonly Slider _eDistanceOut;


                static JumpMenu()
                {
                    FMenu.AddGroupLabel("Jump Options");
                    FMenu.AddGroupLabel(
                        "Hold T & put cursor on enemy you want to jump on");
                    FMenu.AddGroupLabel("To change keybind change Flee in orbwalker menu");
                    _useE = FMenu.Add("jumpE", new CheckBox("Use E (enemy inside of cursor drawing)"));
                    _eDistanceIn = FMenu.Add("jumpEDistanceIn",
                        new Slider("charge E when target is x units inside E range", 100, 0, 1000));
                    _eDistanceOut = FMenu.Add("jumpEDistanceOut",
                        new Slider("Use E when enemy is x distance away", 100, 0, 1000));
                }


                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int EDistanceIn
                {
                    get { return _eDistanceIn.CurrentValue; }
                }

                public static int EDistanceOut
                {
                    get { return _eDistanceOut.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Harass
        {
            private static readonly Menu HMenu;

            static Harass()
            {
                HMenu = Menu.AddSubMenu("Harass");

                HarassMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class HarassMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;


                static HarassMenu()
                {
                    HMenu.AddGroupLabel("Harass Options");
                    _useQ = HMenu.Add("harassQ", new CheckBox("Use Q"));
                    _useW = HMenu.Add("harassW", new CheckBox("Use W"));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class JungleClear
        {
            private static readonly Menu JMenu;

            static JungleClear()
            {
                JMenu = Menu.AddSubMenu("JungleClear");

                JungleClearMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class JungleClearMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;


                static JungleClearMenu()
                {
                    JMenu.AddGroupLabel("JungleClear Options");
                    _useQ = JMenu.Add("jungleUseQ", new CheckBox("Use Q"));
                    _useW = JMenu.Add("jungleUseW", new CheckBox("Use W"));
                }


                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class LaneClear
        {
            private static readonly Menu LMenu;

            static LaneClear()
            {
                LMenu = Menu.AddSubMenu("LaneClear");

                LaneClearMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class LaneClearMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _minQ;
                private static readonly Slider _minW;


                static LaneClearMenu()
                {
                    LMenu.AddGroupLabel("LaneClear Options");
                    _useQ = LMenu.Add("laneUseQ", new CheckBox("Use Q"));
                    _useW = LMenu.Add("laneUseW", new CheckBox("Use W"));
                    _minQ = LMenu.Add("laneMinQ", new Slider("Minion count for Q", 3, 1, 7));
                    _minW = LMenu.Add("laneMinW", new Slider("Minion count for W", 3, 1, 7));
                }


                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int MinQ
                {
                    get { return _minQ.CurrentValue; }
                }

                public static int MinW
                {
                    get { return _minW.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class LastHit
        {
            private static readonly Menu LHMenu;

            static LastHit()
            {
                LHMenu = Menu.AddSubMenu("Last Hit");

                LastHitMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class LastHitMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;


                static LastHitMenu()
                {
                    LHMenu.AddGroupLabel("LastHit Options");
                    _useQ = LHMenu.Add("lastHitQ", new CheckBox("Use Q"));
                    _useW = LHMenu.Add("lastHitW", new CheckBox("Use W"));
                }


                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Misc
        {
            private static readonly Menu MMenu;

            static Misc()
            {
                MMenu = Menu.AddSubMenu("Misc");

                MiscMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class MiscMenu
            {
                private static readonly CheckBox _enablePotion;
                private static readonly CheckBox _enableKSQ;
                private static readonly CheckBox _enableKSW;
                private static readonly CheckBox _RInterrupt;
                private static readonly Slider _minHPPotion;
                private static readonly Slider _minMPPotion;


                static MiscMenu()
                {
                    MMenu.AddGroupLabel("Misc Options");
                    _RInterrupt = MMenu.Add("InterruptR", new CheckBox("Use R to interrupt"));
                    _enableKSQ = MMenu.Add("KSQ", new CheckBox("Enable KS Q"));
                    _enableKSW = MMenu.Add("KSW", new CheckBox("Enable KS W"));
                    MMenu.AddGroupLabel("Potion Manager");
                    _enablePotion = MMenu.Add("Potion", new CheckBox("Use Potions"));
                    _minHPPotion = MMenu.Add("minHPPotion", new Slider("Use at % Health", 60));
                    _minMPPotion = MMenu.Add("minMPPotion", new Slider("Use at % Mana", 20));
                }

                public static bool EnablePotion
                {
                    get { return _enablePotion.CurrentValue; }
                }

                public static bool RInterrupt
                {
                    get { return _RInterrupt.CurrentValue; }
                }

                public static bool EnableKSQ
                {
                    get { return _enableKSQ.CurrentValue; }
                }

                public static bool EnableKSW
                {
                    get { return _enableKSW.CurrentValue; }
                }

                public static int MinHPPotion
                {
                    get { return _minHPPotion.CurrentValue; }
                }

                public static int MinMPPotion
                {
                    get { return _minMPPotion.CurrentValue; }
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
                SMenu = Menu.AddSubMenu("Smite Menu");

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

                static SmiteMenu()
                {
                    SMenu.AddGroupLabel("Smite Options");
                    SMenu.AddSeparator();
                    _smiteToggle = SMenu.Add("EnableSmite",
                        new KeyBind("Enable Smite Monsters (Toggle)", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _smiteEnemies = SMenu.Add("EnableSmiteEnemies",
                        new KeyBind("Blue Smite KS (Toggle)", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _smiteCombo = SMenu.Add("EnableSmiteCombo",
                        new KeyBind("Red Smite Combo (Toggle)", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _redSmitePercent = SMenu.Add("SmiteRedPercent", new Slider("Red Smite Enemy % HP", 60));
                    SMenu.AddSeparator();
                    SMenu.AddGroupLabel("Smiteable Monsters");
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
                DMenu = Menu.AddSubMenu("Draw Menu");

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
                public static readonly CheckBox _drawCursor;
                public static readonly CheckBox _drawEdistance;

                static DrawMenu()
                {
                    DMenu.AddGroupLabel("Draw Options");
                    DMenu.AddSeparator();
                    _drawQ = DMenu.Add("QDraw", new CheckBox("Draw Q"));
                    _drawW = DMenu.Add("WDraw", new CheckBox("Draw W"));
                    _drawE = DMenu.Add("EDraw", new CheckBox("Draw E"));
                    _drawR = DMenu.Add("RDraw", new CheckBox("Draw R"));
                    _drawSmite = DMenu.Add("SmiteDraw", new CheckBox("Draw Smite"));
                    _drawCursor = DMenu.Add("CurDraw", new CheckBox("Draw Cursor Distance for E Charge"));
                    _drawEdistance = DMenu.Add("Edistance", new CheckBox("Draw Distance for E Charge"));
                }

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

                public static bool DrawCursor
                {
                    get { return _drawCursor.CurrentValue; }
                }

                public static bool DrawEDistance
                {
                    get { return _drawEdistance.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}