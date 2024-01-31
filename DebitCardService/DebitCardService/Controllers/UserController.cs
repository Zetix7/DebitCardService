using DebitCardService.DataAccess;
using DebitCardService.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DebitCardService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();

    [HttpGet]
    [Route("{userId}")]
    public User? GetUserById(int userId) => _userRepository.GetById(userId);
}
