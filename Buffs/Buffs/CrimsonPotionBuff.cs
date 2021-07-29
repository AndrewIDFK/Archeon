using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Buffs
{
	public class CrimsonPotionBuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Buffs/CrimsonPotionBuff";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Infectious Power");
			Description.SetDefault("The infection activates your rage");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.2f;
			player.magicDamage += 0.2f;
			player.rangedDamage += 0.2f;
			player.thrownDamage += 0.2f;
			player.minionDamage += 0.2f;
		}
	}
}
