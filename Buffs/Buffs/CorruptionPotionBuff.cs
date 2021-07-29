using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Buffs
{
	public class CorruptionPotionBuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Buffs/CorruptionPotionBuff";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shielding Corruption");
			Description.SetDefault("You feel yourself being corrupted from within");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 12;
		}
	}
}
