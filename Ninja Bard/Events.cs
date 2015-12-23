using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using System.Linq;
using Settings = Bard.Config.Modes.Misc;

namespace Bard
{
    public static class Events
    {


        static Events()
        {
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Drawing.OnDraw += OnDraw;
        }

        public static void Initialize()
        {

        }



        private static void OnDraw(EventArgs args)
        {
            if (Config.Draw.DMenu["QDraw"].Cast<CheckBox>().CurrentValue && SpellManager.Q.IsLearned)
            {
                Circle.Draw(Color.Green, SpellManager.Q.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["WDraw"].Cast<CheckBox>().CurrentValue && SpellManager.W.IsLearned)
            {
                Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["RDraw"].Cast<CheckBox>().CurrentValue && SpellManager.R.IsLearned)
            {
                Circle.Draw(Color.DarkBlue, SpellManager.R.Range, Player.Instance.Position);
            }
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender,
            Interrupter.InterruptableSpellEventArgs e)
        {
            if (Settings.RInterrupt && SpellManager.R.IsReady() && SpellManager.R.IsInRange(sender) && sender.IsEnemy)
            {
                SpellManager.R.Cast(sender);
            }
        }

        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            var m = target as Obj_AI_Minion;
            var alliesNearPlayer = EntityManager.Heroes.Allies.Count(a => Player.Instance.Distance(a) <= Player.Instance.AttackRange);

            if (m == null)
            {
                return;
            }

            if (alliesNearPlayer < 1)
            {
                return;
            }

            if (Bard.Config.Modes.Misc.DisableMAA)
            {
                args.Process = false;
            }
        }

        
    }
}
