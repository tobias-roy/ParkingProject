using DAL;
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

    public Ticket GetTicketByLotID(int lotID)
    {
      throw new NotImplementedException();
    }

    public void DeleteTicketByID(int id)
    {
      _ticketData.DeleteTicketByID(id);
    }

    public Ticket DeleteTicketByLotID(int lotID)
    {
      throw new NotImplementedException();
    }

    public Ticket GetTicketByID(int id)
    {
      return _ticketData.GetTicketByID(id);
    }

    public Ticket GetTicketByLicenseplate(string licenseplate)
    {
      return _ticketData.GetTicketByLicenseplate(licenseplate);
    }


    public void CreateTicket(int type)
    {
      _ticketData.CreateTicket(type);
    }

    public void UpdateTicket(int id, string column, string value)
    {
      _ticketData.UpdateTicket(id, column, value);
    }

    public void UpdateTicket(int id, string column, int value)
    {
      _ticketData.UpdateTicket(id, column, value);
    }

    public void UpdateTicket(int id, string column, decimal value)
    {
      _ticketData.UpdateTicket(id, column, value);
    }

    public int GetLatestID()
    {
      return _ticketData.GetLatestID();
    }
  } 
}