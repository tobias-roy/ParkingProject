namespace BLL.Controllers
{
    public class TicketController : ITicketController
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController (ITicketRepository ticketRepository) {
            _ticketRepository = ticketRepository;
        }
        public void WriteOutAllTickets(){
            List<Ticket> tickets = _ticketRepository.GetAllTickets();
            foreach (var item in tickets)
            {
                Console.WriteLine($"Ticket: {item}");
            }
        }
    }
}
