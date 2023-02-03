using BLL;

namespace DAL
{
  public interface ILotDAL
  {
    List<VehicleLot> GetAllLots();
    List<VehicleLot> GetAllLotsByType(Vehicle.Type type);
    VehicleLot GetLotByID(int ID);
    void UpdateLot(int id, string column, int value);
    void ChangeLotStatus(int id, int value);
  }
}
