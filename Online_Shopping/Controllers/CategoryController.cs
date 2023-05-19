using AutoMapper;
using BAL.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Online_Shopping.DTOs;
using System.Security.AccessControl;

namespace Online_Shopping.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUniteOfWork uniteOfWork,IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;   
            _mapper = mapper;   
                
         }
        public async Task<IActionResult> Index()
        {
            var categories = await _uniteOfWork.Categories.GetAllAsync();
            var result = _mapper.Map<ICollection<CategoryDTo>>(categories);
            return View(result);
        }
        
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTo model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var category = _mapper.Map<Category>(model);
             await _uniteOfWork.Categories.CreateAsync(category);
             await   _uniteOfWork.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}
