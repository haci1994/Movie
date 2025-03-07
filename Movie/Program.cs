namespace Movie
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Salam, sistemde User yoxdur. \nZehmet olmasa en azi  2 user elave edin! \n(1-ci admin, 2-ci user olacaq, sonraki istifadecilerin rolunu ozunuz sececeksiniz!)\n");
            Users userList = new Users();
            userList.AddUsers();
            userList.AddUsers();
            bool contLoopUsers = true;

            do
            {
                Console.WriteLine("Elave User artirirsiniz[H/Y]?\n");
                string command = Console.ReadLine();
                command = command.ToUpper();
                

                switch(command)
                {
                    case ("H"):
                        userList.AddUsers();
                        break;
                    case ("Y"):
                        contLoopUsers = false;
                        break;
                    default:                     
                        break;
                }

            } while (contLoopUsers);

            Console.Clear();
            Console.WriteLine("\nIstifadeci siyahiniz:\n");
            userList.PrintUsers();
            bool cannotLoggedIn = true;

            do
            {
                Console.WriteLine("\nHesabiniza giris edin:\n\n");
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();

                User loggedUser = userList.GetUser(name,pass);

                if (loggedUser.Username != "undefined")
                {
                    cannotLoggedIn = false;
                    Console.WriteLine($"You logged in as {loggedUser.Username} - You are an {loggedUser.Role}.");

                    Genres genreList = new Genres();
                    Movies movieList = new Movies();

                    if (loggedUser.Role == (Role)0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;

                        do
                        {
                            Console.WriteLine("Select command!\n");
                            Console.WriteLine("[1] - Add movie");
                            Console.WriteLine("[2] - Remove movie");
                            Console.WriteLine("[3] - Add genre");
                            Console.WriteLine("[4] - Remove genre");
                            Console.WriteLine("[5] - Most view");
                            Console.WriteLine("[6] - Log Out");
                            Console.WriteLine("[7] - Exit");

                            int command = int.Parse(Console.ReadLine());

                            switch (command)
                            {
                                case 3:
                                    Console.WriteLine("Janr adini daxil edin!");
                                    string newGenreName = Console.ReadLine();
                                    genreList.AddGenre(newGenreName);
                                    genreList.PrintGenreList();
                                    break;
                                case 4:
                                    genreList.PrintGenreList();
                                    Console.WriteLine("Janr ID-sini daxil edin:");
                                    int idForDelete = int.Parse(Console.ReadLine());
                                    genreList.RemoveGenre(idForDelete);
                                    genreList.PrintGenreList();
                                    break;
                                default:
                                    break;
                            }

                        } while (true);






                    } else if (loggedUser.Role == (Role)1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

            } while (cannotLoggedIn);


        }
    }
}
