using Newtonsoft.Json;
using BLL;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

public class TicketDAL : ITicketDAL
{
  string ticketJSONPath = @"/Users/tobiasroy/Documents/Skole/H2/ParkingProject/DAL/Repository/ticketdatajson.json";

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
    List<Ticket> Tickets = new();
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.Query<Ticket>("SELECT * FROM Ticket", new DynamicParameters());
      List<Ticket> dapperTickets = output.ToList();
      return dapperTickets;
    }
  }
  public Ticket DeleteTicketByID(int ID)
  {
    throw new NotImplementedException();
  }
  public Ticket DeleteTicketByLotID(int lotID)
  {
    throw new NotImplementedException();
  }

  private static string GetConnectionString(){
    return "Data Source = ./ParkingDB.db";
  }
}