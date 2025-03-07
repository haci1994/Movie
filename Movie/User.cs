namespace Movie
{
    public class User
    {
        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get; }
        public string Password { get; }
        public Role Role { get; }


    }
}
