using AutoMapper;
using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class MappingRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        protected readonly IMapper _mapper;

        public MappingRepository(CardGameContext cardGameContext, IMapper mapper) : base(cardGameContext)
        {
            _mapper = mapper;
        }
    }
}
