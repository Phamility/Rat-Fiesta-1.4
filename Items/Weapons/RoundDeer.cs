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

namespace TenShadows.Items.Weapons
{
    public class RoundDeer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deer Silhouette");
            Tooltip.SetDefault("Grants regeneration buff on use\n5 minute duration\nDoesn't consume on use");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Shadow>(12)
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
            SoundEngine.PlaySound(SoundID.Item4, player.position);

            player.AddBuff(BuffID.Regeneration, 60 * 5 * 60);
        }
        public override void SetDefaults()
        {

            //   Item.damage = 9;
            Item.width = 38;
            Item.mana = 100;
            Item.height = 34;

            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
                                           //  Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = false;
           // Item.shoot = NPCID.Bunny;

        }

      

        }
    }




