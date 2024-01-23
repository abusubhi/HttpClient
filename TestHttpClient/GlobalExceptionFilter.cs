using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Posts.DataContract.DTOs;
using TestHttpClient.Controllers;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    private readonly IMapper _mapper;

    public GlobalExceptionFilter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void OnException(ExceptionContext context)
    {
        // Your exception handling logic here

        // For example, mapping exceptions
        var mappedException = _mapper.Map<GetUserByIdDTO>(context.Exception);

        // Returning a custom response
        context.Result = new ObjectResult(mappedException)
        {
            StatusCode = 500, // Set your desired status code
            DeclaredType = typeof(GetUserByIdDTO)
        };
    }
}
