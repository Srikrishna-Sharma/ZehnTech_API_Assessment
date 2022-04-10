using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DbContextFile;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Repositories.Domain;
using ZehnTech_API_Assessment.Repositories.Interfaces;

namespace ZehnTech_API_Assessment.Repositories.Classes
{
    public class ProductRepository : IProductRepository
    {

        private readonly ZenTechDbContext _dbContext;

        public ProductRepository(ZenTechDbContext dbContext)
        {
            _dbContext = dbContext;
            Mapper.CreateMap<CompleteProductInfoDTO, ProductDTO>().ReverseMap();
            Mapper.CreateMap<CompleteProductInfoDTO, ProductInformationDTO>().ReverseMap();
            Mapper.CreateMap<ProductDTO, ProductInformationDTO>().ReverseMap();
            

        }

        public bool ChangeProductStatus(ProductDTO productdto)
        {
            var user = Mapper.Map<Product>(productdto);
            _dbContext.Update(productdto);
            int rowsAffetcted = _dbContext.SaveChanges();
            return rowsAffetcted > 0 ? true : false;
        }

        public  List<CompleteProductInfoDTO> GetProducts()
        {
            var results = (from p in _dbContext.Product
                          join pi in _dbContext.ProductInformation on p.Id equals pi.Id 
                          select new { Product = p, ProductInformation = pi });
            List<CompleteProductInfoDTO> products = new List<CompleteProductInfoDTO>();
            foreach (var result in results)
            {
                var compProduct = Mapper.Map<CompleteProductInfoDTO>(result.Product);

                compProduct.Category = result.ProductInformation.Category;
                compProduct.Description = result.ProductInformation.Description;
                products.Add(compProduct);
            }

            return products;
        }

        public bool SavePrduct(CompleteProductInfoDTO productdto)
        {
            var product = Mapper.Map<Product>(productdto);
            _dbContext.Product.Add(product);
            int rowsAffetcted = _dbContext.SaveChanges();
            if(rowsAffetcted >0)
            {
                var productInformation = Mapper.Map<ProductInformation>(productdto);
                _dbContext.ProductInformation.Add(productInformation);
                int rAffetcted = _dbContext.SaveChanges();
                return rAffetcted > 0 ? true : false;

            }
            return false;
        }
    }
}
