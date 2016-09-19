using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockAndInject.ViewModel;
using MockAndInject.Ninject; 

namespace MockAndInject
{
    //http://www.codeproject.com/Articles/1116189/Mock-Inject-your-Service-with-Moq-and-Ninject
    [TestClass]
    public class UnitTestServiceNinject
    {
        public UnitTestServiceNinject()
        {
            IocKernel.Initialize(new DIModule()); 
        }

        [TestMethod]
        public void Test_getCurrentUser()
        { 
            var service = IocKernel.Get<IService>();
            var dto=service.getCurrentUser();
            Assert.IsNotNull(dto);
        }

        [TestMethod]
        public void Test_postValidateUserA()
        {
            var service = IocKernel.Get<IService>();
            var dto =  service.postValidateUser("123", "MoqAndNinject");
            Assert.AreEqual("123", dto.UserName);
        }

        [TestMethod]
        public void Test_postValidateUserB()
        {
            var service = IocKernel.Get<IService>(); 
            var dto = service.postValidateUser("123", "123");
            Assert.AreEqual("DontTryToHackMe", dto.UserName); 
        }
    }
}
