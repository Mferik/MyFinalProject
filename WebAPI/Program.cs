using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolves.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Autofac,Ninject,Castwindsor,StructureMap,Lightinject,DryInject --> IoC Container
            builder.Services.AddControllers();
            // builder.Services.AddSingleton<IProductService,ProductManager>(); // E�er ilk tipte bir ba��ml�l�k g�sterirsen ikinci parametre kar��l���d�r. Arka planda bizim i�in new'liyor //T�m bellekte tek bir nesne �retiyor // ��inde data tutmuyorsan kullan�yorsun
            // builder.Services.AddSingleton<IProductDAL,EfProductDal>(); //ProductManager IProductDAL'a ba��ml� oldugu i�in onun i�in de bir bellekte yer a�t�k
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();
          
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}