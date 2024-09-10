using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DaniaSessionService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Environment.SetEnvironmentVariable("DANIATOKEN", "heElloooooooOoooooOoooooooooOoooooooooOooooooooooooooo????");
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("DANIATOKEN")!)),
                };
            });

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
