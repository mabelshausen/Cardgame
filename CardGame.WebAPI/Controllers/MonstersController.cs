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
    public class MonstersController : BaseCrudController<Monster, MonsterRepository>
    {
        public MonstersController(MonsterRepository monsterRepository) : base(monsterRepository)
        {
        }
    }
}