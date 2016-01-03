﻿using EloBuddy;
using EloBuddy.SDK;

namespace Bard
{
    class Utility
    {
        public static Item HealthPotion;
        public static Item CorruptingPotion;
        public static Item RefillablePotion;
        public static Item HuntersPotion;
        public static Item TotalBiscuit;

        static Utility()
        {
            HealthPotion = new Item(2003, 0);
            TotalBiscuit = new Item(2010, 0);
            CorruptingPotion = new Item(2033, 0);
            RefillablePotion = new Item(2031, 0);
            HuntersPotion = new Item(2032, 0);
        }

        //VodkaSmite
        public readonly static string[] MonstersNames =
        {
            "SRU_Blue", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak",
            "SRU_Red", "SRU_Krug", "SRU_Dragon", "Sru_Crab", "SRU_Baron", "SRU_RiftHerald"
        };

        public readonly static string[] IMportantMonsters =
        {
            "SRU_Gromp", "SRU_Dragon", "Sru_Crab", "SRU_Baron", "SRU_RiftHerald"
        };

        public static readonly string[] SmiteNames =
        {
            "summonersmite", "s5_summonersmiteplayerganker", "s5_summonersmiteduel"
        };

        private static readonly int[] SmiteRed = { 3715, 1415, 1414, 1413, 1412 };
        private static readonly int[] SmiteBlue = { 3706, 1403, 1402, 1401, 1400 };

        public static float SmiteDmgMonster(Obj_AI_Base target)
        {
            return Player.Instance.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Smite);
        }

        public static float SmiteDmgHero(AIHeroClient target)
        {
            return Player.Instance.CalculateDamageOnUnit(target, DamageType.True,
                20.0f + Player.Instance.Level * 8.0f);
        }

        public static float IgniteDmg(Obj_AI_Base target)
        {
            return Player.Instance.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Ignite);
        }

        public static void Initialize()
        {
        }
    }
}