using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.EF;

namespace ReadWriteUnitTest.Data
{
    [TestClass]
    public class EFTestGetList
    {
        [TestMethod]
        public void EF_GetList()
        {
            var context = new EFContext();
            var result = context.WeiBos;
            Assert.IsNotNull(result);
            var count = 0;
            foreach (var item in result)
            {
                count++;
            }
            Assert.AreEqual(3, count);
            Assert.IsTrue(count > 0);
        }
    }
}
