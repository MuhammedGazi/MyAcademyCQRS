using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(AppDbContext _context)
    {
        public async Task Handle(RemoveProductCommand command)
        {
            var product = await _context.Products.FindAsync(command.Id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
