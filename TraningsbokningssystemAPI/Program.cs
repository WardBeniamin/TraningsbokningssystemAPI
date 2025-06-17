using TraningsbokningssystemAPI.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TraningsbokningssystemAPI.Data;
using TraningsbokningssystemAPI.Services;

namespace TraningsbokningssystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🛠️ EF Core med koppling till SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 📦 Lägg till controllers + FluentValidation
            builder.Services.AddControllers()
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<Program>());
            builder.Services.AddHttpClient<IVäderService, VäderService>();

            // 📘 Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 🧪 Swagger i utvecklingsläge
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            using (var scope = app.Services.CreateScope())

            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                SeedData.Init(context);
            }


            app.Run();
        }
    }
}
