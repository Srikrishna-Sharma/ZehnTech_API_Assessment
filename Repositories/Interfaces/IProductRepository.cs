using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DTOs;

namespace ZehnTech_API_Assessment.Repositories.Interfaces
{
     public  interface IProductRepository
    {
        public List<CompleteProductInfoDTO> GetProducts();
        public bool SavePrduct(CompleteProductInfoDTO product);
        public bool ChangeProductStatus(ProductDTO product);
    }
}
