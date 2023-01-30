namespace BLL
{
  public interface ITicketRepository
  {
    ///<summary>
    ///Gets all tickets.
    ///</summary>
    List<Ticket> GetAllTickets();

    //CreateNewTicket
    void CreateNewTicket(string licensePlate);

    //GetTicketByID
    Ticket GetTicketByID(int id);

    //GetTicketByLotID
    Ticket GetTicketByLotID(int lotID);

    //DeleteTicketByID
    Ticket DeleteTicketByID(int ID);

    //DeleteTicketByLotID
    Ticket DeleteTicketByLotID(int lotID);

  } 
}