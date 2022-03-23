namespace DataLayer.Models
{
    public class AuthenticateResponse : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }


        public AuthenticateResponse(Userr user, string token)
        {
            Email = user.Email;
            Token = token;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role != null ? user.Role.RoleName : "";
        }
    }
}
