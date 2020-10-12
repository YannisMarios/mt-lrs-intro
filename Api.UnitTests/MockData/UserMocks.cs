using Api.Models;
using System;
using System.Collections.Generic;

namespace Api.UnitTests.MockData
{
    public static class UserMocks
    {
        public static List<UserType> GetUserTypes()
        {
            return new List<UserType>()
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
        }

        public static List<UserTitle> GetUserTitles()
        {
            return new List<UserTitle>()
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
        }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    BirthDate = DateTime.Parse("1986-2-23"),
                    UserType = GetUserTypes()[0],
                    UserTitle = GetUserTitles()[0],
                    EmailAddress = "johndoe@example.com",
                    IsActive = true
                },
                new User
                {
                    Id = 2,
                    Name = "Maria",
                    Surname = "Santana",
                    BirthDate = DateTime.Parse("1972-7-3"),
                    UserType = GetUserTypes()[1],
                    UserTitle = GetUserTitles()[1],
                    EmailAddress = "mariasantana@example.com",
                    IsActive = true
                },
            };
        }
    }
}
