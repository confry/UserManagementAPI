public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        if (!context.Request.Headers.TryGetValue("Authorization", out var token) || !IsValidToken(token.ToString()))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await _next(context);
    }

  
    private bool IsValidToken(string? token)
    {
        if (string.IsNullOrEmpty(token))
            return false;

       
        return token == "Bearer valid_token_example";
    }
}
