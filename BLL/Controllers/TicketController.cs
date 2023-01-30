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
                Console.WriteLine($"TicketID: {item.ID}, Licenseplate: {item.LicensePlate}");
            }
        }

        // public void WriteOutTicketFromID(int id){
        //     Ticket ticket = _ticketRepository.GetTicketByID(id);
        //     Console.WriteLine($"TicketID: {ticket.ID}, {ticket.LicensePlate}, {ticket.LotID}");
        // }

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
