﻿using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class ManaWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Wings");
			Tooltip.SetDefault("Increases maximum mana by 50 and Greatly Increases mana regeneration\nAllows for infinite flight as long as the user has enough mana");
		}
		
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.buyPrice(0, 8, 50, 0);
			item.rare = 11;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 50;
			player.manaRegenBonus += 5;
			
			if(player.controlJump)
			{
				
				if(player.statMana >= 2)
				{
					player.statMana -= 2;
					player.manaRegenDelay = (int)player.maxRegenDelay / 8;
				}
				else if (player.statMana <= 2 )
				{
				}
			}
			if(player.statMana >= 50)
			{	
				player.wingTimeMax = 6969;	
			}
			
			if(player.statMana == 10)
			{
				player.wingTimeMax = 20;
			}
			
		}
		
		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.45f;
			ascentWhenRising = 0.7f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2.5f;
			constantAscend = 0.105f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 9.1f;
			acceleration *= 1.33f;
		}
	}
}
