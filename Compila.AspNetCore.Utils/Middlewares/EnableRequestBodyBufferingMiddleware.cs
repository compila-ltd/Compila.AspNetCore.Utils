﻿using Microsoft.AspNetCore.Http;

namespace Compila.AspNetCore.Utils.Middlewares
{
	public class EnableRequestBodyBufferingMiddleware
	{
		private readonly RequestDelegate _next;

		public EnableRequestBodyBufferingMiddleware(RequestDelegate next) =>
		_next = next;

		public async Task InvokeAsync(HttpContext context)
		{
			context.Request.EnableBuffering();

			await _next(context);
		}
	}
}
