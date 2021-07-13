using System;
using Xunit;
using Data;
//using FluentAssertions; 

namespace Data.Tests
{

    public class ProductTest
    {    
        [Fact]
        public void When_ProductIsInstantiated_Then_Check()
        {
            Product product = createProduct();
            /* 
            product.Id.Should().NotBe(Guid.Empty);
            product.Name.Should().NotBeNullOrEmpty();
            product.Description.Should().NotBeNullOrEmpty();
            product.Vat.Should().BeGreaterThan(0);
            product.Price.Should().BeGreaterThan(0);
            product.StartDate.Should().BeSameDateAs(DateTime.Now);
            product.EndDate.Should().BeSameDateAs(DateTime.Now.AddDays(100));
            */
            Assert.NotEqual(product.Id,Guid.Empty);
            Assert.NotNull(product.Name);
            Assert.NotEqual(product.Name,String.Empty);
            Assert.NotNull(product.Description);
            Assert.NotEqual(product.Description,String.Empty);
            Assert.True(product.Vat>0);
            Assert.True(product.Price>0);
            Assert.True(product.StartDate.Date==DateTime.Now.Date);
            Assert.True(product.EndDate.Date==DateTime.Now.AddDays(100).Date);
        }

        [Fact]
        public void When_ProductIsInstantiatedWithPrice10AndVat20_Then_ComputeVatShouldReturn2()
        {
            Product product = createProduct();

            var result = product.ComputeVat();

            //result.Should().Be(2);
            Assert.Equal(2,result);
        }

        [Fact]
        public void When_ProductIsInstantiatedWithEndDateGreaterThenStartDate_Then_IsValidShouldReturnTrue()
        {
            Product product = createProduct();

            var result = product.IsValid();

            //result.Should().Be(true);
            Assert.True(result);
        }

        [Fact]
        public void When_ProductIsInstantiatedWithEndDateSmallerThenStartDate_Then_IsValidShouldReturnFalse()
        {
            Product product = new Product("Biscuits", "Chocolate biscuits", DateTime.Now.AddDays(100),DateTime.Now, 10, 20);
            var result=product.IsValid();

            //result.Should().Be(false);
            Assert.False(result);
        }

        private Product createProduct()
        {
            return new Product("Biscuits", "Chocolate biscuits", DateTime.Now, DateTime.Now.AddDays(100), 10, 20);
        }
    }
}

