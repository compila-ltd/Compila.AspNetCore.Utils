using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;

namespace Compila.AspNetCore.Utils.Middlewares
{
	public static class SecretToXApiKeyTransformerMiddleware
	{
		public static void ConfigureSecretToXApiKeyTransformer(this IApplicationBuilder app)
		{
			app.Use(async (_context, next) =>
			{
				if (_context.Request.Query.TryGetValue("secret", out var token))
				{
					if (!_context.Request.Headers.TryAdd("x-api-key", token))
						await _context.ForbidAsync();
				}
				await next.Invoke();
			});
		}
	}
}
