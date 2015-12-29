using System;
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

namespace RekSai
{
    public static class ItemsManager
    {
        public static void HailHydra()
        {
            if (Item.HasItem(3074) && Item.CanUseItem(3074)) Item.UseItem(3074); //hydra
            if (Item.HasItem(3077) && Item.CanUseItem(3077)) Item.UseItem(3077); //tiamat
            if (Item.HasItem(3748) && Item.CanUseItem(3748)) Item.UseItem(3748); //titanic             
        }

        public static void Yomuus()
        {
            if (Item.HasItem(3142) && Item.CanUseItem(3142)) Item.UseItem(3142); Item.UseItem(3142);
        }


        public static void Initialize()
        {

        }
    }
}