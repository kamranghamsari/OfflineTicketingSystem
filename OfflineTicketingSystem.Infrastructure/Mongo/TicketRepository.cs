using MongoDB.Driver;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Infrastructure.Mongo;

internal class TicketRepository : ITicketRepository
{
    private readonly IMongoCollection<Ticket> _collection;

    public TicketRepository(IMongoDbContext context)
    {
        _collection = context.GetCollection<Ticket>("Tickets");
    }

    public async Task<List<Ticket>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<List<Ticket>> GetByUserIdAsync(Guid userId)
    {
        var filter = Builders<Ticket>.Filter.Eq(t => t.AssignedToUserId, userId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(Guid id)
    {
        return await _collection.Find(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Ticket ticket)
    {
        await _collection.InsertOneAsync(ticket);
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        await _collection.ReplaceOneAsync(t => t.Id == ticket.Id, ticket);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(t => t.Id == id);
    }
}
