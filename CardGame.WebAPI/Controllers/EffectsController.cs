using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Lib.Models;
using CardGame.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardGame.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffectsController : BaseCrudController<Effect, EffectRepository>
    {
        public EffectsController(EffectRepository effectRepository) : base(effectRepository)
        {
        }

        [HttpGet]
        [Route("ByCardId/{id}")]
        public async Task<IActionResult> GetByCardId(int id)
        {
            return Ok(await _repository.GetAllByCardId(id).ToListAsync());
        }
    }
}