using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly GetCategoriesQueryHandler _getCategoriesQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        public CategoryController(GetCategoriesQueryHandler getCategoriesQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getCategoriesQueryHandler = getCategoriesQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _getCategoriesQueryHandler.Handle();
            return View(categories);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
    }
}
