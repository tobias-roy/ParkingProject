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

    public void DeleteWashed(int id, string wash)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        try{
          if(wash == "North"){
            connection.Execute($"DELETE FROM CarwashNorthQueue WHERE QueueID =" + $"{id}", new DynamicParameters());
          } else {
            connection.Execute($"DELETE FROM CarwashSouthQueue WHERE QueueID =" + $"{id}", new DynamicParameters());
          }
        } catch {
          Console.WriteLine("FUUUUUUUUUUCK");
        }
      }
    }

    public List<CarwashEntries> GetCarwashQueue(string wash)
    {
      List<CarwashEntries> entriesInQueue = new();
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        try{
          if(wash == "North"){
            var output = connection.Query<CarwashEntries>($"SELECT * FROM CarwashNorthQueue", new DynamicParameters());
            entriesInQueue = output.ToList();
          } else {
            var output = connection.Query<CarwashEntries>($"SELECT * FROM CarwashSouthQueue", new DynamicParameters());
            entriesInQueue = output.ToList();
          }
        } catch {
          Console.WriteLine("FUUUUUUUUUUCK");
          Console.ReadKey();
        };
        return entriesInQueue;
      }
    }

    public void InsertToWashQueue(string wash, string licensePlate, int washtype, decimal price, string startTime, string endTime)
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        if(wash == "North"){
          connection.Execute($"INSERT INTO CarwashNorthQueue(LicensePlate, Washtype, Price, StartTime, EndTime) VALUES('{licensePlate}', '{washtype}', '{price}', '{startTime}', '{endTime}')", new DynamicParameters());
        } else {
          connection.Execute($"INSERT INTO CarwashSouthQueue(LicensePlate, Washtype, Price, StartTime, EndTime) VALUES('{licensePlate}', '{washtype}', '{price}', '{startTime}', '{endTime}')", new DynamicParameters());
        }
      }
    }
  }
}
