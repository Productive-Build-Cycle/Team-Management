using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using TeamManagement.Application.OperationResult;

namespace Endpoint.Rest
{
    public static class ResultErrorCodeToHttpCode
    {
        public static IActionResult ToProblemDetails(this ControllerBase controller, Result result)
        {
            var (status, title) = result.Error!.Code switch
            {
                ResultErrorCodeType.ValidationError =>
                    (StatusCodes.Status400BadRequest, "Validation Error"),

                ResultErrorCodeType.NotFound =>
                    (StatusCodes.Status404NotFound, "Resource Not Found"),

                ResultErrorCodeType.Duplicate =>
                    (StatusCodes.Status409Conflict, "Duplicate Resource"),

                ResultErrorCodeType.AccessDenied =>
                    (StatusCodes.Status403Forbidden, "Access Denied"),

                ResultErrorCodeType.Unauthorized =>
                    (StatusCodes.Status401Unauthorized, "Unauthorized"),

                ResultErrorCodeType.DatabaseDidNotChange =>
                    (StatusCodes.Status409Conflict, "No Changes Applied"),

                ResultErrorCodeType.ExternalServiceError =>
                    (StatusCodes.Status502BadGateway, "External Service Error"),

                ResultErrorCodeType.DatabaseError =>
                    (StatusCodes.Status500InternalServerError, "Database Error"),

                _ =>
                    (StatusCodes.Status500InternalServerError, "Unexpected Error")
            };

            var problem = controller.ProblemDetailsFactory.CreateProblemDetails(
                controller.HttpContext,
                statusCode: status,
                title: title,
                detail: result.Error.Message
            );

            return new ObjectResult(problem)
            {
                StatusCode = status
            };
        }
    }
}
