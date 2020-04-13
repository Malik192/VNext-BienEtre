using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using VNext.BienEtreAuTravail.BLL.Interfaces;
using VNext.BienEtreAuTravail.DAL.Models.Database;
using VNext.BienEtreAuTravail.DAL.Models.DTO;

namespace VNext.BienEtreAuTravail.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
           
        }
        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            var employee = _userService.GetAllUsers();
            return MapEmp(employee);

        }

        [HttpGet("/api/Dep")]
        public IEnumerable<Departement> GetDepartment()
        {

          return _userService.GetDepartment();
        }

        // GET: api/UserController/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _userService.DisplayById(id);
        }

        // POST: api/UserController
        [HttpPost]
        public void Post([FromBody] Employee value)
        {

              _userService.AddUser(value);
        }
        [HttpPost("/api/Dep")]
        public void AddDepartment([FromBody] Departement value)
        {

            _userService.AddDepartment(value);
        }


        [HttpPost("/api/Auth")]
        [EnableCors]

        public void Authentification([FromBody] Employee value)
        {

            _userService.Authentification(value.Pseudo,value.Password);
        }
        
      

        [HttpPost("/api/Auths")]
      

        public async Task<ICollection<StringValues>> Authentication(Employee value)
        {
            if (!_userService.Authentification(value.Pseudo, value.Password))
            {
                return null;
            };
            var principal =_userService.GetPrincipal(value, Startup.CookieAuthScheme);
            await HttpContext.SignInAsync(Startup.CookieAuthScheme, principal);
            ICollection<StringValues> Cookie = HttpContext.Response.Headers.Values;
           

            return Cookie;

        }

        [HttpPost("/api/SignOut")]
        public async void SignOut()
        {
            await HttpContext.SignOutAsync(Startup.CookieAuthScheme);
            


        }

        // PUT: api/UserController/5
        [HttpPut("{id}")] 
        public IEnumerable<EmployeeDTO> Put([FromBody] Employee value)
        {
            var employee = _userService.UpdateUser(value);
            return MapEmp(employee);

        }

        // DELETE: api/UserController/5
        [HttpDelete("{id}")]
        public IEnumerable<EmployeeDTO> Delete(int id)
        {

            var employee = _userService.DeleteEmp(id);
            return MapEmp(employee);
        }
        public IEnumerable<EmployeeDTO> MapEmp(IEnumerable<Employee> emp)
        {
            return _mapper.Map<IEnumerable<EmployeeDTO>>(emp);
        }
    }
}
