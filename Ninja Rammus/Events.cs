using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Rammus
{
    class Events
    {
        static Events()
        {
            Gapcloser.OnGapcloser += OnGapCloser;
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

            if (Config.Draw.DMenu["EDraw"].Cast<CheckBox>().CurrentValue && SpellManager.E.IsLearned)
            {
                Circle.Draw(Color.LightBlue, SpellManager.E.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["RDraw"].Cast<CheckBox>().CurrentValue && SpellManager.R.IsLearned)
            {
                Circle.Draw(Color.DarkBlue, SpellManager.R.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["SmiteDraw"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Color.Purple, SpellManager.Smite.Range, Player.Instance.Position);
            }
        }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs a)
        {
            if (sender == null || sender.IsAlly || !Config.Modes.MiscMenu.GapCloseE)
            {
                return;
            }

            if ((sender.IsAttackingPlayer || a.End.Distance(Player.Instance) <= 70))
            {
                SpellManager.E.Cast(sender);
            }
        }


    }
}
