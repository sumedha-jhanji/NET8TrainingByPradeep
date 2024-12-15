using BusinessLogic.Abstraction;
using BusinessLogic.Implementation;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Abstraction;
using Repositories.Implemenation;

namespace BusinessLogic
{
    public static class ConfigureDependencies
    {
        //IConfiguration will fetch all the cofiguration files
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<ICategoryBL, CategoryBL>(provider =>
            {
                var catRepo = provider.GetRequiredService<CategoryRepository>();
                // var catRepo = provider.GetService<CategoryRepository>();
                return new CategoryBL(catRepo, "custom data");
            });
            services.AddScoped<TrainingDbContext>();
            services.AddDbContext<TrainingDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("conn") ?? "");
            });
        }
    }
}
