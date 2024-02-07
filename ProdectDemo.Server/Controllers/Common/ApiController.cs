using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductDemo.Server.Domain.Errors.Common;

namespace ProductDemo.Server.Controllers.Common;

[ApiController]
//[Authorize]
public class ApiController : ControllerBase
{

    public ApiController()
    {
    }


    protected IActionResult Problem(List<Error> errors)
    {

        HttpContext.Items["errors"] = errors;

        return errors.Count == 1 ? Problem(errors.First()) : ValidationProblem(errors);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = (int)error.Type switch
        {
            //ordered by code
            CustomErrorTypes.BadRequest => StatusCodes.Status400BadRequest,
            (int)ErrorType.Validation => StatusCodes.Status400BadRequest,
            (int)ErrorType.NotFound => StatusCodes.Status404NotFound,
            CustomErrorTypes.NotAcceptable => StatusCodes.Status406NotAcceptable,
            CustomErrorTypes.Timeout => StatusCodes.Status408RequestTimeout,
            (int)ErrorType.Conflict => StatusCodes.Status409Conflict,
            CustomErrorTypes.Gone => StatusCodes.Status410Gone,
            (int)ErrorType.Failure => StatusCodes.Status424FailedDependency,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            title: error.Description
        );
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        ModelStateDictionary modelStateDictionary = new();

        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description
            );
        }

        return ValidationProblem(modelStateDictionary);
    }
}

