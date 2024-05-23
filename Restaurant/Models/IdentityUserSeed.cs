using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Restaurant.Models
{
    public class IdentityUserSeed
    {
        private static readonly string[] userList = ["Admin", "Mutfak", "Garson", "Kasa"];
        private static readonly string[] emailList = ["Admin@gmail.com", "Mutfak@gmail.com",
            "Garson@gmail.com", "Kasa@gmail.com"];
        private static readonly string[] passwordList = ["123456789", "123456789", "123456789", "123456789"];

        public static async void IdentityTestUser(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<IdentityDataContext>();

            if (context.Database.GetAppliedMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var userRole = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

            var user = await userManager.FindByNameAsync("Admin");

            if (user == null)
            {
                for (int i = 0; i < userList.Length; i++)
                {
                    user = new AppUser
                    {
                        UserName = userList[i],
                        Email = emailList[i]

                    };

                    await userManager.CreateAsync(user, passwordList[i]);
                }
                await context.SaveChangesAsync();
            }

            var adminUser = await userManager.FindByNameAsync("Admin");

            if (adminUser != null)
            {
                // Admin kullanıcısı bulundu, Admin rolünü atama
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var Mutfak = await userManager.FindByNameAsync("Mutfak");
            if (Mutfak != null)
            {
                // Mutfak kullanıcısı bulundu, Mutfak rolünü atama
                await userManager.AddToRoleAsync(Mutfak, "Mutfak");
            }

            var Garson = await userManager.FindByNameAsync("Garson");
            if (Garson != null)
            {
                // Garson kullanıcısı bulundu, Garson rolünü atama
                await userManager.AddToRoleAsync(Garson, "Garson");
            }

            var Kasa = await userManager.FindByNameAsync("Kasa");
            if (Kasa != null)
            {
                // Kasa kullanıcısı bulundu, Kasa rolünü atama
                await userManager.AddToRoleAsync(Kasa, "Kasa");
            }

        }
    }
}
