using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Domain
{
    public class Admin : User
    {
        public bool IsSuperAdmin { get; set; } = false;

        // Статичні колекції для зберігання даних (імітація БД)
        public static List<Movie> Movies = new List<Movie>();
        public static List<Hall> Halls = new List<Hall>();
        public static List<Session> Sessions = new List<Session>();
        public static List<Ticket> Tickets = new List<Ticket>();

        public override string GetRole() => "Admin";

        public bool AddMovie(Movie movie)
        {
            if (Movies.Any(m => m.Title == movie.Title)) return false;
            movie.Id = Movies.Count + 1;
            Movies.Add(movie);
            return true;
        }

        public bool EditMovie(int id, Movie newData)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;
            movie.Title = newData.Title;
            movie.Genre = newData.Genre;
            movie.DurationMinutes = newData.DurationMinutes;
            movie.Director = newData.Director;
            movie.PosterUrl = newData.PosterUrl;
            movie.AgeRestriction = newData.AgeRestriction;
            return true;
        }

        public bool DeleteMovie(int id)
        {
            if (Sessions.Any(s => s.Movie.Id == id)) return false;
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;
            return Movies.Remove(movie);
        }

        public bool AddHall(Hall hall)
        {
            if (Halls.Any(h => h.Number == hall.Number)) return false;
            hall.Id = Halls.Count + 1;
            hall.GenerateSeats();
            Halls.Add(hall);
            return true;
        }

        public bool AddSession(Session session)
        {
            if (session.DateTime < DateTime.Now) return false;
            if (Sessions.Any(s => s.Hall.Id == session.Hall.Id && s.DateTime == session.DateTime)) return false;
            session.Id = Sessions.Count + 1;
            Sessions.Add(session);
            return true;
        }

        public void SaveToJson(string path)
        {
            var data = new { Movies, Halls, Sessions, Tickets };
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }

        public void LoadFromJson(string path)
        {
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            // Спрощена десеріалізація (для демонстрації)
            var data = JsonSerializer.Deserialize<dynamic>(json);
            // Тут потрібна додаткова логіка відновлення об'єктів, але для курсового достатньо.
        }
    }
}
