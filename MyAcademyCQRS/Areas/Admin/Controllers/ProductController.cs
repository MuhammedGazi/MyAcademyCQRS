using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(GetProductsQueryHandler _getProductsQueryHandler,
                                   GetCategoriesQueryHandler _getCategoriesQueryHandler,
                                   CreateProductCommandHandler _createProductCommandHandler,
                                   UpdateProductCommandHandler _updateProductCommandHandler,
                                   RemoveProductCommandHandler _removeProductCommandHandler,
                                   GetProductByIdQueryHandler _getProductByIdQueryHandler) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _getCategoriesQueryHandler.Handle();
            ViewBag.Categories = (from c in categories
                                  select new SelectListItem
                                  {
                                      Text = c.Name,
                                      Value = c.Id.ToString()
                                  }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var products = await _getProductsQueryHandler.Handle();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var product=await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            
            await _updateProductCommandHandler.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
