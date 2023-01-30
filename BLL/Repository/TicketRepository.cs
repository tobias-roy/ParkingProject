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

    public void CreateNewTicket(string licensePlate)
    {
      
      throw new NotImplementedException();
    }

    // public Ticket GetTicketByID(int id)
    // {
    //   return _ticketData.GetTicketByID(id);
    // }

    public Ticket GetTicketByLotID(int lotID)
    {
      throw new NotImplementedException();
    }

    public Ticket DeleteTicketByID(int id)
    {
      throw new NotImplementedException();
    }

    public Ticket DeleteTicketByLotID(int lotID)
    {
      throw new NotImplementedException();
    }

    public Ticket GetTicketByID(int id)
    {
      return _ticketData.GetTicketByID(id);
    }
  } 
}