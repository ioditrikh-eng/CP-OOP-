using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Domain
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(Session session, User user, Seat seat);
    }
}
