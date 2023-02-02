namespace DAL
{
  public class LotInfoDAL : ILotInfoDAL
  {
    private static string GetConnectionString(){
      return "Data Source = ./ParkingDB.db";
    }

    // public Ticket GetLotInfo() {
    //   using(IDbConnection connection = new SqliteConnection(GetConnectionString()))
    //   {
    //     int result = int.Parse(connection.ExecuteScalar("SELECT last_insert_rowid()").ToString());
        
    //     return result;
    //   }
    // }
  }
}
