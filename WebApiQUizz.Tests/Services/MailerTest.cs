using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiQUizz.Service.Mail;
using Moq;

namespace WebApiQUizz.Tests.Services
{
    [TestClass]
    public class MailerTest
    {
        [TestMethod]
        public void TestMethodMailToSend()
        {
            var moqMail = new Moq.Mock<IMailClient>();
            moqMail.SetupProperty(client => client.Server, "chat.mail.com")
                .SetupProperty(client => client.Port, "80");
                moqMail.Setup(client=>client.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            IMailer mailer = new DefaultMailer() { From = "from@mail.com", To = "to@mail.com", Subject = "Using Moq", Body = "Moq is awesome" };

            //Use the mock object of MailClient instead of actual object
            var result = mailer.SendMail(moqMail.Object);

            //Verify that it return true
            Assert.IsTrue(result);

            // Verify that the MailClient's SendMail methods gets called exactly once when string is passed as parameters
            moqMail.Verify(client => client.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
