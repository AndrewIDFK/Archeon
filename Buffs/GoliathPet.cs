using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000022 RID: 34
	public class GoliathPet : ModBuff
	{
		// Token: 0x06000098 RID: 152 RVA: 0x000057AB File Offset: 0x000039AB
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Goliath");
			base.Description.SetDefault("Goliath is following you");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.vanityPet[base.Type] = true;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000057E8 File Offset: 0x000039E8
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MyPlayer>().Pet = true;
			
			bool flag = player.ownedProjectileCounts[base.mod.ProjectileType("Goliath")] <= 0;
			if (flag && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, base.mod.ProjectileType("Goliath"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
