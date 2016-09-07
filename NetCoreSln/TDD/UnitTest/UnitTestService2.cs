using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using MockAndInject.Mock;
using MockAndInject.ViewModel; 
namespace MockAndInject
{
    [TestClass]
    public class UnitTestService2
    {
        Container container = new Container();
        public UnitTestService2()
        { 
            container.Register<IService, ServiceMock>(Lifestyle.Transient); 
        }

        [TestMethod]
        public void Test_getCurrentUser()
        {
            var service = container.GetInstance<IService>(); 
            var dto = service.getCurrentUser();
            Assert.IsNotNull(dto);
        }

        [TestMethod]
        public void Test_postValidateUserA()
        {
            var service = container.GetInstance<IService>();
            var dto = service.postValidateUser("123", "MoqAndNinject");
            Assert.AreEqual("123", dto.UserName);
        }

        [TestMethod]
        public void Test_postValidateUserB()
        {
            var service = container.GetInstance<IService>();
            var dto = service.postValidateUser("123", "123");
            Assert.AreEqual("DontTryToHackMe", dto.UserName);
        }
    }
}
