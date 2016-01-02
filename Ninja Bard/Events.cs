using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using SharpDX;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;
using System.Net;
using System.Text.RegularExpressions;
using Version = System.Version;
using Settings = Bard.Config.Modes.Misc;

namespace Bard
{
    public static class Events
    {


        static Events()
        {
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapCloser;
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

            if (Config.Draw.DMenu["SmiteDraw"].Cast<CheckBox>().CurrentValue && SpellManager.HasSmite())
            {
                Circle.Draw(Color.Purple, SpellManager.Smite.Range, Player.Instance.Position);
            }
        }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender == null || sender.IsAlly || !Config.Modes.Misc.QGapcloser)
            {
                return;
            }
            var gapclosepred = SpellManager.Q.GetPrediction(sender);
            if (SpellManager.Q.IsReady() && SpellManager.Q.IsInRange(sender) && e.End.Distance(Player.Instance) <= 300)
            {
                SpellManager.Q.Cast(gapclosepred.CastPosition);
                return;
            }
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (sender == null || sender.IsAlly || !Config.Modes.Misc.RInterrupt)
            {
                return;
            }

            if (SpellManager.R.IsReady() && SpellManager.R.IsInRange(sender) && e.DangerLevel == DangerLevel.High)
            {
                Core.DelayAction(delegate
                {
                    SpellManager.R.Cast(sender);
                }, Config.Modes.Misc.RInterruptDelay);
                return;
            }
        }


        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            var a = target as Obj_AI_Minion;
            var allys = EntityManager.Heroes.Allies.Count(c => Player.Instance.Distance(c) <= Player.Instance.AttackRange);

            if (a == null)
            {
                return;
            }

            if (allys < 1)
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
