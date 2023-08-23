using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PortalTechnicalChallenge.Application.ViewModels.User;
using PortalTechnicalChallenge.Domain.Entities;
using PortalTechnicalChallenge.Infra.Data.Context;
using PortalTechnicalChallenge.Infra.Data.Repositories;
using PortalTechnicalChallengeTest.Fakers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;
using System.Net.Sockets;
using PortalTechnicalChallenge.Domain.Interfaces;



namespace PortalTechnicalChallengeTest.Domain.Entities
{
    public class UserTest
    {

        [Fact]
        public void GetById_Returns_User()
        {
            //Setup DbContext and DbSet mock  
           
            var dbContext = new Mock<PortalTechnicalChallengeContext>();
            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.Setup(s => s.Find(It.IsAny<int>())).Returns(UserFaker.Create());
            dbContext.Setup(s => s.Set<User>()).Returns(dbSetMock.Object);

            //Execute method of SUT (UserRepository)  
            var userRepository = new UserRepository(dbContext.Object);
            var user = userRepository.GetById(1);

            //Assert  
            Assert.NotNull(user);
            Assert.IsAssignableFrom<User>(user);
        }


    }
}
