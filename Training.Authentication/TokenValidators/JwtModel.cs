using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Training.Authentication.TokenValidators
{
    public class JwtModel
    {
        #region Properties
        /// <summary> Issuer of jwt.</summary>
        public string Issuer { get; set; }

        /// <summary> The sub claim indentifies the principal that is the subje ...</summary>
        public string Subject { get; set; }

        public string Audience { get; set; }

        public int LifeTime { get; set; }
        public string SecurityKey { get; set; }

        private SigningCredentials _signingCredentials;

        private SymmetricSecurityKey _symmetricSecurityKey;


        public SymmetricSecurityKey SigningKey
        {
            get
            {
                if (_symmetricSecurityKey == null)
                {
                    _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey));

                }
                return _symmetricSecurityKey;
            }
        }

        public SigningCredentials SigningCredentials
        {
            get
            {
                if (_signingCredentials == null)
                {
                    _signingCredentials = new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256);

                }
                return _signingCredentials;
            }
        }
        #endregion
    }
}
