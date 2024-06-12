using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Training.Authentication.ActionFilters;
using Training.Authentication.TokenValidators;

namespace Training.Authentication.Handlers
{
    public interface IProfileService
    {
        #region Methods
        string GenerateJwt(Claim[] claims, JwtModel jwtConfiguration);

        T DecodeJwt<T>(string token);

        void BypassAuthorizationFilter(AuthorizationHandlerContext authorizationHandlerContext,
            IAuthorizationRequirement requirement, bool bAnonymousAccessAttributeCheck = false);
        #endregion
    }
    public class ProfileService : IProfileService
    {
        #region Methods
        public string GenerateJwt(Claim[] claims, JwtModel jwtConfiguration)
        {
            var systemTime = DateTime.Now;
            var expiration = systemTime.AddSeconds(jwtConfiguration.LifeTime);

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(jwtConfiguration.Issuer, jwtConfiguration.Audience, claims, systemTime,
                expiration, jwtConfiguration.SigningCredentials);

            // From specific information, write token.
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public T DecodeJwt<T>(string token)
        {
            return default(T);
        }

        public void BypassAuthorizationFilter(AuthorizationHandlerContext authorizationHandlerContext,
            IAuthorizationRequirement requirement, bool bAnonymousAccessAttributeCheck)
        {
            // Anonymous access attribute must be checked.
            if (bAnonymousAccessAttributeCheck)
            {
                // Cast AuthorizationHandlerContext to AuthorizationFilterContext.
                var authorizationFilterContext = (AuthorizationFilterContext)authorizationHandlerContext.Resource;

                // No allow anonymous attribute has been found.
                if (!authorizationFilterContext.Filters.Any(x => x is ByPassAuthorizationAttribute))
                    return;
            }

            // User doesn't have primary identity.
            if (authorizationHandlerContext.User.Identities.All(x => x.Name != "Anonymous"))
                authorizationHandlerContext.User.AddIdentity(new GenericIdentity("Anonymous"));
            authorizationHandlerContext.Succeed(requirement);
        }
        #endregion
    }
}
