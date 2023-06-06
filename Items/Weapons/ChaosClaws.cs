using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace RatFiesta.Items.Weapons
{
    public class ChaosClaws : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 32; // Hitbox width of the item.
            Item.height = 30; // Hitbox height of the item.
            Item.scale = 0.75f;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 6; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 6; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Swing; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.



            // Weapon Properties
            Item.DamageType = DamageClass.Melee; // Sets the damage type to ranged.
            Item.damage = 69; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 3f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            // Gun Properties
            Item.shoot = ProjectileID.Arkhalis; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 20f; // The speed of the projectile (measured in pixels per frame.)
                                   //   Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                //   .AddIngredient<ExampleItem>()
                //   .AddTile<Tiles.Furniture.ExampleWorkbench>()
                .Register();
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            float numberProjectiles = 2 + Main.rand.Next(4); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(velocity) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .65f;

                // Watch out for dividing by 0 if there is only 1 projectile.
                if (Main.rand.NextBool(50))
                {

                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.RocketFireworkBlue;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.GreenLaser;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.LightBeam;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.NightBeam;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.EnchantedBeam;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.CrystalLeafShot;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.IceSickle;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.BoulderStaffOfEarth;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.BallofFrost;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.DeathSickle;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.LostSoulFriendly;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.PaladinsHammerFriendly;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.InfernoFriendlyBolt;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.VampireKnife;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.FlamingJack;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Blizzard;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.RocketSnowmanI;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.PineNeedleFriendly;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.ImpFireball;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.MiniRetinaLaser;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.MiniSharkron;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Typhoon;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Bubble;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Meteor1;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.InfluxWaver;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.StarWrath;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Meowmere;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.NebulaBlaze1;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.TerraBeam;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.EighthNote;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.DemonScythe;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.EatersBite;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.ShadowBeamFriendly;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.BallofFire;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.MagnetSphereBall;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Bullet;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.EnchantedBoomerang;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.RainbowCrystalExplosion;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.SpiritFlame;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.SkyFracture;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.BlackBolt;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.ClothiersCurse;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.DryadsWardCircle;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.MagicDagger;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.ShadowFlameKnife;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.IchorDart;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Xenopopper;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.ElectrosphereMissile;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.ChlorophyteOrb;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.MagicDagger;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.CursedFlameFriendly;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.LightDisc;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.PossessedHatchet;

                }
                if (Main.rand.NextBool(50))
                {
                    //  type = ModContent.ProjectileType<ExampleInstancedProjectile>();
                    type = ProjectileID.Beenade;

                }
            
            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }



          



            return false;
        }



   

    }
}