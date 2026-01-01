using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(AppDbContext _context, IMapper _mapper)
    {
        public async Task Handle(CreateProductCommand command)
        {
            var product = _mapper.Map<Product>(command);
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
