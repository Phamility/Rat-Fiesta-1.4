using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using IL.Terraria.GameContent.Personalities;
using On.Terraria.GameContent.Personalities;
using static Terraria.ModLoader.PlayerDrawLayer;
using RatFiesta.Projectiles;

namespace RatFiesta.NPCS
{
    [AutoloadBossHead]
    public class Nue : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.GiantFlyingFox];

            // NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPC.BossBar = ModContent.GetInstance<ExampleBossBar>();
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f;
            NPC.scale = 2.5f;
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 8;
            NPC.defense = 8;
            NPC.lifeMax = 700;
            if (!Main.dedServ)
            {
                Music = MusicID.Boss5;
            }
            NPC.HitSound = SoundID.DD2_LightningAuraZap;
            NPC.DeathSound = SoundID.Thunder;
            NPC.value = 60f;
            NPC.knockBackResist = 0.3f;
            NPC.aiStyle = 14; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic
          //  NPC.noTileCollide = true;
            AIType = NPCID.GiantFlyingFox; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.GiantFlyingFox; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
            //Banner = Item.NPCtoBanner(NPCID.Zombie); // Makes this NPC get affected by the normal zombie banner.
            //BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            // (2) This example shows recreating the drops. This code is commented out because we are using the previous method instead.
            // npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50)); // Drop shackles with a 1 out of 50 chance.
            // npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 250)); // Drop zombie arm with a 1 out of 250 chance.
            //			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Furniture.MinionBossTrophy>(), 10));

            // Finally, we can add additional drops. Many Zombie variants have their own unique drops: https://terraria.fandom.com/wiki/Zombie
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 2)); // 1% chance to drop Confetti
        }

        /* public override float SpawnChance(NPCSpawnInfo spawnInfo)
         {
             return SpawnCondition.OverworldNightMonster.Chance * 0.2f; // Spawn with 1/5th the chance of a regular zombie.
         }*/

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("electric birb"),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
			//	new BestiaryPortraitBackgroundProviderPreferenceInfoElement(Fore),
            });
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            // Spawn confetti when this zombie is hit.

            for (int i = 0; i < 10; i++)
            {
                int dustType = 272;
                var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

                dust.velocity.X += Main.rand.NextFloat(-0.3f, 0.3f);
                dust.velocity.Y += Main.rand.NextFloat(-0.3f, 0.3f);

                dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
            }
        }
                private int timer;
        private int Rage;

        public override void AI()
        {
            if(NPC.life < 400)
            {
                Rage = 2;
            }
            else
            {
                Rage = 1;
            }

            timer += Rage;
            if (timer >= 36)
            {
                Vector2 position = NPC.position - new Vector2(Main.rand.Next(-600, 600), 600);

                var entitySource = NPC.GetSource_FromAI();
                int type = ModContent.ProjectileType<NueLightning>();
                int damage = NPC.damage;



                Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);

                timer = 0;
            }



            if (Main.rand.Next(1, 500) == 2)
            {
                SoundEngine.PlaySound(SoundID.Thunder, NPC.position);

            }
            if (Main.rand.Next(1, 100) == 2)
            {
                SoundEngine.PlaySound(SoundID.DD2_LightningAuraZap, NPC.position);

            }
            if (Main.rand.Next(1, 50) == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    int dustType = 272;
                    var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

                    dust.velocity.X += Main.rand.NextFloat(-0.3f, 0.3f);
                    dust.velocity.Y += Main.rand.NextFloat(-0.3f, 0.3f);

                    dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
                }
            }

        }

        public override void OnKill()
        {
            for (int i = 0; i < 30; i++)
            {
                int dustType = 272;
                var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

                dust.velocity.X += Main.rand.NextFloat(-0.3f, 0.3f);
                dust.velocity.Y += Main.rand.NextFloat(-0.3f, 0.3f);

                dust.scale *= 1f + Main.rand.NextFloat(-0.07f, 0.07f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            SoundEngine.PlaySound(SoundID.Item94, NPC.position);

            // Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
            // Common use is applying buffs/debuffs:

            int buffType = BuffID.Electrified;
            // Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

            int timeToAdd = 1 * 60; //This makes it 5 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);
        }



    }
}
