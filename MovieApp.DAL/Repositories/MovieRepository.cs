using Domain.Models;
using MovieApp.DAL.Interfaces.Repositories;

namespace MovieApp.DAL.Repositories;

public class MovieRepository : IMovieRepository
{
    public IEnumerable<Movie> GetAllMovies()
    {
        return GenerateMovies();
    }

    public Movie GetMovieById(int id)
    {
        var movies = GenerateMovies();
        return movies.FirstOrDefault(m => m.Id.Equals(id));
    }

    private IEnumerable<Movie> GenerateMovies()
    {
        return new List<Movie>
        {
            new()
            {
                Id = 1, Title = "The Echo of Time",
                Description = "A journey through the echoes of time, revealing untold stories from 2003.",
                Year = 2003,
                Rating = 5, CategoryId = 8
            },
            new()
            {
                Id = 2, Title = "Shadows of 1964",
                Description =
                    "Unveiling the shadows that lingered over the year 1964, a story of resilience and revolution.",
                Year = 1964,
                Rating = 4, CategoryId = 10
            },
            new()
            {
                Id = 3, Title = "Whispers from 1955",
                Description = "In 1955, whispers among the winds tell a tale of discovery and destiny.",
                Year = 1955,
                Rating = 4, CategoryId = 10
            },
            new()
            {
                Id = 4, Title = "Dreams of '93",
                Description =
                    "1993: A year of dreams, challenges, and achievements. An inspiring tale of perseverance.",
                Year = 1993,
                Rating = 10, CategoryId = 9
            },
            new()
            {
                Id = 5, Title = "Renaissance of 1956",
                Description = "The year 1956 brought a renaissance of art and expression, changing lives forever.",
                Year = 1956,
                Rating = 5, CategoryId = 3
            },
            new()
            {
                Id = 6, Title = "Echoes of 1995",
                Description = "A look back at 1995, exploring the echoes of the past that shaped the future.",
                Year = 1995,
                Rating = 9, CategoryId = 8
            },
            new()
            {
                Id = 7, Title = "The Forgotten Year",
                Description = "1952: A forgotten year with stories that shaped the world in unseen ways.",
                Year = 1952,
                Rating = 1, CategoryId = 9
            },
            new()
            {
                Id = 8, Title = "Whirlwind of 1992",
                Description = "1992: A year of whirlwind changes, from the personal to the global scale.",
                Year = 1992,
                Rating = 8, CategoryId = 3
            },
            new()
            {
                Id = 9, Title = "Twilight of 1959",
                Description = "The twilight of 1959 brought forth changes that would echo through the ages.",
                Year = 1959,
                Rating = 2, CategoryId = 8
            },
            new()
            {
                Id = 10, Title = "Beyond the Horizon",
                Description = "1997: A tale of exploration and discovery, reaching beyond the known horizons.",
                Year = 1997, Rating = 5, CategoryId = 4
            },
            new()
            {
                Id = 11, Title = "Shadows and Light",
                Description = "1981: A dance of shadows and light, revealing the dual nature of humanity.",
                Year = 1981, Rating = 6, CategoryId = 4
            },
            new()
            {
                Id = 12, Title = "The Vintage Year",
                Description = "1976: A vintage year that brewed revolutions in hearts and societies alike.",
                Year = 1976, Rating = 4, CategoryId = 8
            },
            new()
            {
                Id = 13, Title = "Winds of Change",
                Description = "The winds of 1991 brought change, sweeping across the world in waves of liberation.",
                Year = 1991, Rating = 7, CategoryId = 5
            },
            new()
            {
                Id = 14, Title = "Echoes of the Forgotten",
                Description = "1952 revisited: Unearthing the echoes of the forgotten stories and souls.",
                Year = 1952, Rating = 2, CategoryId = 5
            },
            new()
            {
                Id = 15, Title = "The Year We Remember",
                Description = "1957: A year we remember not for events, but for the emotions it stirred.",
                Year = 1957, Rating = 4, CategoryId = 2
            },
            new()
            {
                Id = 16, Title = "Silent Echoes",
                Description = "1958: A year of silent echoes, whispering the truths of a world in flux.",
                Year = 1958, Rating = 1, CategoryId = 9
            },
            new()
            {
                Id = 17, Title = "New Dawns",
                Description = "2018: Marking new dawns and the beginning of eras yet to be defined.",
                Year = 2018, Rating = 3, CategoryId = 2
            },
            new()
            {
                Id = 18, Title = "Era of Echoes",
                Description = "1988: An era where the echoes of the past met the whispers of the future.",
                Year = 1988, Rating = 6, CategoryId = 1
            },
            new()
            {
                Id = 19, Title = "Whispers of Tomorrow",
                Description = "2013: A year of whispers, gently shaping the contours of tomorrow.",
                Year = 2013, Rating = 1, CategoryId = 7
            },
            new()
            {
                Id = 20, Title = "The Unseen Journey",
                Description = "1991: An unseen journey through the depths of the human spirit and the world around us.",
                Year = 1991, Rating = 0, CategoryId = 3
            },
            new()
            {
                Id = 21, Title = "Tales of 1965",
                Description = "The tales of 1965, a year that wove together stories of hope, struggle, and change.",
                Year = 1965, Rating = 4, CategoryId = 10
            },
            new()
            {
                Id = 22, Title = "Moments of 1995",
                Description = "Exploring the significant moments that defined the year 1995 and its legacy.",
                Year = 1995, Rating = 1, CategoryId = 3
            },
            new()
            {
                Id = 23, Title = "Chronicles of 1986",
                Description =
                    "A vivid chronicle of 1986, capturing the essence of an era filled with innovation and conflict.",
                Year = 1986, Rating = 8, CategoryId = 1
            },
            new()
            {
                Id = 24, Title = "The Silent Echo",
                Description = "1986: A year that resonated with the silent echo of change, felt across generations.",
                Year = 1986, Rating = 0, CategoryId = 3
            },
            new()
            {
                Id = 25, Title = "The Lasting Impression",
                Description =
                    "1974: A year that left a lasting impression on the fabric of society, unraveling tales of hope.",
                Year = 1974, Rating = 10, CategoryId = 10
            },
            new()
            {
                Id = 26, Title = "Reflections of 1982",
                Description =
                    "Delving into the reflections of 1982, a year that mirrored the complexities of the human experience.",
                Year = 1982, Rating = 5, CategoryId = 5
            },
            new()
            {
                Id = 27, Title = "Forgotten Voices",
                Description = "1953: Unearthing the forgotten voices that whispered the truths of their time.",
                Year = 1953, Rating = 0, CategoryId = 1
            },
            new()
            {
                Id = 28, Title = "A New Dawn",
                Description = "2013: Witnessing the birth of a new dawn, challenging the norms and embracing change.",
                Year = 2013, Rating = 7, CategoryId = 2
            },
            new()
            {
                Id = 29, Title = "Rising from Ashes",
                Description =
                    "1962: The year the world rose from the ashes, marking a new chapter of resilience and rebirth.",
                Year = 1962, Rating = 9, CategoryId = 1
            },
            new()
            {
                Id = 30, Title = "Echoes of 1969",
                Description = "1969: A year of echoes from the past and whispers of the future, bridging two eras.",
                Year = 1969, Rating = 5, CategoryId = 3
            },
            new()
            {
                Id = 31, Title = "Crescendo of Dreams",
                Description =
                    "1956: The crescendo of dreams that rose and fell, echoing through the corridors of time.",
                Year = 1956, Rating = 10, CategoryId = 6
            },
            new()
            {
                Id = 32, Title = "Shadows of the Past",
                Description =
                    "1964: Navigating through the shadows of the past, unveiling stories of love, loss, and legacy.",
                Year = 1964, Rating = 9, CategoryId = 8
            },
            new()
            {
                Id = 33, Title = "Through the Looking Glass",
                Description =
                    "1987: A journey through the looking glass, exploring the year with curiosity and courage.",
                Year = 1987, Rating = 5, CategoryId = 3
            },
            new()
            {
                Id = 34, Title = "Whispers of the Heart",
                Description = "2013: A tale of whispers from the heart, weaving stories of love, loss, and hope.",
                Year = 2013, Rating = 6, CategoryId = 5
            },
            new()
            {
                Id = 35, Title = "Reflections of 2007",
                Description =
                    "2007: Reflecting on a year of significant changes, marked by personal growth and global shifts.",
                Year = 2007, Rating = 4, CategoryId = 3
            },
            new()
            {
                Id = 36, Title = "The Horizon Beyond",
                Description =
                    "2020: Gazing into the horizon beyond, exploring the uncertainties and possibilities of a new era.",
                Year = 2020, Rating = 2, CategoryId = 6
            },
            new()
            {
                Id = 37, Title = "Tales from 1961",
                Description = "1961: Tales from a year of transition, capturing the essence of a world in motion.",
                Year = 1961, Rating = 4, CategoryId = 7
            },
            new()
            {
                Id = 38, Title = "Echoes of 1966",
                Description =
                    "1966: The echoes of change that resonated throughout the year, marking a period of transformation.",
                Year = 1966, Rating = 5, CategoryId = 1
            },
            new()
            {
                Id = 39, Title = "The Whispering Year",
                Description =
                    "1961: Remembered as the whispering year, its subtle changes influencing decades to come.",
                Year = 1961, Rating = 3, CategoryId = 8
            },
            new()
            {
                Id = 40, Title = "Memories of 2007",
                Description =
                    "2007: A collection of memories, both bitter and sweet, defining a year of growth and challenge.",
                Year = 2007, Rating = 5, CategoryId = 3
            }
        };
    }
}