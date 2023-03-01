using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.mocks;
using WebShop.Data;
using WebShop.Data.Repository;
using WebShop.Data.Models;

namespace WebShop
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();//обращаемс€ к строке dbsettings.json
        }
        public void ConfigureServices(IServiceCollection services) //—лужит дл€ регистрации различных модулей/плагинов
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));//подключаем _confString и выт€гиваем строчку DefaultConnection
            services.AddTransient<IAllCars, CarRepository>();//команда AddTransien объедин€ет интерфес и класс, который реализует интерфейс
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();          
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();          
            services.AddScoped(sp => ShopCart.GetCart(sp));//сервис позвол€ет создавать корзину дл€ каждого отдельного пользовател€
            services.AddMvc();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.AddMemoryCache();
            services.AddSession();
        }


        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();//позвол€ет отображать страничку с кодами(например 404)
            app.UseStaticFiles();//позвол€ет работать со статическими файлами(картинки и т.д.)
            app.UseSession();
            //app.UseMvcWithDefaultRoute();//использует url поумолчанию, если отсутстует контроллер и вид. ќтобразитс€ home
            app.UseMvc(routes =>//самописный аналог app.UseMvcWithDefaultRoute с дополнительной ссылкой на категории
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

        }
    }
}
