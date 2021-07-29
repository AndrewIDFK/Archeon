using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Buffs
{
	public class MarkOfCainBuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Buffs/MarkOfCainBuff";
			return base.Autoload(ref name, ref texture);
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bloodthirst of The Mark");
			Description.SetDefault("The Mark is craving for violence");
		}
	}
}
