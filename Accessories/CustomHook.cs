using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Archeon.Accessories
{
    public class CustomHook : ModItem
    {
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Custom Hook");
			base.Tooltip.SetDefault("Shoots a Fiery bolt");
		}
        public override void SetDefaults()
        {
            //clone and modify the ones we want to copy
            item.CloneDefaults(ItemID.AmethystHook);
            item.shootSpeed = 18f; // how quickly the hook is shot.
            item.shoot = mod.ProjectileType("CustomHookPr");
        }
        
    }
}