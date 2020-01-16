using System;
using System.IO;
using Archeon;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.FrostElementDragon
{
	// Token: 0x02000645 RID: 1605
	public class FrostElementDragon : ModNPC
	{
		// Token: 0x0600266B RID: 9835 RVA: 0x0024AC3B File Offset: 0x00248E3B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Frost Flaker");
			Main.npcFrameCount[base.npc.type] = 2;
		}

		// Token: 0x0600266C RID: 9836 RVA: 0x0024AC60 File Offset: 0x00248E60
		public override void SetDefaults()
		{
			base.npc.aiStyle = 2;
			base.npc.damage = 55;
			base.npc.width = 52;
			base.npc.height = 30;
			base.npc.defense = 32;
			base.npc.lifeMax = 900;
			base.npc.knockBackResist = 0.6f;
			this.animationType = 2;
			base.npc.value = (float)Item.buyPrice(0, 0, 5, 50);
			base.npc.HitSound = SoundID.NPCHit5;
			base.npc.DeathSound = SoundID.NPCDeath17;
			base.npc.noTileCollide = true;
			
			base.npc.buffImmune[44] = true;
			base.npc.buffImmune[base.mod.BuffType("FrostElementDebuff")] = true;
			
		}

		// Token: 0x0600266D RID: 9837 RVA: 0x0024AD3C File Offset: 0x00248F3C
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FrostElementDust2"), (float)hitDirection, -1f, 0, default(Color), 1f);
			}
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FrostElementDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust.scale *= 1.65f + (float)Main.rand.Next(-31, 31) * 0.01f;
					
					int num2 = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FrostElementDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust2 = Main.dust[num2];
					dust2.velocity.X = dust2.velocity.X + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust2.velocity.Y = dust2.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.11f;
					dust2.scale *= 1.65f + (float)Main.rand.Next(-31, 31) * 0.01f;
					
				}
			}
		}
		
		public override void AI()
        {
			
			npc.ai[0]++;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

            npc.ai[1]++;
            if (npc.ai[1] >= 2)  // 230 is projectile fire rate
            {
                float Speed = 0f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 56;  //projectile damage
                int type = mod.ProjectileType("FrostElementDragonShot");  //put your projectile
				float num = 0.45f;
				
				double num3 = (double)(num / 10f);
				
				
				Projectile.NewProjectile(npc.position.X - 0.5f, npc.position.Y - 0.5f, 0, 0, type, damage, 0, Main.myPlayer, 0f, 0f);
				
                npc.ai[1] = 0;
            }
			
			base.npc.ai[1] += 0f;
			if (base.npc.life <= 90000)
			{
				base.npc.ai[2] += 1f;
			}
			if (base.npc.ai[2] >= 15f)
			{
				NPC npc = base.npc;
				npc.velocity.X = npc.velocity.X;
				NPC npc2 = base.npc;
				npc2.velocity.Y = npc2.velocity.Y;
				Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
				float num = (float)Math.Atan2((double)(vector.Y - (Main.player[base.npc.target].position.Y + (float)Main.player[base.npc.target].height * 0.5f)), (double)(vector.X - (Main.player[base.npc.target].position.X + (float)Main.player[base.npc.target].width * 0.5f)));
				base.npc.velocity.X = (float)(Math.Cos((double)num) * 8.0) * -1f;
				base.npc.velocity.Y = (float)(Math.Sin((double)num) * 8.0) * -1f;
				base.npc.ai[0] %= 6.28318548f;
				new Vector2((float)Math.Cos((double)base.npc.ai[0]), (float)Math.Sin((double)base.npc.ai[0]));
				Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 20, 1f, 0f);
				base.npc.ai[2] = -300f;
				new Rectangle((int)base.npc.position.X, (int)(base.npc.position.Y + (float)((base.npc.height - base.npc.width) / 2)), base.npc.width, base.npc.width);
				int num2 = 30;
				for (int i = 1; i <= num2; i++)
				{
					int num3 = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("FrostElementDust2"), 0f, 0f, 0, default(Color), 1f);
					Main.dust[num3].noGravity = false;
				}
			}
	
		}
		
		

		// Token: 0x0600266E RID: 9838 RVA: 0x0024ADEC File Offset: 0x00248FEC
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if(spawnInfo.player.ZoneSnow && NPC.downedMechBoss3 && Main.hardMode)
			{
				return 0.02f;
			}
			return 0f;
		}	

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(npc.width * 0.5f, npc.height * 0.5f);
            for (int k = 0; k < npc.oldPos.Length; k++)
            {
                Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
                Color color = npc.GetAlpha(lightColor) * ((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, null, color, npc.rotation, drawOrigin, npc.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

		// Token: 0x06002670 RID: 9840 RVA: 0x0024AE54 File Offset: 0x00249054
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("FrostElement"), 2, false, 0, false, false);
					return;
				}
			}
			if (!Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
					return;
				}
			}
		}
	}
}
