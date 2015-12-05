using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using Settings = NinjaNunu.Config.Modes.JungleClear;
using Settings2 = NinjaNunu.Config.Modes.MiscMenu;

namespace NinjaNunu.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Q.IsReady())
            {
                var Jmonsters = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) <= 1300);
                //if (Damage.QDamage(Jmonsters) > Jmonsters.Health)
                if (Jmonsters.Health <= Damage.QDamage(Jmonsters))
                {
                    Q.Cast(Jmonsters);
                    return;
                }
            }

            if (Settings.UseE && E.IsReady() && Player.Instance.ManaPercent >= Settings.MinManaE || Player.Instance.HasBuff("Visionary") && Settings.UseE && E.IsReady())
            {
                var Emonsters = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) <= 1300);
                if (Emonsters != null)
                {
                    E.Cast(Emonsters);
                    return;
                }
            }

            if (Settings.UseW && W.IsReady() && Player.Instance.ManaPercent >= Settings.MinManaW)
            {
                if (Settings.UseW && W.IsReady())
                {
                    W.Cast(Player.Instance);
                    return;
                }
            }
        }
    }
}
