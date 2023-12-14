using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Data;
using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Backend.Controllers;



[ApiController]
[Route("api/user/")]
public class UsersController : Controller
{
    private readonly IUsersRepository _usersRepository;
    private IValidator<Users> _validator;
    private readonly IMapper _mapper;

    public UsersController(IUsersRepository usersRepository, IValidator<Users> validator, IMapper mapper)
    {
        _usersRepository=usersRepository;
        _validator = validator;
       _mapper=mapper;
    }

    [HttpGet("GetUsers")]
   /* public IActionResult GetUsers()
     {
         var users = _usersRepository.GetUsers;
         if (!ModelState.IsValid)
             return BadRequest(ModelState);
         return Ok(users);
     }*/

    [HttpGet("GetUser")]
    public IActionResult GetUser(int userID)
    {
        
        var user = _mapper.Map<UsersDto>(_usersRepository.GetUser(userID));
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(user);
    }

    /*[HttpPost("AddUser")]
    public ActionResult Create()
    {
        return View();
   */

}