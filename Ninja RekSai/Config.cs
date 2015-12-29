using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;


namespace RekSai
{

    public static class Config
    {
        private const string MenuName = "RekSai";

        private static readonly Menu Menu;

        static Config()
        {

            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("RekSai By Zpitty");
            Menu.AddLabel("Report any problems/suggestions to the forum post!");


            Combo.Initialize();
            Flee.Initialize();
            Harass.Initialize();
            JungleClear.Initialize();
            LaneClear.Initialize();
            //LastHit.Initialize();
            Misc.Initialize();
            Smite.Initialize();
            Draw.Initialize();
            
        }

        public static void Initialize()
        {
        }

        public static class Combo
        {
            private static readonly Menu CMBMenu;

            static Combo()
            {
                CMBMenu = Config.Menu.AddSubMenu("Combo");

                ComboMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class ComboMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useQ2;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useE2;
                private static readonly CheckBox _itemUsage;
                private static readonly Slider _e2Distance;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseQ2
                {
                    get { return _useQ2.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseE2
                {
                    get { return _useE2.CurrentValue; }
                }

                public static bool ItemUsage
                {
                    get { return _itemUsage.CurrentValue; }
                }

                public static int E2Distance
                {
                    get { return _e2Distance.CurrentValue; }
                }

                static ComboMenu()
                {

                    CMBMenu.AddGroupLabel("Combo Options");
                    _useQ = CMBMenu.Add("comboUseQ", new CheckBox("Use Q (Unburrowed)"));
                    _useQ2 = CMBMenu.Add("comboUseQ2", new CheckBox("Use Q (Burrowed)"));
                    _useW = CMBMenu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = CMBMenu.Add("comboUseE", new CheckBox("Use E (Unburrowed)"));
                    _useE2 = CMBMenu.Add("comboUseE2", new CheckBox("Use E (Burrowed)"));
                    _itemUsage = CMBMenu.Add("comboUseItems", new CheckBox("Use Items"));
                    _e2Distance = CMBMenu.Add("comboE2Distance", new Slider("Use E (Burrowed) when 0 enemies in range:", 550, 100, 750));
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Flee
        {
            private static readonly Menu FMenu;

            static Flee()
            {
                FMenu = Config.Menu.AddSubMenu("Flee");

                FleeMenu.Initialize();
            }

            public static void Initialize()
            {
            }
            public static class FleeMenu
            {
                private static readonly CheckBox _useE2;

                public static bool UseE2
                {
                    get { return _useE2.CurrentValue; }
                }


                static FleeMenu()
                {
                    FMenu.AddGroupLabel("Flee Options");
                    _useE2 = FMenu.Add("flee", new CheckBox("Use Flee"));
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
                HMenu = Config.Menu.AddSubMenu("Harass");

                HarassMenu.Initialize();
            }

            public static void Initialize()
            {
            }
            public static class HarassMenu
            {
                private static readonly CheckBox _useQ2;

                public static bool UseQ2
                {
                    get { return _useQ2.CurrentValue; }
                }


                static HarassMenu()
                {
                    HMenu.AddGroupLabel("Harass Options");
                    _useQ2 = HMenu.Add("harassQ", new CheckBox("Use Q (burrowed)"));
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
                JMenu = Config.Menu.AddSubMenu("JungleClear");

                JungleClearMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class JungleClearMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useQ2;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;


                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseQ2
                {
                    get { return _useQ2.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }


                static JungleClearMenu()
                {

                    JMenu.AddGroupLabel("JungleClear Options");
                    _useQ = JMenu.Add("jungleUseQ", new CheckBox("Use Q (Unburrowed)"));
                    _useQ2 = JMenu.Add("jungleUseQ2", new CheckBox("Use Q (Burrowed)"));
                    _useW = JMenu.Add("jungleUseW", new CheckBox("Use W"));
                    _useE = JMenu.Add("jungleUseE", new CheckBox("Use E (Unburrowed)"));


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
                LMenu = Config.Menu.AddSubMenu("LaneClear");

                LaneClearMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class LaneClearMenu
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useQ2;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;


                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseQ2
                {
                    get { return _useQ2.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }


                static LaneClearMenu()
                {

                    LMenu.AddGroupLabel("LaneClear Options");
                    _useQ = LMenu.Add("laneUseQ", new CheckBox("Use Q (Unburrowed)"));
                    _useQ2 = LMenu.Add("laneUseQ2", new CheckBox("Use Q (Burrowed)"));
                    _useW = LMenu.Add("laneUseW", new CheckBox("Use W"));
                    _useE = LMenu.Add("laneUseE", new CheckBox("Use E (Unburrowed)"));


                }

                public static void Initialize()
                {
                }
            }
        }

        //public static class LastHit
        //{
        //    private static readonly Menu LHMenu;

        //    static LastHit()
        //    {
        //        LHMenu = Config.Menu.AddSubMenu("Last Hit");

        //        LastHitMenu.Initialize();
        //    }

        //    public static void Initialize()
        //    {
        //    }
        //    public static class LastHitMenu
        //    {
        //        private static readonly CheckBox _useQ2;
        //        private static readonly CheckBox _useW;


        //        public static bool UseQ2
        //        {
        //            get { return _useQ2.CurrentValue; }
        //        }

        //        public static bool UseW
        //        {
        //            get { return _useW.CurrentValue; }
        //        }


        //        static LastHitMenu()
        //        {
        //            LHMenu.AddGroupLabel("LastHit Options");
        //            _useQ2 = LHMenu.Add("lastHitQ2", new CheckBox("Use Q2 (Burrowed)"));
        //            _useW = LHMenu.Add("lastHitW", new CheckBox("Use W"));
        //        }

        //        public static void Initialize()
        //        {
        //        }
        //    }
        //}

        public static class Misc
        {
            private static readonly Menu MMenu;

            static Misc()
            {
                MMenu = Config.Menu.AddSubMenu("Misc");

                MiscMenu.Initialize();
            }

            public static void Initialize()
            {
            }
            public static class MiscMenu
            {
                private static readonly CheckBox _enablePotion;
                private static readonly CheckBox _enableKS;
                private static readonly Slider _minHPPotion;
                private static readonly Slider _minMPPotion;
                private static readonly CheckBox _itemUsage;

                public static bool EnablePotion
                {
                    get { return _enablePotion.CurrentValue; }
                }
                public static bool EnableKS
                {
                    get { return _enableKS.CurrentValue; }
                }

                public static int MinHPPotion
                {
                    get { return _minHPPotion.CurrentValue; }
                }

                public static int MinMPPotion
                {
                    get { return _minMPPotion.CurrentValue; }
                }

                public static bool ItemUsage
                {
                    get { return _itemUsage.CurrentValue; }
                }


                static MiscMenu()
                {
                    MMenu.AddGroupLabel("Misc Options");
                    _enableKS = MMenu.Add("KSEnabled", new CheckBox("Use KS"));
                    _itemUsage = MMenu.Add("miscUseItems", new CheckBox("Use Items JungleClear/LaneClear"));
                    MMenu.AddGroupLabel("Potion Manager");
                    _enablePotion = MMenu.Add("Potion", new CheckBox("Use Potions"));
                    _minHPPotion = MMenu.Add("minHPPotion", new Slider("Use at % Health", 60));
                    _minMPPotion = MMenu.Add("minMPPotion", new Slider("Use at % Mana", 20));
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
                public static readonly CheckBox _drawQ2;
                public static readonly CheckBox _drawE;
                public static readonly CheckBox _drawE2;
                public static readonly CheckBox _drawSmite;

                public static Menu MainMenu
                {
                    get { return DMenu; }
                }


                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawQ2
                {
                    get { return _drawQ2.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }


                public static bool DrawE2
                {
                    get { return _drawE2.CurrentValue; }
                }

                public static bool DrawSmite
                {
                    get { return _drawSmite.CurrentValue; }
                }

                static DrawMenu()
                {
                    DMenu.AddGroupLabel("Draw Options");
                    DMenu.AddSeparator();
                    _drawQ = DMenu.Add("QDraw", new CheckBox("Draw Q (un-burrowed)"));
                    _drawQ2 = DMenu.Add("Q2Draw", new CheckBox("Draw Q (burrowed)"));
                    _drawE = DMenu.Add("EDraw", new CheckBox("Draw E (un-burrowed)"));
                    _drawE2 = DMenu.Add("E2Draw", new CheckBox("Draw E (burrowed)"));
                    _drawSmite = DMenu.Add("SmiteDraw", new CheckBox("Draw Smite"));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}