using Microsoft.AspNetCore.Mvc;
using Posts.DataContract.DTOs;
using Posts.Business.Services;
using Posts.DataContract.Interfaces;

namespace TestHttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly IGetAllUsers _userService;

        public GetUsersController(IGetAllUsers userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetUsers()
        {
            List<GetAllUsersDTO> userPosts = await _userService.GetUsers();

            return Ok(userPosts);
        }




        [HttpGet("GetUserById")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if(user == null)
            {
                throw new Exception();
            }
            return Ok(user);
            
        }
    }
}
