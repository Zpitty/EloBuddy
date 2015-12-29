using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;

using Settings = RekSai.Config.Flee.FleeMenu;

namespace RekSai.Modes
{
    public sealed class Flee : ModeBase
    {

        private static bool burrowed = false;
        public override bool ShouldBeExecuted()
        {

            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {

            

            if (Player.Instance.HasBuff("RekSaiW"))
                burrowed = true;
            else burrowed = false;

            if (!burrowed && W.IsReady() && Settings.UseE2)
            {
                W.Cast();
                return;
            }

            if (burrowed && E2.IsReady() && Settings.UseE2)
            {
                E2.Cast(Game.CursorPos);
                return;
            }
            
        }
    }
}
