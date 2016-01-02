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
using Settings = Bard.Config.Modes.Misc;

namespace Bard.Modes
{
    public sealed class PermaActive : ModeBase
    {
        static Item HealthPotion;
        static Item CorruptingPotion;
        static Item RefillablePotion;
        static Item HuntersPotion;
        static Item TotalBiscuit;

        static PermaActive()
        {
            HealthPotion = new Item(2003, 0);
            TotalBiscuit = new Item(2010, 0);
            CorruptingPotion = new Item(2033, 0);
            RefillablePotion = new Item(2031, 0);
            HuntersPotion = new Item(2032, 0);
        }
        public static AIHeroClient _Bard
        {
            get { return ObjectManager.Player; }
        }
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            #region Potion

            //Haker

            if (Settings.EnablePotion && !Player.Instance.IsInShopRange() && Player.Instance.HealthPercent <= Settings.MinHPPotion && !PotionRunning())
            {
                if (Item.HasItem(HealthPotion.Id) && Item.CanUseItem(HealthPotion.Id))
                {
                    HealthPotion.Cast();
                    return;
                }
                if (Item.HasItem(HuntersPotion.Id) && Item.CanUseItem(HuntersPotion.Id))
                {
                    HuntersPotion.Cast();
                    return;
                }
                if (Item.HasItem(TotalBiscuit.Id) && Item.CanUseItem(TotalBiscuit.Id))
                {
                    TotalBiscuit.Cast();
                    return;
                }
                if (Item.HasItem(RefillablePotion.Id) && Item.CanUseItem(RefillablePotion.Id))
                {
                    RefillablePotion.Cast();
                    return;
                }
                if (Item.HasItem(CorruptingPotion.Id) && Item.CanUseItem(CorruptingPotion.Id))
                {
                    CorruptingPotion.Cast();
                    return;
                }
            }

            if (Settings.EnablePotion && !Player.Instance.IsInShopRange() && Player.Instance.ManaPercent <= Settings.MinMPPotion && !PotionRunning())
            {
                if (Item.HasItem(CorruptingPotion.Id) && Item.CanUseItem(CorruptingPotion.Id))
                {
                    CorruptingPotion.Cast();
                    return;
                }
            }

            #endregion

            #region W Logic

            if (W.IsReady())
            {
                if (_Bard.IsRecalling() || _Bard.IsInShopRange())
                {
                    return;
                }

                var ally = EntityManager.Heroes.Allies.Where(a => a.IsValidTarget(W.Range) && a.HealthPercent <= Settings.WHeal).OrderBy(a => a.Health).FirstOrDefault();
                if (Settings.UseW && ally != null && _Bard.ManaPercent >= Settings.WMana && !ally.IsRecalling() && !ally.IsInShopRange())
                {
                    var prediction = W.GetPrediction(ally);
                    W.Cast(prediction.UnitPosition);
                    return;
                }

                if (Settings.UseW && _Bard.HealthPercent <= Settings.WHeal && _Bard.ManaPercent > Settings.WMana)
                {
                    W.Cast(_Bard);
                    return;
                }
            }

            #endregion

            //Q KS

            if (Settings.UseQKS && Q.IsReady())
            {
                foreach (
                var target in
                    EntityManager.Heroes.Enemies.Where(
                        hero =>
                            hero.IsValidTarget(Q.Range) && !hero.IsDead && !hero.IsZombie && hero.HealthPercent <= 25))
                {
                    var predictionQ = Q.GetPrediction(target);
                    if (target.Health + target.TotalShieldHealth() < ObjectManager.Player.GetSpellDamage(target, SpellSlot.Q))
                    {
                        if (predictionQ.HitChance >= HitChance.High)
                        {
                            Q.Cast(predictionQ.CastPosition);
                            return;
                        }
                    }
                }
            }





            //Ignite KS

            if (Settings.IgniteKS && HasIgnite && SpellManager.Ignite.IsReady())
            {
                var IgniteKS = EntityManager.Heroes.Enemies.FirstOrDefault(e => SpellManager.Ignite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < Misc.IgniteDmg(e));
                if (IgniteKS != null)
                {
                    SpellManager.Ignite.Cast(IgniteKS);
                    return;
                }
            }

            #region Smite
            if (!Smite.IsReady()) { return; }

            if (Smite.IsReady())
            {


                //Red Smite Combo

                if (Config.Smite.SmiteMenu.SmiteCombo && Smite.Name.Equals("s5_summonersmiteduel") && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    foreach (
                        var SmiteTarget in
                            EntityManager.Heroes.Enemies
                                .Where(h => h.IsValidTarget(Smite.Range)).Where(h => h.HealthPercent <= Config.Smite.SmiteMenu.RedSmitePercent).OrderByDescending(TargetSelector.GetPriority))
                    {
                        Smite.Cast(SmiteTarget);
                        return;
                    }
                }



                // Blue Smite KS

                if (Config.Smite.SmiteMenu.SmiteEnemies && Smite.Name.Equals("s5_summonersmiteplayerganker"))
                {
                    var SmiteKS = EntityManager.Heroes.Enemies.FirstOrDefault(e => Smite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < SmiteDamage.SmiteDmgHero(e));
                    if (SmiteKS != null)
                    {
                        Smite.Cast(SmiteKS);
                        return;
                    }
                }

                // Smite Monsters
                if (Config.Smite.SmiteMenu.SmiteToggle)
                {
                    var monsters2 =
                        EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, Smite.Range)
                            .Where(e => !e.IsDead && e.Health > 0 && SmiteDamage.MonstersNames.Contains(e.BaseSkinName) && !e.IsInvulnerable && e.IsVisible && e.Health <= SmiteDamage.SmiteDmgMonster(e));
                    foreach (var n in monsters2)
                    {
                        if (Config.Smite.SmiteMenu.MainMenu[n.BaseSkinName].Cast<CheckBox>().CurrentValue)
                        {
                            Smite.Cast(n);
                            return;
                        }
                    }
                }
            }
            #endregion

           
        }
    }
}
