using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;

using Settings = RekSai.Config.Combo.ComboMenu;

namespace RekSai.Modes
{
    public sealed class Combo : ModeBase
    {

        private static bool burrowed = false;



        public override bool ShouldBeExecuted()
        {

            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Player.Instance.HasBuff("RekSaiW"))
                burrowed = true;
            else burrowed = false;

            if (Player.Instance.CountEnemiesInRange(800) > 0)
            {

                RekSai.ItemsManager.Yomuus();
            }

            if (burrowed)
            {
                if (Settings.UseW && W.IsReady())
                {
                    var targetw = TargetSelector.GetTarget(Player.Instance.BoundingRadius + 175, DamageType.Physical);
                    if (targetw != null && targetw.IsValidTarget())
                    {
                        W.Cast();
                        return;
                    }
                }

                if (Settings.UseQ2 && Q2.IsReady())
                {
                    var targetQ2 = TargetSelector.GetTarget(850, DamageType.Magical);
                    var predictionQ2 = Q2.GetPrediction(targetQ2);
                    if (targetQ2 != null && targetQ2.IsValidTarget() && predictionQ2.HitChance >= HitChance.Medium)
                    {
                        Q2.Cast(predictionQ2.CastPosition);
                        return;
                    }

                }

                if (Settings.UseE2 && E2.IsReady())
                {
                    var targetE = TargetSelector.GetTarget(550, DamageType.Physical);
                    if (Player.Instance.CountEnemiesInRange(Settings.E2Distance) < 1)
                    {
                        var targetE2 = TargetSelector.GetTarget(E2.Range, DamageType.Physical);
                        var predE2 = E2.GetPrediction(targetE2);
                        if (targetE2.IsValidTarget())
                        {
                            E2.Cast(targetE2.Position + 200);
                            return;

                        }
                    }
                }
            }

                if (!burrowed)
                {
                    if (Settings.UseE && E.IsReady())
                    {
                        var targetE = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                        if (targetE != null && targetE.IsValidTarget())
                        {
                            E.Cast(targetE);
                            return;
                        }
                    }

                    if (Settings.UseW && W.IsReady())
                    {
                        if (Player.Instance.CountEnemiesInRange(400) == 0)
                        {
                            W.Cast();
                            return;
                        }
                    }

                    if (Settings.UseW && W.IsReady())
                    {

                        var lastTarget = Orbwalker.LastTarget;
                        var target = TargetSelector.GetTarget(300, DamageType.Physical);
                        if (lastTarget.IsValidTarget(Player.Instance.BoundingRadius + 250) && !target.HasBuff("reksaiknockupimmune"))
                        {
                            W.Cast();
                            return;
                        }
                    }
                }
            }
        
    }
}
