using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotatoApi.Models
{
    public class PotatoDatabaseSettings : IPotatoDatabaseSettings

    {
        public string PotatosCollectionName { get; set; }
        public string CroppedPotatoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPotatoDatabaseSettings
    {
        string PotatosCollectionName { get; set; }
        string CroppedPotatoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

