using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace DAL
{
  public class LicenseplateDAL : ILicenseplateDAL
  {
    private static string GetConnectionString(){
      return "Data Source = ./ParkingDB.db";
    }
    public List<string> GetAllLicenseplates()
    {
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        var output = connection.Query<string>("SELECT LicensePlate FROM Ticket WHERE ParkingEnd IS NULL", new DynamicParameters());
        List<string> licenseplates = output.ToList();
        return licenseplates;
      }
    }
  }
}