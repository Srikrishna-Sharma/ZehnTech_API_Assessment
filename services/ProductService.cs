using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Interfaces;
using ZehnTech_API_Assessment.Repositories.Interfaces;

namespace ZehnTech_API_Assessment.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _prRepository;
        public ProductService(IProductRepository prRepository)
        {
            _prRepository = prRepository;
        }

        public bool ChangeCurrentProductStatus(ProductDTO product)
        {
            return _prRepository.ChangeProductStatus(product);
        }
        

        public List<CompleteProductInfoDTO> GetAllProducts()
        {
            return _prRepository.GetProducts();
        }

        public bool SaveNewPrduct(CompleteProductInfoDTO product)
        {
            return _prRepository.SavePrduct(product);
        }
    }
}
