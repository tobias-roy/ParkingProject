namespace BLL
{
  class CarLot : VehicleLot
  {
    public CarLot (string lotID, Status status) {
      this.LotID = lotID;
      this.Status = status;
      this.Price = HourlyPrice.car;
    }
  }
}