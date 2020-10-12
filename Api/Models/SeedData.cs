
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Database
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new LrsContext(serviceProvider.GetRequiredService<
                    DbContextOptions<LrsContext>>()))
            {
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                var userTypes = new List<UserType>()
                {
                    new UserType
                    {
                        Description = "Subscriber",
                        Code = "SB"
                    },
                    new UserType
                    {
                        Description = "Manager",
                        Code = "MN"
                    }
                };

                context.UserType.AddRange(userTypes);

                var userTitles = new List<UserTitle>()
                {
                    new UserTitle
                    {
                        Description = "Mr.",
                    },
                    new UserTitle
                    {
                        Description = "Mrs",

                    }
                };

                context.UserTitle.AddRange(userTitles);

                var users = new List<User>()
                {
                    new User
                    {
                        Name = "John",
                        Surname = "Doe",
                        BirthDate = DateTime.Parse("1986-2-23"),
                        UserType = userTypes[0],
                        UserTitle = userTitles[0],
                        EmailAddress = "johndoe@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Maria",
                        Surname = "Santana",
                        BirthDate = DateTime.Parse("1972-7-3"),
                        UserType = userTypes[1],
                        UserTitle = userTitles[1],
                        EmailAddress = "mariasantana@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Nick",
                        Surname = "The Greek",
                        BirthDate = DateTime.Parse("1974-8-2"),
                        UserType = userTypes[1],
                        UserTitle = userTitles[0],
                        EmailAddress = "nickthegreek@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Helen",
                        Surname = "Anderson",
                        BirthDate = DateTime.Parse("1967-9-8"),
                        UserType = userTypes[1],
                        UserTitle = userTitles[1],
                        EmailAddress = "helenanderson@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Bob",
                        Surname = "Olson",
                        BirthDate = DateTime.Parse("2004-3-3"),
                        UserType = userTypes[0],
                        UserTitle = userTitles[0],
                        EmailAddress = "bobolson@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Trisha",
                        Surname = "Reeves",
                        BirthDate = DateTime.Parse("2000-6-8"),
                        UserType = userTypes[1],
                        UserTitle = userTitles[1],
                        EmailAddress = "trishareeves@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Rachel",
                        Surname = "Smith",
                        BirthDate = DateTime.Parse("1987-2-5"),
                        UserType = userTypes[0],
                        UserTitle = userTitles[1],
                        EmailAddress = "rachelsmith@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Jim",
                        Surname = "Doherty",
                        BirthDate = DateTime.Parse("2002-7-9"),
                        UserType = userTypes[1],
                        UserTitle = userTitles[0],
                        EmailAddress = "jimdoherty@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Jack",
                        Surname = "Adams",
                        BirthDate = DateTime.Parse("1971-10-26"),
                        UserType = userTypes[0],
                        UserTitle = userTitles[0],
                        EmailAddress = "jackadams@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Matilda",
                        Surname = "Wellington",
                        BirthDate = DateTime.Parse("1979-4-22"),
                        UserType = userTypes[0],
                        UserTitle = userTitles[1],
                        EmailAddress = "matildawellington@example.com",
                        IsActive = true
                    },
                    new User
                    {
                        Name = "Diana",
                        Surname = "Lauren",
                        BirthDate = DateTime.Parse("1966-9-2"),
                        UserType = userTypes[0],
                        UserTitle = userTitles[1],
                        EmailAddress = "dianalauren@example.com",
                        IsActive = true
                    },
                };

                context.User.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
