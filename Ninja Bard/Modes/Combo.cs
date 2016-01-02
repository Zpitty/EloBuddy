using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;
using Settings = Bard.Config.Modes.Combo;

namespace Bard.Modes
{
    public sealed class Combo : ModeBase
    {
        public static AIHeroClient _Bard
        {
            get { return ObjectManager.Player; }
        }

        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            #region Q Logic

            if (Settings.UseQ && Q.IsReady())
            {
                
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                var predictionQ = Q.GetPrediction(target);                              
                if (target != null && target.IsValid && Misc.WallBangable(target))
                {
                    Q.Cast(target);
                    return;
                }

                //else if (predictionQ.HitChance == HitChance.Collision)
                //{
                //    var collisionQ = predictionQ.CollisionObjects;
                //    if (collisionQ.Count() == 1)
                //    {
                //        Q.Cast(predictionQ.CastPosition);
                //        return;
                //    }

                //}

                else if (predictionQ.CollisionObjects.Count() == 1)
                {
                    Q.Cast(predictionQ.CastPosition);
                    return;
                }

            }
            #endregion
        }
    }
}
