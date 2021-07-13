using System;
using Xunit;
using Data;
//using FluentAssertions;
namespace Data.Tests
{
  
    public class ArchitectTest
    {
        [Fact]
        public void When_ArchitectIsInstantiated_Then_Check()
        {
            Architect architect = createArchitect();
            /* 
            architect.Id.Should().NotBe(Guid.Empty);
            architect.FirstName.Should().NotBeNullOrEmpty();
            architect.LastName.Should().NotBeNullOrEmpty();
            architect.StartDate.Should().BeOnOrBefore(DateTime.Now);
            architect.EndDate.Should().BeOnOrAfter(DateTime.Now);
            architect.Salary.Should().BeGreaterThan(0);
            */
            Assert.NotEqual(architect.Id,Guid.Empty);
            Assert.NotNull(architect.FirstName);
            Assert.NotEqual(architect.FirstName,String.Empty);
            Assert.NotNull(architect.LastName);
            Assert.NotEqual(architect.LastName,String.Empty);
            Assert.True(architect.StartDate<DateTime.Now);
            Assert.True(architect.EndDate>DateTime.Now);
            Assert.True(architect.Salary>0);
        }

        [Fact]
        public void When_ArchitectIsInstantiatedWithFirstNameJohnAndLastNameDoe_Then_GetFullNameShouldReturnJohn_Doe()
        {
            Architect architect=createArchitect();

            var result = architect.GetFullName();

            //result.Should().Be("John Doe");
            Assert.Equal("John Doe",result);
        }

        [Fact]
        public void When_ArchitectIsInstantiatedWithStartDateSmallerThanNowAndEndDateGreaterThanNow_Then_IsActiveShouldReturnTrue()
        {
            Architect architect=createArchitect();

            var result = architect.IsActive();

            //result.Should().Be(true);
            Assert.True(result);
        }

        [Fact]
        public void When_ArchitectIsInstantiatedWithStartDateGreaterThanNowAndEndDateGreaterThanNow_Then_IsActiveShouldReturnFalse()
        {
            Architect architect=new Architect("John", "Doe", new DateTime(2020,04,01), new DateTime(2025,04,01), 25000,"classical");

            var result = architect.IsActive();

            //result.Should().Be(false);
            Assert.False(result);
        }

        [Fact]
        public void When_ArchitectIsInstantiatedWithStartDateSmallerThanNowAndEndDateSmallerThanNow_Then_IsActiveShouldReturnFalse()
        {
            Architect architect=new Architect("John", "Doe", new DateTime(2000,04,01), new DateTime(2000,05,01), 25000,"classical");

            var result = architect.IsActive();

            //result.Should().Be(false);
            Assert.False(result);
        }
        
        [Fact]
        public void When_ArchitectIsInstantiatedWithStartDateGreaterThanNowAndEndDateSmallerThanNow_Then_IsActiveShouldReturnFalse()
        {
            Architect architect=new Architect("John", "Doe", new DateTime(2020,04,01), new DateTime(2025,04,01), 25000,"classical");

            var result = architect.IsActive();

            //result.Should().Be(false);
            Assert.False(result);
        }
        
        public Architect createArchitect(){
            return new Architect("John", "Doe", new DateTime(2000,04,01), new DateTime(2025,04,01), 25000, "classical");
        }
    }
}
