using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000024 RID: 36
	public class TANTRUMBUFF : ModBuff
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00005B51 File Offset: 0x00003D51
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/TANTRUMBUFF";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00005B62 File Offset: 0x00003D62
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("TANTRUM!!");
			base.Description.SetDefault("Increases Speed and Strength but poisons you");
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005B84 File Offset: 0x00003D84
		public override void Update(Player player, ref int buffIndex)
		{
			
			player.lifeRegen -= 8;
			
			player.meleeDamage += 0.2f;
			player.magicDamage += 0.2f;
			player.rangedDamage += 0.2f;
			player.thrownDamage += 0.2f;
			player.minionDamage += 0.2f;
			
			player.moveSpeed += 0.2f;
			
			int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 1f), player.width + 1, player.height + 2, base.mod.DustType("TantrumDust"), player.velocity.X * 0.5f, player.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num].noGravity = true;
			Main.dust[num].scale = 1.34f;
			int num2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 1f), player.width + 1, player.height + 2, base.mod.DustType("TantrumDust"), player.velocity.X * 0.5f, player.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num2].noGravity = true;
			Main.dust[num2].scale = 1.34f;
		}
	}
}
