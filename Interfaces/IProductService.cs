using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DTOs;

namespace ZehnTech_API_Assessment.Interfaces
{
   public interface IProductService
    {
        public List<CompleteProductInfoDTO> GetAllProducts();
        public bool SaveNewPrduct(CompleteProductInfoDTO product);
        public bool ChangeCurrentProductStatus(ProductDTO product);
    }
}
