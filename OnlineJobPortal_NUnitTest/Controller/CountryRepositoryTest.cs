using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineJobPortal.Data;
using OnlineJobPortal.Models;
using OnlineJobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJobPortal_NUnitTest.Controller
{
    internal class CountryRepositoryTest
    {
        private Mock<DbSet<Country>> _mockCountrySet;
        private Mock<ApplicationDbContext> _mockContext;
        private CountryRepository _repository;
        [SetUp]
        public void Setup()
        {
            _mockCountrySet = new Mock<DbSet<Country>>();
            _mockContext = new Mock<ApplicationDbContext>();

            _mockContext.Setup(c => c.Countries).Returns(_mockCountrySet.Object);
            _repository = new CountryRepository(_mockContext.Object);
        }
        [Test]
        public async Task GetAllCountryAsync_ReturnsAllCountries()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { CountryID = 1, CountryName = "Country1" },
                new Country { CountryID = 2, CountryName = "Country2" }
            }.AsQueryable();

            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Act
            var result = await _repository.GetAllCountryAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Country1", result[0].CountryName);
        }
        [Test]
        public async Task GetCountryByIdAsync_ReturnsCountry()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { CountryID = 1, CountryName = "Country1" }
            }.AsQueryable();

            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockCountrySet.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Act
            var result = await _repository.GetCountryByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Country1", result.CountryName);
        }
        [Test]
        public async Task AddCountryAsync_AddsCountry()
        {
            // Arrange
            var country = new Country { CountryID = 1, CountryName = "Country1" };

            // Act
            var result = await _repository.AddCountryAsync(country);

            // Assert
            _mockContext.Verify(c => c.Countries.Add(It.IsAny<Country>()), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(1, result);
        }
        [Test]
        public async Task UpdateCountryByIDAsync_UpdatesCountry()
        {
            // Arrange
            var existingCountry = new Country { CountryID = 1, CountryName = "OldName" };
            _mockCountrySet.Setup(m => m.FindAsync(1)).ReturnsAsync(existingCountry);

            var updatedCountry = new Country { CountryID = 1, CountryName = "NewName" };

            // Act
            await _repository.UpdateCountryByIDAsync(1, updatedCountry);

            // Assert
            Assert.AreEqual("NewName", existingCountry.CountryName);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
        [Test]
        public async Task DeleteCountryByIDAsync_DeletesCountry()
        {
            // Arrange
            var country = new Country { CountryID = 1 };

            _mockCountrySet.Setup(m => m.FindAsync(1)).ReturnsAsync(country);

            // Act
            await _repository.DeleteCountryByIDAsync(1);

            // Assert
            _mockContext.Verify(c => c.Countries.Remove(It.IsAny<Country>()), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
