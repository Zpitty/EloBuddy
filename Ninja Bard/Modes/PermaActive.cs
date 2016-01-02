using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;

using Settings = Bard.Config.Modes.Misc;

namespace Bard.Modes
{
    public sealed class PermaActive : ModeBase
    {
        
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
                if (Item.HasItem(Utility.HealthPotion.Id) && Item.CanUseItem(Utility.HealthPotion.Id))
                {
                    Utility.HealthPotion.Cast();
                    return;
                }
                if (Item.HasItem(Utility.HuntersPotion.Id) && Item.CanUseItem(Utility.HuntersPotion.Id))
                {
                    Utility.HuntersPotion.Cast();
                    return;
                }
                if (Item.HasItem(Utility.TotalBiscuit.Id) && Item.CanUseItem(Utility.TotalBiscuit.Id))
                {
                    Utility.TotalBiscuit.Cast();
                    return;
                }
                if (Item.HasItem(Utility.RefillablePotion.Id) && Item.CanUseItem(Utility.RefillablePotion.Id))
                {
                    Utility.RefillablePotion.Cast();
                    return;
                }
                if (Item.HasItem(Utility.CorruptingPotion.Id) && Item.CanUseItem(Utility.CorruptingPotion.Id))
                {
                    Utility.CorruptingPotion.Cast();
                    return;
                }
            }

            if (Settings.EnablePotion && !Player.Instance.IsInShopRange() && Player.Instance.ManaPercent <= Settings.MinMPPotion && !PotionRunning())
            {
                if (Item.HasItem(Utility.CorruptingPotion.Id) && Item.CanUseItem(Utility.CorruptingPotion.Id))
                {
                    Utility.CorruptingPotion.Cast();
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
                var IgniteKS = EntityManager.Heroes.Enemies.FirstOrDefault(e => SpellManager.Ignite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < Utility.IgniteDmg(e));
                if (IgniteKS != null)
                {
                    SpellManager.Ignite.Cast(IgniteKS);
                    return;
                }
            }

            #region Smite
            

            if (!Smite.IsReady()) { return; }

            if (HasSmite && Smite.IsReady())
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
                    var SmiteKS = EntityManager.Heroes.Enemies.FirstOrDefault(e => Smite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < Utility.SmiteDmgHero(e));
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
                            .Where(e => !e.IsDead && e.Health > 0 && Utility.MonstersNames.Contains(e.BaseSkinName) && !e.IsInvulnerable && e.IsVisible && e.Health <= Utility.SmiteDmgMonster(e));
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
