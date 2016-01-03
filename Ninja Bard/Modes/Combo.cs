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
                var Qext = TargetSelector.GetTarget(Q2.Range, DamageType.Magical);
                var predQext = Q2.GetPrediction(Qext);

                if (target == null) { return; }

                if (target != null && target.IsValid && Misc.WallBangable(target) && predictionQ.CollisionObjects.Count() == 0)
                {
                    Q.Cast(predictionQ.CastPosition);
                    return;
                }
                //else if (predictionQ.CollisionObjects.Count() == 1)
                //{
                //    Q.Cast(predictionQ.CastPosition);
                //    return;
                //}

                //if (Qext == null)
                //{ return; }
                else if (predQext.CollisionObjects.Count(a => a.IsValidTarget(Q.Range) && a.Distance(Qext) <= Settings.QBindDistanceM) == 1)
                {
                    Q.Cast(predQext.CastPosition);
                    return;
                }
            }
            #endregion
        }
    }
}
