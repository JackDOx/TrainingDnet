using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Training.Authentication.TokenValidators
{
    public class JwtBearerValidator : ISecurityTokenValidator
    {
        #region Methods

        // Wheter validator can read token or not.
        public bool CanReadToken(string securityToken)
        {

        return true; 
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            // Handler which is for handling security token
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            // Validate jwt
            var claimsPrincipal =
                jwtSecurityTokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);
            return claimsPrincipal;
        }

        #endregion

        #region Properties

        // Whether this validator can validate token or not.
        public bool CanValidateToken => true;

        // Maximum token size
        public int MaximumTokenSizeInBytes { get; set; }

        #endregion
    }
}
