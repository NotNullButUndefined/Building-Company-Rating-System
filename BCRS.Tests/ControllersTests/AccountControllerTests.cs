using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BCRS.Controllers;
using Moq;
using DAL.Services;
using System.Web.Mvc;
using BCRS.Models;

namespace BCRS.Tests.ControllersTests
{

    [TestClass]
    public class AccountControllerTests
    {
        AccountController _accController;
        Mock<IUserService> _mockUserService;
        Mock<ICookie> _cookie;
        LoginDto _loginDto;

        public AccountControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _cookie = new Mock<ICookie>();
            _accController = new AccountController(_mockUserService.Object, _cookie.Object);
            _loginDto = new LoginDto { Email = "email", Password = "password" };
        }

        [TestMethod]
        public void LoginShouldReturnTrueIfLoginIsSuccessful()
        {
            //arrange
            _mockUserService.Setup(s => s.TryLogin(It.IsAny<string>(),
                                                   It.IsAny<string>()))
                                                                       .Returns(true);

            //act
            var result = _accController.Login(_loginDto);

            //assert    
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginShouldRetunrFalselIfLoginIsNotSuccessful()
        {
            //arrange
            _mockUserService.Setup(s => s.TryLogin(It.IsAny<string>(),
                                                   It.IsAny<string>()))
                                                                       .Returns(false);

            //act
            var result = _accController.Login(_loginDto);

            //assert    
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoginShouldReturnFalseIfModelStateIsNotValid()
        {
            //arrange
            _accController.ModelState.AddModelError("error", "error");

            //act
            var result = _accController.Login(_loginDto);

            //assert    
            Assert.IsFalse(result);
        }
    }
}
