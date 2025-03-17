﻿using Core.entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public ActionResult Get()
    {
        var users = _userService.GetList();
        return Ok(users);
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    // POST api/<UsersController>
    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        var newUser = _userService.Add(user);
        return Ok(newUser);
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] User user)
    {
        var updatedUser = _userService.Update(user);
        return Ok(updatedUser);
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok();
    }
}
