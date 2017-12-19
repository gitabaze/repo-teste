using System;
using System.Text;
using System.Collections.Generic;
using WebApiQUizz.Service;
using Models;
using WebApiQUizz.Controllers;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Net.Http;
using System.Linq;
using System.Data.Entity;
using System.Web.Script.Serialization;
using Xunit;
using Ploeh.AutoFixture;

namespace WebApiQUizz.Tests.Controllers
{
    /// <summary>
    /// Description résumée pour LangueControlleurTest
    /// </summary>
  //  [TestClass]
    public class LangueControlleurTest
    {
        private Moq.Mock<IGenericRepository<Langue>> _langueMock;
        private LanguesController _controller;

       // [TestInitialize]
       
        public void Initialise()
        {
            _langueMock = new Moq.Mock<IGenericRepository<Langue>>();
            _controller = new LanguesController(_langueMock.Object);
        }

      //  [TestMethod]
        [Fact]
        public void MethodsListeLangues()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
            _langueMock = new Moq.Mock<IGenericRepository<Langue>>();
            _controller = new LanguesController(_langueMock.Object);

            var langues = new List<Langue>() {
                new Langue { Id=1, Libelle="fransais", Sigle="fr" },
                 new Langue { Id=2, Libelle="anglais", Sigle="en" }
                }.AsQueryable();
            var mockrepository = new Moq.Mock<IGenericRepository<Langue>>();
            _langueMock.Setup(c => c.GetAll())
                .Returns(langues);

         //   var controller = new LanguesController(mockrepository.Object);
            var actionResult = _controller.GetLangue();
            //// Assert
         
            Assert.NotNull(actionResult);
            Assert.Equal(langues.ToList().Count, actionResult.ToList().Count);
        }

       // [TestMethod]
        [Fact]
        public void MethodeListeLanggueByID()
        {
            _langueMock = new Moq.Mock<IGenericRepository<Langue>>();
            _controller = new LanguesController(_langueMock.Object);
            var fixture = new Fixture();
           // fixture.Customize(new AutoMoqCustomization());
            // This tells AutoFixture to only generate ints between 1 and int.MaxValue.
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, int.MaxValue));

            var id = fixture.Create<int>();
            var attendu = new Langue { Id = 1, Libelle = "fransais", Sigle = "fr" };
           // var mockrepository = new Moq.Mock<IGenericRepository<Langue>>();
            _langueMock.Setup(api => api.GetByKey(1))
                .Returns(Task.FromResult(attendu));
            ////Act
            Task<IHttpActionResult> actionResult = _controller.GetLangue(1);
            actionResult.Wait();
            var contentResult = actionResult.Result as OkNegotiatedContentResult<Langue>;
            var result = contentResult.Content;
          
            //  Assert.IsNotNull(contentResult);
            //   Assert.AreEqual(1,contentResult.Id);
             Assert.Equal(attendu, result);
        }

        //public async Task DeleteNavMenuAsync_ReturnsOk()
        //{
        //    MyController = new MyController(_mockClient.Object);

        //    //TODO: This is always returning a 500, not sure why.
        //    IHttpActionResult actionResult = await MyController.DeleteNavMenuAsync(6);

        //    _mockClient.Verify(m => m.MyMethod(It.IsAny<int>()), Times.Once());
        //    Assert.IsNotNull(actionResult as OkResult);
        //}
        //[TestMethod]
        [Fact]
        public async Task Delete_returns_a_NotFound()
        {
            var attendu = new Langue { Id = 1, Libelle = "fransais", Sigle = "fr" };
            _langueMock
                .Setup(x => x.RemoveAsync(attendu))
                .Returns(Task.FromResult(0)); // This makes me *so* happy...
            IHttpActionResult result = await _controller.DeleteLangue(attendu.Id);
            var notFound = result as NotFoundResult;
           // Assert.IsNotNull(notFound);
            _langueMock.Verify(x => x.RemoveAsync(attendu));
        }

        //[TestMethod]
        [Fact]
        public async Task Delete_returns_an_Ok()
        {
            var attendu = new Langue { Id = 1, Libelle = "fransais", Sigle = "fr" };
            _langueMock
                .Setup(x => x.RemoveAsync(attendu))
                  .Returns(Task.FromResult(1)); // I'm still excited now!

            IHttpActionResult result = await _controller.DeleteLangue(attendu.Id);

            var ok = result as OkResult;
            //Assert.IsNotNull(ok);
            _langueMock.Verify(x => x.RemoveAsync(attendu));
        }
    }
}
