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
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();//���������� � ������ dbsettings.json
        }
        public void ConfigureServices(IServiceCollection services) //������ ��� ����������� ��������� �������/��������
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));//���������� _confString � ���������� ������� DefaultConnection
            services.AddTransient<IAllCars, CarRepository>();//������� AddTransien ���������� �������� � �����, ������� ��������� ���������
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();          
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();          
            services.AddScoped(sp => ShopCart.GetCart(sp));//������ ��������� ��������� ������� ��� ������� ���������� ������������
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
            app.UseStatusCodePages();//��������� ���������� ��������� � ������(�������� 404)
            app.UseStaticFiles();//��������� �������� �� ������������ �������(�������� � �.�.)
            app.UseSession();
            //app.UseMvcWithDefaultRoute();//���������� url �����������, ���� ���������� ���������� � ���. ����������� home
            app.UseMvc(routes =>//���������� ������ app.UseMvcWithDefaultRoute � �������������� ������� �� ���������
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
