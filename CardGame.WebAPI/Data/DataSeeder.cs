using CardGame.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    Name = "RegularUser", 
                    Email = "regularuser@example.test", 
                    Password = "password", 
                    IsAdmin = false},
                new User { 
                    Id = 2, 
                    Name = "Admin", 
                    Email = "admin@example.test", 
                    Password = "password", 
                    IsAdmin = true});

            modelBuilder.Entity<Deck>().HasData(
                new { 
                    Id = 1, 
                    Name = "WeakMonsterDeck" },
                new { 
                    Id = 2, 
                    Name = "StrongMonsterDeck" },
                new { 
                    Id = 3, 
                    Name = "UserDeck1", 
                    UserId = 1 },
                new { 
                    Id = 4, 
                    Name = "UserDeck2", 
                    UserId = 1 },
                new { 
                    Id = 5, 
                    Name = "UserDeck3", 
                    UserId = 2 });

            modelBuilder.Entity<Monster>().HasData(
                new { 
                    Id = 1, 
                    Name = "WeakMonster", 
                    Health = 10, 
                    DeckId = 1},
                new { 
                    Id = 2, 
                    Name = "StrongMonster", 
                    Health = 2000, 
                    DeckId = 2});

            modelBuilder.Entity<Card>().HasData(
                new Card { 
                    Id = 1 , 
                    Name = "WeakCard1", 
                    Description = "This is a weak card." },
                new Card { 
                    Id = 2, 
                    Name = "WeakCard2", 
                    Description = "This is also a weak card." },
                new Card { 
                    Id = 3, 
                    Name = "StrongCard1", 
                    Description = "This is a strong card." },
                new Card { 
                    Id = 4, 
                    Name = "StrongCard2", 
                    Description = "This is also a strong card." });

            modelBuilder.Entity<Effect>().HasData(
                new { 
                    Id = 1, 
                    Code = "WeakEffect1", 
                    CardId = 1, 
                    Power = 1, 
                    Chance = 0.5m }, 
                new { 
                    Id = 2, 
                    Code = "WeakEffect2", 
                    CardId = 2, 
                    Power = 0, 
                    Chance = 1m },
                new { 
                    Id = 3, 
                    Code = "StrongEffect1", 
                    CardId = 3, 
                    Power = 20, 
                    Chance = 1m }, 
                new { 
                    Id = 4, 
                    Code = "StrongEffect2", 
                    CardId = 4, 
                    Power = 30, 
                    Chance = 0.8m },
                new { 
                    Id = 5, 
                    Code = "StrongEffect3", 
                    CardId = 4, 
                    Power = 0, 
                    Chance = 1m });

            modelBuilder.Entity<DeckCards>().HasData(
                new { DeckId = 1, CardId = 1, AmountOfCopies = 3 },
                new { DeckId = 1, CardId = 2, AmountOfCopies = 3 },
                new { DeckId = 2, CardId = 3, AmountOfCopies = 3 },
                new { DeckId = 2, CardId = 4, AmountOfCopies = 3 },
                new { DeckId = 3, CardId = 1, AmountOfCopies = 2 },
                new { DeckId = 3, CardId = 4, AmountOfCopies = 1 },
                new { DeckId = 4, CardId = 2, AmountOfCopies = 3 },
                new { DeckId = 4, CardId = 3, AmountOfCopies = 2 },
                new { DeckId = 5, CardId = 4, AmountOfCopies = 1 });
        }
    }
}
