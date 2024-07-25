using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayer.Model;

namespace VideoPlayer.Controller
{
    public class MoviesController
    {
        List<Movie> movies = MainWindow.applicationContext.Movies.ToList();
        public Movie GetById(int id)
        {
            RefreshList();
            Movie movie = null;
            foreach (var i in movies)
            {
                if (i.Id == id)
                {
                    movie = i;
                }
            }
            return movie;
        }
        public void RefreshList()
        {
            movies = MainWindow.applicationContext.Movies.ToList();
        }
        public void SearchMovies(string searchString)
        {
            movies = movies.Where(movie => movie.Title.ToLower().Contains(searchString.ToLower()) || movie.Description.ToLower().Contains(searchString.ToLower()) || movie.Director.Name.ToLower().Contains(searchString.ToLower()) || movie.YearOfCreation.ToString().ToLower().Contains(searchString)).ToList();
        }
        public void FilterMoviesByGenre(string genre, string searchString, string sortParam)
        {
            RefreshList();
            movies = movies.Where(movie => movie.Genre.Name == genre).ToList();
            SearchMovies(searchString);
            SortMovies(sortParam);
        }
        public void SortMovies(string sortParam)
        {
            if (sortParam == "Название ↑")
            {
                movies.OrderBy(movie => movie.Title);
            }
            else if (sortParam == "Название ↓")
            {
                movies.OrderByDescending(movie => movie.Title);
            }
            else if (sortParam == "Год производства ↑")
            {
                movies.OrderBy(movie => movie.YearOfCreation);
            }
            else if (sortParam == "Год производства ↓")
            {
                movies.OrderByDescending(movie => movie.YearOfCreation);
            }
            else if (sortParam == "Продолжительность ↑")
            {
                movies.OrderBy(movie => movie.Duration);
            }
            else if (sortParam == "Продолжительность ↓")
            {
                movies.OrderByDescending(movie => movie.Duration);
            }
        }
    }
}
