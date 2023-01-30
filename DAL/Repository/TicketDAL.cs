using BLL;
using Newtonsoft.Json;

public class TicketDAL : ITicketDAL
{
  string ticketJSONPath = @"/Users/tobiasroy/Documents/Skole/H2/ParkingProject/DAL/Repository/ticketdatajson.json";
  List<Ticket> Tickets = new();

  public void CreateNewTicket(string licensePlate)
  {
    throw new NotImplementedException();
  }
  public Ticket GetTicketByID(int id)
  {
    Ticket emptyTicket = new();
    if(File.Exists(ticketJSONPath)){
      string json = File.ReadAllText(ticketJSONPath);
      List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
      foreach (var ticket in tickets)
      {
        if(ticket.ID == id){
          return ticket;
        }
      }
      return emptyTicket;
    } else {
      return emptyTicket;
    } 
  }
  public Ticket GetTicketByLotID(int lotID)
  {
    throw new NotImplementedException();
  }
  public List<Ticket> GetAllTickets() 
  {
    if(File.Exists(ticketJSONPath)){
      string json = File.ReadAllText(ticketJSONPath);
      List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
      foreach (var item in tickets)
      {
        Tickets.Add(item);
      }
    }
    return Tickets;
  }
  public Ticket DeleteTicketByID(int ID)
  {
    throw new NotImplementedException();
  }
  public Ticket DeleteTicketByLotID(int lotID)
  {
    throw new NotImplementedException();
  }
}