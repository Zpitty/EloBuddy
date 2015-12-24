using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Settings = NinjaNunu.Config.Modes.MiscMenu;

namespace NinjaNunu.Modes
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
        public override bool ShouldBeExecuted()
        {
            return true;
        }

        public override void Execute()
        {
            if (Player.Instance.Spellbook.IsChanneling || Player.Instance.HasBuff("Absolute Zero") || ChannelingR())
            {
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
                return;
            }
            else
            {
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }

            #region Potion

            //Haker

            if (Settings.EnablePotion && !Player.Instance.IsInShopRange() && Player.Instance.HealthPercent <= Settings.MinHPPotion && !PotionRunning() && !ChannelingR())
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
            
            if (Settings.EnablePotion && !Player.Instance.IsInShopRange() && Player.Instance.ManaPercent <= Settings.MinMPPotion && !PotionRunning() && !ChannelingR())
            {
                if (Item.HasItem(CorruptingPotion.Id) && Item.CanUseItem(CorruptingPotion.Id))
                {
                    CorruptingPotion.Cast();
                    return;
                }
            }

            #endregion

            //AutoQ - NidaleeBuddy
            var target = EntityManager.MinionsAndMonsters.Combined.OrderByDescending(a => a.MaxHealth).FirstOrDefault(b => b.Distance(Player.Instance) <= 220);
            if (target != null && Settings.UseAutoQ && Q.IsReady() && Player.Instance.HealthPercent <= Settings.AutoQHealth && !ChannelingR())
            {
                Q.Cast(target);
                return;
            }

            // Ignite KS

            if (Settings.IgniteKS && HasIgnite && SpellManager.Ignite.IsReady() && !ChannelingR())
            {
                var IgniteKS = EntityManager.Heroes.Enemies.FirstOrDefault(e => SpellManager.Ignite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < Damage.IgniteDmg(e));
                if (IgniteKS != null)
                {
                    SpellManager.Ignite.Cast(IgniteKS);
                    return;
                }
            }

            #region Smite

            if (!Smite.IsReady() || !(Config.Smite.SmiteMenu.SmiteToggle) || !(Config.Smite.SmiteMenu.SmiteCombo) || !(Config.Smite.SmiteMenu.SmiteEnemies))
            {
                return;
            }

            //Red Smite Combo

            if (Config.Smite.SmiteMenu.SmiteEnemies && Smite.Name.Equals("s5_summonersmiteduel") && !ChannelingR() && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
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

            

            // Blue Smite KS - VodkaSmite

            if (Config.Smite.SmiteMenu.SmiteEnemies && Smite.Name.Equals("s5_summonersmiteplayerganker") && !ChannelingR())
            {
                var SmiteKS = EntityManager.Heroes.Enemies.FirstOrDefault(e => Smite.IsInRange(e) && !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.TotalShieldHealth() < SmiteDamage.SmiteDmgHero(e));
                if (SmiteKS != null)
                {
                    Smite.Cast(SmiteKS);
                    return;
                }
            }



            // Consume + Smite - VodkaSmite
            var monsters =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Smite.Range)
                    .Where(e => !e.IsDead && e.Health > 0 && SmiteDamage.MonstersNames.Contains(e.BaseSkinName) && !e.IsInvulnerable && e.IsVisible && e.Health <= SmiteDamage.SmiteDmgMonster(e) + Damage.QDamage(e));
            foreach (var m in monsters)
            {
                if (Config.Smite.SmiteMenu.MainMenu[m.BaseSkinName].Cast<CheckBox>().CurrentValue && Q.IsReady() && Smite.IsReady() && !ChannelingR() && Player.Instance.Position.IsInRange(m, 300))
                {
                    Smite.Cast(m); Q.Cast(m);
                    return;
                }
            }

            // Smite Monsters - VodkaSmite
            var monsters2 =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Smite.Range)
                    .Where(e => !e.IsDead && e.Health > 0 && SmiteDamage.MonstersNames.Contains(e.BaseSkinName) && !e.IsInvulnerable && e.IsVisible && e.Health <= SmiteDamage.SmiteDmgMonster(e));
            foreach (var n in monsters2)
            {
                if (Config.Smite.SmiteMenu.MainMenu[n.BaseSkinName].Cast<CheckBox>().CurrentValue && Smite.IsReady() && !ChannelingR())
                {
                    Smite.Cast(n);
                    return;
                }
            }

            #endregion


        }
    }
}
