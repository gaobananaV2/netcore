using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.EF;
using System.Linq;
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
            //var count = 0;
            //foreach (var item in result)
            //{
            //    count++;
            //}
            //Assert.AreEqual(3, count);
            //Assert.IsTrue(count > 0);
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [TestMethod]
        public void EF_linqTest()
        {
            var context = new EFContext();
            var result = context.WeiBos;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToList().Count > 0);

            var query1 = from d in context.WeiBos
                         orderby d.WeiBoId
                         select d;

            // lambda expressions to define the query
            var query2 = context.WeiBos.OrderBy(d => d.WeiBoId);
            //strongly typed, which gives you IntelliSense and compile-time checking
            //C# uses the lambda sign ( => ) to separate the left and right sides of the expression.


            Assert.IsTrue(query1.Count() == query2.Count());

        }
    }
}
