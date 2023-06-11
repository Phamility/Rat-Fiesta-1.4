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

namespace TenShadows.Items.Shadows
{
    public class RoundDeer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deer Silhouette");
            Tooltip.SetDefault("5 second cooldown\nDoesn't cause potion sickness\nCan't be used by quick heal\nDoesn't consume on use");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(12)
                .AddIngredient<BoneAntler>(2)

                .AddTile(TileID.DemonAltar)
                .Register();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(8 * player.direction, 3);
        }
        public override void OnConsumeMana(Player player, int manaConsumed)
        {

            player.AddBuff(Item.buffType, 60 * 5);


        }
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Zombie33; // What sound should play when using the item
            Item.healLife = 25; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
            Item.potion = false; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
            //   Item.damage = 9;
            Item.width = 38;
            Item.mana = 100;
            Item.height = 34;

            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.buffType = ModContent.BuffType<DeerDebuff>();
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = false;
           // Item.shoot = NPCID.Bunny;

        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff<DeerDebuff>())
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




