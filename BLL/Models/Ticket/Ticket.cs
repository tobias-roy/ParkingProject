namespace BLL
{
    //Ticket class
  public class Ticket 
  {
    //Unique for each ticket
    public int ID { get; set; }
    //ID corresponding to the LOT the ticket is assigned too
    public int LotID { get; set; }
    public Vehicle.Type VehicleType { get; set; }
    //License plate of vehicle
    public string LicensePlate { get; set; }
    //Start time of parking
    public string ParkingStart { get; set; }
    public string ParkingEnd { get; set; }
    //Price for vehicle
    public decimal Price { get; set; }
    public int OrderedWash { get; set; }
    public decimal WashPrice { get; set; }

    public void ParkedTime () {}
    public void FullPrice () {}
  }
}