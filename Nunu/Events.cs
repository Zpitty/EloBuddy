using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace NinjaNunu
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
            if (Config.Draw.DMenu["QDraw"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Color.Green, 195, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["WDraw"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["EDraw"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Color.LightBlue, SpellManager.E.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["RDraw"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Color.DarkBlue, SpellManager.R.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["SmiteDraw"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Color.Purple, SpellManager.Smite.Range, Player.Instance.Position);
            }
        }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Player.Instance.Spellbook.IsChanneling || Player.Instance.HasBuff("Absolute Zero"))
            {
                return;
            }

            if (sender == null || sender.IsAlly || !Config.Modes.MiscMenu.GapcloseE)
            {
                return;
            }

            if ((sender.IsAttackingPlayer || e.End.Distance(Player.Instance) <= 70))
            {
                SpellManager.E.Cast(sender);
            }
        }


    }
}
