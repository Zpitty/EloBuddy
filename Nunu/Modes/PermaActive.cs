using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using Settings = NinjaNunu.Config.Modes.MiscMenu;

namespace NinjaNunu.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (Player.Instance.Spellbook.IsChanneling || Player.Instance.HasBuff("Absolute Zero"))
            {
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
                return;
            }
            else
            {
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }

            //AutoQ - NidaleeBuddy

            var target = EntityManager.MinionsAndMonsters.Combined.OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) <= 300);
            if (Settings.UseAutoQ && Q.IsReady() && Player.Instance.HealthPercent <= Settings.AutoQHealth && !ChannelingR())
            {
                Q.Cast(target);
                return;
            }

            if (!Smite.IsReady() || !(Config.Smite.SmiteMenu.SmiteEnabled))
            {
                return;
            }

            // Blue Smite KS - VodkaSmite
            if (Config.Smite.SmiteMenu.SmiteEnemies && Smite.Name.Equals("s5_summonersmiteplayerganker") && !ChannelingR())
            {
                var enemy = EntityManager.Heroes.Enemies.FirstOrDefault(e => Smite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < Smiter.SmiteDmgHero(e));
                if (enemy != null)
                {
                    Smite.Cast(enemy);
                    return;
                }
            }

            // Consume + Smite - VodkaSmite
            var monsters =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Smite.Range)
                    .Where(e => !e.IsDead && e.Health > 0 && Smiter.MonstersNames.Contains(e.BaseSkinName) && !e.IsInvulnerable && e.IsVisible && e.Health <= Smiter.SmiteDmgMonster(e) + Damage.QDamage(e));
            foreach (var m in monsters)
            {
                if (Config.Smite.SmiteMenu.MainMenu[m.BaseSkinName].Cast<CheckBox>().CurrentValue && Q.IsReady() && Smite.IsReady() && !ChannelingR()  && Player.Instance.Position.IsInRange(m, 300))
                {
                    Q.Cast(m);
                    Smite.Cast(m);
                    return;
                }
            }

            // Smite Monsters - VodkaSmite
            var monsters2 =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Smite.Range)
                    .Where(e => !e.IsDead && e.Health > 0 && Smiter.MonstersNames.Contains(e.BaseSkinName) && !e.IsInvulnerable && e.IsVisible && e.Health <= Smiter.SmiteDmgMonster(e));
            foreach (var n in monsters2)
            {
                if (Config.Smite.SmiteMenu.MainMenu[n.BaseSkinName].Cast<CheckBox>().CurrentValue && Q.IsOnCooldown && Smite.IsReady() && !ChannelingR() || Config.Smite.SmiteMenu.MainMenu[n.BaseSkinName].Cast<CheckBox>().CurrentValue)
                {
                    Smite.Cast(n);
                    return;
                }
            }
        }
    }
}
