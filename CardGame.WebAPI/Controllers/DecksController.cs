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

        [HttpPost]
        [Route("DeckCards")]
        public virtual async Task<IActionResult> Post([FromBody] DeckCards deckCards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DeckCards createdEntity = await _repository.Add(deckCards);
            if (createdEntity == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), deckCards);
        }

        [HttpPut]
        [Route("DeckCards/{deckId}/{cardId}")]
        public virtual async Task<IActionResult> Put([FromRoute] int deckId,
            [FromRoute] int cardId,
            [FromBody] DeckCards deckCards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (deckId != deckCards.DeckId || cardId != deckCards.CardId)
            {
                return BadRequest();
            }

            DeckCards updatedEntity = await _repository.Update(deckCards);
            if (updatedEntity == null)
            {
                return NotFound();
            }
            return Ok(updatedEntity);
        }
    }
}