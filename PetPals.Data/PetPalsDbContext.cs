using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetPals.Data.Configurations;
using PetPals.Data.Models;
using System.Reflection.Emit;

namespace PetPals.Data;

public class PetPalsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public PetPalsDbContext(DbContextOptions<PetPalsDbContext> options)
        : base(options)
    {

    }


    public DbSet<Pet> Pets { get; set; } = null!;
    public DbSet<AdoptionRequest> AdoptionRequests { get; set; } = null!;
    public DbSet<Donation> Donations { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Volunteer> Volunteers { get; set; } = null!;
    public DbSet<Feedback> Feedbacks { get; set; } = null!;

    public DbSet<Wishlist> Wishlists { get; set; } = null!;

    public DbSet<Photo> Photos { get; set; }






    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        // Configure the composite primary key
        builder.Entity<ApplicationUserPet>()
            .HasKey(a => new { a.ApplicationUserId, a.PetId });

        // Relationships
        builder.Entity<ApplicationUserPet>()
            .HasOne(a => a.ApplicationUser)
            .WithMany(u => u.ApplicationUserMovies)
            .HasForeignKey(a => a.ApplicationUserId);

        builder.Entity<ApplicationUserPet>()
            .HasOne(a => a.Pet)
            .WithMany(p => p.UserPets)
            .HasForeignKey(a => a.PetId);


        //Photo
        builder.Entity<Photo>()
                .HasOne(p => p.Pet)
                .WithMany(p => p.Photos)
                .HasForeignKey(p => p.PetId)
                .OnDelete(DeleteBehavior.Cascade);


        //Seed Pets
        //builder.ApplyConfiguration(new SeedPetsEntityConfiguration());

        //Seed Photos
        //builder.ApplyConfiguration(new SeedPhotosEntityConfiguration());



        base.OnModelCreating(builder);

    }
}
