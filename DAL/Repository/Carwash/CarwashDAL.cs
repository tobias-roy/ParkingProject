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

    public void DeleteWashed(int id)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        try{
          connection.Execute("DELETE FROM CarwashQueue WHERE QueueID =" + $"{id}", new DynamicParameters());

        } catch {
          Console.WriteLine("FUUUUUUUUUUCK");
        }
      }
    }

    public List<CarwashEntries> GetCarwashQueue()
    {
      List<CarwashEntries> entriesInQueue = new();
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        try{
          var output = connection.Query<CarwashEntries>("SELECT * FROM CarwashQueue", new DynamicParameters());
          entriesInQueue = output.ToList();
        } catch {
          Console.WriteLine("FUUUUUUUUUUCK");
          Console.ReadKey();
        };
        return entriesInQueue;
      }
    }

    public void InsertToWashQueue(string licensePlate, int washtype, decimal price, string startTime, string endTime)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        connection.Execute($"INSERT INTO CarwashQueue(LicensePlate, Washtype, Price, StartTime, EndTime) VALUES('{licensePlate}', '{washtype}', '{price}', '{startTime}', '{endTime}')", new DynamicParameters());
      }
    }
  }
}
