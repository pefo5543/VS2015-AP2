using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Game_AVP2.Models.Avp2.CharacterModels;
using System.Collections.Generic;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using System.ComponentModel.DataAnnotations.Schema;
using Game_AVP2.Models.Avp2.GameModels.Tables;

namespace Game_AVP2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Characters = new HashSet<Character>();
        }
        public virtual ICollection<Character> Characters { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<StaticCharacter> StaticCharacters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armour> Armours { get; set; }
        public DbSet<Misc> Misc { get; set; }
        //public DbSet<Item> Items { get; set; }
        public DbSet<CharacterWeapon> CharacterWeapons { get; set; }
        public DbSet<CharacterArmour> CharacterArmours { get; set; }
        public DbSet<CharacterItem> CharacterItems { get; set; }
        public DbSet<WeaponImage> WeaponImages { get; set; }
        public DbSet<ArmourImage> ArmourImages { get; set; }
        public DbSet<CharacterImage> CharacterImages { get; set; }
        public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<MonsterImage> MonsterImages { get; set; }
        public DbSet<MonsterAttribute> MonsterAttributes { get; set; }
        public DbSet<Story>Stories { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //this.Configuration.ProxyCreationEnabled = false; //proposed solution to circular reference error json
            //Database.SetInitializer(new ApplicationDBInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Game_AVP2.Migrations.Configuration>("ApplicationDBConnectionString"));
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Change the name of the table to be Users instead of AspNetUsers
            //modelBuilder.Entity<IdentityUser>()
            //    .ToTable("Users");
            //behövs
            modelBuilder.Entity<Attribute>()
    .HasRequired(m => m.StaticCharacter)
    .WithOptional(m => m.Attribute)
    .WillCascadeOnDelete(true);
            modelBuilder.Entity<CharacterAttribute>()
    .HasRequired(m => m.Character)
    .WithOptional(m => m.CharacterAttribute)
    .WillCascadeOnDelete(true);
            modelBuilder.Entity<CharacterAttribute>()
            .HasRequired(m => m.Attribute)
            .WithMany(m => m.CharacterAttributes)
            .WillCascadeOnDelete(false);
            modelBuilder.Entity<CharacterArmour>()
    .HasRequired(m => m.Character)
    .WithMany(c=>c.CharacterArmours)
    .WillCascadeOnDelete(false);
            modelBuilder.Entity<CharacterWeapon>()
    .HasRequired(m => m.Character)
    .WithMany(c => c.CharacterWeapons)
    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Battle>()
    .HasRequired(m => m.Monster)
    .WithMany(c => c.Battles)
    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Character>()
            //    .Property(c => c.CharacterId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // modelBuilder.Entity<Character>()
            //.HasMany(f => f.CharacterArmours)
            //.WithOptional()
            //.WillCascadeOnDelete(false);
            //    modelBuilder.Entity<StaticCharacter>()
            //.HasOptional(a => a.Attribute)
            //.WithOptionalDependent(ad => ad.StaticCharacter)
            //.WillCascadeOnDelete(true);
            //modelBuilder.Entity<StaticCharacter>()
            //    .HasOptional(s => s.Attribute)
            //    .WithRequired(ad => ad.StaticCharacter);
            //modelBuilder.Entity<CharacterAttribute>()
            //    .HasOptional(s => s.Character)
            //    .WithRequired(ad => ad.CharacterAttribute);
            //modelBuilder.Entity<Ability>().HasKey(t => t.AbilityId)
            //            .HasOptional(q => q.StaticCharacter)
            // .WithOptionalPrincipal(p => p.Quotation)  //as both Principals
            //        .WithOptionalDependent(p => p.Quotation) // as the dependent
            //         .Map(t => t.MapKey("QuotationId"));    done in POCO.
            ;

            //modelBuilder.Entity<Character>().HasKey(t => t.CharacterId)
            //             .HasOptional(t => t.CharacterAttribute)
            //             .WithOptionalPrincipal(d => d.Character)
            //             .Map(t => t.MapKey("CharacterId"));  // declaring here  via MAP means NOT declared in POCO

            //modelBuilder.Entity<Item>().HasKey(t => t.ItemId)
            //             .HasOptional(t => t.Weapon)
            //             .WithOptionalPrincipal(d => d.Item)
            //             .Map(t => t.MapKey("ItemId"));  // declaring here  via MAP means NOT declared in POCO
            //modelBuilder.Entity<Weapon>().HasKey(t => t.WeaponId)
            //            .HasOptional(q => q.Item);
            //modelBuilder.Entity<Item>().HasKey(t => t.ItemId)
            //             .HasOptional(t => t.Misc)
            //             .WithOptionalPrincipal(d => d.Item)
            //             .Map(t => t.MapKey("ItemId"));  // declaring here  via MAP means NOT declared in POCO
            //modelBuilder.Entity<Misc>().HasKey(t => t.MiscId)
            //            .HasOptional(q => q.Item);
            //modelBuilder.Entity<Item>().HasKey(t => t.ItemId)
            //             .HasOptional(t => t.Armour)
            //             .WithOptionalPrincipal(d => d.Item)
            //             .Map(t => t.MapKey("ItemId"));  // declaring here  via MAP means NOT declared in POCO
            //modelBuilder.Entity<Armour>().HasKey(t => t.ArmourId)
            //            .HasOptional(q => q.Item);
        }
    }
}