using EloBuddy.SDK;
using SharpDX;
using System.Collections.Generic;

namespace Bard.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            Farm();
        }
        public void Farm()
        {
            var minions = Orbwalker.LaneclearMinions.FindAll(m => m.IsValidTarget(Q.Range));

            if (minions.Count <= 1)
            {
                return;
            }
            if (Q.IsReady() && Config.Modes.JungleClear.UseQ)
            {
                var minion = minions[0];
                foreach (var m in minions)
                {
                    var pred = Q.GetPrediction(m);

                    if (pred.CollisionObjects.Length >= 1)
                    {
                        Q.Cast(m);
                        return;
                    }
                }
            }
        }
    }
}
