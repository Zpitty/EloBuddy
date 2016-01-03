﻿using System;
using System.Linq;
using SharpDX;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;

using Settings = Bard.Config.Modes.Misc;

namespace Bard
{
    public static class Events
    {
        public static int TunnelNetworkID;
        public static Vector3 TunnelEntrance = Vector3.Zero;
        public static Vector3 TunnelExit = Vector3.Zero;


        static Events()
        {
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapCloser;
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Drawing.OnDraw += OnDraw;
            GameObject.OnCreate += OnCreate;
            GameObject.OnDelete += OnDelete;

        }

        private static void OnCreate(GameObject sender, EventArgs args)
        {
            if (sender.Name.Contains("BardDoor_EntranceMinion") && sender.NetworkId == TunnelNetworkID)
            {
                TunnelNetworkID = -1;
                TunnelEntrance = Vector3.Zero;
                TunnelExit = Vector3.Zero;
            }
        }

        private static void OnDelete(GameObject sender, EventArgs args)
        {
            if (sender.Name.Contains("BardDoor_EntranceMinion"))
            {
                TunnelNetworkID = sender.NetworkId;
                TunnelEntrance = sender.Position;
            }

            if (sender.Name.Contains("BardDoor_ExitMinion"))
            {
                TunnelExit = sender.Position;
            }
        }

        public static void Initialize()
        {

        }



        private static void OnDraw(EventArgs args)
        {
            if (Config.Draw.DMenu["QDraw"].Cast<CheckBox>().CurrentValue && SpellManager.Q.IsLearned)
            {
                Circle.Draw(Color.Green, SpellManager.Q.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["WDraw"].Cast<CheckBox>().CurrentValue && SpellManager.W.IsLearned)
            {
                Circle.Draw(Color.Red, SpellManager.W.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["RDraw"].Cast<CheckBox>().CurrentValue && SpellManager.R.IsLearned)
            {
                Circle.Draw(Color.DarkBlue, SpellManager.R.Range, Player.Instance.Position);
            }

            if (Config.Draw.DMenu["SmiteDraw"].Cast<CheckBox>().CurrentValue && SpellManager.HasSmite())
            {
                Circle.Draw(Color.Purple, SpellManager.Smite.Range, Player.Instance.Position);
            }
        }

        public static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender == null || sender.IsAlly || !Config.Modes.Misc.QGapcloser)
            {
                return;
            }
            var gapclosepred = SpellManager.Q.GetPrediction(sender);
            if (SpellManager.Q.IsReady() && SpellManager.Q.IsInRange(sender) && e.End.Distance(Player.Instance) <= 300)
            {
                SpellManager.Q.Cast(gapclosepred.CastPosition);
                return;
            }
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (sender == null || sender.IsAlly || !Config.Modes.Misc.RInterrupt)
            {
                return;
            }

            if (SpellManager.R.IsReady() && SpellManager.R.IsInRange(sender) && e.DangerLevel == DangerLevel.High)
            {
                Core.DelayAction(delegate
                {
                    SpellManager.R.Cast(sender);
                }, Config.Modes.Misc.RInterruptDelay);
                return;
            }
        }


        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            var a = target as Obj_AI_Minion;
            var allys = EntityManager.Heroes.Allies.Count(c => Player.Instance.Distance(c) <= Player.Instance.AttackRange);

            if (a == null)
            {
                return;
            }

            if (allys < 1)
            {
                return;
            }

            if (Bard.Config.Modes.Misc.DisableMAA)
            {
                args.Process = false;
            }
        }

        
    }
}
