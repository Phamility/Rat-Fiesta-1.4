using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;
using TenShadows.Misc;
using TenShadows.GamblingBuffs;

namespace TenShadows.Items.Techniques
{
    public class RestlessGambler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Restless Gambler");
            Tooltip.SetDefault("41 second cooldown\nUpon use, have a [c/FF33D6:50 / 50 chance] between a random buff or debuff lasting 41 seconds!\nIf the last roll was a buff, have a [c/33FF3D:65% chance] for a random buff, and a [c/FF0000:35% chance] for a random debuff!\n[c/FF33D6:Can only be used during bosses!]");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(20)
        .AddIngredient(ItemID.SoulofLight, 5)

        .AddIngredient(ItemID.SoulofNight, 5)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
 
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(4 * player.direction, 3);
        }
        public static int PREVIOUSRoll = 0;
        //			Main.NewText("You have used " + PlayerStats.Idolsconsumed + " out of 5 Mysterious Idols!\n");
        string pretext;
        private void RollPositive(Player player)
        {
            if (PREVIOUSRoll >= 3)
            {
                PREVIOUSRoll = 4;

                if (Main.rand.Next(1, 3) == 2)
                {
                    pretext = player.name + " just keeps on going! ";
                }
                else
                {
                    pretext = player.name + "'s unstoppable right now! ";

                }
            }
            else
            if (PREVIOUSRoll >= 2)
            {
                PREVIOUSRoll = 3;

                if (Main.rand.Next(1, 3) == 2)
                {
                    pretext = player.name + " scored three in a row! ";
                }
                else
                {
                    pretext = player.name + "'s three for THREE! ";

                }
            }
            else
                if (PREVIOUSRoll >= 1)
            {
                PREVIOUSRoll = 2;

                if (Main.rand.Next(1, 3) == 2)
                {
                    pretext = player.name + "'s on a streak! ";
                }
                else
                {
                    pretext = player.name + " starts their streak! ";

                }

            }
            else
            {
                if (PREVIOUSRoll <= -2)
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        pretext = player.name + " 's making a comeback! ";
                        PREVIOUSRoll = 1;

                    }
                    else
                    {
                        pretext = player.name + "'s still in the game! ";
                        PREVIOUSRoll = 1;

                    }
                }
                else
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        pretext = player.name + "'s positive once again! ";
                    }
                    else
                    {
                        pretext = player.name + "'s back to winning! ";

                    }
                    PREVIOUSRoll = 1;
                }
            }

            int InnateNumber;

            InnateNumber = Main.rand.Next(1,8);

            if(InnateNumber == 1)
            {
                player.AddBuff(ModContent.BuffType<ArmorPenBuff>(), 41 * 60);
                Main.NewText(pretext +  "They rolled an increase in armor penetration by 30!", Color.LimeGreen);
            }
            if (InnateNumber == 2)
            {
                player.AddBuff(ModContent.BuffType<CritBuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled an increase in critical chance by 45%!", Color.LimeGreen);
            }
            if (InnateNumber == 3)
            {
                player.AddBuff(ModContent.BuffType<DamageBuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled an increase in damage by 40%!", Color.LimeGreen);
            }
            if (InnateNumber == 4)
            {
                player.AddBuff(ModContent.BuffType<DRBuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled an increase in damage reduction by 35%!", Color.LimeGreen);
            }
            if (InnateNumber == 5)
            {
                player.AddBuff(ModContent.BuffType<HealthBuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled an increase in max life by 250!", Color.LimeGreen);
            }
            if (InnateNumber == 6)
            {
                player.AddBuff(ModContent.BuffType<ManaReducBuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a decrease in mana costs by 45%!", Color.LimeGreen);
            }
            if (InnateNumber == 7)
            {
                player.AddBuff(ModContent.BuffType<SummonBuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled an increase in max number of minions by 4!", Color.LimeGreen);
            }


        }
        public override void OnConsumeMana(Player player, int manaConsumed)
        {
            GamblingDebuff.once = false;

            GamblingDebuff.timer = 0;
            int ROLLNUMBER;
            player.AddBuff(Item.buffType, 41 * 60);

            ROLLNUMBER = Main.rand.Next(101);

            if (PREVIOUSRoll >= 1) {
                if (ROLLNUMBER <=65)
                {
                    RollPositive(player);
                }
                else
                {
                    RollNegative(player);

                }
            }
            else
            {
                if (ROLLNUMBER <= 50)
                {
                    RollPositive(player);
                }
                else
                {
                    RollNegative(player);
                }
            }



        }
        private void RollNegative(Player player){
            if (PREVIOUSRoll >= 3)
            {
                if (Main.rand.Next(1, 3) == 2)
                {
                    pretext = player.name + "'s luck ran out! ";
                }
                else
                {
                    pretext = player.name + "'s streak finally comes to an end! ";

                }
                PREVIOUSRoll = -1;
            }
            else
            if (PREVIOUSRoll >= 2)
            {
                pretext = player.name + "'s streak broke! ";
                PREVIOUSRoll = -1;
            }
            else
            if (PREVIOUSRoll >= 1)
            {
                if (Main.rand.Next(1, 3) == 2)
                {
                    pretext = player.name + "'s back to losing! ";
                }
                else
                {
                    pretext = player.name + "'s negative once again! ";

                }
                PREVIOUSRoll = -1;
            }
            else
            {
                if (PREVIOUSRoll <= -3)
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        pretext = player.name + " is suffering. ";
                    }
                    else
                    {
                        pretext = player.name + " is in shambles. ";

                    }
                    PREVIOUSRoll = -4;
                }
                else
                if (PREVIOUSRoll <= -2)
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        pretext = player.name + "'s luck is not the best right now! ";
                    }
                    else
                    {
                        pretext = player.name + "'s three for three for LOSING! ";

                    }
                    PREVIOUSRoll = -3;
                }
                else
                {
                    PREVIOUSRoll = -2;

                    if (Main.rand.Next(1, 3) == 2)
                    {
                        pretext = player.name + "'s not doing so hot! ";
                    }
                    else
                    {
                        pretext = player.name + "'s not having a good time! ";

                    }
                }
            }

            int InnateNumber;

            InnateNumber = Main.rand.Next(1,8);

            if (InnateNumber == 1)
            {
                player.AddBuff(ModContent.BuffType<WingDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a heavy reduction in wing time!", Color.Red);
            }
            if (InnateNumber == 2)
            {
                player.AddBuff(ModContent.BuffType<CritDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a decrease in critical chance by 45%!", Color.Red);
            }
            if (InnateNumber == 3)
            {
                player.AddBuff(ModContent.BuffType<DamageDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a decrease in damage by 40%!", Color.Red);
            }
            if (InnateNumber == 4)
            {
                player.AddBuff(ModContent.BuffType<DefenseDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a decrease in defense by 40!", Color.Red);
            }
            if (InnateNumber == 5)
            {
                player.AddBuff(ModContent.BuffType<HealthDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a decrease in max life by 250!", Color.Red);
            }
            if (InnateNumber == 6)
            {
                player.AddBuff(ModContent.BuffType<ManaCostsDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled an increase mana costs by 50%!", Color.Red);
            }
            if (InnateNumber == 7)
            {
                player.AddBuff(ModContent.BuffType<SummonDebuff>(), 41 * 60);
                Main.NewText(pretext + "They rolled a decrease in max number of minions by 3!", Color.Red);
            }
        }
        

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item141; // What sound should play when using the item
           // Item.healLife = 25; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
           //tem.potion = false; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
            //   Item.damage = 9;
            Item.width = 26;
            Item.mana = 100;
            Item.height = 30;

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
            Item.buffType = ModContent.BuffType<GamblingDebuff>();
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = false;
           // Item.shoot = NPCID.Bunny;

        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff<GamblingDebuff>() == true || !NPC.AnyDanger(false, true))
            {

                return false;
            }
            else
            {
                return true;

            }
        }
   
    }
    }




