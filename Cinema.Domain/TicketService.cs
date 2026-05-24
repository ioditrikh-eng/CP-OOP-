using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public delegate void TicketSoldEventHandler(Ticket ticket);

    public class TicketService
    {
        public event TicketSoldEventHandler TicketSold;

        public void SellTicket(Ticket ticket)
        {
            // Імітація продажу: викликаємо подію
            TicketSold?.Invoke(ticket);
        }
    }
}
