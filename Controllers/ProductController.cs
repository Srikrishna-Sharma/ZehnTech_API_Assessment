using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Interfaces;

namespace ZehnTech_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _prService;

        public ProductController(IProductService prService)
        {
            _prService = prService;
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _prService.GetAllProducts();
            return Ok(products);
        }
        [HttpPost]
        [Route("saveProduct")]
        public IActionResult saveItem(CompleteProductInfoDTO product)
        {
            if (_prService.SaveNewPrduct(product))
            {
                return StatusCode(201);
            }
            return StatusCode(500);
        }
        [HttpPost]
        [Authorize]

        [Route("changeProductStatus")]
        public IActionResult changeProductStatus(CompleteProductInfoDTO product)
        {

            if (_prService.SaveNewPrduct(product))
            {
                return StatusCode(201);
            }
            return StatusCode(500);
        }
    }
}