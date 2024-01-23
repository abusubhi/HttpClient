using Microsoft.AspNetCore.Mvc;
using Posts.Business.Services;
using Posts.DataContract.DTOs;
using Posts.DataContract.Interfaces;

namespace TestHttpClient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IGetPosts _postService;
    public PostsController(IGetPosts postService)
    {
        _postService = postService;
    }

    [HttpGet("GetPostById")]
    public async Task<ActionResult> GetPostById(int id)
    {

        var post = await _postService.GetPostById(id);

        return Ok(post);
    }

    [HttpGet("GetPostsByUserId")]
    public async Task<ActionResult> GetUserPosts(int userId)
    {
        List<GetPostByUserIdDTO> userPosts = await _postService.GetPostsByUserId(userId);

        return Ok(userPosts);
    }
}
