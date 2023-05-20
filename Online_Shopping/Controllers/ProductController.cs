using AutoMapper;
using BAL.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping.DTOs;
/*
  I didn't get The Point Of Grouped The Product sith Category And Sub Category With Pagination 
  so i make the login in (product repo) 'if i understand right you want to know product in each category' but the question is if first 50 product have same category that 
  mean the others catgory will not dispear so , i would better know the business better to 
  make it clear 
*/
namespace Online_Shopping.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;

        }
        
        public async Task<IActionResult> Index()
        {
            var includesList = new List<string>()
            {
                "Category",
                "SubCategory"
            };
            ViewBag.listCount = _uniteOfWork.Products.GetCount();

            var products =  _uniteOfWork.Products.GetPage(0,10, includesList);
            
            var result = _mapper.Map<IEnumerable<ProductDTo>>(products);
            return View(result);
        }
        [HttpGet]
        public   IActionResult Pagination(int PageNumber,int PageSize)
        {
            var includesList = new List<string>()
            {
                "Category",
                "SubCategory"
            };
            var products =  _uniteOfWork.Products.GetPage(PageNumber, PageSize, "Category").Select(s=>new 
            {
                s.Id,
                s.LocalName,
                s.LatinName,
                s.Description,
                s.ImgeName,
                CategoryName=s.Category.Name,
                subCategoryName=s.SubCategory.Name,
                s.HasAvailableStock
            }
            );

            return Ok(products);
            
        }
       
        public  IActionResult Create()
        {

           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTo model)
        {
            if(!ModelState.IsValid)
                 return View(model);
           
            if(model.Imge != null)
            {
                model.ImgeName = Helpers.Helper.AddPhoto(model.Imge);
            }
           
            

            var product = _mapper.Map<Product>(model);
            await _uniteOfWork.Products.CreateAsync(product);
            await _uniteOfWork.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
