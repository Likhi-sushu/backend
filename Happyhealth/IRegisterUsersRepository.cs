using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Happyhealth.Repository.RegisterUsersRepository;
using Happyhealth.Models;

namespace Happyhealth.Repository.RegisterUsersRepository
{
    public interface IRegisterUsersRepository
    {
        Task<ActionResult<IEnumerable<RegisterUsers>>> Getusers();
        Task<ActionResult<RegisterUsers>> GetRegisterUser(int id);
        Task<ActionResult<RegisterUsers>> GetRegisterUserByPwd(string email, string password);
        Task<ActionResult<RegisterUsers>> PostRegisterUser(RegisterUsers registerUser);
        Task<ActionResult<RegisterUsers>> DeleteRegisterUser(int id);
        bool RegisterUserExists(int id);
    }
}