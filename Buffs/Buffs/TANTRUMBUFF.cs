using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Buffs
{
	public class TANTRUMBUFF : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Buffs/TANTRUMBUFF";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("TANTRUM");
			Description.SetDefault("The power of energy drinks are getting more appealing by the second");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			
			player.lifeRegen -= 8;
			
			player.meleeDamage += 0.2f;
			player.magicDamage += 0.2f;
			player.rangedDamage += 0.2f;
			player.thrownDamage += 0.2f;
			player.minionDamage += 0.2f;
			
			player.moveSpeed += 0.2f;
			
			int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 1f), player.width + 1, player.height + 2, 106, player.velocity.X * 0.5f, player.velocity.Y * 0.4f, 40, default(Color), 1.2f);
			Main.dust[num].noGravity = true;
			Main.dust[num].scale = 1.34f;
			int num2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 1f), player.width + 1, player.height + 2, 107, player.velocity.X * 0.5f, player.velocity.Y * 0.4f, 100, default(Color), 1.2f);
			Main.dust[num2].noGravity = true;
			Main.dust[num2].scale = 1.34f;
		}
	}
}
