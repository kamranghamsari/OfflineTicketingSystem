using MongoDB.Driver;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Domain.Entities;

namespace OfflineTicketingSystem.Infrastructure.Mongo;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(IMongoDbContext context)
    {
        _collection = context.GetCollection<User>("Users");
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _collection
            .Find(u => u.Email.ToLower() == email.ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }
}
