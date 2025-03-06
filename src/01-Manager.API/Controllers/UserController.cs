using _02_Manager.Domain.Entities;
using _02_Manager.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace _1_Manager.API.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase{

        private readonly UserService _userService;
        private readonly IValidator<User> _userValidator;

        public UserController(UserService userService, IValidator<User> userValidator){
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpGet]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound();

            }
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            var validationResult = _userValidator.Validate(user);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }


            var createdUser = _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new {id = createdUser.Id}, createdUser );

        }
        [HttpPut]
        public ActionResult<User> UpdateUser(int id, User user) 
        {
            if (id != user.Id)
            return BadRequest();
            _userService.UpdateUser(user);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            _userService.RemoveUser(id);
            return NoContent();

        }




    }
}