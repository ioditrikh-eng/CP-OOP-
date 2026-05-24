using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Session : IComparable<Session>
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public DateTime DateTime { get; set; }
        public decimal BasePrice { get; set; }
        public List<Seat> BookedSeats { get; set; } = new List<Seat>();

        public bool IsSeatAvailable(Seat seat)
        {
            return !BookedSeats.Any(s => s.Row == seat.Row && s.Number == seat.Number);
        }

        public bool BookSeat(Seat seat)
        {
            if (!IsSeatAvailable(seat)) return false;
            BookedSeats.Add(seat);
            return true;
        }

        public int CompareTo(Session other)
        {
            return this.DateTime.CompareTo(other.DateTime);
        }
    }
}
