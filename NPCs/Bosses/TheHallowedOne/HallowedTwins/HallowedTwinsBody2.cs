using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.TheHallowedOne.HallowedTwins
{
	// Token: 0x020000C7 RID: 199
	public class HallowedTwinsBody2 : ModNPC
	{
		private int Timer = 925;
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Hallowed Twin");
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001E06C File Offset: 0x0001C26C
		public override void SetDefaults()
		{
			base.npc.width = 42;
			base.npc.height = 54;
			base.npc.damage = 49;
			base.npc.defense = 48;
			base.npc.lifeMax = 15000;
			base.npc.knockBackResist = 0f;
			base.npc.noTileCollide = true;
			base.npc.netAlways = true;
			base.npc.noGravity = true;
			base.npc.dontCountMe = true;
			base.npc.HitSound = SoundID.NPCHit4;
			base.npc.behindTiles = true;
			if (Main.expertMode)
			{
				base.npc.scale = 1.1f;
			}
			else
			{
				base.npc.scale = 1f;
			}
			base.npc.aiStyle = 5;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0001E131 File Offset: 0x0001C331
		public override bool CheckActive()
		{
			return false;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001E134 File Offset: 0x0001C334
		public override bool PreAI()
		{
			Lighting.AddLight(base.npc.position, 0.455f, 0.155f, 0.505f);
			Player player = Main.player[base.npc.target];
			if (base.npc.target < 0 || base.npc.target == 255 || player.dead || !player.active)
			{
				base.npc.TargetClosest(true);
				player = Main.player[base.npc.target];
				base.npc.netUpdate = true;
				if (!player.active || player.dead)
				{
					base.npc.velocity = new Vector2(10f, 32f);
					if (base.npc.timeLeft > 250)
					{
						base.npc.timeLeft = 250;
					}
				}
			}
			if (base.npc.ai[3] > 0f)
			{
				base.npc.realLife = (int)base.npc.ai[3];
			}
			if (base.npc.target < 0 || base.npc.target == 255 || Main.player[base.npc.target].dead)
			{
				base.npc.TargetClosest(true);
			}
			if (!Main.npc[(int)base.npc.ai[3]].active)
			{
				base.npc.timeLeft = 0;
				base.npc.active = false;
			}
			else
			{
				base.npc.timeLeft = 60000;
			}
			if (Main.netMode != 1 && !Main.npc[(int)base.npc.ai[1]].active)
			{
				base.npc.life = 0;
				base.npc.HitEffect(0, 15.0);
				base.npc.active = false;
			}
			this.Timer--;
			if (this.Timer <= Main.rand.Next(125, 281))
			{
				if (Main.rand.Next(3) == 1)
				{
					Projectile.NewProjectile(base.npc.position, new Vector2(0f), base.mod.ProjectileType("HallowedOneShotNoMoving"), 22, 11f, 255, 0f, 0f);
				}
				this.Timer = Main.rand.Next(510, 600);
			}
			if ((double)base.npc.ai[1] < (double)Main.npc.Length)
			{
				Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
				float num = Main.npc[(int)base.npc.ai[1]].position.X + (float)(Main.npc[(int)base.npc.ai[1]].width / 2) - vector.X;
				float num2 = Main.npc[(int)base.npc.ai[1]].position.Y + (float)(Main.npc[(int)base.npc.ai[1]].height / 2) - vector.Y;
				base.npc.rotation = (float)Math.Atan2((double)num2, (double)num) + 1.57f;
				float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
				float num4 = (num3 - (float)base.npc.width) / num3;
				float num5 = num * num4;
				float num6 = num2 * num4;
				base.npc.velocity = Vector2.Zero;
				base.npc.position.X = base.npc.position.X + num5;
				base.npc.position.Y = base.npc.position.Y + num6;
			}
			return false;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0001E524 File Offset: 0x0001C724
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture2D = Main.npcTexture[base.npc.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)texture2D.Height * 0.5f);
			Main.spriteBatch.Draw(texture2D, base.npc.Center - Main.screenPosition, null, drawColor, base.npc.rotation, origin, base.npc.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001E5AC File Offset: 0x0001C7AC
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return new bool?(false);
		}

		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
				for (int i = 0; i < 10; i++)
                {
                    int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("StroidDust1"));
                    Dust dust = Main.dust[dustIndex];
                    dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                    dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                    dust.scale *= 2.25f + Main.rand.Next(-31, 31) * 0.01f;
                }
				if (Main.rand.Next(2) == 0) //drop chance - This gives a 49% chance as 50-1 = 49
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HallowedOneBodyGore"), 0.8f);   //make sure you put the right folder name where your gores is located and the right name of gores
				}
			}
        }
	}
}
