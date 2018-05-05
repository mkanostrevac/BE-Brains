using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Project.Models
{

    public class DataAccessContextInitializer : DropCreateDatabaseAlways<DataAccessContext>
    {
        protected override void Seed(DataAccessContext context)
        {
            // SEED USERS
            IList<UserModel> users = new List<UserModel>();
            UserModel user1 = new UserModel() { FirstName = "Boris", LastName = "Nedic", Username = "nedic", Password = "password", Email = "boris.nedic@gmail.com", UserRole = UserRoles.ROLE_SELLER };
            users.Add(user1);
            UserModel user2 = new UserModel() { FirstName = "Aleksandra", LastName = "Vukovic", Username = "vukovic", Password = "password", Email = "aleksandra.vukovic@gmail.com", UserRole = UserRoles.ROLE_SELLER };
            users.Add(user2);
            users.Add(new UserModel() { FirstName = "Svetlana", LastName = "Radovanovic", Username = "radovanovic", Password = "password", Email = "svetlana.radovanovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Nikola", LastName = "Brankovic", Username = "brankovic", Password = "password", Email = "nikola.brankovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
            users.Add(new UserModel() { FirstName = "Cedomir", LastName = "Ribic", Username = "ribic", Password = "password", Email = "cedomir.ribic@gmail.com", UserRole = UserRoles.ROLE_SELLER });
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

            // SEED CATEGORIES
            IList<CategoryModel> categories = new List<CategoryModel>();
            CategoryModel category1 = new CategoryModel() { Name = "Frizider", Description = "Bela tehnika" };
            categories.Add(category1);
            CategoryModel category2 = new CategoryModel() { Name = "Sporet", Description = "Bela tehnika" };
            categories.Add(category2);
            context.Categories.AddRange(categories);
            base.Seed(context);

            // SEED OFFERS
            IList<OfferModel> offers = new List<OfferModel>();
            offers.Add(new OfferModel()
            {
                Name = "Ponuda 1",
                Description = "Ponuda 1",
                Created = new DateTime(2018, 5, 5),
                Expires = new DateTime(2018, 5, 10),
                RegularPrice = 4.34,
                ActionPrice = 4.12,
                ImagePath = "",
                AvailableOffers = 2,
                BoughtOffers = 10,
                Status = OfferStatuses.WAIT_FOR_APPROVING,
                Category = category1,
                User = user1
            });
            offers.Add(new OfferModel()
            {
                Name = "Ponuda 2",
                Description = "Ponuda 2",
                Created = new DateTime(2018, 5, 5),
                Expires = new DateTime(2018, 5, 20),
                RegularPrice = 5.34,
                ActionPrice = 3.12,
                ImagePath = "",
                AvailableOffers = 1,
                BoughtOffers = 4,
                Status = OfferStatuses.WAIT_FOR_APPROVING,
                Category = category1,
                User = user2
            });
            offers.Add(new OfferModel()
            {
                Name = "Ponuda 3",
                Description = "Ponuda 3",
                Created = new DateTime(2018, 5, 5),
                Expires = new DateTime(2018, 5, 30),
                RegularPrice = 10.34,
                ActionPrice = 5.12,
                ImagePath = "",
                AvailableOffers = 10,
                BoughtOffers = 6,
                Status = OfferStatuses.WAIT_FOR_APPROVING,
                Category = category2,
                User = user2
            });
            context.Offers.AddRange(offers);
            base.Seed(context);
        }
    }
}