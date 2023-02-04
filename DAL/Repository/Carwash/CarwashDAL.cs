using BLL;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
namespace DAL
{
  public class CarwashDAL : ICarwashDAL
  {
    private static string GetConnectionString(){
      return "Data Source = ./ParkingDB.db";
    }

    public List<Ticket> GetQueue()
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        var output = connection.Query<Ticket>("SELECT * FROM CarwashQueue", new DynamicParameters());
        List<Ticket> Tickets = output.ToList();
        return Tickets;
      }
    }
    
  }
}
