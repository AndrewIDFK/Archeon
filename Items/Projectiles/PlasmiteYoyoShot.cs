using System;
using Archeon.Buffs;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000060 RID: 96
	public class PlasmiteYoyoShot : ModProjectile
	{
		// Token: 0x060001A7 RID: 423 RVA: 0x0000EE58 File Offset: 0x0000D058
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 0;
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.aiStyle = 99;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.melee = true;
			ProjectileID.Sets.YoyosLifeTimeMultiplier[base.projectile.type] = 10f;
			ProjectileID.Sets.YoyosMaximumRange[base.projectile.type] = 320f;
			ProjectileID.Sets.YoyosTopSpeed[base.projectile.type] = 16.5f;
		}

		
		
		// Token: 0x06001968 RID: 6504 RVA: 0x0014934C File Offset: 0x0014754C
		public override void AI()
		{
			int[] array = new int[20];
			int num = 0;
			float num2 = 550f;
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(base.projectile, false))
				{
					float num3 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float num4 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num3) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num4) < num2 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
					{
						if (num < 45)
						{
							array[num] = i;
							num++;
						}
						flag = true;
					}
				}
			}
			if (flag)
			{
				int num5 = Main.rand.Next(num);
				num5 = array[num5];
				float num6 = Main.npc[num5].position.X + (float)(Main.npc[num5].width / 1.95);
				float num7 = Main.npc[num5].position.Y + (float)(Main.npc[num5].height / 1.95);
				base.projectile.localAI[0] += 1f;
				if (base.projectile.localAI[0] > 30f)
				{
					base.projectile.localAI[0] = 0f;
					float num8 = 5f;
					Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
					vector += base.projectile.velocity * 5f;
					float num9 = num6 - vector.X;
					float num10 = num7 - vector.Y;
					float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
					num11 = num8 / num11;
					num9 *= num11;
					num10 *= num11;
					Main.PlaySound(SoundID.Item15, base.projectile.position);
					if (base.projectile.owner == Main.myPlayer)
					{
						Projectile.NewProjectile(vector.X, vector.Y, num9, num10, base.mod.ProjectileType("PlasmiteYoYoPlasma"), (int)((double)base.projectile.damage) * 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
					}
				}
			}
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x00116EDF File Offset: 0x001150DF
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(base.mod.BuffType("CosmicalPoisoning"), 360, false);
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x00149634 File Offset: 0x00147834
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, base.projectile.GetAlpha(lightColor), base.projectile.rotation, texture2D.Size() / 2f, base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
