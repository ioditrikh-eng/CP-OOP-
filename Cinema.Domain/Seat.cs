using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Seat
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsVip { get; set; } = false;
        public string GetSeatNumber() => $"Ряд {Row}, Місце {Number}";
    }
}
