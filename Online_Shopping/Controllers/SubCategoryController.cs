using AutoMapper;
using BAL.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping.DTOs;
using System.Linq.Expressions;

namespace Online_Shopping.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public SubCategoryController(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var subCategories = await _uniteOfWork.SubCategories.GetAllAsync("Category");
            var result = _mapper.Map<ICollection<SubCategoryDTo>>(subCategories);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(byte categoryId)
        {
            Expression<Func<SubCategory,bool>> expression= sc=>sc.CategoryId==categoryId;
            var result =  _uniteOfWork.SubCategories.Filter(expression);

            return Ok(result);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryDTo model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var subCategory = _mapper.Map<SubCategory>(model);
            await _uniteOfWork.SubCategories.CreateAsync(subCategory);
            await _uniteOfWork.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
