using BLL;

namespace DAL 
{
  public interface ITicketDAL
  {
    List<Ticket> GetAllTickets();

    void CreateTicket(int type);
    Ticket GetTicketByID(int ID);
    Ticket GetTicketByLotID(int lotID);
    void DeleteTicketByID(int ID);
    void DeleteTicketByLotID(int lotID);
    void UpdateTicket(int id, string column, string value);
    void UpdateTicket(int id, string column, int value);
    void UpdateTicket(int id, string column, decimal value);
    int GetLatestID();
  }
}
