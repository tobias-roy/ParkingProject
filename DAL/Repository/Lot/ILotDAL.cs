using BLL;

namespace DAL
{
  public interface ILotDAL
  {
    List<VehicleLot> GetAllLots();
    List<VehicleLot> GetAllLotsByType(int type);
    VehicleLot GetLotByID(int ID);
    void UpdateLot(int id, string column, int value);
    void ChangeLotStatus(int id, int value);
    void GetLotByID(Func<object> isNotNull);
  }
}
