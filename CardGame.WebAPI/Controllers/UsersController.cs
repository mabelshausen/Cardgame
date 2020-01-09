using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Lib.Models;
using CardGame.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseCrudController<User, UserRepository>
    {
        public UsersController(UserRepository repository) : base(repository)
        {
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await _repository.ListAllDetail());
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetDetailById(id));
        }

        [HttpGet("{email}, {password}")]
        public async Task<IActionResult> ValidatePassword(string email, string password)
        {
            return Ok(await _repository.ValidatePassword(email, password));
        }
    }
}