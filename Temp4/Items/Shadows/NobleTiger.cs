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
    public class NobleTiger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tiger Silhouette");
            Tooltip.SetDefault("Upon use, increases damage by 7% and critical chance by 4%\n40 second duration\nDoesn't consume on use");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(10)
                .AddIngredient(ItemID.ShadowScale, 10)

                .AddTile<ShrineTile>()
                .Register();
           CreateRecipe()
        .AddIngredient<CursedEnergy>(10)
        .AddIngredient(ItemID.TissueSample, 10)

        .AddTile<ShrineTile>()
        .Register();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(4 * player.direction, 3);
        }
        public override void OnConsumeMana(Player player, int manaConsumed)
        {

            player.AddBuff(Item.buffType, 60 * 40);


        }
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Zombie28; // What sound should play when using the item


            //   Item.damage = 9;
            Item.width = 30;
            Item.mana = 40;
            Item.height = 30;

            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
            Item.buffType = ModContent.BuffType<TigerBuff>();
            //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
                                           //  Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = true;
           // Item.shoot = NPCID.Bunny;

        }

      

        }
    }




