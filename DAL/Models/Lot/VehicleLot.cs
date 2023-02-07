namespace BLL 
{
  public class VehicleLot
  {
    public string LotID { get; set; }
    public Status Status { get; set; }
    public LotType LotType { get; set; }
    public decimal Price { get; set; }
  }

//Future project reference needs a "reserved" option.
  public enum Status 
  {
    Free = 1,
    Taken,
  }

  public enum LotType
  {
    CarLot = 1,
    TrailerLot,
    BusLot,
    TruckLot
  }
}