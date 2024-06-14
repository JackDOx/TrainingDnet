
namespace Training.Domain.ViewModel.Users
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<RoleViewModel> Roles {  get; set; }
        public string Gender { get; set; }
        public string National {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalId { get; set; }


    }

    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
