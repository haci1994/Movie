namespace Movie
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Genres genreList = new Genres();
            Movies movieList = new Movies(genreList);
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


        login:

            Console.BackgroundColor = default;
            Console.ForegroundColor = ConsoleColor.White;

            bool cannotLoggedIn = true;
        
            do
            {
                Console.WriteLine("\nHesabiniza giris edin:\n\n");
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();

                User loggedUser = userList.GetUser(name, pass);

                if (loggedUser.Username != "undefined")
                {
                    cannotLoggedIn = false;
                    Console.WriteLine($"You logged in as {loggedUser.Username} - You are an {loggedUser.Role}.");

                    

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
                                case 1:
                                    movieList.AddMovie(genreList);
                                    movieList.PrintMovies();
                                    break;
                                case 2:
                                    Console.WriteLine("Silmek istediyiniz filmin ID-sini daxil edin:");
                                    int id = int.Parse(Console.ReadLine());
                                    movieList.RemoveMovie(id);
                                    break;
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
                                case 5:
                                    movieList.MostView(movieList);
                                    break;
                                case 6:
                                    cannotLoggedIn = true;
                                    goto login;
                                    break;
                                case 7:
                                    Environment.Exit(0);
                                    break;
                                default:
                                    break;
                            }

                        } while (!cannotLoggedIn);
                    }


                    else if (loggedUser.Role == (Role)1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        Movies watchList = new Movies(genreList,5);

                        do
                        {
                            Console.WriteLine("Select command!\n");
                            Console.WriteLine("[1] - watch movie");
                            Console.WriteLine("[2] - filter movie by genre");
                            Console.WriteLine("[3] - add to watchlist");
                            Console.WriteLine("[4] - search movie");
                            Console.WriteLine("[5] - Log Out");
                            Console.WriteLine("[6] - Exit");

                            int command = int.Parse(Console.ReadLine());

                            switch (command)
                            {
                                case 1:
                                    movieList.PrintMovies();
                                    Console.WriteLine("Izlemek istediyiniz filmi secin:");
                                    int id = int.Parse(Console.ReadLine());

                                    movieList.Watch(id);
                                    break;

                                case 2:
                                    movieList.FilterByGenre(movieList, genreList);
                                    break;
                                case 3:
                                    watchList.AddToWatchList(movieList,watchList);
                                    watchList.PrintWatchlist();
                                    break;
                                case 5:
                                    cannotLoggedIn = true;
                                    goto login;
                                    break;
                                case 6:
                                    Environment.Exit(0);
                                    break;
                                default:
                                    break;
                            }
                        } while (true);


                        
                    }
                }

            } while (!cannotLoggedIn);


        }
    }
}
