using FinanZen.Data.Contexts;
using FinanZen.Data.Entities;
using FinanZen.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinanZen.Test;

public class UnitTestUserBillRepository
{
    [Fact]
    public void DeleteAsync_UserIsNull()
    {
        // Arrange
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserBillRepository(context);
        
        // Act
        UserBill userBill = null;
        
        // Asserts
        Assert.ThrowsAsync<ArgumentNullException>(() => repository.DeleteAsync(userBill));
    }
    
    [Fact]
    public void AddAsync_UserIsNull()
    {
        // Arrange
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserBillRepository(context);
        
        // Act
        UserBill userBill = null;
        
        // Asserts
        Assert.ThrowsAsync<ArgumentNullException>(() => repository.AddAsync(userBill));
    }
    
    [Fact]
    public void UpdateAsync_IdIsLessThanOrEqualToZero()
    {
        // Arrange
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserBillRepository(context);
        
        // Act
        UserBill userBill = new UserBill
        {
            Id = 0,
            Amount = 500,
            User = null,
            Reason = "TEST",
            DateTime = DateTime.Now,
            UserId = 1
        };
        
        // Asserts
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => repository.UpdateAsync(userBill, userBill.Id));
    }
    
    [Fact]
    public void UpdateAsync_UserIsNull()
    {
        // Arrange
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserBillRepository(context);
        
        // Act
        UserBill userBill = null;
        int id = 1;
        
        // Asserts
        Assert.ThrowsAsync<ArgumentNullException>(() => repository.UpdateAsync(userBill, id));
    }
    
    [Fact]
    public void GetById_IdIsLessThanOrEqualToZero()
    {
        // Arrange
        var context = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        var repository = new UserBillRepository(context);
        
        // Act
        int id = -5;
        
        // Asserts
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => repository.GetByIdAsync(id));
    }
}