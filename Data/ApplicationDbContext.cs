using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<PetImage> PetImages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PetShelter> PetShelters { get; set; }
    public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
    public DbSet<MessageThread> MessageThreads { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    // Pet -> PetImages (One-to-Many)
    modelBuilder.Entity<Pet>()
        .HasMany(p => p.Images)
        .WithOne(pi => pi.Pet)
        .HasForeignKey(pi => pi.PetID)
        .OnDelete(DeleteBehavior.Cascade); 

    // AdoptionRequest -> Pet (One-to-Many)
    modelBuilder.Entity<AdoptionRequest>()
        .HasOne(ar => ar.Pet)
        .WithMany()
        .HasForeignKey(ar => ar.PetID)
        .OnDelete(DeleteBehavior.Cascade); 

    // AdoptionRequest -> User (One-to-Many)
    modelBuilder.Entity<AdoptionRequest>()
        .HasOne(ar => ar.User)
        .WithMany(u => u.AdoptionRequests)
        .HasForeignKey(ar => ar.UserID)
        .OnDelete(DeleteBehavior.Restrict); 

    // AdoptionRequest -> MessageThread (One-to-One)
    modelBuilder.Entity<AdoptionRequest>()
        .HasOne(ar => ar.MessageThread)
        .WithOne(mt => mt.AdoptionRequest)
        .HasForeignKey<MessageThread>(mt => mt.AdoptionRequestID)
        .OnDelete(DeleteBehavior.Cascade);

    // MessageThread -> Messages (One-to-Many)
    modelBuilder.Entity<MessageThread>()
        .HasMany(mt => mt.Messages)
        .WithOne(m => m.MessageThread)
        .HasForeignKey(m => m.MessageThreadID)
        .OnDelete(DeleteBehavior.Cascade);
            
    }

}