using BLL;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace DAL
{
public class TicketDAL : ITicketDAL
{
  private static string GetConnectionString(){
    return "Data Source = ./ParkingDB.db";
  }
  public void CreateTicket(int type)
  {
    Ticket createdTicket = new(){
      VehicleType = (Vehicle.Type)type
    };
    //By using we lock the database from being written to but not read from until queries are done executing and the database is freed.
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      switch ((int)type)
      {
        case 1:
          string carLotId = connection.ExecuteScalar("SELECT LotID FROM VehicleLot WHERE Status = '0' AND LotID LIKE 'A%' LIMIT 1", new DynamicParameters()).ToString();
          connection.Execute($"INSERT INTO Ticket(VehicleType, LotID) VALUES('{type}', '{carLotId}')", new DynamicParameters());
          break;
        
        case 2:
          string trailerLotId = connection.ExecuteScalar("SELECT LotID FROM VehicleLot WHERE Status = '0' AND LotID LIKE 'B%' LIMIT 1", new DynamicParameters()).ToString();
          connection.Execute($"INSERT INTO Ticket(VehicleType, LotID) VALUES('{type}', '{trailerLotId}')", new DynamicParameters());
          break;

        case 3:
          string busLotId = connection.ExecuteScalar("SELECT LotID FROM VehicleLot WHERE Status = '0' AND LotID LIKE 'C%' LIMIT 1", new DynamicParameters()).ToString();
          connection.Execute($"INSERT INTO Ticket(VehicleType, LotID) VALUES('{type}', '{busLotId}')", new DynamicParameters());
          break;

        case 4:
          string truckLotId = connection.ExecuteScalar("SELECT LotID FROM VehicleLot WHERE Status = '0' AND LotID LIKE 'D%' LIMIT 1", new DynamicParameters()).ToString();
          connection.Execute($"INSERT INTO Ticket(VehicleType, LotID) VALUES('{type}', '{truckLotId}')", new DynamicParameters());
          break;
        default:
          break;
      }
      string result = connection.ExecuteScalar("SELECT last_insert_rowid()").ToString();
      createdTicket.ID = int.Parse(result);
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
  public void UpdateTicket(int id, string column, string value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE Ticket SET {column} = {value} WHERE ID =" + $"{id}", new DynamicParameters());
    }
  }
  public void UpdateTicket(int id, string column, int value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE Ticket SET {column} = {value} WHERE ID =" + $"{id}", new DynamicParameters());
    }
  }
  public void UpdateTicket(int id, string column, decimal value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE Ticket SET {column} = {value} WHERE ID =" + $"{id}", new DynamicParameters());
    }
  }
}

}