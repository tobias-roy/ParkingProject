namespace BLL
{
  public interface ITicketRepository
  {
    ///<summary>
    ///Gets all tickets.
    ///</summary>
    List<Ticket> GetAllTickets();

    //CreateNewTicket
    void CreateTicket (int type);

    //GetTicketByID
    Ticket GetTicketByID(int id);

    Ticket GetTicketByLicenseplate(string licenseplate);


    //GetTicketByLotID
    Ticket GetTicketByLotID(int lotID);

    //DeleteTicketByID
    void DeleteTicketByID(int ID);

    //DeleteTicketByLotID
    Ticket DeleteTicketByLotID(int lotID);

    void UpdateTicket(int id, string column, string value);
    void UpdateTicket(int id, string column, int value);
    void UpdateTicket(int id, string column, decimal value);
    int GetLatestID();
    void CancelledTicketCreation();
  } 
}