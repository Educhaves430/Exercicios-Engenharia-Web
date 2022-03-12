using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Aula09.Data
{
    public class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any() == false)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("Client")).Wait();
            }
        }
    }
}
