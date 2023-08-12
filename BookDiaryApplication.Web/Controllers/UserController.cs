using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserController(IRepository<User> userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
    {
      var users = await _userRepository.GetAllAsync();

      if (users == null)
      {
        return NotFound();
      }

      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserByIdAsync(int id)
    {
      if (id < 0)
      {
        return BadRequest();
      }

      var user = await _userRepository.GetByIdAsync(id);

      if (user == null)
      {
        return NotFound(id);
      }

      return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(UserDTO userInputModel)
    {
      if (userInputModel == null)
      {
        return BadRequest();
      }

      var user = _mapper.Map<User>(userInputModel);

      await _userRepository.InsertAsync(user);

      return Ok(user);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, UserDTO userInputModel)
    {
      if (!_userRepository.Exists(id))
      {
        return NotFound();
      }

      var user = _mapper.Map<User>(userInputModel);
      user.Id = id;

      await _userRepository.UpdateAsync(user);

      return Ok(user);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
      var user = await _userRepository.GetByIdAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      await _userRepository.DeleteAsync(user);

      return Ok(user);
    }
  }
}
