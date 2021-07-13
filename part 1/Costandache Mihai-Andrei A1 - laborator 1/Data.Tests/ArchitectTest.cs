using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using FluentAssertions;
namespace Data.Tests
{
    [TestClass]
    public class ArchitectTest
    {
        [TestMethod]
        public void When_ArchitectIsInstantiated_Then_Check()
        {
            Architect architect = createArchitect();
            architect.Id.Should().NotBe(Guid.Empty);
            architect.FirstName.Should().NotBeNullOrEmpty();
            architect.LastName.Should().NotBeNullOrEmpty();
            architect.StartDate.Should().BeOnOrBefore(DateTime.Now);
            architect.EndDate.Should().BeOnOrAfter(DateTime.Now);
            architect.Salary.Should().BeGreaterThan(0);
            architect.Style.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void When_ArchitectIsInstantiatedWithFirstNameJohnAndLastNameDoe_Then_GetFullNameShouldReturnJohn_Doe()
        {
            Architect architect=createArchitect();

            var result = architect.GetFullName();

            result.Should().Be("John Doe");
        }

        [TestMethod]
        public void When_ArchitectIsInstantiatedWithStartDateSmallerThanNowAndEndDateGreaterThanNow_Then_IsActiveShouldReturnTrue()
        {
            Architect architect=createArchitect();

            var result = architect.IsActive();

            result.Should().Be(true);
        }

        [TestMethod]
        public void When_ArchitectIsInstantiatedWithStartDateGreaterThanNowAndEndDateGreaterThanNow_Then_IsActiveShouldReturnFalse()
        {
            Architect architect=new Architect("John", "Doe", new DateTime(2020,04,01), new DateTime(2025,04,01), 25000,"classical");

            var result = architect.IsActive();

            result.Should().Be(false);
        }

        [TestMethod]
        public void When_ArchitectIsInstantiatedWithStartDateSmallerThanNowAndEndDateSmallerThanNow_Then_IsActiveShouldReturnFalse()
        {
            Architect architect=new Architect("John", "Doe", new DateTime(2000,04,01), new DateTime(2000,05,01), 25000,"classical");

            var result = architect.IsActive();

            result.Should().Be(false);
        }
        
        [TestMethod]
        public void When_ArchitectIsInstantiatedWithStartDateGreaterThanNowAndEndDateSmallerThanNow_Then_IsActiveShouldReturnFalse()
        {
            Architect architect=new Architect("John", "Doe", new DateTime(2020,04,01), new DateTime(2025,04,01), 25000,"classical");

            var result = architect.IsActive();

            result.Should().Be(false);
        }

        public Architect createArchitect(){
            return new Architect("John", "Doe", new DateTime(2000,04,01), new DateTime(2025,04,01), 25000, "classical");
        }
    }
}
