namespace CasaDoCodigo.API.Filters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(new
            {
                success = false,
                errors = context.ModelState.Values.SelectMany(v => v.Errors)
            });
        }
    }
}
