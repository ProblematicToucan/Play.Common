using System;
using System.Threading.Tasks;
using Moq;
using Play.Common;
using Xunit;

public class MyServiceTests
{
    private readonly Mock<IRepository<TestEntity>> _mockRepository = new Mock<IRepository<TestEntity>>();

    [Fact]
    public async Task TestMyServiceMethod()
    {
        // Arrange
        var expectedEntity = new TestEntity { Id = Guid.NewGuid() };
        _mockRepository.Setup(r => r.GetAsync(expectedEntity.Id)).ReturnsAsync(expectedEntity);
        var myService = new MyService(_mockRepository.Object);

        // Act
        var result = await myService.MyMethod(expectedEntity.Id);

        // Assert
        Assert.Equal(expectedEntity, result);
    }
}
