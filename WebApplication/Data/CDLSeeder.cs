using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.Entities;

namespace WebApplication.Data
{
    public class CDLSeeder
    {
        private readonly CDLContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public CDLSeeder(CDLContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("sebastianferrari@live.com");
            if (user == null)
            {
                user = new StoreUser
                {
                    FirstName = "Sebastian",
                    LastName = "Ferrari",
                    Email = "sebastianferrari@live.com",
                    UserName = "sebastianferrari@live.com"
                };

                var result = await _userManager.CreateAsync(user, "Password1!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create a new user in seeder");
                }
            }

            if (!_ctx.Licenses.Any())
            {
                // Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/lic.json");
                var json = File.ReadAllText(filepath);
                var licenses = JsonConvert.DeserializeObject<IEnumerable<CustomerDriverLicense>>(json);
                _ctx.Licenses.AddRange(licenses);
                _ctx.SaveChanges();
            }
        }
    }
}
