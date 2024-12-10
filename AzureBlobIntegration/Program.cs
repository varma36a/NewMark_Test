
using AzureBlobIntegration.Services;

namespace AzureBlobIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                    builder.WithOrigins("http://localhost:5173") // Add your front-end URL here
                           .AllowAnyHeader()
                           .AllowAnyMethod());
            });
            // Register BlobService
            builder.Services.AddScoped<BlobService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowLocalhost"); // Apply the CORS policy

            app.MapControllers();

            app.Run();
        }
    }
}
