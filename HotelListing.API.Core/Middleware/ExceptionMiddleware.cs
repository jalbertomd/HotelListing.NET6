﻿using HotelListing.API.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace HotelListing.API.Core.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext contex)
        {
            try
            {
                await _next(contex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred in {contex.Request.Path}");
                await HandleExceptionAsync(contex, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext contex, Exception ex)
        {
            contex.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails
            {
                ErrorType = "Failure",
                ErrorMessage = ex.Message
            };

            switch(ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not Found";
                    break;
            }

            string response = JsonConvert.SerializeObject(errorDetails);
            contex.Response.StatusCode = (int)statusCode;
            return contex.Response.WriteAsync(response);
        }
    }

    public class ErrorDetails
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
