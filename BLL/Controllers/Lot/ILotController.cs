namespace BLL.Controllers
{
    public interface ILotController
    {
        List<VehicleLot> GetAllLots();
        List<VehicleLot> GetAllLotsByType(Vehicle.Type type);
        VehicleLot GetLotByID(int ID);
        void UpdateLot(string id, string column, int value);
    }
}
