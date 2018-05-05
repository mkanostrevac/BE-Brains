using System.Collections.Generic;
using System.Data.Entity;

namespace Project.Models
{

    public class DataAccessContextInitializer : DropCreateDatabaseAlways<DataAccessContext>
    {
        protected override void Seed(DataAccessContext context)
        {
            IList<UserModel> users = new List<UserModel>();

            users.Add(new UserModel() { FirstName = "Boris", LastName = "Nedic", Username = "nedic", Password = "password", Email = "boris.nedic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Aleksandra", LastName = "Vukovic", Username = "vukovic", Password = "password", Email = "aleksandra.vukovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Svetlana", LastName = "Radovanovic", Username = "radovanovic", Password = "password", Email = "svetlana.radovanovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Nikola", LastName = "Brankovic", Username = "brankovic", Password = "password", Email = "nikola.brankovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Cedomir", LastName = "Ribic", Username = "ribic", Password = "password", Email = "cedomir.ribic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Dusko", LastName = "Kovac", Username = "kovac", Password = "password", Email = "dusko.kovac@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Milan", LastName = "Golubovic", Username = "golubovic", Password = "password", Email = "milan.golubovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Milan", LastName = "Ludoski", Username = "ludoski", Password = "password", Email = "milan.ludoski@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Milan", LastName = "Kablar", Username = "kablar", Password = "password", Email = "milan.kablar@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Nemanja", LastName = "Vujic", Username = "vujic", Password = "password", Email = "nemanja.vujic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Borislav", LastName = "Petrovic", Username = "petrovic", Password = "password", Email = "borislav.petrovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Vladimir", LastName = "Gvozdenovic", Username = "gvozdenovic", Password = "password", Email = "vladimir.gvozdenovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Vladimir", LastName = "Cavic", Username = "cavic", Password = "password", Email = "vladimir.cavic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Zlatko", LastName = "Spasojevic", Username = "spasojevic", Password = "password", Email = "zlatko.spasojevic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Zoran", LastName = "Tomic", Username = "tomic", Password = "password", Email = "zoran.tomic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });

            context.Users.AddRange(users);

            base.Seed(context);
        }
    }
}