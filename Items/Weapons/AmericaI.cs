using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using RatFiesta.Projectiles;

namespace RatFiesta.Items.Weapons
{
    public class AmericaI : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("America I");
            Tooltip.SetDefault("Rain 3 bombs from the sky to explode your foes!\nThese explosives do not destroy tiles!");
        }
        public override void AddRecipes()
        {

        }
        public override void SetDefaults()
        {

            Item.damage = 17;
            Item.width = 30;
            Item.mana = 7;
            Item.height = 28;

            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
            Item.knockBack = 3;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<AmericaBomb>();

        }
        public int positive;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position.X = Main.MouseWorld.X;
            position.Y = player.position.Y - 500;

            int numberProjectiles = 3;
                for (int i = 0; i < numberProjectiles; i++)
                {
                position.X = Main.MouseWorld.X + (Main.rand.Next(1, 80) - 40);
                position.Y = player.position.Y - 500 + (Main.rand.Next(1, 140) - 70);

                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                    //Projectile.NewProjectile(Main.MouseWorld.X, player.position.Y - 800, 0f, 0f, ProjectileID.Bomb, damage, 4, player.whoAmI);
                }
            
            return false;

        }
    }
}


