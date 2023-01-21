using Repository;

namespace UniversityProjectInWebAPI.Middlewares
{
    public class JWTTokenExpireCheck
    {
        private readonly RequestDelegate _next;

        public JWTTokenExpireCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            using (AcademyDbContext academy = new())
            {
                if (academy.ExpiredTokens.Any(t => t.Token == token))
                {
                    await context.Response.WriteAsync("توکن معتبر نیست");
                    return;
                }
            }

            await _next(context);
        }
    }
}
