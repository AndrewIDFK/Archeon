using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.DarkMatterArrows
{
	// Token: 0x0200005E RID: 94
	public class DarkMatterArrow2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shadow's Cruelty");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.scale = 1.2f;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 50;
			base.projectile.aiStyle = 1;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000E32C File Offset: 0x0000C52C
		public override void AI()
		{
			
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 40f;
			Main.dust[num].scale = 1.25f;
			Main.dust[num].noGravity = true;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + MathHelper.ToRadians(270f);
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.immune[base.projectile.owner] = 1;
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

		// Token: 0x0600019F RID: 415 RVA: 0x0000E454 File Offset: 0x0000C654
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 2.9f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * 11.6f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -20.2f, base.projectile.velocity.Y * -10.7f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 13.9f, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 80f;
			Main.dust[num6].scale = 1.1f;
			
			Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y + 16.5f, projectile.velocity.X, projectile.velocity.Y - 32.6f, base.mod.ProjectileType("DarkMatterRealHoming2"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
		}
	}
}
