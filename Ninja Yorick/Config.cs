using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace Yorick
{
    public static class Config
    {
        private const string MenuName = "Ninja Yorick";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Yorick By Zpitty");
            Menu.AddLabel("Reporty any suggestions/problems to the forum post!");


            Combo.Initialize();
            Flee.Initialize();
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
                private static readonly CheckBox _clone;
                private static readonly Slider _healthR;

                static ComboMenu()
                {
                    CMenu.AddGroupLabel("Combo");
                    _useQ = CMenu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = CMenu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = CMenu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = CMenu.Add("comboUseR", new CheckBox("Use R", false));
                    _clone = CMenu.Add("comboclone", new CheckBox("Move Clone?"));
                    _healthR = CMenu.Add("combohealthR", new Slider("Use R when Health % below", 20));
                    CMenu.AddLabel("Use R on:");
                    if (EntityManager.Heroes.Allies.Count > 0)
                    {
                        var addedChamps = new List<string>();
                        foreach (
                            var ally in
                                EntityManager.Heroes.Allies.Where(ally => !addedChamps.Contains(ally.ChampionName)))
                        {
                            addedChamps.Add(ally.ChampionName);
                            CMenu.Add(ally.ChampionName, new CheckBox(string.Format("{0}", ally.ChampionName)));
                        }
                    }
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

                public static int HealthR
                {
                    get { return _healthR.CurrentValue; }
                }

                public static bool Clone
                {
                    get { return _clone.CurrentValue; }
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
                FMenu = Menu.AddSubMenu("Flee");

                FleeMenu.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class FleeMenu
            {
                private static readonly CheckBox _useW;


                static FleeMenu()
                {
                    FMenu.AddGroupLabel("Flee Options");
                    _useW = FMenu.Add("fleeW", new CheckBox("Use W"));
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
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _manaW;
                private static readonly Slider _manaE;


                static HarassMenu()
                {
                    HMenu.AddGroupLabel("Harass Options");
                    _useW = HMenu.Add("harassW", new CheckBox("Use W"));
                    _useE = HMenu.Add("harassE", new CheckBox("Use E"));
                    _manaW = HMenu.Add("harassManaW", new Slider("Use W until % Mana", 40));
                    _manaE = HMenu.Add("harassManaE", new Slider("Use E until % Mana", 40));
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int ManaE
                {
                    get { return _manaE.CurrentValue; }
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
                private static readonly CheckBox _useE;
                private static readonly Slider _manaQ;
                private static readonly Slider _manaE;
                private static readonly Slider _manaW;


                static JungleClearMenu()
                {
                    JMenu.AddGroupLabel("JungleClear Options");
                    _useQ = JMenu.Add("jungleUseQ", new CheckBox("Use Q"));
                    _useW = JMenu.Add("jungleUseW", new CheckBox("Use W"));
                    _useE = JMenu.Add("jungleUseE", new CheckBox("Use E"));
                    _manaQ = JMenu.Add("jungleManaQ", new Slider("Use Q until % Mana", 40));
                    _manaW = JMenu.Add("jungleManaW", new Slider("Use W until % Mana", 40));
                    _manaE = JMenu.Add("jungleManaE", new Slider("Use E until % Mana", 40));
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

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                public static int ManaE
                {
                    get { return _manaE.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
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
                private static readonly CheckBox _useE;
                private static readonly Slider _manaQ;
                private static readonly Slider _manaW;
                private static readonly Slider _manaE;
                private static readonly Slider _minW;


                static LaneClearMenu()
                {
                    LMenu.AddGroupLabel("LaneClear Options");
                    _useQ = LMenu.Add("laneUseQ", new CheckBox("Use Q"));
                    _useW = LMenu.Add("laneUseW", new CheckBox("Use W"));
                    _useE = LMenu.Add("laneUseE", new CheckBox("Use E"));
                    _minW = LMenu.Add("laneMinW", new Slider("Minion count for W", 3, 1, 4));
                    _manaQ = LMenu.Add("laneManaQ", new Slider("Use Q until % Mana", 40));
                    _manaW = LMenu.Add("laneManaW", new Slider("Use W until % Mana", 40));
                    _manaE = LMenu.Add("laneManaE", new Slider("Use E until % Mana", 40));
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

                public static int ManaQ
                {
                    get { return _manaQ.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int ManaE
                {
                    get { return _manaE.CurrentValue; }
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
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _manaW;
                private static readonly Slider _manaE;


                static LastHitMenu()
                {
                    LHMenu.AddGroupLabel("LastHit Options");
                    _useW = LHMenu.Add("lastHitW", new CheckBox("Use W"));
                    _useE = LHMenu.Add("lastHitE", new CheckBox("Use E"));
                    _manaW = LHMenu.Add("lastHitManaW", new Slider("Use W until % Mana", 40));
                    _manaE = LHMenu.Add("lastHitManaE", new Slider("Use E until % Mana", 40));
                }


                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int ManaW
                {
                    get { return _manaW.CurrentValue; }
                }

                public static int ManaE
                {
                    get { return _manaE.CurrentValue; }
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
                private static readonly CheckBox _igniteks;
                private static readonly CheckBox _ksq;
                private static readonly CheckBox _ksw;
                private static readonly CheckBox _kse;
                private static readonly Slider _minHPPotion;
                private static readonly Slider _minMPPotion;


                static MiscMenu()
                {
                    MMenu.AddGroupLabel("Misc Options");
                    _igniteks = MMenu.Add("ksignite", new CheckBox("Use Ignite to KS"));
                    _ksq = MMenu.Add("ksq", new CheckBox("Use Q to KS"));
                    _ksw = MMenu.Add("ksw", new CheckBox("Use W to KS"));
                    _kse = MMenu.Add("kse", new CheckBox("Use E to KS"));
                    MMenu.AddGroupLabel("Potion Manager");
                    _enablePotion = MMenu.Add("Potion", new CheckBox("Use Potions"));
                    _minHPPotion = MMenu.Add("minHPPotion", new Slider("Use at % Health", 60));
                    _minMPPotion = MMenu.Add("minMPPotion", new Slider("Use at % Mana", 20));
                }

                public static bool Igniteks
                {
                    get { return _igniteks.CurrentValue; }
                }

                public static bool Ksq
                {
                    get { return _ksq.CurrentValue; }
                }

                public static bool Ksw
                {
                    get { return _ksw.CurrentValue; }
                }

                public static bool Kse
                {
                    get { return _kse.CurrentValue; }
                }

                public static bool EnablePotion
                {
                    get { return _enablePotion.CurrentValue; }
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
                public static readonly CheckBox _drawW;
                public static readonly CheckBox _drawE;
                public static readonly CheckBox _drawR;
                public static readonly CheckBox _drawSmite;

                static DrawMenu()
                {
                    DMenu.AddGroupLabel("Draw Options");
                    DMenu.AddSeparator();
                    _drawW = DMenu.Add("WDraw", new CheckBox("Draw W"));
                    _drawE = DMenu.Add("EDraw", new CheckBox("Draw E"));
                    _drawR = DMenu.Add("RDraw", new CheckBox("Draw R"));
                    _drawSmite = DMenu.Add("SmiteDraw", new CheckBox("Draw Smite (if enabled)"));
                }

                public static Menu MainMenu
                {
                    get { return DMenu; }
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

                public static void Initialize()
                {
                }
            }
        }
    }
}