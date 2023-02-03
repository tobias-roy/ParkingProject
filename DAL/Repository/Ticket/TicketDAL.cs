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
      //By using we lock the database from being written to but not read from until queries are done executing and the database is freed.
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        var lotId = connection.ExecuteScalar($"SELECT LotID FROM VehicleLot WHERE Status = '0' AND LotType = '{type}' LIMIT 1", new DynamicParameters());
        connection.Execute($"UPDATE VehicleLot SET Status = 1 WHERE LotID = '{lotId}'");
        connection.Execute($"INSERT INTO Ticket(VehicleType, LotID, Price) VALUES('{type}', '{lotId}', (SELECT Price FROM VehicleLot WHERE LotType = '{type}'))", new DynamicParameters());
      }
    }
    public Ticket GetTicketByID(int id)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        var output = connection.QuerySingle<Ticket>($"SELECT * FROM Ticket WHERE ID = '{id}'", new DynamicParameters());
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
    public void DeleteTicketByID(int id)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        connection.Execute("DELETE FROM Ticket WHERE ID =" + $"{id}", new DynamicParameters());
      }
    }
    public void DeleteTicketByLotID(int lotID)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        connection.Execute("DELETE FROM Ticket WHERE LotID =" + $"{lotID}", new DynamicParameters());
      }
    }
    public void UpdateTicket(int id, string column, string value)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        connection.Execute($"UPDATE Ticket SET {column} = '{value}' WHERE ID =" + $"{id}", new DynamicParameters());
      }
    }
    public void UpdateTicket(int id, string column, int value)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        connection.Execute($"UPDATE Ticket SET {column} = '{value}' WHERE ID =" + $"{id}", new DynamicParameters());
      }
    }
    public void UpdateTicket(int id, string column, decimal value)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        connection.Execute($"UPDATE Ticket SET {column} = '{value}' WHERE ID =" + $"{id}", new DynamicParameters());
      }
    }

    public int GetLatestID(){
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        int result = int.Parse(connection.ExecuteScalar("SELECT last_insert_rowid()").ToString());
        return result;
      }
    }
  }
}