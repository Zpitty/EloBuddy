using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using Settings = Nunu.Config.Modes.JungleClear;
using Settings2 = Nunu.Config.Modes.MiscMenu;

namespace Nunu.Modes
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
                if (Damage.QDamage(Jmonsters) > Jmonsters.Health)
                {
                    Q.Cast(Jmonsters);
                    return;
                }
            }
            if (Settings.UseE && E.IsReady() && Player.Instance.ManaPercent >= Settings.MinManaE)
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
