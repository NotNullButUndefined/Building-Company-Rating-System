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
        public void LoginShouldReturnViewUserPageIfLoginIsSuccessful()
        {
            //arrange
            _mockUserService.Setup(s => s.TryLogin(It.IsAny<string>(),
                                                   It.IsAny<string>()))
                                                                       .Returns(true);

            //act
            var result = _accController.Login(_loginDto, "return url") as ViewResult;

            //assert    
            Assert.AreEqual("UserPage", result.ViewName);
        }

        [TestMethod]
        public void LoginShouldAddErrorToModelIfLoginIsNotSuccessful()
        {
            //arrange
            _mockUserService.Setup(s => s.TryLogin(It.IsAny<string>(),
                                                   It.IsAny<string>()))
                                                                       .Returns(false);

            //act
            var result = _accController.Login(_loginDto, "return url") as ViewResult;
            
            //assert    
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void LoginShouldReturnViewLoginAgainIfModelStateIsNotValid()
        {
            //arrange
            _accController.ModelState.AddModelError("error", "error");

            //act
            var result = _accController.Login(_loginDto, "return url") as ViewResult;

            //assert    
            Assert.AreEqual("", result.ViewName);
        }
    }
}
