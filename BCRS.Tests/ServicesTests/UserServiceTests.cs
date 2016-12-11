using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Services;
using DAL.Repositories;
using Moq;
using DAL.Entities;

namespace BCRS.Tests.ServicesTests
{
    [TestClass]
    public class UserServiceTests
    {
        IUserService _userService;
        Mock<IUserRepository> _userRepo;
        User _user;

        public UserServiceTests()
        {
            _userRepo = new Mock<IUserRepository>();
            _userService = new UserService(_userRepo.Object);
            _user = new User { Id = 0, Name = "name", Email = "email", Password = "password", RoleId = 1, Surname = "surname" };
        }

       
        [TestMethod]
        public void TryLoginShouldReturnTrueIfUserWithSuchEmailAndPasswordExists()
        {
            //arrange
            _userRepo.Setup(u => u.GetByEmail(It.IsAny<string>(),
                                              It.IsAny<string>()))
                                                                  .Returns(_user);
            //act
            var result = _userService.TryLogin(_user.Email, _user.Password);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TryLoginShouldReturnFalseIfUserWithSuchEmailAndPasswordDoesNotExist()
        {
            //arrange
            User us = null;
            _userRepo.Setup(u => u.GetByEmail(It.IsAny<string>(),
                                              It.IsAny<string>()))
                                                                  .Returns(us);
            //act
            var result = _userService.TryLogin(_user.Email, _user.Password);

            //assert
            Assert.IsFalse(result);
        }
    }
}
