using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RideAlongAPI;
using RideAlongAPI.Controllers;
using RideAlongAPI.Persistence;
using RideAlongAPI.Persistence.Repositories;
namespace RideAlongAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
        
        //[TestMethod]
        //public void DBContext()
        //{
        //    //Arrange
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    //Act
            

        //}
        //public void SharesController()
        //{
        //    //Arrange
        //    SharesController controller = new SharesController(new Share)
        //}
    }
}
