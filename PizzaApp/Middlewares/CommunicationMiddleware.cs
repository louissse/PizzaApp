﻿using Microsoft.AspNetCore.Http;
using PizzaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Middlewares
{
    public class CommunicationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public CommunicationMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Equals("/CheckEmailConfirmationStatus"))
            {
                await ProcessEmailConfirmation(context);
            }
            else
            {
                await _next?.Invoke(context);
            }

        }
        private async Task ProcessEmailConfirmation(HttpContext context)
        {
            var email = context.Request.Query["email"];
            var user = await _userService.GetUserByEmail(email);
            if (string.IsNullOrEmpty(email))
            {
                await context.Response.WriteAsync("BadRequest:Email is required");
            } else if ((await _userService.GetUserByEmail(email)).IsEmailConfirmed)
            {
                context.Request.HttpContext.Session.SetString("email", email);
                await context.Response.WriteAsync("OK");
            } else
            {
                await context.Response.WriteAsync("WaitingForEmailConfirmation");
                user.IsEmailConfirmed = true;
                _userService.UpdateUser(user).Wait();
            }
        }
    }
}
