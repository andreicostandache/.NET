using System;
using Xunit;
using Data;
//using FluentAssertions;

namespace Data.Tests
{
   
    public class ManagerTest
    {
        [Fact]
        public void When_ManagerIsInstantiated_Then_Check()
        {
            Manager manager = createManager();
            /* 
            manager.Id.Should().NotBe(Guid.Empty);
            manager.FirstName.Should().NotBeNullOrEmpty();
            manager.LastName.Should().NotBeNullOrEmpty();
            manager.StartDate.Should().BeOnOrBefore(DateTime.Now);
            manager.EndDate.Should().BeOnOrAfter(DateTime.Now);
            manager.Salary.Should().BeGreaterThan(0);
            */
            Assert.NotEqual(manager.Id,Guid.Empty);
            Assert.NotNull(manager.FirstName);
            Assert.NotEqual(manager.FirstName,String.Empty);
            Assert.NotNull(manager.LastName);
            Assert.NotEqual(manager.LastName,String.Empty);
            Assert.True(manager.StartDate<DateTime.Now);
            Assert.True(manager.EndDate>DateTime.Now);
            Assert.True(manager.Salary>0);
        }

        [Fact]
        public void When_ManagerIsInstantiatedWithFirstNameJohnAndLastNameDoe_Then_GetFullNameShouldReturnJohn_Doe()
        {
            Manager manager=createManager();

            var result = manager.GetFullName();

            //result.Should().Be("John Doe");
            Assert.Equal("John Doe",result);
        }

        [Fact]
        public void When_ManagerIsInstantiatedWithStartDateSmallerThanNowAndEndDateGreaterThanNow_Then_IsActiveShouldReturnTrue()
        {
            Manager manager=createManager();

            var result = manager.IsActive();

            //result.Should().Be(true);
            Assert.True(result);
        }

        [Fact]
        public void When_ManagerIsInstantiatedWithStartDateGreaterThanNowAndEndDateGreaterThanNow_Then_IsActiveShouldReturnFalse()
        {
            Manager manager=new Manager("John", "Doe", new DateTime(2020,04,01), new DateTime(2025,04,01), 25000,"HR");

            var result = manager.IsActive();

            //result.Should().Be(false);
            Assert.False(result);
        }

        [Fact]
        public void When_ManagerIsInstantiatedWithStartDateSmallerThanNowAndEndDateSmallerThanNow_Then_IsActiveShouldReturnFalse()
        {
            Manager manager=new Manager("John", "Doe", new DateTime(2000,04,01), new DateTime(2000,05,01), 25000,"HR");

            var result = manager.IsActive();

            //result.Should().Be(false);
            Assert.False(result);
        }
        
        [Fact]
        public void When_ManagerIsInstantiatedWithStartDateGreaterThanNowAndEndDateSmallerThanNow_Then_IsActiveShouldReturnFalse()
        {
            Manager manager=new Manager("John", "Doe", new DateTime(2020,04,01), new DateTime(2025,04,01), 25000,"HR");

            var result = manager.IsActive();

            //result.Should().Be(false);
            Assert.False(result);
        }

        public Manager createManager(){
            return new Manager("John", "Doe", new DateTime(2000,04,01), new DateTime(2025,04,01), 25000, "HR");
        }
    }
}
