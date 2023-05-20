using AutoMapper;
using BAL.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping.DTOs;
/*using PagedList;
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
                subCategoryName=s.SubCategory.Name
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
