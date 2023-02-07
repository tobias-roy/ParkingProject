using BLL;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace DAL 
{
public class LotDAL : ILotDAL
{
  private static string GetConnectionString(){
    return "Data Source = ./ParkingDB.db";
  }
  public VehicleLot GetLotByID(int id)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.QuerySingle<VehicleLot>("SELECT * FROM VehicleLot WHERE LotID =" + $"{id}", new DynamicParameters());
      VehicleLot vehicleLot = output;
      return vehicleLot;
    }
  }

  public void UpdateLot(int lotId, string column, string value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE VehicleLot SET {column} = '{value}' WHERE LotID =" + $"{lotId}", new DynamicParameters());
    }
  }
  public List<VehicleLot> GetAllLots()
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.Query<VehicleLot>("SELECT * FROM VehicleLot", new DynamicParameters());
      List<VehicleLot> vehicles = output.ToList();
      return vehicles;
    }
  }

  public List<VehicleLot> GetAllLotsByType(int type)
  {
    try{
      using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
      {
        var output = connection.Query<VehicleLot>($"SELECT * FROM VehicleLot WHERE LotType = {type}", new DynamicParameters());
        List<VehicleLot> vehicles = output.ToList();
        return vehicles;
      }
    } catch (Exception)
    {
      Console.SetCursorPosition(0, Console.WindowHeight - 5);
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Vi kunne ikke opnå forbindelse til databasen.");
      Console.WriteLine("Prøv venligst igen senere, eller kontakt kundeservice.");
      Console.ForegroundColor = ConsoleColor.White;
      List<VehicleLot> empty = new();
      Console.ReadKey();
      return empty;
    }
  }

  public void UpdateLot(int id, string column, int value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE VehicleLot SET {column} = {value} WHERE LotID = " + $"{id}", new DynamicParameters());
    }
  }

  public void ChangeLotStatus(int id, int value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE VehicleLot SET 'Status' = {value} WHERE LotID = " + $"{id}", new DynamicParameters());
    }
  }
  }
}
