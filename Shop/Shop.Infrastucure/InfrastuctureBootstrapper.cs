using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repository;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastucture.Persistent.Ef.CategoryAgg;
using Shop.Infrastucture.Persistent.Ef.CommentAgg;
using Shop.Infrastucture.Persistent.Ef.OrderAgg;
using Shop.Infrastucture.Persistent.Ef.ProductAgg;
using Shop.Infrastucture.Persistent.Ef.RoleAgg;
using Shop.Infrastucture.Persistent.Ef.SellerAgg;
using Shop.Infrastucture.Persistent.Ef.SiteEntities.Repositories;
using Shop.Infrastucture.Persistent.Ef.UserAgg;
using Shop.Infrastucture.Persistent.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastucture.Persistent.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastucture
{
    public class InfrastuctureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();

           

            services.AddTransient(_ => new DapperContext(connectionString));

            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
