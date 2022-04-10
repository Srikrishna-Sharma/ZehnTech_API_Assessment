using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZehnTech_API_Assessment.Repositories.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public string Price { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }

    }
}
