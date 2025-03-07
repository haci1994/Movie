namespace Movie
{
    public class Genre
    {
        public string GenreName { get; protected set; }
        public int ID { get; }
        private static int _idCounterGenre = 50;

        public Genre(string genreName)
        {
            GenreName = genreName;
            ID = _idCounterGenre++;
        }
    }

    public class Genres
    {
        private Genre[] _genreList = new Genre[4];
        private int _size = 2;

        public Genres()
        {
            _genreList[0] = new Genre("Dram");            
            _genreList[1] = new Genre("Comic");            
        }

        public void AddGenre(string name)
        {
            if(_size >= _genreList.Length)
            {
                Genre[] tmp = new Genre[_genreList.Length * 2];
                Array.Copy(_genreList, tmp, _genreList.Length);
                _genreList = tmp;
            }
            Genre newGenre = new Genre(name);
                       
            _genreList[_size++] = newGenre;
                       
        }

        public void RemoveGenre (int ID )
        {
            for (int i = 0; i < _size; i++)
            {
                if (_genreList[i].ID == ID)
                {
                    for(int j = i; j <_size-1;j++)
                    {
                        _genreList[j] = _genreList[j + 1];
                    }

                    _genreList[_size] = default;
                    _size -= 1;
                    return;
                } 
            }

            Console.WriteLine("ID tapilmadi!");
            
        }

        public void PrintGenreList()
        {
            Console.WriteLine($"{"ID",-5} {"Name"}");
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"{_genreList[i].ID,-5} {_genreList[i].GenreName}");
            }
        }
        

    }


}

