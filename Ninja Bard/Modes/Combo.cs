using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = Bard.Config.Modes.Combo;

namespace Bard.Modes
{
    public sealed class Combo : ModeBase
    {
        public static AIHeroClient _Bard
        {
            get { return ObjectManager.Player; }
        }

        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            #region Q Logic

            if (Settings.UseQ && Q.IsReady())
            {

                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                var predictionQ = Q.GetPrediction(target);

                if (target == null) { return; }

                if (target != null && target.IsValid && Misc.WallBangable(target))
                {
                    Q.Cast(target);
                    return;
                }

                else if (predictionQ.CollisionObjects.Count() == 1)
                {
                    Q.Cast(predictionQ.CastPosition);
                    return;
                }

            }
            #endregion
        }
    }
}
