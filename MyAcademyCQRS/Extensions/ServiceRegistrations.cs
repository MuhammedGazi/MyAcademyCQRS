using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using System.Reflection;

namespace MyAcademyCQRS.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddCQRSHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetCategoriesQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();


            services.AddScoped<GetProductsQueryHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();
        }

        public static void AddPackageExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
