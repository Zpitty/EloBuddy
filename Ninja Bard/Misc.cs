using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using System;

namespace Bard
{
    public static class Misc
    {

        public static AIHeroClient _Bard
        {
            get { return ObjectManager.Player; }
        }

        public static bool WallBangable(AIHeroClient wallbanged)
        {
            var predictionQ = Prediction.Position.PredictUnitPosition(wallbanged, 250);

            var position = _Bard.Position.Extend(wallbanged.Position, _Bard.Distance(wallbanged)).To3D();
            var predictedposition = _Bard.Position.Extend(predictionQ, _Bard.Distance(wallbanged)).To3D();
            for (int i = 0; i < 450; i += (int)wallbanged.BoundingRadius)
            {
                var bPos = _Bard.Position.Extend(position, _Bard.Distance(position) + i).To3D();
                var bPredPos = _Bard.Position.Extend(predictedposition, _Bard.Distance(predictedposition) + i).To3D();

                if (bPredPos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Wall) || bPredPos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Building) || bPos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Wall) || bPos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Building))
                {
                    return true;
                }
            }
            return false;            
        }

        public static float IgniteDmg(Obj_AI_Base target)
        {
            return Player.Instance.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Ignite);
        }

        public static void Initialize()
        {

        }
    }
}
