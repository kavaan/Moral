using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moral.Api.Context;
using Moral.Api.Entities;

namespace Moral.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MoralContext _context;

        public ManageController( MoralContext context, 
            RoleManager<IdentityRole> roleManager,
            UserManager<Account> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Users()
        {
            return Ok(_context.Users);
        }
    }
}