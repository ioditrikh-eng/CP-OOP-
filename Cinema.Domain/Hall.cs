using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Domain
{
    public class Hall
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Rows { get; set; }
        public int SeatsPerRow { get; set; }
        public enum HallType { Regular, ThreeD, IMAX }
        public HallType Type { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();

        public void GenerateSeats()
        {
            Seats.Clear();
            for (int r = 1; r <= Rows; r++)
                for (int s = 1; s <= SeatsPerRow; s++)
                    Seats.Add(new Seat { Row = r, Number = s });
        }

        public List<Seat> GetAvailableSeats(Session session)
        {
            var available = new List<Seat>();
            foreach (var seat in Seats)
                if (session.IsSeatAvailable(seat))
                    available.Add(seat);
            return available;
        }
    }
}
