using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using System.Linq;

namespace Zac
{
    class Events
    {
        public static bool ChannelingE = false;

        static Events()
        {
            Drawing.OnDraw += OnDraw;
            Player.OnBuffLose += Player_OnBuffLose;
            Player.OnBuffGain += Player_OnBuffGain;
        }

        private static void Player_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (!sender.IsMe) return;
            if (sender.IsMe && args.Buff.Name == "ZacE")
            {
                ChannelingE = true;
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
            }

            if (sender.IsMe && args.Buff.Name == "ZacR")
            {
                Orbwalker.DisableAttacking = true;
            }
        }

        private static void Player_OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (!sender.IsMe) return;
            if (sender.IsMe && args.Buff.Name == "ZacE")
            {
                ChannelingE = false;
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }

            if (sender.IsMe && args.Buff.Name == "ZacR")
            {
                Orbwalker.DisableAttacking = false;
            }

        }

        private static void OnDraw(EventArgs args)
        {
            Circle.Draw(Color.Green, (int)new int[] { 1150, 1300, 1450, 1600, 1750 }[SpellManager.E.Level - 1], Player.Instance.Position);   

        }
        public static void Initialize()
        {

        }

    }
}
