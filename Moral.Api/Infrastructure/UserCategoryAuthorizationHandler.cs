using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Moral.Api.Infrastructure
{
    //public class UserCategoryAuthorizationHandler :
    //    AuthorizationHandler<UserCategoryRequirement, VideoVM>
    //{
    //    private readonly UserManager<IdentityUser> _userManager;

    //    public UserCategoryAuthorizationHandler(UserManager<IdentityUser> userManager)
    //    {
    //        _userManager = userManager;
    //    }

    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
    //        UserCategoryRequirement requirement,
    //        VideoVM resource)
    //    {
    //        var loggedInUserTask = _userManager.GetUserAsync(context.User);

    //        loggedInUserTask.Wait();

    //        var userClaimsTask = _userManager.GetClaimsAsync(loggedInUserTask.Result);

    //        userClaimsTask.Wait();

    //        var userClaims = userClaimsTask.Result;

    //        if (userClaims.Any(c => c.Type == resource.Category.ToString()))
    //        {
    //            context.Succeed(requirement);
    //        }

    //        return Task.CompletedTask;
    //    }
    //}

    public class UserCategoryRequirement : IAuthorizationRequirement { }
}
