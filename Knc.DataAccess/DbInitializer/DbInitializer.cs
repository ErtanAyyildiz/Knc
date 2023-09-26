using Knc.DataAccess.Database;
using Knc.Entity.Modals;

namespace Knc.DataAccess.DbInitializer
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.AdminUsers.Any()) return;

            var users = new AdminUser[]
            {
            new AdminUser{ Id = 1, UserName = "KncAdmin", Password="123456*-" }
            //add other users
            };

            foreach (var user in users)
                dbContext.AdminUsers.Add(user);

            dbContext.SaveChanges();
        }
    }
}
