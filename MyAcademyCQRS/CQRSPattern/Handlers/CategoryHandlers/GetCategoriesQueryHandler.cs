using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler
    {
        private readonly AppDbContext _context;

        public GetCategoriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoriesQueryResult>> Handle()
        {
            var category = await _context.Categories.ToListAsync();
            return category.Select(c => new GetCategoriesQueryResult
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
