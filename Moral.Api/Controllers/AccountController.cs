using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Moral.Api.Constants;
using Moral.Api.Dtos;
using Moral.Api.Entities;
using Moral.Api.Infrastructure;
using Moral.Api.Services;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Moral.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private UserManager Manager { get; set; }

        public AccountController(UserManager userManager)
        {
            Manager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]RegistrationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var user = new Account()
            {
                UserName = request.Email,
                Email = request.Email,
            };
            var result = await Manager.Create(user, request.Password);
            if (result.Succeeded) return Ok();
            AddIdentityErrorsToModelState(result);
            return BadRequest(ModelState);
        }

        [HttpPut("")]
        [Authorize]
        public async Task<ActionResult> Put(
            [FromBody]UpdateUserRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var userId = User.Claims.Single(x => x.Type.ToLower() == "userid").Value;
            var user = new Account()
            {
                Id = userId,
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
            };
            var result = await Manager.Update(user);
            if (result.Succeeded) return Ok();
            if (result.Errors != null &&
                result.Errors.Any(i => i.Code == UserManager.UserNotFound))
                return NotFound();
            AddIdentityErrorsToModelState(result);
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthToken>> Post([FromBody]LoginRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var token = await Manager.SignIn(request.Email, request.Password);
            if (token == null) return BadRequest();
            return Ok(token);
        }

        [HttpGet("ping")]
        [AllowAnonymous]
        public async Task<ActionResult> Ping()
        {
            return Content("Pong!");
        }

        private void AddIdentityErrorsToModelState(IdentityResult result)
        {
            if (result.Errors == null) return;
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
        }
    }
}