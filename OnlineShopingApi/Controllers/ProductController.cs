using AutoMapper;
using BAL.Models;
using BLL.Interfaces;
using BLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopingApi.Exceptions;
using OnlineShopingApi.Models;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace OnlineShopingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUniteOfWork uniteOfWork,IMapper mapper)
        {
            _uniteOfWork=uniteOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var includeList = new List<string>()
            {
                "Category",
                "SubCategory"
            };
            var product = await _uniteOfWork.Products.GetAllAsync(includeList);
           
            var result = _mapper.Map<ICollection<APIProductDTo>>(product);
            var response = new APIResponse(result);
            return Ok(response);
        }
        [HttpGet]
        [Route("GetAll/{page}")]
        public async Task<IActionResult> GetAll(int page)
        {
            var  products = _uniteOfWork.Products.GetPage(page, 10)
                .OrderBy(p => p.LatinName);
            var result = _mapper.Map <ICollection<APIProductDTo>>(products);
            var response = new APIResponse(result);


            return Ok(response);
        }
    }
}
