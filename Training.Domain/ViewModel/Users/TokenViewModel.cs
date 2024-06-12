
namespace Training.Domain.ViewModel.Users
{
    public class TokenViewModel
    {
        #region Properties

        // Code which is for accessing into system
        public string Code { get; set; }

        // When should the token be expires.
        public double Expiration { get; set; }
        // Life time of the token
        public int LifeTime { get; set; }

        public BookViewModel UserProfile { get; set; }
        #endregion

        #region Constructors
        public TokenViewModel()
        {

        }

        public TokenViewModel(string code, double expiration, int lifeTime, BookViewModel userProfileViewModel)
        {
            Code = code;
            Expiration = expiration;
            LifeTime = lifeTime;
            UserProfile = userProfileViewModel;
        }

        #endregion
    }
}
