using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket);
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
    }
}
