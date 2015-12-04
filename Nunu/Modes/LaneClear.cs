using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = Nunu.Config.Modes.LaneClear;

namespace Nunu.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {

            if (Settings.UseQ && Q.IsReady())
            {
                var Lmonsters = EntityManager.MinionsAndMonsters.GetLaneMinions().OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) < 1300);
                if (Lmonsters != null)
                {
                    Q.Cast(Lmonsters);
                    return;
                }
            }

            if (Settings.UseW && W.IsReady() && Player.Instance.ManaPercent >= Settings.MinManaW)
            {
                var ally = EntityManager.Heroes.Allies.OrderByDescending(a => a.TotalAttackDamage).FirstOrDefault(b => b.Distance(Player.Instance) < 700);
                if (ally != null && Player.Instance.CountEnemiesInRange(1500) > 1)
                {
                    W.Cast(ally);
                    return;
                }
                if (Settings.UseW && W.IsReady() && Player.Instance.CountEnemiesInRange(1500) > 1)
                {
                    W.Cast(Player.Instance);
                    return;
                }
            }
            // TODO: Add laneclear logic here
            if (Settings.UseE && E.IsReady() && Player.Instance.ManaPercent >= Settings.MinManaE)
            {
                var Lmonsters = EntityManager.MinionsAndMonsters.GetLaneMinions().OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) < 1300);
                if (Lmonsters != null)
                {
                    E.Cast(Lmonsters);
                    return;
                }
            }
        }
    }
}
