
using Microsoft.EntityFrameworkCore;
using UintsOfWorkTest.Data;
using UintsOfWorkTest.Services;
using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddDbContext<AppDbContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

           // builder.Services.AddDbContextFactory<AppDbContext>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUnitOfWorkFactory,UnitOfWorkFactory>();
            builder.Services.AddScoped<OrderService>();

            builder.Services.AddControllers();
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

            // ESEGUE LA MIGRATION AUTOMATICA
            using (var scope = app.Services.CreateScope())
            {
                //var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //dbContext.Database.Migrate(); // ⚠️ esegue le migration se non ancora applicate

                var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
                using var dbContext = factory.CreateDbContext();
                dbContext.Database.Migrate();
            }



            app.MapControllers();

            app.Run();
        }
    }
}
