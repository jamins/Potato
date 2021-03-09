using PotatoApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace PotatoApi.Services
{
    public class CroppedPotatoServices
    {
        private readonly IMongoCollection<CroppedPotato> _croppedPotatos;

        public CroppedPotatoServices(IPotatoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _croppedPotatos = database.GetCollection<CroppedPotato>(settings.CroppedPotatoCollectionName);
        }

        public List<CroppedPotato> Get() =>
            _croppedPotatos.Find(croppedPotato => true).ToList();

        public CroppedPotato Get(string id) =>
            _croppedPotatos.Find<CroppedPotato>(croppedPotato => croppedPotato.Id == id).FirstOrDefault();

        public CroppedPotato Create(CroppedPotato croppedPotato)
        {
            _croppedPotatos.InsertOne(croppedPotato);
            return croppedPotato;
        }

        public void Update(string id, CroppedPotato croppedPotatoIn) =>
            _croppedPotatos.ReplaceOne(croppedPotato => croppedPotato.Id == id, croppedPotatoIn);

        public void Remove(CroppedPotato croppedPotatoIn) =>
           _croppedPotatos.DeleteOne(croppedPotato => croppedPotato.Id == croppedPotato.Id);

        public void Remove(string id) =>
           _croppedPotatos.DeleteOne(croppedPotato => croppedPotato.Id == id);
    }
}