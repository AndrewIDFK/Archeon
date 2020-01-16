using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.FireElementHover
{
	// Token: 0x02000667 RID: 1639
	public class FireElementHover : ModNPC
	{
		// Token: 0x0600278C RID: 10124 RVA: 0x0025DEEB File Offset: 0x0025C0EB
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fire Guardian");
			Main.npcFrameCount[base.npc.type] = 4;
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x0025DF10 File Offset: 0x0025C110
		public override void SetDefaults()
		{
			base.npc.npcSlots = 0.5f;
			base.npc.aiStyle = 14;
			this.aiType = 152;
			this.animationType = 152;
			base.npc.damage = 63;
			base.npc.width = 54;
			base.npc.height = 72;
			base.npc.defense = 34;
			base.npc.lifeMax = 450;
			base.npc.knockBackResist = 0.6f;
			base.npc.value = (float)Item.buyPrice(0, 0, 6, 30);
			base.npc.HitSound = SoundID.NPCHit24;
			base.npc.DeathSound = SoundID.NPCDeath5;
			
			npc.lavaImmune = true; 
			base.npc.buffImmune[24] = true;
			base.npc.buffImmune[base.mod.BuffType("FireElementDebuff")] = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if(spawnInfo.player.ZoneUnderworldHeight && NPC.downedMechBoss3 && Main.hardMode)
			{
				return 0.12f;
			}
			return 0f;
		}

		// Token: 0x0600278F RID: 10127 RVA: 0x0025DD17 File Offset: 0x0025BF17
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			player.AddBuff(24, 300, true);
		}
		
		public override void AI()
        {
			int numxd = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, 6, base.npc.velocity.X * 2f, base.npc.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[numxd].velocity /= 50f;
			Main.dust[numxd].scale = 1.2f;
			Main.dust[numxd].noGravity = true;
			Main.dust[numxd].fadeIn = 1.2f;
			
            npc.ai[0]++;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

            if (npc.ai[1] >= 129)  // 230 is projectile fire rate
            {
                float Speed = 4f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 42;  //projectile damage
                int type = mod.ProjectileType("FireElementHoverShot");  //put your projectile
				Main.PlaySound(SoundID.Item8);
                float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -2), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                npc.ai[1] = 0;
            }
			

        }

		// Token: 0x06002790 RID: 10128 RVA: 0x0025E0D8 File Offset: 0x0025C2D8
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 3; i++)
			{
				Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FireElementDust2"), (float)hitDirection, -1f, 0, default(Color), 1f);
			}
			
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FireElementDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust.scale *= 1.65f + (float)Main.rand.Next(-31, 31) * 0.01f;
					
					int num2 = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FireElementDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust2 = Main.dust[num2];
					dust2.velocity.X = dust2.velocity.X + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust2.velocity.Y = dust2.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust2.scale *= 1.65f + (float)Main.rand.Next(-31, 31) * 0.01f;
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("FireElement"), 2, false, 0, false, false);
					return;
				}
			}
			if (!Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
					return;
				}
			}
		}
	}
}
