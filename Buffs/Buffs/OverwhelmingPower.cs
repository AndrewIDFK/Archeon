using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Buffs
{
	public class OverwhelmingPower : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Buffs/OverwhelmingPower";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Overwhelming Power");
			Description.SetDefault("You can feel your body creaking from the power");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.35f;
			player.magicDamage += 0.35f;
			player.rangedDamage += 0.35f;
			player.thrownDamage += 0.35f;
			player.minionDamage += 0.35f;
		}
	}
}
