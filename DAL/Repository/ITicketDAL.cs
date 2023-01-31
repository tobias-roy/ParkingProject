using BLL;
public interface ITicketDAL
{
  List<Ticket> GetAllTickets();

  void CreateTicket(int type);
  Ticket GetTicketByID(int ID);
  Ticket GetTicketByLotID(int lotID);
  Ticket DeleteTicketByID(int ID);
  Ticket DeleteTicketByLotID(int lotID);
}