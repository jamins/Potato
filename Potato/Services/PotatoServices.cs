using PotatoApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PotatoApi.Services
{
    public class PotatoServices
    { 
   private readonly IMongoCollection<PotatoQ> _potatos;

    public PotatoServices(IPotatoDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

            _potatos = database.GetCollection<PotatoQ>(settings.PotatosCollectionName);
    }

    public List<PotatoQ> Get() =>
        _potatos.Find(potato => true).ToList();

    public PotatoQ Get(string id) =>
        _potatos.Find<PotatoQ>(potato => potato.Id == id).FirstOrDefault();

    public PotatoQ Create(PotatoQ potato)
    {
            _potatos.InsertOne(potato);
        return potato;
    }

    public void Update(string id, PotatoQ potatoIn) =>
        _potatos.ReplaceOne(potato => potato.Id == id, potatoIn);

    public void Remove(PotatoQ potatoIn) =>
       _potatos.DeleteOne(potato => potato.Id == potatoIn.Id);

    public void Remove(string id) =>
       _potatos.DeleteOne(potato => potato.Id == id);
}
}