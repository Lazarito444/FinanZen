namespace FinanZen.Data.Entities;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public string ImagePath { get; set; }

    public DateTime BirthDate { get; set; }

    //Nav. Properties
    public ICollection<UserBill> UserBills { get; set; }
    
    public ICollection<UserEarning> UserEarnings { get; set; }
}