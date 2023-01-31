using BLL;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

public class TicketDAL : ITicketDAL
{
  public void CreateTicket(int type)
  {
    Ticket createdTicket = new(){
      VehicleType = (Vehicle.Type)type
    };
    //By using we lock the database from being written to but not read from until queries are done executing and the database is freed.
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"INSERT INTO Ticket(VehicleType) VALUES('{type}')", new DynamicParameters());
      var result = connection.ExecuteScalar("SELECT last_insert_rowid()");
      createdTicket.ID = int.Parse(result.ToString());
    }
  }
  public Ticket GetTicketByID(int id)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.QuerySingle<Ticket>("SELECT * FROM Ticket WHERE ID =" + $"{id}", new DynamicParameters());
      Ticket ticket = output;
      return ticket;
    }
  }
  public Ticket GetTicketByLotID(int lotID)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.QuerySingle<Ticket>("SELECT * FROM Ticket WHERE LotID =" + $"{lotID}", new DynamicParameters());
      Ticket ticket = output;
      return ticket;
    }
  }
  public List<Ticket> GetAllTickets() 
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.Query<Ticket>("SELECT * FROM Ticket", new DynamicParameters());
      List<Ticket> Tickets = output.ToList();
      return Tickets;
    }
  }
  public Ticket DeleteTicketByID(int id)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.QuerySingle<Ticket>("DELETE FROM Ticket WHERE ID =" + $"{id}", new DynamicParameters());
      Ticket ticket = output;
      return ticket;
    }
  }
  public Ticket DeleteTicketByLotID(int lotID)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.QuerySingle<Ticket>("DELETE FROM Ticket WHERE LotID =" + $"{lotID}", new DynamicParameters());
      Ticket ticket = output;
      return ticket;
    }
  }

  private static string GetConnectionString(){
    return "Data Source = ./ParkingDB.db";
  }

}