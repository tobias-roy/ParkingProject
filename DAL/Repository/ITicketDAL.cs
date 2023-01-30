using BLL;
public interface ITicketDAL
{
  List<Ticket> GetAllTickets();

  void CreateNewTicket(string licensePlate);
  Ticket GetTicketByID(int ID);
  Ticket GetTicketByLotID(int lotID);
  Ticket DeleteTicketByID(int ID);
  Ticket DeleteTicketByLotID(int lotID);
}