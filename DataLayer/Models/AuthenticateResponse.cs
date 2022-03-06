namespace DataLayer.Models
{
    public class AuthenticateResponse : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }


        public AuthenticateResponse(User user, Role role, string token)
        {
            Email = user.Email;
            Token = token;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = role.RoleName;
        }
    }
}
