using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PotatoApi.Models
{
    public class potatoViewModel
    {
        public string Name { get; set; }
        public IFormFile Img{ get; set; }
        public bool IsPotato { get; set; }
    }
}
