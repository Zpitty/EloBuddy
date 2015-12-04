using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using EloBuddy.SDK.Enumerations;
using Settings = Nunu.Config.Modes.Combo;

namespace Nunu.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (ChannelingR() && EntityManager.Heroes.Enemies.Count(h => h.IsValidTarget(650)) < Settings.MinR)
            {
                Orbwalker.DisableMovement = false;
                Orbwalker.DisableAttacking = false;
                return;
            }

            if (Settings.UseR && R.IsReady())
            {
                if (EntityManager.Heroes.Enemies.Count(h => h.IsValidTarget(400)) >= Settings.MinR)
                {
                    Orbwalker.DisableMovement = true;
                    Orbwalker.DisableAttacking = true;
                    R.Cast();
                    return;
                }

            }

            if (Settings.UseE && E.IsReady() && !ChannelingR())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (target != null)
                {
                    E.Cast(target);
                    return;
                }
            }

            if (Settings.UseW && W.IsReady() && !ChannelingR())
            {
                var ally = EntityManager.Heroes.Allies.OrderByDescending(a => a.TotalAttackDamage).FirstOrDefault(b => b.Distance(Player.Instance) < 700);
                if (ally != null && Player.Instance.CountEnemiesInRange(1500) > 0)
                {
                    W.Cast(ally);
                    return;
                }
                if (Settings.UseW && W.IsReady() && Player.Instance.CountEnemiesInRange(1500) > 0)
                {
                    W.Cast(Player.Instance);
                    return;
                }

                //if (Settings.UseW && W.IsReady() && !ChannelingR())
                //{
                // foreach (var ally in EntityManager.Heroes.Allies.Where(b => !b.IsDead && !b.IsMe && b.Position.Distance(b.Position) <= W.Range && b.CountEnemiesInRange(1000) >= 1))
                //{
                // W.Cast(ally);
                // return;
                // }
                //if (EntityManager.Heroes.Enemies.Count(c => c.IsValidTarget(1500)) >= 1)
                //{
                // W.Cast(Player.Instance);
                // return;
                // }
                //}         
            }
        }
    }
}
