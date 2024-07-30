using FinanZen.Data.Entities;
using FinanZen.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UserEarningController : Controller
{
    private readonly IUserEarningRepository _userEarningRepository;

    public UserEarningController(IUserEarningRepository userEarningRepository)
    {
        _userEarningRepository = userEarningRepository;
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
    public IActionResult Create(UserEarning userEarning)
    {
        userEarning.UserId = 1;
        _userEarningRepository.AddAsync(userEarning);
        
        return RedirectToAction(nameof(Index));
    }
}