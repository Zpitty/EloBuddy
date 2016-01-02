using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = Bard.Config.Modes.JungleClear;

namespace Bard.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {

            if (Settings.UseQ && Q.IsReady() && Player.Instance.ManaPercent >= Settings.ManaQ)
            {
                var monster = EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(a => a.IsValidTarget(Q.Range)).OrderByDescending(a => a.MaxHealth);
                var junglemonsters = EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(a => a.IsValidTarget(Q.Range) && a.Health > Player.Instance.GetAutoAttackDamage(a) * 2).OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) <= Q.Range);
                var Qfarm = EntityManager.MinionsAndMonsters.GetLineFarmLocation(monster, Q.Width, (int)Q.Range);
                foreach (var m in monster)
                {
                    if (m.Health > Player.Instance.GetAutoAttackDamage(m) * 2)
                    {
                        Q.Cast(m);
                        return;
                    }
                }
            }
          
        }
    }
}
