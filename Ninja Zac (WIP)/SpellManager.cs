using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using System;
using System.Linq;

namespace Zac
{

    public static class SpellManager
    {
        
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Chargeable E { get; private set; }
        public static Spell.Active R { get; private set; }

        public static uint[] EMaxRanges = new uint[] {1200, 1350, 1500, 1650, 1800 };

        public static int[] EMaxChannelTimes = new int[] { 0, 900, 1000, 1100, 1200, 1300 };




        static SpellManager()
        {

            Q = new Spell.Skillshot(SpellSlot.Q, 550, SkillShotType.Linear);
            W = new Spell.Active(SpellSlot.W, 350);
            E = new Spell.Chargeable(SpellSlot.E, 0, 1800, 1300, 0, 1500, 300);
            R = new Spell.Active(SpellSlot.R, 300);

           //E = new Spell.Chargeable(SpellSlot.E, 250, EMaxRanges[E.Level - 1], EMaxChannelTimes[E.Level - 1], 0, 1500, 300); dont work :(

            Q.AllowedCollisionCount = int.MaxValue;
            E.AllowedCollisionCount = int.MaxValue;
            
        }



        public static void Initialize()
        {

        }
    }
}
