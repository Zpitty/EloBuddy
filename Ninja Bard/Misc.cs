using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Bard
{
    public static class Misc
    {
        public static List<Vector2> Points = new List<Vector2>();

        public static AIHeroClient _Bard
        {
            get { return ObjectManager.Player; }
        }

        //fluxy
        public static bool WallBangable(this AIHeroClient hero, Vector2 pos = new Vector2())
        {
            if (hero.HasBuffOfType(BuffType.SpellImmunity) || hero.HasBuffOfType(BuffType.SpellShield)) return false;
            var Qprediction = SpellManager.Q.GetPrediction(hero);
            var Qpredlist = pos.IsValid() ? new List<Vector3>() { pos.To3D() } : new List<Vector3>
                        {
                            hero.ServerPosition,
                            hero.Position,
                            Qprediction.CastPosition,
                            Qprediction.UnitPosition
                        };

            var bangableWalls = 0;
            Points = new List<Vector2>();
            foreach (var position in Qpredlist)
            {
                for (var i = 0; i < Config.Modes.Combo.QBindDistance; i += (int)hero.BoundingRadius)
                {
                    var cPos = _Bard.Position.Extend(position, _Bard.Distance(position) + i).To3D();
                    Points.Add(cPos.To2D());
                    if (NavMesh.GetCollisionFlags(cPos).HasFlag(CollisionFlags.Wall) || NavMesh.GetCollisionFlags(cPos).HasFlag(CollisionFlags.Building))
                    {
                        bangableWalls++;
                        break;
                    }
                }
            }
            if ((bangableWalls / Qpredlist.Count) >= Config.Modes.Combo.QAccuracyPercent / 100f)
            {
                return true;
            }

            return false;
        }

        

        public static void Initialize()
        {

        }
    }
}
