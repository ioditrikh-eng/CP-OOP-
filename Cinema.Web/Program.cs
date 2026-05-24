using Cinema.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Створюємо екземпляр адміністратора
var admin = new Admin();

// Додаємо тестові дані, якщо їх ще немає
if (Admin.Movies.Count == 0)
{
    // Створюємо зал
    var hall = new Hall { Number = 1, Rows = 5, SeatsPerRow = 6, Type = Hall.HallType.Regular };
    hall.GenerateSeats();
    Admin.Halls.Add(hall);

    // Створюємо фільми
    var movie1 = new Movie
    {
        Title = "Дюна: Частина друга",
        Genre = "Фантастика",
        DurationMinutes = 166,
        Director = "Дені Вільнев",
        AgeRestriction = 12
    };
    var movie2 = new Movie
    {
        Title = "Оппенгеймер",
        Genre = "Біографія",
        DurationMinutes = 180,
        Director = "Крістофер Нолан",
        AgeRestriction = 16
    };
    admin.AddMovie(movie1);
    admin.AddMovie(movie2);

    // Створюємо сеанси
    var session1 = new Session
    {
        Movie = movie1,
        Hall = hall,
        DateTime = DateTime.Now.AddDays(1).AddHours(18),
        BasePrice = 250
    };
    var session2 = new Session
    {
        Movie = movie2,
        Hall = hall,
        DateTime = DateTime.Now.AddDays(2).AddHours(20),
        BasePrice = 200
    };
    admin.AddSession(session1);
    admin.AddSession(session2);
}

app.Run();