# CP-OOP
2026

#  Cinema Management System «Планета Кіно»

Курсовий проєкт з дисципліни «Об’єктно-орієнтоване програмування».  
Розроблено веб-застосунок для управління кінотеатром: перегляд фільмів, сеансів, вибір місць, покупка квитків (без реєстрації), адмін-панель зі збереженням/завантаженням даних у JSON.

##  Технології

- **Мова програмування:** C# (.NET 8)
- **Фреймворк:** ASP.NET Core MVC
- **Тестування:** MSTest (unit-тести)
- **Frontend:** HTML, CSS (Razor Pages, Bootstrap за бажанням)
- **Збереження даних:** JSON-файли (серіалізація/десеріалізація)
- **Версійний контроль:** Git, GitHub

##  Структура проєкту

- `Cinema.Domain/` – бібліотека класів предметної області (ООП, SOLID)
  - `Models/` – User, Admin, Guest, Movie, Hall, Seat, Session, Ticket
  - `Interfaces/` – IJsonSerializable, IPriceCalculator, ITicketRepository
  - `Services/` – TicketService (делегати, події)
- `Cinema.Tests/` – Unit-тести (MSTest)
- `Cinema.Web/` – веб-застосунок ASP.NET Core MVC
  - `Controllers/` – Home, Sessions, Tickets, Admin
  - `Views/` – Razor-сторінки
  - `wwwroot/` – статичні файли (CSS, JS, data/cinema.json)
  - `Program.cs`
- `README.md`


##  Вимоги

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 / 2025 / VS Code
- Браузер (Chrome, Firefox, Edge)

##  Запуск проєкту

1. **Клонувати репозиторій:**
   ```bash
   git clone https://github.com/ваш_логін/CinemaManagement.git
   cd CinemaManagement

2. Відкрити рішення CinemaManagement.sln у Visual Studio.

3. Встановити проєкт Cinema.Web як стартовий (клацнути правою кнопкою → Set as Startup Project).

4. Запустити (F5). Веб-застосунок відкриється у браузері.

Перший запуск може запитати довіру до SSL-сертифіката – натисніть «Так».

## Принципи SOLID
У проєкті реалізовано п’ять принципів SOLID:

S (Single Responsibility) – кожен клас має одну відповідальність.

O (Open/Closed) – розширення через інтерфейс IPriceCalculator.

L (Liskov Substitution) – нащадки User замінюють базовий клас.

I (Interface Segregation) – інтерфейси розділені на маленькі.

D (Dependency Inversion) – залежність від ITicketRepository.

# Автор
Дітріх Ілля
Курсовий проєкт, 2026 р.
Викладач: доц. Шевченко І.В.
