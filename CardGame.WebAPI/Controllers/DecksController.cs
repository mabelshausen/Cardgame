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
    public class DecksController : BaseCrudController<Deck, DeckRepository>
    {
        public DecksController(DeckRepository deckRepository) : base(deckRepository)
        {
        }

        [HttpGet]
        [Route("ByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            return Ok(await _repository.GetAllByUserId(id).ToListAsync());
        }

        [HttpGet]
        [Route("WithCards/{id}")]
        public async Task<IActionResult> GetWithCards(int id)
        {
            return Ok(await _repository.GetByIdWithCards(id));
        }
    }
}