using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Projeto.Base.CrossCutting.Configuration.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto.Base.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected IMediator MediatorService { get; }

        protected BaseController(IMediator mediatorService)
        {
            MediatorService = mediatorService;

        }

        protected virtual async Task<IActionResult> GenerateResponseAsync(Func<Task> func, HttpStatusCode responseCode)
        {
            try
            {
                await func();

                return StatusCode((int)responseCode);
            }
            catch
            {
                throw;
            }
        }

        protected virtual async Task<IActionResult> GenerateResponseAsync<TDataObject>(Func<Task<TDataObject>> func)
        {
            return await GenerateResponseAsync(func, HttpStatusCode.OK);
        }

        protected virtual async Task<IActionResult> GenerateResponseAsync<TDataObject>(Func<Task<TDataObject>> func, HttpStatusCode responseCode)
        {
            try
            {
                var response = await func();

                return StatusCode((int)responseCode, new
                {
                    data = response

                });
            }
            catch (ValidationException validExcep)
            {
                return HandleValidationExceptionResult(validExcep);
            }
            catch (HttpRequestException ex)
            {
                return HandleHttpExceptionResult(ex);
            }
            catch(CosmosException ex)
            {
                return HandleCosmosExceptionResult(ex);
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }
        private IActionResult HandleCosmosExceptionResult(CosmosException ex)
        {
            var notifications = new List<string>();
            return StatusCode((int)ex.StatusCode, new { notifications = ex.Message });
        }

        private IActionResult HandleHttpExceptionResult(HttpRequestException ex)
        {
            var notifications = new List<string>();
            var statusCode = 500;

            if (ex.Message == HttpStatusCode.Unauthorized.GetDescription())
            {
                statusCode = (int)HttpStatusCode.Unauthorized;
                notifications.Add($"{HttpStatusCode.Unauthorized.GetDescription()} - usuário não autenticado.");
            }

            return StatusCode(statusCode, new { notifications });
        }

        private IActionResult HandleExceptionResult(Exception ex)
        {
            var notifications = new List<string>();
            notifications.Add("Ocorreu um erro Interno. Contate o administrador");
            var statusCode = 500;

            return StatusCode((int)statusCode, new { notifications });
        }

        private IActionResult HandleValidationExceptionResult(ValidationException e)
        {
            var statusCode = 400;

            return StatusCode((int)statusCode, new { notifications = e.Errors.Select(x => x.ErrorMessage) });
        }
    }
}