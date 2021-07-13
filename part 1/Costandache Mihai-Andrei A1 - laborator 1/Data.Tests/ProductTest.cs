using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using FluentAssertions; 

namespace Data.Tests
{
    [TestClass]
    public class ProductTest
    {    
        [TestMethod]
        public void When_ProductIsInstantiated_Then_Check()
        {
            Product product = createProduct();
            product.Id.Should().NotBe(Guid.Empty);
            product.Name.Should().NotBeNullOrEmpty();
            product.Description.Should().NotBeNullOrEmpty();
            product.Vat.Should().BeGreaterThan(0);
            product.Price.Should().BeGreaterThan(0);
            product.StartDate.Should().BeSameDateAs(DateTime.Now);
            product.EndDate.Should().BeSameDateAs(DateTime.Now.AddDays(100));
        }

        [TestMethod]
        public void When_ProductIsInstantiatedWithPrice10AndVat20_Then_ComputeVatShouldReturn2()
        {
            Product product = createProduct();

            var result = product.ComputeVat();

            result.Should().Be(2);
        }

        [TestMethod]
        public void When_ProductIsInstanciatedWithEndDateGreaterThenStartDate_Then_IsValidShouldReturnTrue()
        {
            Product product = createProduct();

            var result = product.IsValid();

            result.Should().Be(true);
        }

        [TestMethod]
        public void When_ProductIsInstanciatedWithEndDateSmallerThenStartDate_Then_IsValidShouldReturnFalse()
        {
            Product product = new Product("Biscuits", "Chocolate biscuits", DateTime.Now.AddDays(100),DateTime.Now, 10, 20);
            var result=product.IsValid();

            result.Should().Be(false);
        }

        private Product createProduct()
        {
            return new Product("Chocolate", "Chocolate Biscuits", DateTime.Now, DateTime.Now.AddDays(100), 10, 20);
        }
    }
}

