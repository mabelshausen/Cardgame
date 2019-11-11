using CardGame.Lib.Models;
using CardGame.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Controllers
{
    public class BaseCrudController<T, R> : ControllerBase 
        where T : BaseEntity 
        where R : BaseRepository<T>
    {
        protected R _repository;

        public BaseCrudController(R repository)
        {
            _repository = repository;
        }
    }
}
