using FinanZen.Data.Contexts;
using FinanZen.Data.Entities;
using FinanZen.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinanZen.Test;

public class UnitTestUserEarningRepository
{
    private readonly DbContextOptions<ApplicationContext> _dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;

    [Fact]
    public async void AddUserEarning_ShouldAddEarning()
    {
        var context = new ApplicationContext(_dbContextOptions);
        var repository = new UserEarningRepository(context);
        var userEarning = new UserEarning
        {
            Amount = 100,
            DateTime = DateTime.Now,
            Reason = "Salary",
            UserId = 1
        };
        
        await repository.AddAsync(userEarning);
        var addedEarning = await context.UserEarnings.FirstOrDefaultAsync(e => e.Amount == 100);

        Assert.Equal(100, addedEarning.Amount);
    }

    [Fact]
    public async void UpdateUserEarning_ShouldUpdateEarning()
    { 
        var context = new ApplicationContext(_dbContextOptions);
        var repository = new UserEarningRepository(context);
        var userEarning = new UserEarning
        {
            Amount = 100,
            DateTime = DateTime.Now,
            Reason = "Salary",
            UserId = 1
        };
        await context.UserEarnings.AddAsync(userEarning);
        await context.SaveChangesAsync();
        
        userEarning.Amount = 200;
        await repository.UpdateAsync(userEarning, userEarning.Id);
        var updatedEarning = await context.UserEarnings.FindAsync(userEarning.Id);

        Assert.Equal(200, updatedEarning.Amount);
    }

    [Fact]
    public async void DeleteUserEarning_ShouldRemoveEarning()
    {
        var context = new ApplicationContext(_dbContextOptions);
        var repository = new UserEarningRepository(context);
        var userEarning = new UserEarning
        {
            Amount = 100,
            DateTime = DateTime.Now,
            Reason = "Salary",
            UserId = 1
        };
        
        await context.UserEarnings.AddAsync(userEarning);
        await context.SaveChangesAsync();
        await repository.DeleteAsync(userEarning);
        var deletedEarning = await context.UserEarnings.FindAsync(userEarning.Id);

        Assert.Null(deletedEarning);
    }

    [Fact]
    public async void GetUserEarningById_ShouldReturnEarning()
    {
        var context = new ApplicationContext(_dbContextOptions);
        var repository = new UserEarningRepository(context);
        var userEarning = new UserEarning
        {
            Amount = 100,
            DateTime = DateTime.Now,
            Reason = "Salary",
            UserId = 1
        };
       
        await context.UserEarnings.AddAsync(userEarning);
        await context.SaveChangesAsync();
        var fetchedEarning = await repository.GetByIdAsync(userEarning.Id);

        Assert.Equal(userEarning.Id, fetchedEarning.Id);
    }

    [Fact]
    public async void GetAllUserEarnings_ShouldReturnAllEarnings()
    {
        var context = new ApplicationContext(_dbContextOptions);
        var repository = new UserEarningRepository(context);
        var userEarnings = new List<UserEarning>
        {
            new UserEarning { Amount = 100, DateTime = DateTime.Now, Reason = "Salary", UserId = 1 },
            new UserEarning { Amount = 200, DateTime = DateTime.Now, Reason = "Bonus", UserId = 1 }
        };
        
        await context.UserEarnings.AddRangeAsync(userEarnings);
        await context.SaveChangesAsync();
        var allEarnings = await repository.GetAllAsync();

        Assert.Equal(2, allEarnings.Count);
    }
}