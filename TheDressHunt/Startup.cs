using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TheDressHunt.Models;

[assembly: OwinStartupAttribute(typeof(TheDressHunt.Startup))]
namespace TheDressHunt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // I am creating admin Role and creating default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                //admin role create
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //creating admin super user to maintain site
                var user = new ApplicationUser();
                user.UserName = "black45";
                user.Email = "bFrost@gmail.com";


                string userPWD = "Nov1150@317";
                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

            }

            //if (!roleManager.RoleExists("Tester"))
            //{
            //    //admin role create
            //    var role = new IdentityRole();
            //    role.Name = "Tester";
            //    roleManager.Create(role);

            //    //creating admin super user to maintain site
            //    var user = new ApplicationUser();
            //    user.UserName = "black224125";
            //    user.Email = "bFrost2221@gmail.com";


            //    string userPWD = "Nov1150@317";
            //    var chkUser = UserManager.Create(user, userPWD);
            //    bool item = chkUser.Succeeded;
            //    if (chkUser.Succeeded)
            //    {
            //        
            //        var result1 = UserManager.AddToRole(user.Id, "Tester");
            //    }

            //}
            //creating manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //create user
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }
    }
}
