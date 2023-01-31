namespace BLL 
{
  class VehicleLot
  {
    public string LotID { get; set; }
    public Status Status { get; set; }
    public LotType LotType { get; set; }
    public decimal Price { get; set; }
  }

//Future project reference needs a "reserved" option.
  public enum Status 
  {
    Free,
    Taken,
  }

  public enum LotType
  {
    CarLot,
    TrailerLot,
    BusLot,
    TruckLot
  }
}