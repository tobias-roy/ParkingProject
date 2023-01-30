using BLL;

public class TicketDAL : ITicketDAL
{
  public List<Ticket> GetAllTickets() 
  {
    List<Ticket> TicketList = new();
    TicketList.Add(new Ticket() { ID = 1, LotID = "A01", VehicleType = Vehicle.Type.Car, LicensePlate = "AB23432", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    TicketList.Add(new Ticket() { ID = 2, LotID = "A02", VehicleType = Vehicle.Type.Car, LicensePlate = "JD23574", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    TicketList.Add(new Ticket() { ID = 3, LotID = "A03", VehicleType = Vehicle.Type.Car, LicensePlate = "KL54789", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    TicketList.Add(new Ticket() { ID = 4, LotID = "A04", VehicleType = Vehicle.Type.Car, LicensePlate = "DL23561", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    TicketList.Add(new Ticket() { ID = 5, LotID = "A05", VehicleType = Vehicle.Type.Car, LicensePlate = "XV23123", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    TicketList.Add(new Ticket() { ID = 6, LotID = "A06", VehicleType = Vehicle.Type.Car, LicensePlate = "MB23651", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    TicketList.Add(new Ticket() { ID = 7, LotID = "A07", VehicleType = Vehicle.Type.Car, LicensePlate = "TJ12345", ParkingStart = DateTime.UtcNow, Price = 37, OrderedWash = false });
    return TicketList;
  }
}