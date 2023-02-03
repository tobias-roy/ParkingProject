namespace BLL
{
  public interface ILotRepository
  {
    List<VehicleLot> GetAllLots();
    List<VehicleLot> GetAllLotsByType(Vehicle.Type type);
    VehicleLot GetLotByID(int ID);
    void UpdateLot(int id, string column, int value);
  } 
}