using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PolicyTest.Models;

namespace PolicyTest.Security
{
    public class MinimumAgeRequired : IAuthorizationRequirement
    {
        public int MinimumAge { get; }

        public MinimumAgeRequired(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }

    public class MinimumAgeRequiredHandler : AuthorizationHandler<MinimumAgeRequired>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MinimumAgeRequiredHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequired requirement)
        {
            var user = _userManager.GetUserAsync(context.User).Result;
            var userAge = (DateTime.Now - user.BirthDate).Days / 365;

            if (userAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
