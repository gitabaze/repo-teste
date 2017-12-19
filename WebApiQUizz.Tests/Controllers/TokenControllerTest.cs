using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebApiQUizz.Controllers;
using System.Web.Mvc;

namespace WebApiQUizz.Tests.Controllers
{
    [TestClass]
    public class TokenControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestMethodGet()
        {
            TokenController controller = new TokenController();
            ViewResult result = controller.Get() as ViewResult;
            // Affirmer
            Assert.IsNotNull(result);
            var model = result.Model;
           // Assert.AreEqual("Home Page", result.ViewBag.Title);

        }
    }
}
