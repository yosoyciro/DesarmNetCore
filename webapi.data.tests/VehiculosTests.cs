using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;
using System.Reflection.Metadata;
using webapi.api.tests.Doubles;
using webapi.core.Modelos;
using webapi.data.Repositorios;
using webapi.data.Repositorios.Implementaciones;

namespace webapi.data.tests
{
    public class VehiculosTests
    {
        [Fact]
        public async Task GetById_ReturnsValue()
        {
            // Arrange
            var data = new List<Vehiculos>
            {
                new Vehiculos { Id = 1 },
                new Vehiculos { Id = 2 },
                new Vehiculos { Id = 3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Vehiculos>>();
            mockSet.As<IDbAsyncEnumerable<Vehiculos>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Vehiculos>(data.GetEnumerator()));

            mockSet.As<IQueryable<Vehiculos>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Vehiculos>(data.Provider));

            mockSet.As<IQueryable<Vehiculos>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehiculos>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehiculos>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DesarmDatacenterContext>();
            mockContext.Setup(c => c.Vehiculos).Returns(mockSet.Object);

            // Act
            var repository = new VehiculosRepositorio(mockContext.Object);
            var vehiculo = await repository.GetById(1);

            // Assert
            Assert.Equal(1, vehiculo.Id);
        }
    }
}