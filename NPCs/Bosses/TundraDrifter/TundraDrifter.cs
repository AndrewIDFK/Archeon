using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace Archeon.NPCs.Bosses.TundraDrifter
{
	public class TundraDrifter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tundra Drifter");
        }

        public override void SetDefaults()
        {
			aiType = -1;
			npc.aiStyle = -1;
			npc.lifeMax = 8500;
			npc.damage = 40;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.width = 52;
			npc.height = 100;
			npc.value = (float)Item.buyPrice(0, 4, 50, 0);
			npc.lavaImmune = true;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath8;
			npc.netAlways = true;
			npc.boss = true;
			
			music = 8;
			
			npc.npcSlots = 20f;
			for (int i = 0; i < npc.buffImmune.Length; i++)
			{
				npc.buffImmune[i] = true;
			}
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)((float)npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)((float)npc.damage * 0.6f);
		}
		
		private const int State_Appear = 0;
		private const int State_Idle = 1;
		
		private float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }
        private float StateTimer
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }
		public int appearTimer;
		
		public override void AI()
        {
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			if (npc.HasValidTarget)
            {		
				if(State == State_Appear)
				{
					Vector2 teleportAppear = new Vector2(player.position.X + 500, player.position.Y - 50 - (npc.height / 2));
					appearTimer++;
					if(appearTimer >= 5 && appearTimer <= 110)
					{
						for(int i = 0; i < 6; i++)
						{
							int rightDust = Dust.NewDust(teleportAppear, npc.width, npc.height, 261, 0f, 0f, 0, Color.Cyan, 1f);
							Main.dust[rightDust].noGravity = true;
							Main.dust[rightDust].scale = 1.25f;
							Main.dust[rightDust].velocity = npc.DirectionTo(Main.player[(int)Player.FindClosest(npc.Center, 0, 0)].Center) * Main.rand.Next(-6, 6);
						}
						Vector2 circularMotion = teleportAppear * npc.scale * 0.95f;
						circularMotion /= 1.95f;
						Vector2 realCircularMotion = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * circularMotion;
						for (int i = 0; i < 8; i++) 
						{
							int numDust = Dust.NewDust(teleportAppear, 0, 0, 261);
							Main.dust[numDust].position = realCircularMotion + teleportAppear;
							Main.dust[numDust].position += npc.velocity;
							Main.dust[numDust].velocity.X = npc.velocity.X / 3;
							Main.dust[numDust].velocity.Y = npc.velocity.Y / 3;
							Main.dust[numDust].scale *= 1.15f;
							Main.dust[numDust].noGravity = true;
							Main.dust[numDust].color = Color.Cyan;
						}
						
					}
					if(appearTimer == 110)
					{
						npc.position = teleportAppear;
						for (int i = 0; i < 20; i++)
						{
							int num = Dust.NewDust(npc.position, npc.width, npc.height, 261, 0f, 0f, 0, Color.Cyan, 1f);
							Main.dust[num].velocity *= 3.75f;
							Main.dust[num].noGravity = true;
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num].scale = 0.75f;
								Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
							}
						}
					}
					else if (appearTimer < 110)
					{
						npc.position.X = player.Center.X;
						npc.position.Y = player.Center.Y - 1000;
					}
					if(appearTimer >= 160)
					{
						State = State_Idle;
						npc.noGravity = false;
					}
					else npc.noGravity = true;
				}
				else if (State == State_Idle)
				{
					//if player gets too close, Main rand jump backwards or teleport to other side of player. Can't do the same action more than 3 times in a row.
					
				}
			}
			else
			{
				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}
				npc.netUpdate = true;
				
				if (!player.active || player.dead)
				{
					npc.TargetClosest(false);
					player = Main.player[npc.target];
					if (!player.active || player.dead)
					{
						for(int i = 0; i < 3; i++)
						{
							int rightDust = Dust.NewDust(npc.Center, npc.width, npc.height, 261, 0f, 0f, 0, Color.Cyan, 1f);
							Main.dust[rightDust].noGravity = true;
							Main.dust[rightDust].scale = 1.25f;
							Main.dust[rightDust].velocity = -npc.DirectionTo(Main.player[(int)Player.FindClosest(npc.Center, 0, 0)].Center) * Main.rand.Next(-6, 6);
						}
						if (npc.timeLeft > 160)
						{
							npc.timeLeft = 160;
						}
						return;
					}
				}
				else if (npc.timeLeft < 1400)
				{
					npc.timeLeft = 1400;
				}
			}
        }
    }
}
