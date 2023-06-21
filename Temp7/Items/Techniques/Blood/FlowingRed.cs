﻿using System;
using TenShadows.Buffs;
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

namespace TenShadows.Items.Techniques.Blood
{
    public class FlowingRed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flowing Red Scale");
            Tooltip.SetDefault("Gain 15% cursed damage for 2 minutes\nHowever, during this time, life regeneration is decreased by 10");
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(0 * player.direction, 3);
        }

        public override void UpdateInventory(Player player)
        {
            Cost = 15;

            if (player.HasBuff(ModContent.BuffType<SixEyesBuff>()))
            {
                Reduction = Cost - 1;
            }
            else if (player.HasBuff(ModContent.BuffType<TwinEyesBuff>()))
            {

                Reduction = 4;
            }
            else if (player.HasBuff(ModContent.BuffType<NueEyeBuff>()))
            {

                Reduction = 2;
            }
            else
            {
                Reduction = 0;
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            TooltipLine tooltip = new TooltipLine(Mod, "Ten Shadows: Cost", $"Costs {Cost - Reduction} cursed energy") { OverrideColor = Color.DodgerBlue };

            tooltips.Insert(1, tooltip);
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(Item.buffType, 2 * 60 * 60);

            bool once = false;
            for (int i = 0; i < Main.InventorySlotsTotal; i++)
            {
                if (player.inventory[i].type == ModContent.ItemType<CursedEnergy>() && once == false)
                {
                    if (player.HasBuff(ModContent.BuffType<SixEyesBuff>()))
                    {
                        player.inventory[InventoryNumber].stack -= Cost - Reduction;
                        once = true;
                        player.AddBuff(Item.buffType, 60 * 60);


                    }
                    else if (player.HasBuff(ModContent.BuffType<TwinEyesBuff>()))
                    {
                        player.inventory[InventoryNumber].stack -= Cost - Reduction;
                        once = true;
                        player.AddBuff(Item.buffType, 60 * 60);


                    }
                    else if (player.HasBuff(ModContent.BuffType<NueEyeBuff>()))
                    {
                        player.inventory[InventoryNumber].stack -= Cost - Reduction;
                        once = true;
                        player.AddBuff(Item.buffType, 60 * 60);


                    }
                    else
                    {
                        player.inventory[InventoryNumber].stack -= Cost - Reduction;
                        once = true;
                        player.AddBuff(Item.buffType, 60 * 60);


                    }
                }
            }
            return true;
        }

        public int InventoryNumber;
        public int Cost;
        public int Reduction = 0;

        public override bool CanUseItem(Player player)
        {
            bool Condition2 = false;
            Cost = 15;
            if (player.HasBuff(ModContent.BuffType<SixEyesBuff>()))
            {
                Reduction = Cost - 1;
            }
            else if (player.HasBuff(ModContent.BuffType<TwinEyesBuff>()))
            {

                Reduction = 4;
            }
            else if (player.HasBuff(ModContent.BuffType<NueEyeBuff>()))
            {

                Reduction = 2;
            }
            else
            {
                Reduction = 0;
            }
            bool Condition1;
            if (player.HasBuff<HeavenlyBuff>())
            {

                Condition1 = false;
            }
            else
            {
                Condition1 = true;
            }
            for (int i = 0; i < 58; i++)
            {
                if (player.inventory[i].type == ModContent.ItemType<CursedEnergy>())
                {
                    if (player.inventory[i].stack >= Cost - Reduction && Condition1 == true)
                    {
                        InventoryNumber = i;
                        return true;

                    }
                    else
                    {
                        Condition2 = false;

                    }
                }

            }

            if (Condition2 == true && Condition1 == true)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.NPCDeath19; // What sound should play when using the item
                                                //  Item.healLife = 25; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
                                                //  Item.potion = false; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
                                                //   Item.damage = 9;
            Item.width = 28;
            Item.height = 31;
            Cost = 15;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.
            Item.buffType = ModContent.BuffType<FlowingRedBuff>();
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = false;
            // Item.shoot = NPCID.Bunny;

        }


    }
}




