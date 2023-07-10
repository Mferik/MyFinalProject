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
            // builder.Services.AddSingleton<IProductService,ProductManager>(); // Eðer ilk tipte bir baðýmlýlýk gösterirsen ikinci parametre karþýlýðýdýr. Arka planda bizim için new'liyor //Tüm bellekte tek bir nesne üretiyor // Ýçinde data tutmuyorsan kullanýyorsun
            // builder.Services.AddSingleton<IProductDAL,EfProductDal>(); //ProductManager IProductDAL'a baðýmlý oldugu için onun için de bir bellekte yer açtýk
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