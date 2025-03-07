namespace Movie
{
    public class Users
    {
        private User[] _userlist = new User[2];
        private int _size = 0;

        public User this[int index]
        {
            get => _userlist[index];
        }
        public int Count { get; }
        public void AddUsers()
        {
            int role;

            Console.Write("Enter User Name:");
            string name = Console.ReadLine();

            Console.Write("Enter User Password:");
            string pass = Console.ReadLine();

            if (_size == 0)
            {
                role = 0;
            }
            else if (_size == 1)
            {
                role = 1;
            }
            else
            {
                Console.Write("Enter User Role [0 - Admin, 1 - User]:");
                role = int.Parse(Console.ReadLine());
            }

            User newUser = new User(name, pass, (Role)role);

            if (_size >= _userlist.Length)
            {
                User[] tmp = new User[_userlist.Length * 2];
                Array.Copy(_userlist, tmp, _userlist.Length);
                _userlist = tmp;
            }

            _userlist[_size++] = newUser;

            Console.WriteLine($"\n{name} adlı istifadeçi *{(Role)role}* rolunda yaradildi!\n");
        }

        public void PrintUsers()
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine($"|  {"Username",-20} {"|  Role"}");

            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(new String('-', 40));
                Console.WriteLine($"|  {_userlist[i].Username,-20} |  {_userlist[i].Role}");
            }
            Console.WriteLine(new String('-', 40));
        }

        public User GetUser(string name, string pass)
        {
            for (int i = 0; i < _size; i++)
            {
                if (name == _userlist[i].Username && pass == _userlist[i].Password)
                {
                    return _userlist[i];
                }
            }

            Console.WriteLine("User Not Found!");
            User nullUSer = new User("undefined", "undefined", 0);
            return nullUSer;
        }
    }
}

