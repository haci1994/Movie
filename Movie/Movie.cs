using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Movie
{

    public class Movie
    {
        public string MovieName { get; protected set; }
        public Genre Genre { get; protected set; }
        public int ID { get; }


        public int ViewCount { get; set; }

        private static int _idCounterMovie = 1000;

        public Movie(string movieName, int index, Genres genres)
        {
            MovieName = movieName;
            ID = _idCounterMovie++;
            ViewCount = 0;
            Genre myGenre = genres[index];
            Genre = myGenre;
        }

        public void WathcMovie()
        {
            ViewCount += 1;
        }
    }


    public class Movies
    {
        public static int _watchlistCount = 0;
        public Movies(Genres genres)
        {
            _movieList[0] = new Movie("Titanic", 0, genres);
            _movieList[1] = new Movie("Mr.Bean", 1, genres);
        }

        public Movies(Genres genres, int a)
        {
           
        }

        private Movie[] _movieList = new Movie[10];
        private int _size = 2;

        public Movie this[int index]
        {
            get => _movieList[index];
            set => _movieList[index] = value;
        }

        public void AddMovie(Genres genres)
        {
            Console.WriteLine("Kino adini daxil edin:");
            string newMovieName = Console.ReadLine();

            Console.WriteLine("Kino janr ID daxil edin:");
            int genreID = int.Parse(Console.ReadLine());

            Movie newMovie = new Movie(newMovieName, genreID, genres);
            if (_size >= _movieList.Length)
            {
                Movie[] tmp = new Movie[_movieList.Length * 2];
                Array.Copy(_movieList, tmp, _movieList.Length);
                _movieList = tmp;
            }
            _movieList[_size++] = newMovie;
        }

        public void RemoveMovie(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_movieList[i].ID == id)
                {
                    Console.WriteLine($"{_movieList[i].MovieName} silindi.");

                    for (int j = i; j < _size - 1; j++)
                    {
                        _movieList[j] = _movieList[j + 1];
                    }
                }
            }

            _movieList[_size] = default;
            _size -= 1;
        }

        public void PrintMovies()
        {
            Console.WriteLine(new string('_', 60));
            Console.WriteLine($"{"ID",-5} {"Name",-20} {"Genre",-20} {"Views",-5}");

            for (int i = 0; i < _size; i++)
            {
                string genreName;
                if (_movieList[i].Genre == null)
                {
                    genreName = "unknown";
                }
                else
                {
                    genreName = _movieList[i].Genre.GenreName;
                }

                Console.WriteLine(new string('_', 60));
                Console.WriteLine($"{_movieList[i].ID,-5} {_movieList[i].MovieName,-20} {genreName,-20} {_movieList[i].ViewCount,-5}");
            }
            Console.WriteLine(new string('_', 60));
        }

        public void Watch(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_movieList[i].ID == id)
                {
                    _movieList[i].WathcMovie();
                }
            }
        }

        public int Size ()
        {
            return _size;
        }

        public void MostView(Movies list)
        {
            
            if(list.Size() > 1)
            {
                int maxIndex = 0;
            for (int i = 1; i < list.Size(); i++)
            {
                if (list[i].ViewCount > list[maxIndex].ViewCount)
                {
                    maxIndex = i;
                }                
            }

                Console.WriteLine($"En cox baxilan film {list[maxIndex].MovieName} - {list[maxIndex].ViewCount} defe izlenmishdir.");
                return;
            }
            

            if (list.Size() == 0)
            {
                Console.WriteLine("Siyahida film yoxdur!");
                return;
            }

            if (list.Size() == 1)
            {
                Console.WriteLine($"Siyahida 1 film var! En cox baxilan film {list[0].MovieName} - {list[0].ViewCount} defe izlenmishdir.");
                return;
            }
        }

        public void FilterByGenre (Movies list, Genres genres)
        {
            genres.PrintGenreList();
            Console.WriteLine("Filterlemek istediyiniz Janrin ID-sini yazin!");
            int id = int.Parse(Console.ReadLine());


            Console.WriteLine(new string('_', 60));
            Console.WriteLine($"{"ID",-5} {"Name",-20} {"Genre",-20} {"Views",-5}");
            for (int i = 0; i < list.Size();i++)
            {
                if (list[i].Genre == null) continue;

                if (list[i].Genre.ID == id)
                {
                    Console.WriteLine(new string('_', 60));
                    Console.WriteLine($"{list[i].ID,-5} {list[i].MovieName,-20} {list[i].ViewCount,-5}");

                }

                
            }

            Console.WriteLine(new string('_', 60));
        }

        public int Length() => _movieList.Length;

        public void AddToWatchList(Movies list, Movies watchList)
        {
            
            Console.WriteLine("Watchliste artirmaq istediyiniz kinonun ID-sini yazin:");
            int id = int.Parse(Console.ReadLine());
            Movie movie = null;

            for (int i = 0; i < list.Size(); i++)
            {
                if (list[i].ID == id)
                {
                    movie = list[i];
                }
            }


            

            watchList[_watchlistCount++] = movie;


            Console.WriteLine("Watchlist:");
           
        }

        public void PrintWatchlist()
        {
            Console.WriteLine(new string('_', 60));
            Console.WriteLine($"{"ID",-5} {"Name",-20} {"Genre",-20} {"Views",-5}");

            for (int i = 0; i < _watchlistCount; i++)
            {
                string genreName;
                if (_movieList[i].Genre == null)
                {
                    genreName = "unknown";
                }
                else
                {
                    genreName = _movieList[i].Genre.GenreName;
                }

                Console.WriteLine(new string('_', 60));
                Console.WriteLine($"{_movieList[i].ID,-5} {_movieList[i].MovieName,-20} {genreName,-20} {_movieList[i].ViewCount,-5}");
            }
            Console.WriteLine(new string('_', 60));
        }
    }
}

