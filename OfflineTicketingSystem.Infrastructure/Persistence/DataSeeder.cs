using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighViewApi.Infrastructure.Persistence;

public static class DataSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var db = serviceProvider.GetRequiredService<IMongoDbContext>();
        var usersCollection = db.GetCollection<User>("Users");

        var existingUsers = await usersCollection.Find(_ => true).AnyAsync();
        if (existingUsers) return;

        var users = new List<User>
{
    new User
    {
        Id = Guid.NewGuid(),
        FullName = "Admin One",
        Email = "admin1@example.com",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin1234!"),
        Role = UserRole.Admin
    },
    new User
    {
        Id = Guid.NewGuid(),
        FullName = "Admin Two",
        Email = "admin2@example.com",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin1234!"),
        Role = UserRole.Admin
    },
    new User
    {
        Id = Guid.NewGuid(),
        FullName = "Employee One",
        Email = "employee1@example.com",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Employee1234!"),
        Role = UserRole.Employee
    },
    new User
    {
        Id = Guid.NewGuid(),
        FullName = "Employee Two",
        Email = "employee2@example.com",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Employee1234!"),
        Role = UserRole.Employee
    }
};

        await usersCollection.InsertManyAsync(users);
    }
}
