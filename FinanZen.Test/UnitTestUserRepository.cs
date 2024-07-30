using FinanZen.Data.Contexts;
using FinanZen.Data.Entities;
using FinanZen.Data.Interfaces;
using FinanZen.Data.Repositories;
using FinanZen.Data.Repositories.Mocks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;

namespace FinanZen.Test;

public class UnitTestUserRepository
{
    [Fact]  
    public void DeleteAsync_UserIsNull()
    {
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserRepository(context);
        User user = null;
        
        Assert.ThrowsAsync<ArgumentNullException>(() => repository.DeleteAsync(user));
    }
    
    [Fact]
    public void AddAsync_UserIsNull()
    {
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserRepository(context);
        User user = null;
        
        Assert.ThrowsAsync<ArgumentNullException>(() => repository.AddAsync(user));
    }
    
    [Fact]
    public void UpdateAsync_IdIsLessThanOrEqualToZero()
    {
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserRepository(context);
        User user = new User
        {
            Id = 0,
            Password = "P@ssw0rd",
            BirthDate = DateTime.Now,
            FirstName = "Ariel",
            ImagePath = "test",
            LastName = "Lázaro",
            UserBills = null,
            UserEarnings = null
        };
        
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => repository.UpdateAsync(user, user.Id));
    }
    
    [Fact]
    public void UpdateAsync_UserIsNull()
    {
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserRepository(context);
        User user = null;
        int id = 1;

        Assert.ThrowsAsync<ArgumentNullException>(() => repository.UpdateAsync(user, id));
    }
    
    [Fact]
    public void GetById_IdIsLessThanOrEqualToZero()
    {
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserRepository(context);
        int id = -5;

        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => repository.GetByIdAsync(id));
    }
}