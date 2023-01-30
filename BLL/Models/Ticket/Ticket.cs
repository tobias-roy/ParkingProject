namespace BLL
{
    //Ticket class
    public class Ticket 
    {
      //Unique for each ticket
      public int ID { get; set; }
      //ID corresponding to the LOT the ticket is assigned too
      public string? LotID { get; set; }
      public Vehicle.Type VehicleType { get; set; }
      //License plate of vehicle
      public string? LicensePlate { get; set; }
      //Start time of parking
      public DateTime ParkingStart { get; set; }
      public DateTime ParkingEnd { get; set; }
      //Price for vehicle
      public decimal Price { get; set; }
      public bool OrderedWash { get; set; }

      public void ParkedTime () {}
      public void FullPrice () {}
    }
}