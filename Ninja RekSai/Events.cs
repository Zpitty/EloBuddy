using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using System.Linq;
using RekSai.Modes;

using Settings = RekSai.Config.Combo.ComboMenu;
using Settings2 = RekSai.Config.JungleClear.JungleClearMenu;
using Settings3 = RekSai.Config.Misc.MiscMenu;
using Settings4 = RekSai.Config.Draw.DrawMenu;

namespace RekSai
{
    class Events
    {

        private static bool burrowed = false;

        static Events()
        {
            
            
            Orbwalker.OnPostAttack += OnAfterAttack;
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += OnDraw;
            
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Player.Instance.HasBuff("RekSaiW"))
                burrowed = true;
            else burrowed = false;
            if (burrowed)
                Orbwalker.DisableAttacking = true;
            else
            {
                Orbwalker.DisableAttacking = false;
            }

            KS();
        }

        public static void OnAfterAttack(AttackableUnit target, EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                if (Settings.ItemUsage && Item.HasItem(3074) && Item.CanUseItem(3074) || Settings.ItemUsage && Item.HasItem(3077) && Item.CanUseItem(3077) || Settings.ItemUsage && Item.HasItem(3748) && Item.CanUseItem(3748))
                {
                    ItemsManager.HailHydra();
                    if (Settings.UseQ && SpellManager.Q.IsReady())
                    {
                        SpellManager.Q.Cast();
                        return;
                    }
                }

                else if (Settings.UseQ && SpellManager.Q.IsReady())
                {
                    SpellManager.Q.Cast();
                    return;
                }
            }

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {

                if (Settings3.ItemUsage && Item.HasItem(3074) && Item.CanUseItem(3074) || Settings3.ItemUsage && Item.HasItem(3077) && Item.CanUseItem(3077) || Settings3.ItemUsage && Item.HasItem(3748) && Item.CanUseItem(3748))
                {
                    ItemsManager.HailHydra();
                    if (Settings2.UseQ && SpellManager.Q.IsReady())
                    {
                        SpellManager.Q.Cast();
                        return;
                    }
                }
                
                else if (!burrowed && Settings2.UseQ && SpellManager.Q.IsReady())
                {
                    var junglemonsters = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, 300);
                    if (junglemonsters != null)
                    {
                        SpellManager.Q.Cast();
                        return;
                    }
                }
            }
            
        }

        public static void KS()
        {
            var targetKSQ2 = TargetSelector.GetTarget(SpellManager.Q2.Range, DamageType.Magical);
            var predQ2 = SpellManager.Q2.GetPrediction(targetKSQ2);
            if (burrowed && Settings3.EnableKS && SpellManager.Q2.IsReady())
            {
                if (predQ2.HitChance >= HitChance.High && targetKSQ2.Health < Player.Instance.GetSpellDamage(targetKSQ2, SpellSlot.Q))
                {
                    SpellManager.Q2.Cast(predQ2.CastPosition);
                    return;
                }
            }
        }


        

        private static void OnDraw(EventArgs args)
        {
            if (Settings4.DrawQ && SpellManager.Q.IsLearned)
            {
                Circle.Draw(Color.Green, SpellManager.Q.Range, Player.Instance.Position);
            }

            if (Settings4.DrawQ2 && SpellManager.Q.IsLearned)
            {
                Circle.Draw(Color.Green, SpellManager.Q2.Range, Player.Instance.Position);
            }

            if (Settings4.DrawE && SpellManager.E.IsLearned)
            {
                Circle.Draw(Color.Green, SpellManager.E.Range, Player.Instance.Position);
            }

            if (Settings4.DrawE2 && SpellManager.E.IsLearned)
            {
                Circle.Draw(Color.Green, SpellManager.E2.Range, Player.Instance.Position);
            }

            if (Settings4.DrawSmite && SpellManager.Smite.IsLearned)
            {
                Circle.Draw(Color.Blue, SpellManager.Smite.Range, Player.Instance.Position);
            }
        }
        public static void Initialize()
        {

        }

    }
}
