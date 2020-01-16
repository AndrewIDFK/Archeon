using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.DarkMatterHomingShot
{
	// Token: 0x02000054 RID: 84
	public class DarkMatterExplosion : ModProjectile
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.25f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
			base.projectile.timeLeft = 1;
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.immune[base.projectile.owner] = 0;
			projectile.netUpdate = true; // netUpdate this javelin
			target.AddBuff(BuffType<Buffs.DarkMatterDebuff>(), 240); // Adds the ExampleJavelin debuff for a very small DoT
			
			if (target.type == mod.NPCType("AirElementEye"))
			{
				damage *= 3;
				
				return;
			}
			
			if (target.type == mod.NPCType("FireElementHover"))
			{
				damage *= 3;
				
				return;
			}
			
			if (target.type == mod.NPCType("EarthElementBody"))
			{
				damage *= 3;
				
				return;
			}
			
			if (target.type == mod.NPCType("FrostElementDragon"))
			{
				damage *= 3;
				
				return;
			}
		}
		public override void AI()
		{
			if (base.projectile.owner == Main.myPlayer && base.projectile.timeLeft <= 3)
			{
				
				base.projectile.ai[1] = 0f;
				base.projectile.knockBack = 8f;
				base.projectile.alpha = 255;
				base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 1.85f);
				base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 1.85f);
				base.projectile.width = 18;
				base.projectile.height = 18;
				base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 1.85f);
				base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 1.85f);
				base.projectile.tileCollide = false;
			}
			else
			{
				if (Math.Abs(base.projectile.velocity.X) >= 9f || Math.Abs(base.projectile.velocity.Y) >= 9f)
				{
					for (int i = 0; i < 3; i++)
					{
						float num = 0f;
						float num2 = 0f;
						if (i == 1)
						{
							num = base.projectile.velocity.X * 0.5f;
							num2 = base.projectile.velocity.Y * 0.5f;
						}
						int num3 = Dust.NewDust(new Vector2(base.projectile.position.X + 4f + num, base.projectile.position.Y + 4f + num2) - base.projectile.velocity * 0.5f, base.projectile.width - 6, base.projectile.height - 6, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num3].scale *= 1.85f + (float)Main.rand.Next(9) * 0.15f;
						Main.dust[num3].velocity *= 0.2f;
						Main.dust[num3].noGravity = true;
					}
				}
				if (Math.Abs(base.projectile.velocity.X) < 15f && Math.Abs(base.projectile.velocity.Y) < 15f)
				{
					base.projectile.velocity *= 2f;
				}
				else if (Main.rand.Next(2) == 0)
				{
					int num4 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 0.5f);
					Main.dust[num4].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[num4].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[num4].noGravity = true;
					Main.dust[num4].position = base.projectile.Center + new Vector2(0f, -(float)base.projectile.height / 2f).RotatedBy((double)base.projectile.rotation, default(Vector2)) * 1.1f;
					Main.rand.Next(2);
					num4 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 0.5f);
					Main.dust[num4].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[num4].noGravity = true;
					Main.dust[num4].position = base.projectile.Center + new Vector2(0f, -(float)base.projectile.height / 2f - 6f).RotatedBy((double)base.projectile.rotation, default(Vector2)) * 1.1f;
				}
			}
			base.projectile.ai[0] += 1f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.62f;
			if (base.projectile.ai[0] > 10f || base.projectile.ai[0] > 5f)
			{
				base.projectile.ai[0] = 10f;
				if (base.projectile.velocity.Y == 0f && base.projectile.velocity.X != 0f)
				{
					base.projectile.velocity.X = base.projectile.velocity.X * 0.93f;
					if ((double)base.projectile.velocity.X > -0.01 && (double)base.projectile.velocity.X < 0.01)
					{
						base.projectile.velocity.X = 0f;
						base.projectile.netUpdate = true;
					}
				}
				base.projectile.velocity.Y = base.projectile.velocity.Y + 0.2f;
			}
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x000C38D8 File Offset: 0x000C1AD8
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = 38;
			base.projectile.height = 38;
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
			for (int i = 0; i < 35; i++)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
				}
			}
			for (int j = 0; j < 42; j++)
			{
				int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 2f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 5f;
				num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 1f);
				Main.dust[num2].velocity *= 2f;
			}
			
			base.projectile.Damage();
		}
	}
}
