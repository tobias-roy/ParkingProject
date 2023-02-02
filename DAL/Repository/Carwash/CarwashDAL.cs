namespace DAL
{
  public class CarwashDAL : ICarwashDAL
  {
    private static string GetConnectionString(){
      return "Data Source = ./ParkingDB.db";
    }
    
  }
}
