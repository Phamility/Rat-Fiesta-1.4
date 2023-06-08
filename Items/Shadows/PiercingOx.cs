using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.Audio;

using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;

namespace TenShadows.Items.Shadows
{
    public class PiercingOx : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ox Silhouette");
            Tooltip.SetDefault("Conjures a piercing ox that charges through the screen!");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Shadow>(15)
                .AddIngredient<Horn>(2)

                .AddTile(TileID.DemonAltar)
                .Register();
        }
        public override void SetDefaults()
        {

            Item.damage = 40;
            Item.width = 30;
            Item.mana = 30;
            Item.height = 28;

            Item.useTime = 100;
            Item.useAnimation = 100;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
            Item.knockBack = 3;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<OxProjectile>();

        }
        public static int positive;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position.X = Main.MouseWorld.X;
            position.Y = player.position.Y;
            if(player.direction == 1)
            {
                positive = 1;
            } else
            {
                positive = -1;

            }
            SoundEngine.PlaySound(SoundID.Zombie64, player.position);


            position.X = Main.MouseWorld.X - (800 * player.direction);
                position.Y = player.position.Y - 150;

                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                //Projectile.NewProjectile(Main.MouseWorld.X, player.position.Y - 800, 0f, 0f, ProjectileID.Bomb, damage, 4, player.whoAmI);
            

            return false;

        }

    }
}


