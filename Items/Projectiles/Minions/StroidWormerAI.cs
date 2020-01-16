using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000079 RID: 121
	public abstract class StroidWormerAI : Minion
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00012FCC File Offset: 0x000111CC
		// (set) Token: 0x0600021B RID: 539 RVA: 0x00012FD4 File Offset: 0x000111D4
		public bool isHead { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00012FDD File Offset: 0x000111DD
		// (set) Token: 0x0600021D RID: 541 RVA: 0x00012FE5 File Offset: 0x000111E5
		public int position { get; set; }

		// Token: 0x0600021E RID: 542 RVA: 0x00012FEE File Offset: 0x000111EE
		public virtual void CreateDust()
		{
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00012FF0 File Offset: 0x000111F0
		public virtual void SelectFrame()
		{
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00012FF4 File Offset: 0x000111F4
		public override void Behavior()
		{
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			int num = 10;
			int num2 = 10;
			float num3 = 0.01f;
			bool flag = base.projectile.type == base.mod.ProjectileType("StroidWormerHead");
			bool flag2 = base.projectile.type == base.mod.ProjectileType("StroidWormerHead") || base.projectile.type == base.mod.ProjectileType("StroidWormerBody") || base.projectile.type == base.mod.ProjectileType("StroidWormerBody2") || base.projectile.type == base.mod.ProjectileType("StroidWormerTail");
			if (flag2)
			{
				if (player.dead || !player.HasBuff(base.mod.BuffType("StroidWormerBuff")))
				{
					modPlayer.StroidWormer = false;
				}
				if (modPlayer.StroidWormer)
				{
					base.projectile.timeLeft = 2;
				}
				num = 30;
				num2 = 50;
				num3 = 0.2f;
				if (Main.rand.Next(60) == 0)
				{
					int num4 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("StroidWormDeathDust"), 0f, 0f, 0, default(Color), 1.15f);
					Main.dust[num4].noGravity = true;
					Main.dust[num4].fadeIn = 2f;
					Point point = Utils.ToTileCoordinates(Main.dust[num4].position);
					if (WorldGen.InWorld(point.X, point.Y, 5) && WorldGen.SolidTile(point.X, point.Y))
					{
						Main.dust[num4].noLight = true;
					}
				}
			}
			if (flag)
			{
				Vector2 center = player.Center;
				float num5 = 800f;
				float num6 = 1100f;
				int num7 = -1;
				if (base.projectile.Distance(center) > 1800f)
				{
					base.projectile.Center = center;
					base.projectile.netUpdate = true;
				}
				bool flag3 = true;
				if (flag3)
				{
					for (int i = 0; i < 200; i++)
					{
						NPC npc = Main.npc[i];
						if (npc.CanBeChasedBy(base.projectile, false) && player.Distance(npc.Center) < num6)
						{
							float num8 = base.projectile.Distance(npc.Center);
							if (num8 < num5)
							{
								num7 = i;
								bool boss = npc.boss;
							}
						}
					}
				}
				if (num7 != -1)
				{
					NPC npc2 = Main.npc[num7];
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
					float num9 = 30f;
					if (base.projectile.velocity.Length() > num9)
					{
						base.projectile.velocity = Vector2.Normalize(base.projectile.velocity) * num9;
					}
				}
				else
				{
					float num10 = 0.2f;
					Vector2 vector2 = center - base.projectile.Center;
					if (vector2.Length() < 200f)
					{
						num10 = 0.12f;
					}
					if (vector2.Length() < 140f)
					{
						num10 = 0.06f;
					}
					if (vector2.Length() > 100f)
					{
						if (Math.Abs(center.X - base.projectile.Center.X) > 20f)
						{
							base.projectile.velocity.X = base.projectile.velocity.X + num10 * (float)Math.Sign(center.X - base.projectile.Center.X);
						}
						if (Math.Abs(center.Y - base.projectile.Center.Y) > 10f)
						{
							base.projectile.velocity.Y = base.projectile.velocity.Y + num10 * (float)Math.Sign(center.Y - base.projectile.Center.Y);
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
					float num11 = 15f;
					if (base.projectile.velocity.Length() > num11)
					{
						base.projectile.velocity = Vector2.Normalize(base.projectile.velocity) * num11;
					}
				}
				base.projectile.rotation = Utils.ToRotation(base.projectile.velocity) + 1.57079637f;
				int direction = base.projectile.direction;
				base.projectile.direction = (base.projectile.spriteDirection = ((base.projectile.velocity.X > 0f) ? 1 : -1));
				if (direction != base.projectile.direction)
				{
					base.projectile.netUpdate = true;
				}
				float num12 = MathHelper.Clamp(base.projectile.localAI[0], 0f, 4f);
				base.projectile.position = base.projectile.Center;
				Vector2 center2 = Main.projectile[0].Center;
				Vector2 position = Main.projectile[0].position;
				Vector2 center3 = Main.projectile[1].Center;
				Vector2 position2 = Main.projectile[1].position;
				base.projectile.scale = 1.3f + num12 * 0.01f;
				base.projectile.width = (base.projectile.height = (int)((float)num * base.projectile.scale));
				base.projectile.Center = base.projectile.position;
				if (base.projectile.alpha > 0)
				{
					for (int j = 0; j < 2; j++)
					{
						int num13 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 135, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].noLight = true;
					}
					base.projectile.alpha -= 42;
					if (base.projectile.alpha < 0)
					{
						base.projectile.alpha = 0;
					}
				}
				base.projectile.damage = (int)((float)num2 * (1f + base.projectile.localAI[0] * num3) * player.minionDamage) / 10;
				return;
			}
			bool flag4 = false;
			Vector2 value = Vector2.Zero;
			Vector2 zero = Vector2.Zero;
			float num14 = 0f;
			float scaleFactor2 = 0f;
			float num15 = 1f;
			if (base.projectile.ai[1] == 1f)
			{
				base.projectile.ai[1] = 0f;
				base.projectile.netUpdate = true;
			}
			if (flag2 && base.projectile.owner != Main.myPlayer && base.projectile.ai[0] < 0f)
			{
				this.ProjectileFixDesperation(base.projectile.owner);
			}
			int num16 = (int)base.projectile.ai[0];
			if (flag2 && base.projectile.ai[0] >= 0f && Main.projectile[num16].active && (Main.projectile[num16].type == base.mod.ProjectileType("StroidWormerHead") || Main.projectile[num16].type == base.mod.ProjectileType("StroidWormerBody") || Main.projectile[num16].type == base.mod.ProjectileType("StroidWormerBody2") || Main.projectile[num16].type == base.mod.ProjectileType("StroidWormerTail")))
			{
				flag4 = true;
				value = Main.projectile[num16].Center;
				Vector2 velocity = Main.projectile[num16].velocity;
				num14 = Main.projectile[num16].rotation;
				float num17 = MathHelper.Clamp(Main.projectile[num16].scale, 0f, 4f);
				num15 = num17;
				scaleFactor2 = 16f;
				int alpha = Main.projectile[num16].alpha;
				Main.projectile[num16].localAI[0] = base.projectile.localAI[0] + 1f;
				if (Main.projectile[num16].type != base.mod.ProjectileType("StroidWormerHead"))
				{
					Main.projectile[num16].localAI[1] = (float)base.projectile.whoAmI;
				}
			}
			if (!flag4)
			{
				return;
			}
			if (base.projectile.alpha > 0)
			{
				for (int k = 0; k < 2; k++)
				{
					int num18 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 135, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num18].noGravity = true;
					Main.dust[num18].noLight = true;
				}
			}
			base.projectile.alpha -= 42;
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			base.projectile.velocity = Vector2.Zero;
			Vector2 vector3 = value - base.projectile.Center;
			if (num14 != base.projectile.rotation)
			{
				float num19 = MathHelper.WrapAngle(num14 - base.projectile.rotation);
				vector3 = Utils.RotatedBy(vector3, (double)(num19 * 0.1f), default(Vector2));
			}
			base.projectile.rotation = Utils.ToRotation(vector3) + 1.57079637f;
			base.projectile.position = Main.projectile[0].Center;
			base.projectile.scale = num15;
			base.projectile.width = (base.projectile.height = (int)((float)num * base.projectile.scale));
			base.projectile.Center = base.projectile.position;
			if (vector3 != Vector2.Zero)
			{
				base.projectile.Center = value - Vector2.Normalize(vector3) * scaleFactor2 * num15;
			}
			base.projectile.spriteDirection = ((vector3.X > 0f) ? 1 : -1);
			base.projectile.damage = (int)((float)num2 * (1f + base.projectile.localAI[0] * num3) * player.minionDamage) / 10;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00013C28 File Offset: 0x00011E28
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00013C30 File Offset: 0x00011E30
		public void ProjectileFixDesperation(int own)
		{
			int num = base.projectile.type;
			if (num != 461)
			{
				if (num == base.mod.ProjectileType("StroidWormerTail"))
				{
					num = 628;
				}
				switch (num)
				{
				case 626:
				case 627:
				case 628:
				{
					if (base.projectile.ai[0] >= 0f)
					{
						base.projectile.ai[0] = -base.projectile.ai[0] - 1f;
					}
					int num2 = -(int)base.projectile.ai[0] - 1;
					int num3 = Main.projectileIdentity[own, num2];
					if (num3 >= 0 && Main.projectile[num3].active)
					{
						base.projectile.ai[0] = (float)num3;
					}
					break;
				}
				case 629:
				case 630:
				case 631:
					break;
				case 632:
					goto IL_F1;
				default:
					switch (num)
					{
					case 642:
					case 644:
						goto IL_F1;
					default:
						return;
					}
					break;
				}
				return;
			}
			IL_F1:
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].owner == base.projectile.owner && (float)Main.projectile[i].identity == base.projectile.ai[1] && Main.projectile[i].active)
				{
					base.projectile.ai[1] = (float)i;
					return;
				}
			}
		}

		// Token: 0x0400003E RID: 62
		protected float idleAccel = 0.05f;

		// Token: 0x0400003F RID: 63
		protected float spacingMult = 1f;

		// Token: 0x04000040 RID: 64
		protected float viewDist = 1E+08f;

		// Token: 0x04000041 RID: 65
		protected float chaseDist = 500f;

		// Token: 0x04000042 RID: 66
		protected float chaseAccel = 6f;

		// Token: 0x04000043 RID: 67
		protected float inertia = 10f;
	}
}
