namespace BLL.Controllers
{
  public class LotController : ILotController
  {
    private readonly ILotRepository _lotRepository;

    public LotController (ILotRepository lotRepository) {
        _lotRepository = lotRepository;
    }

    public List<VehicleLot> GetAllLots()
    {
      throw new NotImplementedException();
    }

    public List<VehicleLot> GetAllLotsByType(Vehicle.Type type)
    {
      throw new NotImplementedException();
    }

    public VehicleLot GetLotByID(int ID)
    {
      throw new NotImplementedException();
    }

    public void UpdateLot(string id, string column, int value)
    {
      throw new NotImplementedException();
    }
  }
}
