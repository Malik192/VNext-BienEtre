﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNext.BienEtreAuTravail.BLL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;

namespace VNext.BienEtreAuTravail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }

        // GET: api/UserController
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET: api/UserController/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<Employee> Get(int id)
        {
            return _userService.DisplayById(id);
        }

        // POST: api/UserController
        [HttpPost]
        public void Post([FromBody] Employee value)
        {

            _userService.AddUser(value);
        }

       
        [HttpPost("/api/Auth")]
        [EnableCors]

        public void Authentification([FromBody] Employee value)
        {

            _userService.Authentification(value.Pseudo,value.Password);
        }
        
      

        [HttpPost("/api/Auths")]
      

        public async Task<string> Authentication(Employee value)
        {
            if (!_userService.Authentification(value.Pseudo, value.Password))
            {
                return "Login failed";
            };
            var principal =_userService.GetPrincipal(value, Startup.CookieAuthScheme);
            await HttpContext.SignInAsync(Startup.CookieAuthScheme, principal);
            Console.WriteLine(Startup.CookieAuthScheme);
            return this.User?.Identity.Name;

        }
       

        // PUT: api/UserController/5
        [HttpPut("{id}")] 
        public void Put([FromBody] Employee value)
        {
           
            _userService.UpdateUser(value);
        }

        // DELETE: api/UserController/5
        [HttpDelete("{id}")]
        public IEnumerable<Employee> Delete(int id)
        {
           
           return _userService.DeleteEmp(id);
        }
    }
}
