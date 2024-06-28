namespace FinanZen.Data.Entities;

public class UserEarning
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double Amount { get; set; }

    public DateTime DateTime { get; set; }
    
    public string? Reason { get; set; }
    
    //Nav. Properties
    public User User { get; set; }
}