using BusinessLogic.Abstraction;
using BusinessLogic.Implementation;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Abstraction;
using Repositories.Implemenation;

namespace BusinessLogic
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<TrainingDbContext>();
        }
    }
}
