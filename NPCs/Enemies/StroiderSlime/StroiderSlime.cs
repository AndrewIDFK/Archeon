using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.StroiderSlime
{
	// Token: 0x020000CD RID: 205
	public class StroiderSlime : ModNPC
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x0002166A File Offset: 0x0001F86A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroider Slime");
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0002167C File Offset: 0x0001F87C
		public override void SetDefaults()
		{
			base.npc.aiStyle = 1;
			this.aiType = 1;
			base.npc.lifeMax = 800;
			base.npc.damage = 52;
			base.npc.defense = 36;
			base.npc.knockBackResist = 0.5f;
			base.npc.width = 18;
			base.npc.height = 30;
			this.animationType = 1;
			Main.npcFrameCount[base.npc.type] = 2;
			base.npc.value = (float)Item.buyPrice(0, 0, 8, 70);
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.netAlways = true;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00021764 File Offset: 0x0001F964
		public override void NPCLoot()
		{
			Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("StroidOre"), Main.rand.Next(1, 2), false, 0, false, false);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000217D0 File Offset: 0x0001F9D0
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust.scale *= 0.8f + (float)Main.rand.Next(-31, 31) * 0.11f;
					int num2 = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), base.npc.velocity.X * -30.2f, base.npc.velocity.Y * -14.7f, 0, default(Color), 1f);
					Main.dust[num2].velocity /= 60f;
					Main.dust[num2].scale = 0.7f;
					int num3 = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), base.npc.velocity.X * -10.4f, base.npc.velocity.Y * 2.9f, 0, default(Color), 1f);
					Main.dust[num3].velocity /= 60f;
					Main.dust[num3].scale = 0.9f;
					int num4 = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), base.npc.velocity.X * 30.9f, base.npc.velocity.Y * -21.9f, 0, default(Color), 1f);
					Main.dust[num4].velocity /= 60f;
					Main.dust[num4].scale = 0.9f;
					int num5 = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), base.npc.velocity.X * -22.4f, base.npc.velocity.Y * 11.6f, 0, default(Color), 1f);
					Main.dust[num5].velocity /= 60f;
					Main.dust[num5].scale = 0.8f;
				}
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00021BA3 File Offset: 0x0001FDA3
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.dayTime && spawnInfo.player.ZoneHoly && ArcheonWorld.downedHallowedOne)
			{
				return 1.75f;
			}
			return 0f;
		}
	}
}
