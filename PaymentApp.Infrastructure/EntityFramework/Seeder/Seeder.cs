using System.Threading.Tasks;
using PaymentApp.Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Hosting;

namespace PaymentApp.Infrastructure.EntityFramework.Seeder
{
    public class Seeder
    {
        private readonly DataContext context;
        private readonly IHostingEnvironment _hosting;

        public Seeder(DataContext ctx, IHostingEnvironment hosting)
        {
            context = ctx;
            _hosting = hosting;
        }

        public async Task SeedAsync()
        {
            context.Database.EnsureCreated();
        }
    }
}
