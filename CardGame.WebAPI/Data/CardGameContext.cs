using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Lib.Models;

namespace CardGame.WebAPI.Data
{
    public class CardGameContext : DbContext
    {
        public CardGameContext(DbContextOptions<CardGameContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeckCards>()
                .ToTable("DeckCards")
                .HasKey(dc => new { dc.DeckId, dc.CardId });

            modelBuilder.Entity<DeckCards>()
                .HasOne(dc => dc.Deck)
                .WithMany(d => d.DeckCards)
                .HasForeignKey(dc => dc.DeckId);

            modelBuilder.Entity<DeckCards>()
                .HasOne(dc => dc.Card)
                .WithMany(c => c.DeckCards)
                .HasForeignKey(dc => dc.CardId);

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedDateTime)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Deck>()
                .Property(d => d.CreatedDateTime)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Monster>()
                .Property(m => m.CreatedDateTime)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Card>()
                .Property(c => c.CreatedDateTime)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Effect>()
                .Property(e => e.CreatedDateTime)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.IsDeleted)
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Deck>()
                .Property(d => d.IsDeleted)
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Monster>()
                .Property(m => m.IsDeleted)
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Card>()
                .Property(c => c.IsDeleted)
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Effect>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();


            DataSeeder.Seed(modelbuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Effect> Effects { get; set; }
    }
}
