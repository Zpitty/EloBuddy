using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;


using Settings = RekSai.Config.Harass.HarassMenu;

namespace RekSai.Modes
{
    public sealed class Harass : ModeBase
    {
        private static bool burrowed = false;

        public override bool ShouldBeExecuted()
        {

            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {

            if (Player.Instance.HasBuff("RekSaiW"))
                burrowed = true;
            else burrowed = false;

            if (Settings.UseQ2 && Q2.IsReady())
            {
                var targetQ2 = TargetSelector.GetTarget(Q2.Range, DamageType.Magical);
                var predictionQ2 = Q2.GetPrediction(targetQ2);
                if (burrowed && targetQ2 != null && targetQ2.IsValidTarget() && predictionQ2.HitChance >= HitChance.Medium)
                {
                    Q2.Cast(predictionQ2.CastPosition);
                    return;
                }
                else if (!burrowed && predictionQ2.HitChance >= HitChance.Medium)
                {
                    W.Cast();
                    return;
                }
            }
            
        }
    }
}
