using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiQUizz.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            IRecaptchaService service = new RecaptchaService();
            var de = service.ValidateInvOkeRecaptcha();
        }
    }
}
