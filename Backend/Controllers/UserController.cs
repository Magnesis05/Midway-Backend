using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Data;
using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repositories;
using Backend.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace Backend.Controllers;



[ApiController]
[Route("api/user/")]
public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;
    private IValidator<User> _validator;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository usersRepository, IValidator<User> validator, IMapper mapper)
    {
        _userRepository = usersRepository;
        _validator = validator;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult GetUsers()
    {
        var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(users);
    }
    
    [HttpGet("GetUser")]
    public IActionResult GetUser(int userID)
    {

        var user = _mapper.Map<UserDto>(_userRepository.GetUser(userID));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(user);
    }

    [HttpGet("{userId}/allergies")]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(400)]
    public IActionResult GetAllergieOfUser(int userId)
    {
        if (!_userRepository.UserExists(userId))
        {
            return NotFound();
        }

        var userAllergie = _mapper.Map<List<AllergiesDto>>(
            _userRepository.GetAllergieOfUser(userId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(userAllergie);
    }

    [HttpPost("CreateUser")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateUser([FromQuery] int allergieId, [FromBody] UserDto userCreate)
    {
        if (userCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        var userMap = _mapper.Map<User>(userCreate);
    
      
        if (!_userRepository.CreateUser(allergieId, userMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }
    [HttpPut("{userId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateUser(int userId, [FromQuery] int allergieId, [FromBody] UserDto updatedUser)
    {
        if (updatedUser == null)
            return BadRequest(ModelState);

        if (allergieId != updatedUser.Id)
            return BadRequest(ModelState);

        if (!_userRepository.UserExists(userId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var userMap = _mapper.Map<User>(updatedUser);

        if (!_userRepository.UpdateUser(allergieId, userMap))
        {
            ModelState.AddModelError("", "Something went wrong updating owner");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
    [HttpDelete("DeleteUserId")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteUser(int userId)
    {
        if (!_userRepository.UserExists(userId))
        {
            return NotFound();
        }
        var userToDelete = _userRepository.GetUser(userId);
        if (!_userRepository.DeleteUser(userToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting owner");
        }
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        

        return NoContent();
    }


}