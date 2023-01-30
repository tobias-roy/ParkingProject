namespace BLL
{
  public class TicketRepository : ITicketRepository
  {
    
    public ITicketDAL _ticketData;
    public TicketRepository(ITicketDAL ticketData)
    {
      _ticketData = ticketData;
    }
   
    public List<Ticket> GetAllTickets()
    {
      return _ticketData.GetAllTickets();
    } 

    //CreateNewTicket

    //GetTicketByID

    //DeleteTicketByID
  } 
}