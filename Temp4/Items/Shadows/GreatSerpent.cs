using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using TenShadows.Items.Materials;
using TenShadows.Items.Shadows;
using TenShadows.Misc;
using TenShadows.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
namespace TenShadows.Items.Shadows
{
    // Flamethrowers have some special characteristics, such as shooting several projectiles in one click, and only consuming ammo on the first projectile
    // The most important characteristics, however, are explained in the FlamethrowerProjectile code.
    public class GreatSerpent : ModItem
    {

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Serpent Silhouette");
            Tooltip.SetDefault("Upon use, fire streams of poison that inflict venom!\nInflicted venom lasts 60 seconds");
        }

        public override void SetDefaults()
        {
            Item.damage = 25; // The item's damage.
            Item.DamageType = DamageClass.Magic;
            Item.width = 30;
            Item.height = 30;
            // A useTime of 4 with a useAnimation of 20 means this weapon will shoot out 5 jets of fire in one shot.
            // Vanilla Flamethrower uses values of 6 and 30 respectively, which is also 5 jets in one shot, but over 30 frames instead of 20.
            Item.useTime = 4;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; // So the item's animation doesn't do damage
            Item.knockBack = 2; // A high knockback. Vanilla Flamethrower uses 0.3f for a weak knockback.
            Item.value = Item.sellPrice(gold: 9); // How many coins the item is worth
            Item.mana = 5;                        //  Item.color = new Color(61, 252, 3); // Makes the item color green, since we are reusing vanilla sprites for simplicity.
            Item.rare = ItemRarityID.Pink; // Sets the item's rarity.
            Item.UseSound = SoundID.Zombie32    ;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PoisonFlame>();
            Item.shootSpeed = 9f; // How fast the flames will travel. Vanilla Flamethrower uses 7f and consequentially has less reach. item.shootSpeed and projectile.timeLeft together control the range.
            Item.useAmmo = AmmoID.None; // Makes the weapon use up Gel as ammo
        }

        // Vanilla Flamethrower uses the commented out code below to prevent shooting while underwater, but this weapon can shoot underwater, so we don't use this code. The projectile also is specifically programmed to survive underwater.
        /*public override bool CanUseItem(Player player)
		{
			return !player.wet;
		}*/


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(25)
                                .AddIngredient(ItemID.SpiderFang, 15)

                .AddIngredient(ItemID.SoulofFright, 15)


            .AddTile<ShrineTile>()

                .Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 54; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
            position += muzzleOffset;

            // This is to prevent shooting through blocks and to make the fire shoot from the muzzle.
            return true;
        }

   
        public override Vector2? HoldoutOffset()
        // HoldoutOffset has to return a Vector2 because it needs two values (an X and Y value) to move your flamethrower sprite. Think of it as moving a point on a cartesian plane.
        {
            return new Vector2(0, -2); // If your own flamethrower is being held wrong, edit these values. You can test out holdout offsets using Modder's Toolkit.
        }
    }
}