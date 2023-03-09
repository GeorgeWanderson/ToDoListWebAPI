using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListWebAPI.Models;

namespace ToDoListWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            return Ok();
        }


    }
}
