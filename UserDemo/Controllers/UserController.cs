using Microsoft.AspNetCore.Mvc;
using UserDemo.DAL;

namespace UserDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext dbContext;

        public UserController(MyDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var user = dbContext.UserDTO.ToList();
            if (user.Count == 0) return NotFound("No user found");
            else return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(UserDTO ud)
        {
            try
            {
                dbContext.Add(ud);
                dbContext.SaveChanges();
                return Ok("User saved");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult Put(UserDTO ud)
        {
            try
            {
                var user = dbContext.UserDTO.Find(ud.UserId);
                if (user != null)
                {
                    user.Name = ud.Name;
                    user.Address = ud.Address;
                    user.Age = ud.Age;
                    dbContext.Update(user);
                    dbContext.SaveChanges();
                    return Ok("User updated");
                }
                else
                {
                    return Ok("user not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int userID)
        {
            try
            {
                var user = dbContext.UserDTO.Find(userID);
                if (user != null)
                {
                    dbContext.Remove(user);
                    dbContext.SaveChanges();
                    return Ok("User deleted");
                }
                return Ok("User no exists");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}