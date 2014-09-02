namespace Users
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            AddNewUserToAdmins("Pencho");
            AddNewUserToAdmins("Gencho");
        }

        private static void AddNewUserToAdmins(string username)
        {
            using (var db = new UsersEntities())
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (!db.Groups.Any(x => x.Name == "Admins"))
                        {
                            db.Groups.Add(new Group() { Name = "Admins" });
                            db.SaveChanges();
                        }
                        var adminsGroup = db.Groups.First(x => x.Name == "Admins");
                        adminsGroup.Users.Add(new User() { Name = username });
                        db.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        
                        tran.Rollback();
                    }
                    
                }
            }
        }
    }
}