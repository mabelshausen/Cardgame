using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class EffectRepository : BaseRepository<Effect>
    {
        public EffectRepository(CardGameContext cardGameContext) : base(cardGameContext)
        {
        }
    }
}
