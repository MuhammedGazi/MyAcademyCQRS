using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(AppDbContext _context, IMapper _mapper)
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var product = await _context.Products.FindAsync(query.Id);
            return _mapper.Map<GetProductByIdQueryResult>(product);
        }
    }
}
