using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Play.Common;
using Xunit;

public class MongoRepositoryTests
{
    private readonly Mock<IRepository<TestEntity>> _mockRepository = new Mock<IRepository<TestEntity>>();

    [Fact]
    public async Task TestGetAllAsync()
    {
        // Arrange
        var expectedEntities = new List<TestEntity>
        {
            new TestEntity { Id = Guid.NewGuid() },
            new TestEntity { Id = Guid.NewGuid() },
            new TestEntity { Id = Guid.NewGuid() }
        };
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedEntities);

        // Act
        var result = await _mockRepository.Object.GetAllAsync();

        // Assert
        Assert.Equal(expectedEntities.Count, result.Count());
        Assert.Equal(expectedEntities, result);
    }

    [Fact]
    public async Task TestGetAsync()
    {
        // Arrange
        var expectedEntities = new TestEntity { Id = Guid.NewGuid() };
        _mockRepository.Setup(r => r.GetAsync(expectedEntities.Id)).ReturnsAsync(expectedEntities);

        // Act
        var result = await _mockRepository.Object.GetAsync(expectedEntities.Id);

        // Assert
        Assert.Equal(expectedEntities.Id.GetType(), result.Id.GetType());
        Assert.Equal(expectedEntities, result);
    }
}
