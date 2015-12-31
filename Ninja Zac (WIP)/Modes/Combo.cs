using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using System;
using System.Linq;


using Settings = Zac.Config.Modes.Combo;

namespace Zac.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {

            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Settings.UseE && E.IsReady())
            {
                
                var targetE = TargetSelector.GetTarget((int)new int[] { 1200, 1350, 1500, 1650, 1800 }[SpellManager.E.Level - 1], DamageType.Magical);
                var EPred = E.GetPrediction(targetE);
                var direction = targetE.Direction;

                if (!Events.ChannelingE)
                {
                    if (targetE != null)
                    {
                        if (!ObjectManager.Player.IsFacing(targetE))
                        { return; }
                        if (ObjectManager.Player.IsFacing(targetE) && targetE.Distance(Player.Instance.Position) > 550)
                        {

                            if (targetE.Distance(Game.ActiveCursorPos) < 300)
                            {
                                E.StartCharging();
                                return;
                            }
                        }
                    }
                }

                if (Events.ChannelingE)
                {

                    if (EPred.HitChance >= HitChance.High)
                    {
                        if (EPred.CastPosition.Distance(Player.Instance.Position) <= (int)new int[] { 1200, 1350, 1500, 1650, 1800 }[SpellManager.E.Level - 1])
                        {
                            E.Cast(EPred.CastPosition);
                            return;
                        }
                    }
                }
            }
            if (!Events.ChannelingE && Settings.UseQ && Q.IsReady())
            {
                var targetQ = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                if (targetQ != null)
                {
                    Q.Cast(targetQ);
                    return;
                }
            }

            if (!Events.ChannelingE &&  Settings.UseW && W.IsReady())
            {
                var targetW = TargetSelector.GetTarget(W.Range, DamageType.Magical);
                if (targetW != null)
                {
                    W.Cast();
                    return;
                }
            }            
        }
    }
}
