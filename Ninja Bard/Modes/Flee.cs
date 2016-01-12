using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Bard.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            DoFlee();
        }
        private static bool IsOverWall(Vector3 start, Vector3 end)
        {
            double distance = Vector3.Distance(start, end);
            for (uint i = 0; i < distance; i += 10)
            {
                var tempPosition = start.Extend(end, i);
                if (IsWall(tempPosition))
                {
                    return true;
                }
            }

            return false;
        }

        private static Vector3 GetFirstWallPoint(Vector3 start, Vector3 end)
        {
            double distance = Vector3.Distance(start, end);
            for (uint i = 0; i < distance; i += 10)
            {
                var tempPosition = start.Extend(end, i);
                if (IsWall(tempPosition))
                {
                    return (Vector3)tempPosition.Extend(start, -35);
                }
            }

            return Vector3.Zero;
        }

        private static float GetWallLength(Vector3 start, Vector3 end)
        {
            double distance = Vector3.Distance(start, end);
            var firstPosition = Vector3.Zero;
            var lastPosition = Vector3.Zero;

            for (uint i = 0; i < distance; i += 10)
            {
                var tempPosition = (Vector3)start.Extend(end, i);
                if (IsWall(tempPosition) && firstPosition == Vector3.Zero)
                {
                    firstPosition = tempPosition;
                }
                lastPosition = tempPosition;
                if (!IsWall(lastPosition) && firstPosition != Vector3.Zero)
                {
                    break;
                }
            }

            return Vector3.Distance(firstPosition, lastPosition);
        }


        private static void DoFlee()
        {
            if ((IsOverWall(ObjectManager.Player.ServerPosition, Game.CursorPos)
                && GetWallLength(ObjectManager.Player.ServerPosition, Game.CursorPos) >= 250f) && (SpellManager.E.IsReady()
                || (Events.TunnelNetworkID != -1
                && (ObjectManager.Player.ServerPosition.Distance(Events.TunnelEntrance) < 250f))))
            {
                Orbwalker.MoveTo(GetFirstWallPoint(ObjectManager.Player.ServerPosition, Game.CursorPos));
            }
            else
            {
                Orbwalker.MoveTo(Game.CursorPos);
            }

            //if (GetItemValue<bool>("dz191.bard.flee.q"))
            {
                var ComboTarget = TargetSelector.GetTarget(SpellManager.Q.Range, DamageType.Magical);

                if (SpellManager.Q.IsReady() &&
                    ComboTarget.IsValidTarget())
                {
                    var predictionQ = SpellManager.Q.GetPrediction(ComboTarget);
                    if (ComboTarget != null && ComboTarget.IsValid)
                    {
                        SpellManager.Q.Cast(ComboTarget);
                        return;
                    }
                }
            }

            //if (GetItemValue<bool>("dz191.bard.flee.w"))
            {
                if (ObjectManager.Player.CountAlliesInRange(1000f) - 1 < ObjectManager.Player.CountEnemiesInRange(1000f)
                    || (/*ObjectManager.Player.HealthPercent <= GetItemValue<Slider>("dz191.bard.wtarget.healthpercent").Value &&*/ ObjectManager.Player.CountEnemiesInRange(900f) >= 1))
                {
                    var castPosition = ObjectManager.Player.ServerPosition.Extend(Game.CursorPos, 65);
                    SpellManager.W.Cast(ObjectManager.Player);
                }
            }

            //if (GetItemValue<bool>("dz191.bard.flee.e"))
            {
                var dir = ObjectManager.Player.ServerPosition.To2D() + ObjectManager.Player.Direction.To2D().Perpendicular() * (ObjectManager.Player.BoundingRadius * 2.5f);
                var Extended = Game.CursorPos;
                if (IsWall(dir) && IsOverWall(ObjectManager.Player.ServerPosition, Extended)
                    && SpellManager.E.IsReady()
                    && GetWallLength(ObjectManager.Player.ServerPosition, Extended) >= 250f)
                {
                    TacticalMap.ShowPing(PingCategory.Danger, (Vector3)Player.Instance.ServerPosition.Extend(Extended, GetWallLength(ObjectManager.Player.ServerPosition, Extended)), true);
                    SpellManager.E.Cast((Vector3)Player.Instance.ServerPosition.Extend(Extended, GetWallLength(ObjectManager.Player.ServerPosition, Extended)));
                }
            }
        }

        public static bool IsWall(Vector3 position)
        {
            return NavMesh.GetCollisionFlags(position).HasFlag(CollisionFlags.Wall);
        }
        public static bool IsWall(Vector2 vector)
        {
            return NavMesh.GetCollisionFlags(vector.X, vector.Y).HasFlag(CollisionFlags.Wall);
        }
    }
}
