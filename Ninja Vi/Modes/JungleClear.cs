using EloBuddy.SDK;
using EloBuddy;
using System.Linq;
using Settings = Vi.Config.Modes.JungleClear;
namespace Vi.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady() && Player.Instance.ManaPercent >= Settings.MinMana || Q.IsCharging)
            {
                var dragon = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, Q.MaximumRange)
                    .Where(e => !e.IsDead && e.Health > 0 && e.IsVisible && e.IsValidTarget() && SmiteDamage.IMportantMonsters.Contains(e.BaseSkinName));
                var dragonline = EntityManager.MinionsAndMonsters.GetLineFarmLocation(dragon, Q.Width, (int)Q.MaximumRange);
                //if (dragon == null)
                //{
                //    return;
                //}

                if (Q.IsCharging && Q.IsFullyCharged && dragonline.CastPosition.IsValid())
                {
                    Q.Cast(dragonline.CastPosition);
                    return;
                }

                else if (dragonline.HitNumber > 0)
                {
                    Q.StartCharging();
                    return;
                }

            }

            if (Settings.UseQ && Q.IsReady() && Player.Instance.ManaPercent >= Settings.MinMana || Q.IsCharging)
            {
                var MinionsQ = EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(a => a.IsInRange(Player.Instance.ServerPosition, Q.MaximumRange)).OrderByDescending(e => e.MaxHealth);
                var Qfarm = EntityManager.MinionsAndMonsters.GetLineFarmLocation(MinionsQ, 100, (int)Q.MaximumRange);
                

                //if (MinionsQ == null)
                //{
                //    return;
                //}

                if (Q.IsCharging && Q.IsFullyCharged && Qfarm.CastPosition.IsValid())
                {
                    Q.Cast(Qfarm.CastPosition);
                    return;
                }

                else if (Qfarm.HitNumber >= 2)
                {
                    Q.StartCharging();
                    return;
                }
  
            }
        }
    }
}
