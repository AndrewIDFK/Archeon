using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Buffs
{
	public class DryadBlessingBuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Buffs/DryadBlessingBuff";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dryad's Blessing");
			Description.SetDefault("The artificial blessing seems to be working");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 8;
			player.lifeRegen += 6;
			if (player.thorns < 1f)
			{
				player.thorns += 0.2f;
			}
		}
	}
}
