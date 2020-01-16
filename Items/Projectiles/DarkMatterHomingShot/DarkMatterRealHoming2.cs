using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.DarkMatterHomingShot
{
	// Token: 0x02000054 RID: 84
	public class DarkMatterRealHoming2 : ModProjectile
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.5f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
			base.projectile.timeLeft = 145;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 1.5f;
			int num22 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num22].velocity /= 160f;
			Main.dust[num22].scale = 1.5f;
			int num23 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num23].velocity /= 160f;
			Main.dust[num23].scale = 1.5f;
			int num24 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num24].velocity /= 160f;
			Main.dust[num24].scale = 1.5f;
			int num25 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num25].velocity /= 160f;
			Main.dust[num25].scale = 1.5f;
			
			float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 840f;
			bool flag = false;
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
				{
					float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
					float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
					float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height) - num6);
					if (num7 < num4)
					{
						num4 = num7;
						num2 = num5;
						num3 = num6;
						flag = true;
					}
				}
			}
			if (flag)
			{
				float num8 = 24f;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector.X;
				float num10 = num3 - vector.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 19f + num9 + 12) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 19f + num10 + 12) / 21f;
			}
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
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

		// Token: 0x060015C2 RID: 5570 RVA: 0x0011CCC0 File Offset: 0x0011AEC0
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item38, base.projectile.position);
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), base.projectile.oldVelocity.X * 2.5f, base.projectile.oldVelocity.Y * 2.5f, 0, default(Color), 1f);
			}	
			
			Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.mod.ProjectileType("DarkMatterExplosion"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
		}
	}
}
