using AutoMapper;
using AutoMapper.QueryableExtensions;
using CardGame.Lib.Dto;
using CardGame.Lib.Models;
using CardGame.Lib.Services;
using CardGame.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class UserRepository : MappingRepository<User>
    {
        public UserRepository(CardGameContext cardGameContext, IMapper mapper) : base(cardGameContext, mapper)
        { 
        }

        public async Task<UserDto> GetDetailById(int id)
        {
            return _mapper.Map<UserDto>( await _cardGameContext.Set<User>()
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted));
        }

        public async Task<IEnumerable<UserDto>> ListAllDetail()
        {
            return await GetAll()
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> ValidatePassword(string email, string password)
        {
            var user = await GetAll().FirstOrDefaultAsync(u => u.Email == email);

            if (user is null) return false;

            return PasswordHasher.ComparePasswords(user.Password, password);
        }
    }
}
