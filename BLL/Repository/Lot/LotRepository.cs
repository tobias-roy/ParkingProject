using DAL;

namespace BLL
{
  public class LotRepository : ILotRepository
  {
    
    public ILotDAL _lotData;
    public LotRepository(ILotDAL lotData)
    {
      _lotData = lotData;
    }

    public List<VehicleLot> GetAllLots()
    {
      return _lotData.GetAllLots();
    }

    public List<VehicleLot> GetAllLotsByType(int type)
    {
      return _lotData.GetAllLotsByType(type);
    }

    public VehicleLot GetLotByID(int id)
    {
      return _lotData.GetLotByID(id);
    }

    public void UpdateLot(int id, string column, int value)
    {
      _lotData.UpdateLot(id, column, value);
    }
  } 
}