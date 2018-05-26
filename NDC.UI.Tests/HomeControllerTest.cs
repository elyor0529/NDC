using System.Security.Principal;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDC.Common.Enums;
using NDC.Common.ViewModels;
using NDC.UI.Controllers;
using NDC.UI.SoapServiceReference;

namespace NDC.UI.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private const string ROLE = "user";
        private const string USR = "elyor.blog@gmail.com";
        private HomeController _controller;
        private Mock<IPersonService> _soapMock;

        [TestInitialize]
        public void SetupTests()
        {

            // Arrange
            _soapMock = new Mock<IPersonService>(MockBehavior.Loose);
            _soapMock.Setup(service => service.Search(USR, It.IsAny<SearchModel>())).Returns(delegate
            {
                return 1;
            });

            _controller = new HomeController(_soapMock.Object);
            var controllerContext = new Mock<ControllerContext>();
            var principal = new Mock<IPrincipal>();
            principal.Setup(p => p.IsInRole(ROLE)).Returns(true);
            principal.SetupGet(x => x.Identity.Name).Returns(USR);
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            _controller.ControllerContext = controllerContext.Object;
            
        }

        [TestMethod]
        public void Index_Test()
        {
            // Act 
            var result = _controller.Index(new SearchModel
            {
                Gender = Gender.Male,
                Names = "John",
                MinWeight = 50,
                MaxWeight = 150,
                MinHeigth = 50,
                MaxHeigth = 200,
                MinAge = 5,
                MaxAge = 100,
                Nationality = "USA"
            }) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.Success);
        }
    }
}