using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

using Happyhealth.Repository.RegisterUsersRepository;
using Happyhealth.Models;

namespace Happyhealth
{
    public class RegisterUsersRepository : IRegisterUsersRepository
    {
        private readonly HappyHealthDbContext _context;
        private readonly ILogger<RegisterUsersRepository> _logger;

        public RegisterUsersRepository(HappyHealthDbContext context, ILogger<RegisterUsersRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<RegisterUsers>>> Getusers()
        {
            _logger.LogInformation("Getting all the users successfully.");
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<RegisterUsers>> GetRegisterUser(int id)
        {
            var registerUser = await _context.Users.FindAsync(id);
            if (registerUser == null)
            {
                throw new NullReferenceException("Sorry, no user found with this id " + id);
            }
            else
            {
                return registerUser;
            }
        }

        public async Task<ActionResult<RegisterUsers>> GetRegisterUserByPwd(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (user == null)
            {
                throw new NullReferenceException("Sorry, no user found with this credentials.");
            }
            else
            {
                return user;
            }
        }

        public async Task<ActionResult<RegisterUsers>> PostRegisterUser(RegisterUsers registerUser)
        {
            _context.Users.Add(registerUser);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User created successfully.");

            return registerUser;
        }

        public async Task<ActionResult<RegisterUsers>> DeleteRegisterUser(int id)
        {
            var registerUser = await _context.Users.FindAsync(id);

            if (registerUser == null)
            {
                throw new NullReferenceException("Sorry, no user found with this id " + id);
            }
            else
            {
                _context.Users.Remove(registerUser);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User deleted successfully.");

                return registerUser;
            }
        }

        public bool RegisterUserExists(int id)
        {
            return _context.Users.Any(e => e.user_id == id);
        }
    }
}

//        internal static Task LoginAsync(string email, string password)
//        {
//            throw new NotImplementedException();
//        }

//        Task<ActionResult<IEnumerable<RegisterUsers>>> IRegisterUsersRepository.Getusers()
//        {
//            throw new NotImplementedException();
//        }

//        Task<ActionResult<RegisterUsers>> IRegisterUsersRepository.GetRegisterUser(int id)
//        {
//            throw new NotImplementedException();
//        }

//        Task<ActionResult<RegisterUsers>> IRegisterUsersRepository.GetRegisterUserByPwd(string email, string password)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<RegisterUsers>> PostRegisterUsers(RegisterUsers registerUser)
//        {
//            throw new NotImplementedException();
//        }

//        Task<ActionResult<RegisterUsers>> IRegisterUsersRepository.DeleteRegisterUser(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}