using Bogus;
using PortalTechnicalChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallengeTest.Fakers
{
    public static class UserFaker
    {
        public static User Create()
        {
            return new Faker<User>()
                .CustomInstantiator(f => new User
                {
                    Id = 1,
                    Age = 25,
                    Name = "Samuel",
                    LastName = "Emidio",
                    CreatedAt = DateTime.Now,
                    Email = f.Internet.Email()
                });
        }
    }
}
