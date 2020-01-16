using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x0200024B RID: 587
	public class EarthNado: ModProjectile
	{
		// Token: 0x06000CF8 RID: 3320 RVA: 0x00094690 File Offset: 0x00092890
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Earthnado");
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
			Main.projFrames[base.projectile.type] = 6;
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x000946E4 File Offset: 0x000928E4
		public override void SetDefaults()
		{
			base.projectile.width = 42;
			base.projectile.height = 42;
			base.projectile.netImportant = true;
			base.projectile.friendly = true;
			base.projectile.minionSlots = 0.25f;
			base.projectile.timeLeft = 18000;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft *= 5;
			base.projectile.minion = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.ignoreWater = true;
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00094794 File Offset: 0x00092994
		public override void AI()
		{
			if (base.projectile.localAI[0] == 0f)
			{
				
				int num = 36;
				for (int i = 0; i < num; i++)
				{
					Vector2 value = (Vector2.Normalize(base.projectile.velocity) * new Vector2((float)base.projectile.width / 2f, (float)base.projectile.height) * 0.75f).RotatedBy((double)((float)(i - (num / 2 - 1)) * 6.28318548f / (float)num), default(Vector2)) + base.projectile.Center;
					Vector2 vector = value - base.projectile.Center;
					int num2 = Dust.NewDust(value + vector, 0, 0, base.mod.DustType("EarthElementDust"), vector.X * 1.5f, vector.Y * 1.5f, 100, default(Color), 1.4f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].noLight = true;
					Main.dust[num2].velocity = vector;
				}
				base.projectile.localAI[0] += 1f;
			}
		
			int num3 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("EarthElementDust"), 0f, 0f, 0, default(Color), 1f);
			Main.dust[num3].velocity *= 0.1f;
			Main.dust[num3].scale = 1.4f;
			Main.dust[num3].noGravity = true;
			
			bool flag = base.projectile.type == base.mod.ProjectileType("EarthNado");
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.FireNado = false;
				}
				if (modPlayer.FireNado)
				{
					base.projectile.timeLeft = 2;
				}
			}
			base.projectile.rotation = base.projectile.velocity.X * 0.05f;
			base.projectile.frameCounter++;
			int num69 = 2;
			if (base.projectile.frameCounter >= 6 * num69)
			{
				base.projectile.frameCounter = 0;
			}
			base.projectile.frame = base.projectile.frameCounter / num69;
			int num4;
			for (int j = 0; j < 1000; j = num4 + 1)
			{
				if (j != base.projectile.whoAmI && Main.projectile[j].active && Main.projectile[j].owner == base.projectile.owner && Main.projectile[j].type == base.mod.ProjectileType("EarthNado") && Math.Abs(base.projectile.position.X - Main.projectile[j].position.X) + Math.Abs(base.projectile.position.Y - Main.projectile[j].position.Y) < (float)base.projectile.width)
				{
					if (base.projectile.position.X < Main.projectile[j].position.X)
					{
						base.projectile.velocity.X = base.projectile.velocity.X - 0.02f;
					}
					else
					{
						base.projectile.velocity.X = base.projectile.velocity.X + 0.09f;
					}
					if (base.projectile.position.Y < Main.projectile[j].position.Y)
					{
						base.projectile.velocity.Y = base.projectile.velocity.Y - 0.02f;
					}
					else
					{
						base.projectile.velocity.Y = base.projectile.velocity.Y + 0.09f;
					}
				}
				num4 = j;
			}
			float num5 = base.projectile.position.X;
			float num6 = base.projectile.position.Y;
			float num7 = 1300f;
			bool flag2 = false;
			int num8 = 1100;
			if (base.projectile.ai[1] != 0f)
			{
				num8 = 1800;
			}
			if (Math.Abs(base.projectile.Center.X - Main.player[base.projectile.owner].Center.X) + Math.Abs(base.projectile.Center.Y - Main.player[base.projectile.owner].Center.Y) > (float)num8)
			{
				base.projectile.ai[0] = 1f;
			}
			if (base.projectile.ai[0] == 0f)
			{
				if (player.HasMinionAttackTargetNPC)
				{
					NPC npc = Main.npc[player.MinionAttackTargetNPC];
					if (npc.CanBeChasedBy(base.projectile, false))
					{
						float num9 = npc.position.X + (float)(npc.width / 2);
						float num10 = npc.position.Y + (float)(npc.height / 2);
						float num11 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num9) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num10);
						if (num11 < num7 && Collision.CanHit(base.projectile.position, base.projectile.width, base.projectile.height, npc.position, npc.width, npc.height))
						{
							num5 = num9;
							num6 = num10;
							flag2 = true;
						}
					}
				}
				else
				{
					for (int k = 0; k < 200; k = num4 + 1)
					{
						if (Main.npc[k].CanBeChasedBy(base.projectile, false))
						{
							float num12 = Main.npc[k].position.X + (float)(Main.npc[k].width / 2);
							float num13 = Main.npc[k].position.Y + (float)(Main.npc[k].height / 2);
							float num14 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num12) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num13);
							if (num14 < num7 && Collision.CanHit(base.projectile.position, base.projectile.width, base.projectile.height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height))
							{
								num7 = num14;
								num5 = num12;
								num6 = num13;
								flag2 = true;
							}
						}
						num4 = k;
					}
				}
			}
			if (!flag2)
			{
				float num15 = 8f;
				if (base.projectile.ai[0] == 1f)
				{
					num15 = 12f;
				}
				Vector2 vector2 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num16 = Main.player[base.projectile.owner].Center.X - vector2.X;
				float num17 = Main.player[base.projectile.owner].Center.Y - vector2.Y - 60f;
				float num18 = (float)Math.Sqrt((double)(num16 * num16 + num17 * num17));
				if (num18 < 100f && base.projectile.ai[0] == 1f && !Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
				{
					base.projectile.ai[0] = 0f;
				}
				if (num18 > 2000f)
				{
					base.projectile.position.X = Main.player[base.projectile.owner].Center.X - (float)(base.projectile.width / 2);
					base.projectile.position.Y = Main.player[base.projectile.owner].Center.Y - (float)(base.projectile.width / 2);
				}
				if (num18 > 70f)
				{
					num18 = num15 / num18;
					num16 *= num18;
					num17 *= num18;
					base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num16) / 21f;
					base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num17) / 21f;
				}
				else
				{
					if (base.projectile.velocity.X == 0f && base.projectile.velocity.Y == 0f)
					{
						base.projectile.velocity.X = -0.12f;
						base.projectile.velocity.Y = -0.04f;
					}
					base.projectile.velocity *= 1.04f;
				}
				base.projectile.rotation = base.projectile.velocity.X * 0.05f;
				if ((double)Math.Abs(base.projectile.velocity.X) > 0.6)
				{
					base.projectile.spriteDirection = -base.projectile.direction;
					return;
				}
			}
			else
			{
				if (base.projectile.ai[1] == -1f)
				{
					base.projectile.ai[1] = 11f;
				}
				if (base.projectile.ai[1] > 0f)
				{
					base.projectile.ai[1] -= 1f;
				}
				if (base.projectile.ai[1] == 0f)
				{
					float num19 = 8f;
					Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
					float num20 = num5 - vector3.X;
					float num21 = num6 - vector3.Y;
					float num22 = (float)Math.Sqrt((double)(num20 * num20 + num21 * num21));
					if (num22 < 100f)
					{
						num19 = 11f;
					}
					num22 = num19 / num22;
					num20 *= num22;
					num21 *= num22;
					base.projectile.velocity.X = (base.projectile.velocity.X * 14f + num20) / 15f;
					base.projectile.velocity.Y = (base.projectile.velocity.Y * 14f + num21) / 15f;
				}
				else if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 10f)
				{
					base.projectile.velocity *= 1.12f;
				}
				base.projectile.rotation = base.projectile.velocity.X * 0.08f;
				if ((double)Math.Abs(base.projectile.velocity.X) > 0.2)
				{
					base.projectile.spriteDirection = -base.projectile.direction;
					return;
				}
			}
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x000954FC File Offset: 0x000936FC
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Rectangle myRect = new Rectangle((int)base.projectile.position.X, (int)base.projectile.position.Y, base.projectile.width, base.projectile.height);
			if (base.projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && ((base.projectile.friendly && (!Main.npc[i].friendly || base.projectile.type == 318 || (Main.npc[i].type == 22 && base.projectile.owner < 255 && Main.player[base.projectile.owner].killGuide) || (Main.npc[i].type == 54 && base.projectile.owner < 255 && Main.player[base.projectile.owner].killClothier))) || (base.projectile.hostile && Main.npc[i].friendly && !Main.npc[i].dontTakeDamageFromHostiles)) && (base.projectile.owner < 0 || Main.npc[i].immune[base.projectile.owner] == 0 || base.projectile.maxPenetrate == 1) && (Main.npc[i].noTileCollide || !base.projectile.ownerHitCheck || base.projectile.CanHit(Main.npc[i])))
					{
						bool flag;
						if (Main.npc[i].type == 414)
						{
							Rectangle rect = Main.npc[i].getRect();
							int num = 8;
							rect.X -= num;
							rect.Y -= num;
							rect.Width += num * 2;
							rect.Height += num * 2;
							flag = base.projectile.Colliding(myRect, rect);
						}
						else
						{
							flag = base.projectile.Colliding(myRect, Main.npc[i].getRect());
						}
						if (flag)
						{
							if (Main.npc[i].reflectingProjectiles && base.projectile.CanReflect())
							{
								Main.npc[i].ReflectProjectile(base.projectile.whoAmI);
								return;
							}
							base.projectile.ai[1] = -1f;
							base.projectile.netUpdate = true;
						}
					}
				}
			}
		}
	}
}
