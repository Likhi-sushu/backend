using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;
using Happyhealth.Models;
using Happyhealth.Repository.RegisterUsersRepository;

namespace Happyhealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUsersController : ControllerBase
    {
        private readonly HappyHealthDbContext _context;
        private readonly ILogger<RegisterUsersController> _logger;
        private readonly IRegisterUsersRepository _registerUsersRepository;

        public RegisterUsersController(HappyHealthDbContext context, ILogger<RegisterUsersController> logger,
            IRegisterUsersRepository registerUsersRepository)
        {
            _context = context;
            _logger = logger;
            _registerUsersRepository = registerUsersRepository;
        }

        // GET: api/RegisterUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterUsers>>> Getusers()
        {
            //_logger.LogInformation("Getting all the users successfully.");
            //return await _context.users.ToListAsync();
            return await _registerUsersRepository.Getusers();
        }

        // GET: api/RegisterUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterUsers>> GetRegisterUser(int id)
        {
            //var registerUser = await _context.users.FindAsync(id);

            //if (registerUser == null)
            //{
            //    _logger.LogError("Sorry, no user found with this id " + id);
            //    return NotFound();
            //}

            //return registerUser;
            try
            {
                return await _registerUsersRepository.GetRegisterUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        // Authenticating user by their email and password
        // GET: api/RegisterUsers/sai123@gmail.com/sai123
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<RegisterUsers>> GetRegisterUserByPwd(string email, string password)
        {
            try
            {
                var authUser = await _registerUsersRepository.GetRegisterUserByPwd(email, password);
                if (authUser != null)
                {
                    // Return the user directly without encapsulating in another object
                    return Ok(authUser);
                }
                else
                {
                    return NotFound(new { Status = "Error", Message = "Invalid Credentials" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new { Status = "Error", Message = ex.Message });
            }
        }

        //[Route("Login")]
        //public ActionResult Login(string email, string pwd)//([FromBody] User user)

        //{
        //    Hashtable err = new Hashtable();

        //    try
        //    {
        //        var result = _context.users.Where(x => x.Email.Equals(email) && x.Password.Equals(pwd)).FirstOrDefault();
        //        if (result != null) return Ok(result);
        //        else

        //        {
        //            err.Add("Status", "Error");

        //            err.Add("Message", "Invalid Credentials");

        //            return Ok(err);

        //        }
        //    }

        //    catch (Exception)

        //    {
        //        throw;

        //    }

        //    return null;
        //}

        // PUT: api/RegisterUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterUser(int id, RegisterUsers registerUser)
        {
            //if (id != registerUser.UserId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(registerUser).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RegisterUserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //_logger.LogInformation("User updated successfully.");
            //return NoContent();

            if (id != registerUser.user_id)
            {
                return BadRequest();
            }

            _context.Entry(registerUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogInformation("User updated successfully.");
            return NoContent();
        }

        // POST: api/RegisterUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegisterUsers>> PostRegisterUser(RegisterUsers registerUser)
        {
            //_context.users.Add(registerUser);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation("User created successfully.");

            //return CreatedAtAction("GetRegisterUser", new { id = registerUser.UserId }, registerUser);
            await _registerUsersRepository.PostRegisterUser(registerUser);
            return CreatedAtAction("GetRegisterUser", new { id = registerUser.user_id }, registerUser);
        }

        // DELETE: api/RegisterUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegisterUsers>> DeleteRegisterUser(int id)
        {
            try
            {
                return await _registerUsersRepository.DeleteRegisterUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
        [HttpGet("checkDuplicateUser")]
        public IActionResult CheckDuplicateUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be empty.");
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return Ok(new { isDuplicate = true });
            }

            return Ok(new { isDuplicate = false });
        }

        private bool RegisterUserExists(int id)
        {
            return _registerUsersRepository.RegisterUserExists(id);
        }
    }
}