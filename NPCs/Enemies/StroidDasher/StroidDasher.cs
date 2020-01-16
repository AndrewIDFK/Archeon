using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.StroidDasher
{
	// Token: 0x020000CC RID: 204
	public class StroidDasher : ModNPC
	{
		// Token: 0x060003BC RID: 956 RVA: 0x00020DD8 File Offset: 0x0001EFD8
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Dasher");
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00020DEC File Offset: 0x0001EFEC
		public override void SetDefaults()
		{
			base.npc.aiStyle = 5;
			base.npc.lifeMax = 1250;
			base.npc.damage = 56;
			base.npc.defense = 48;
			base.npc.knockBackResist = 0f;
			base.npc.width = 19;
			base.npc.height = 28;
			this.animationType = 2;
			Main.npcFrameCount[base.npc.type] = 3;
			base.npc.value = (float)Item.buyPrice(0, 0, 15, 65);
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit53;
			base.npc.DeathSound = SoundID.NPCDeath43;
			base.npc.netAlways = true;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00020ED0 File Offset: 0x0001F0D0
		public override void AI()
		{
			base.npc.ai[1] += 0f;
			if (base.npc.life <= 90000)
			{
				base.npc.ai[2] += 1f;
			}
			if (base.npc.ai[2] >= 15f)
			{
				NPC npc = base.npc;
				npc.velocity.X = npc.velocity.X * 0.48f;
				NPC npc2 = base.npc;
				npc2.velocity.Y = npc2.velocity.Y * 0.48f;
				Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
				float num = (float)Math.Atan2((double)(vector.Y - (Main.player[base.npc.target].position.Y + (float)Main.player[base.npc.target].height * 0.5f)), (double)(vector.X - (Main.player[base.npc.target].position.X + (float)Main.player[base.npc.target].width * 0.5f)));
				base.npc.velocity.X = (float)(Math.Cos((double)num) * 16.0) * -1f;
				base.npc.velocity.Y = (float)(Math.Sin((double)num) * 16.0) * -1f;
				base.npc.ai[0] %= 6.28318548f;
				new Vector2((float)Math.Cos((double)base.npc.ai[0]), (float)Math.Sin((double)base.npc.ai[0]));
				Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 20, 1f, 0f);
				base.npc.ai[2] = -300f;
				new Rectangle((int)base.npc.position.X, (int)(base.npc.position.Y + (float)((base.npc.height - base.npc.width) / 2)), base.npc.width, base.npc.width);
				int num2 = 30;
				for (int i = 1; i <= num2; i++)
				{
					int num3 = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), 0f, 0f, 0, default(Color), 1f);
					Main.dust[num3].noGravity = false;
				}
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0002120C File Offset: 0x0001F40C
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("StroidOre"), Main.rand.Next(2, 6), false, 0, false, false);
					return;
				}
			}
			if (!Main.expertMode)
			{
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("StroidOre"), Main.rand.Next(1, 4), false, 0, false, false);
				}
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000212FC File Offset: 0x0001F4FC
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
					dust.scale *= 1.2f + (float)Main.rand.Next(-31, 31) * 0.01f;
					int num2 = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), base.npc.velocity.X * -20.2f, base.npc.velocity.Y * -14.7f, 0, default(Color), 1f);
					Main.dust[num2].velocity /= 60f;
					Main.dust[num2].scale = 0.7f;
					int num3 = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, base.mod.DustType("StroidWormDeathDust"), base.npc.velocity.X * -10.4f, base.npc.velocity.Y * 2.9f, 0, default(Color), 1f);
					Main.dust[num3].velocity /= 60f;
					Main.dust[num3].scale = 0.9f;
					
				}
			}
		}
		
		

		// Token: 0x060003C1 RID: 961 RVA: 0x0002161C File Offset: 0x0001F81C
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<MyPlayer>().zoneStroidBiome && !Main.dayTime)
			{
				return 2.15f;
			}
			return 0f;
		}

		// Token: 0x04000049 RID: 73
		private Vector2[] oldPos = new Vector2[4];

		// Token: 0x0400004A RID: 74
		private float[] oldrot = new float[4];

		// Token: 0x0400004B RID: 75
		public bool inbiome = true;
	}
}
