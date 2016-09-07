using MockAndInject.Mock;
using MockAndInject.ViewModel;
using NUnit.Framework;
using SimpleInjector;
namespace UnitTestNunit
{
    [TestFixture]
    public class UnitTestService
    {
        Container container = new Container();
        public UnitTestService()
        {
            container.Register<IService, ServiceMock>(Lifestyle.Transient);
        }

        [Test]
        public void NunitTest_getCurrentUser()
        {
            var service = container.GetInstance<IService>();
            var dto = service.getCurrentUser();
            Assert.IsNotNull(dto);
        }

        [Test]
        public void NunitTest_postValidateUserA()
        {
            var service = container.GetInstance<IService>();
            var dto = service.postValidateUser("123", "MoqAndNinject");
            Assert.AreEqual("123", dto.UserName);
        }

        [Test]
        public void NunitTest_postValidateUserB()
        {
            var service = container.GetInstance<IService>();
            var dto = service.postValidateUser("123", "123");
            Assert.AreEqual("DontTryToHackMe", dto.UserName);
        }

    }
}
