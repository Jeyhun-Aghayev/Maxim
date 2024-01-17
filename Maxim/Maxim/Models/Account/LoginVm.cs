namespace Maxim.Models.Account
{
    public class LoginVm
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
