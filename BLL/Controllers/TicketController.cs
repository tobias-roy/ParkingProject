namespace BLL.Controllers
{
    public class TicketController : ITicketController
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController (ITicketRepository ticketRepository) {
            _ticketRepository = ticketRepository;
        }
        public void CreateTicket(int type){
          _ticketRepository.CreateTicket(type);
        }


        public void WriteOutAllTickets(){
            List<Ticket> tickets = _ticketRepository.GetAllTickets();
            foreach (var item in tickets)
            {
                Console.WriteLine($"TicketID: {item.ID}, Licenseplate: {item.LicensePlate}");
            }
        }

    public void WriteOutTicketFromID()
    {
      throw new NotImplementedException();
    }

    public void WriteOutTicketFromID(int id)
    {
      Ticket ticket = _ticketRepository.GetTicketByID(id);
      Console.WriteLine(ticket.LicensePlate);
    }
  }
}
