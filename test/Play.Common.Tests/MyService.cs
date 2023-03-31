using System;
using System.Threading.Tasks;
using Play.Common;

public class MyService
{
    private IRepository<TestEntity> @object;

    public MyService(IRepository<TestEntity> @object)
    {
        this.@object = @object;
    }
    public async Task<TestEntity> MyMethod(Guid id)
    {
        return await @object.GetAsync(id);
    }
}