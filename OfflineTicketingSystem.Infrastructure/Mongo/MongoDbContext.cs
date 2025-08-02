using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Infrastructure.Mongo;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient,IConfiguration configuration)
    {

        _database = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}
