namespace BLL
{
  public interface ILotRepository
  {
    List<VehicleLot> GetAllLots();
    List<VehicleLot> GetAllLotsByType(int type);
    VehicleLot GetLotByID(int ID);
    void UpdateLot(int id, string column, int value);
  } 
}