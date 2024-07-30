using FinanZen.Data.Entities;
using FinanZen.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UserBillController : Controller
{
    private readonly IUserBillRepository _userBillRepository;

    public UserBillController(IUserBillRepository userBillRepository)
    {
        _userBillRepository = userBillRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UserBill userBill)
    {
        userBill.UserId = 1;
        _userBillRepository.AddAsync(userBill);
        
        return RedirectToAction(nameof(Index));
    }
}