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
      var output = connection.QuerySingle<VehicleLot>("SELECT * FROM VehicleLot WHERE ID =" + $"{id}", new DynamicParameters());
      VehicleLot vehicleLot = output;
      return vehicleLot;
    }
  }

  public void UpdateLot(int lotId, string column, string value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE VehicleLot SET {column} = '{value}' WHERE ID =" + $"{lotId}", new DynamicParameters());
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

  public List<VehicleLot> GetAllLotsByType(Vehicle.Type type)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      var output = connection.Query<VehicleLot>($"SELECT * FROM VehicleLo WHERE LotType = {(int)type}", new DynamicParameters());
      List<VehicleLot> vehicles = output.ToList();
      return vehicles;
    }
  }

  public void UpdateLot(string id, string column, int value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE VehicleLot SET {column} = {value} WHERE ID = " + $"{id}", new DynamicParameters());
    }
  }

  public void ChangeLotStatus(int id, int value)
  {
    using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    {
      connection.Execute($"UPDATE VehicleLot SET 'Status' = {value} WHERE ID = " + $"{id}", new DynamicParameters());
    }
  }
  }
}
