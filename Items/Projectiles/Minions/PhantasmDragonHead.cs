using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000074 RID: 116
	public class PhantasmDragonHead : PhantasmDragonMinionAI
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x00011CFE File Offset: 0x0000FEFE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Phantasm Dragon Head");
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00011D24 File Offset: 0x0000FF24
		public override void CheckActive()
		{
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead)
			{
				modPlayer.PhantasmDragonMinion = false;
			}
			if (modPlayer.PhantasmDragonMinion)
			{
				base.projectile.timeLeft = 2;
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00011D74 File Offset: 0x0000FF74
		public override void SetDefaults()
		{
			base.projectile.width = 44;
			base.projectile.height = 100;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 66666;
			base.projectile.timeLeft *= 5;
			base.projectile.minion = true;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.alpha = 255;
			base.projectile.netImportant = true;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00011E08 File Offset: 0x00010008
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(Color.White), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, (base.projectile.spriteDirection == 1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
			return false;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00011F04 File Offset: 0x00010104
		public override void AI()
		{
			bool flag2 = base.projectile.type == base.mod.ProjectileType("PhantasmDragonHead");
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			player.AddBuff(base.mod.BuffType("PhantasmDragonBuff"), 3600, true);
			if (flag2)
			{
				if (player.dead)
				{
					modPlayer.PhantasmDragonMinion = false;
				}
				if (modPlayer.PhantasmDragonMinion)
				{
					base.projectile.timeLeft = 2;
				}
			}
			if ((int)Main.time % 120 == 0)
			{
				base.projectile.netUpdate = true;
			}
			if (!player.active)
			{
				base.projectile.active = false;
				return;
			}
			if (player.dead)
			{
				modPlayer.PhantasmDragonMinion = false;
			}
			if (modPlayer.PhantasmDragonMinion)
			{
				base.projectile.timeLeft = 2;
			}
			int num = 30;
			Vector2 center = player.Center;
			float num2 = 700f;
			float num3 = 1000f;
			int num4 = -1;
			if (base.projectile.Distance(center) > 2000f)
			{
				base.projectile.Center = center;
				base.projectile.netUpdate = true;
			}
			
			bool flag = true;
			if (flag)
			{
				NPC ownerMinionAttackTargetNPC = base.projectile.OwnerMinionAttackTargetNPC;
				if (ownerMinionAttackTargetNPC != null && ownerMinionAttackTargetNPC.CanBeChasedBy(base.projectile, false))
				{
					float num5 = base.projectile.Distance(ownerMinionAttackTargetNPC.Center);
					if (num5 < num2 * 2f)
					{
						num4 = ownerMinionAttackTargetNPC.whoAmI;
						if (ownerMinionAttackTargetNPC.boss)
						{
							int whoAmI = ownerMinionAttackTargetNPC.whoAmI;
						}
						else
						{
							int whoAmI2 = ownerMinionAttackTargetNPC.whoAmI;
						}
					}
				}
				if (num4 < 0)
				{
					for (int i = 0; i < 200; i++)
					{
						NPC npc = Main.npc[i];
						if (npc.CanBeChasedBy(base.projectile, false) && player.Distance(npc.Center) < num3)
						{
							float num6 = base.projectile.Distance(npc.Center);
							if (num6 < num2)
							{
								num4 = i;
								bool boss = npc.boss;
							}
						}
					}
				}
			}
			if (num4 != -1)
			{
				NPC npc2 = Main.npc[num4];
				Vector2 vector = npc2.Center - base.projectile.Center;
				Utils.ToDirectionInt(vector.X > 0f);
				Utils.ToDirectionInt(vector.Y > 0f);
				float scaleFactor = 0.4f;
				if (vector.Length() < 600f)
				{
					scaleFactor = 0.6f;
				}
				if (vector.Length() < 300f)
				{
					scaleFactor = 0.8f;
				}
				if (vector.Length() > npc2.Size.Length() * 0.75f)
				{
					base.projectile.velocity += Vector2.Normalize(vector) * scaleFactor * 1.5f;
					if (Vector2.Dot(base.projectile.velocity, vector) < 0.25f)
					{
						base.projectile.velocity *= 0.8f;
					}
				}
				float num7 = 30f;
				if (base.projectile.velocity.Length() > num7)
				{
					base.projectile.velocity = Vector2.Normalize(base.projectile.velocity) * num7;
				}
			}
			else
			{
				float num8 = 0.2f;
				Vector2 vector2 = center - base.projectile.Center;
				if (vector2.Length() < 200f)
				{
					num8 = 0.12f;
				}
				if (vector2.Length() < 140f)
				{
					num8 = 0.06f;
				}
				if (vector2.Length() > 100f)
				{
					if (Math.Abs(center.X - base.projectile.Center.X) > 20f)
					{
						base.projectile.velocity.X = base.projectile.velocity.X + num8 * (float)Math.Sign(center.X - base.projectile.Center.X);
					}
					if (Math.Abs(center.Y - base.projectile.Center.Y) > 10f)
					{
						base.projectile.velocity.Y = base.projectile.velocity.Y + num8 * (float)Math.Sign(center.Y - base.projectile.Center.Y);
					}
				}
				else if (base.projectile.velocity.Length() > 2f)
				{
					base.projectile.velocity *= 0.96f;
				}
				if (Math.Abs(base.projectile.velocity.Y) < 1f)
				{
					base.projectile.velocity.Y = base.projectile.velocity.Y - 0.1f;
				}
				float num9 = 15f;
				if (base.projectile.velocity.Length() > num9)
				{
					base.projectile.velocity = Vector2.Normalize(base.projectile.velocity) * num9;
				}
			}
			base.projectile.rotation = Utils.ToRotation(base.projectile.velocity) + 1.57079637f;
			int direction = base.projectile.direction;
			base.projectile.direction = (base.projectile.spriteDirection = ((base.projectile.velocity.X > 0f) ? 1 : -1));
			if (direction != base.projectile.direction)
			{
				base.projectile.netUpdate = true;
			}
			float num10 = MathHelper.Clamp(base.projectile.localAI[0], 0f, 50f);
			base.projectile.position = base.projectile.Center;
			base.projectile.scale = 1f + num10 * 0.01f;
			base.projectile.width = (base.projectile.height = (int)((float)num * base.projectile.scale));
			base.projectile.Center = base.projectile.position;
			if (base.projectile.alpha > 0)
			{
				base.projectile.alpha -= 42;
				if (base.projectile.alpha < 0)
				{
					base.projectile.alpha = 0;
				}
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00012507 File Offset: 0x00010707
		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}
