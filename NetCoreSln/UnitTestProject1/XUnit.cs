using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTestProject
{
    public class XUnitTest
    {
        [Fact,Category("A")]
        public void TestA()
        {
            Assert.Equal("2", "2");
        }


        [Fact, Category("A")]
        public void TestB()
        {
            Assert.Equal("2", "2");
        }

        [Fact, Category("AQ")]
        public void TestC()
        {
            Assert.Equal("2", "2");
        }


        [Fact, Category("AQ")]
        public void TestV()
        {
            Assert.Equal("2", "2");
        }
    }


    /// <summary>
    /// Apply this attribute to your test method to specify a category.
    /// </summary>
    [TraitDiscoverer("CategoryDiscoverer", "TraitExtensibility")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class CategoryAttribute : Attribute, ITraitAttribute
    {
        public CategoryAttribute(string category) { }
    }


    /// <summary>
    /// This class discovers all of the tests and test classes that have
    /// applied the Category attribute
    /// </summary>
    public class CategoryDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        /// Gets the trait values from the Category attribute.
        /// </summary>
        /// <param name="traitAttribute">The trait attribute containing the trait values.</param>
        /// <returns>The trait values.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var ctorArgs = traitAttribute.GetConstructorArguments().ToList();
            yield return new KeyValuePair<string, string>("Category", ctorArgs[0].ToString());
        }
    }
}
