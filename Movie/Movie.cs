namespace Movie
{
   
        public class Movie
    {

        public string MovieName { get; protected set; }
        public int ID { get; }
        public Genre Genre { get; protected set; }
        private int _viewCount;
        private static int _idCounterMovie = 1000;

        public Movie(string movieName, int genreID)
        {
            MovieName = movieName;
            ID = _idCounterMovie++;

            
        }
    }


    public class Movies
    {
        private Movie[] _movieList = new Movie[10];

        public Movie this[int index]
        {
            get => _movieList[index];
            set => _movieList[index] = value;
        }

        public void AddMovie(string name, int genreID)
        {
            Movie newMovie = new Movie(name, genreID);
        }
    }
}

