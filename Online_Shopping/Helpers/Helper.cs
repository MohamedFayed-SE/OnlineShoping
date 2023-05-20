using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Online_Shopping.Helpers
{
    public static class Helper
    {

        public static string AddPhoto(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imges");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = file.FileName + fileInfo.Extension;
           

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        public static async Task<IdentityRole> SeedAdminRoleWithClaimsAsync(RoleManager<IdentityRole> roleManager)
        {
            var adminRole = new IdentityRole("Admin");
            var created = await roleManager.CreateAsync(adminRole);
            var AdminClaims = new List<Claim>()
            {
                new Claim("Admin","Add"),
                new Claim("Admin","Edit"),
                new Claim("Admin","Delete"),
                new Claim("Admin","View")
            };

            if (created.Succeeded)

            {
                foreach (var Calim in AdminClaims)
                {
                    await roleManager.AddClaimAsync(adminRole, Calim);
                }
            }


            return adminRole;

        }

        public static async Task AddDefaultUserAdmin(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
                return;
            var defaultUser = new IdentityUser() { UserName = userName };
          

            var Created = await userManager.CreateAsync(defaultUser, password);
             if(Created.Succeeded)
            {
               await SeedAdminRoleWithClaimsAsync(roleManager);
              await  userManager.AddToRoleAsync(defaultUser, "Admin");
            }




        }

    }
}
