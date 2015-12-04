using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Nunu
{
    internal class Damage
    {
        public static Spell.Targeted Smite;
        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public static double QDamage(Obj_AI_Base target)
        {
            if (!Player.GetSpell(SpellSlot.Q).IsLearned) return 0;
            return _Player.CalculateDamageOnUnit(target, DamageType.True,
                (float)(new double[] { 400, 550, 700, 850, 1000 }[SpellManager.Q.Level - 1]));
        }
    }
}