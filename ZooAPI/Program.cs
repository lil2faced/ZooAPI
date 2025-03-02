
using ZooAPI.Automapper;
using ZooAPI.Middlewares;
using ZooAPI.Services;
using ZooAPI.Services.Interfaces;

namespace ZooAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddTransient<AnimalService>();
            
            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

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
