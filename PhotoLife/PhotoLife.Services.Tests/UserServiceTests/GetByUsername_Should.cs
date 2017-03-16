﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PhotoLife.Data.Contracts;
using PhotoLife.Models;

namespace PhotoLife.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetByUsername_Should
    {
        [TestCase("branimiri")]
        [TestCase("not_branimiri")]
        public void _CallRepository_GetAll_Method(string username)
        {
            //Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);
                
            //Act
            userService.GetUserByUsername(username);

            //Assert            
            mockedRepository.Verify(r => r.GetAll(It.IsAny<Expression<Func<User,bool>>>()), Times.Once);
        }
    }
}
